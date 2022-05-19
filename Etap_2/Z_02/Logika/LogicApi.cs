using Dane;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

namespace Logika
{
    public abstract class AbstractLogicApi
    {
        public static AbstractLogicApi CreateApi(AbstractDataApi abstractDataApi = null)
        {
            return new LogicApi(abstractDataApi);
        }

        public abstract List<OrbLogic> GetOrbs();

        public abstract void Enable(int width, int height, int orbQuantity, int orbRadius);

        public abstract void Disable();

        public abstract bool IsEnabled();

        internal sealed class LogicApi : AbstractLogicApi
        {
            private AbstractDataApi DataApi;

            private List<OrbLogic> orbs = new List<OrbLogic>();

            bool enabled = false;

            public bool Enabled
            {
                get { return enabled; }
                set { enabled = value; }
            }

            internal LogicApi(AbstractDataApi abstractDataApi = null)
            {
                if (abstractDataApi == null)
                {
                    this.DataApi = AbstractDataApi.CreateApi();
                }
                else
                {
                    this.DataApi = abstractDataApi;
                }
            }

            public override List<OrbLogic> GetOrbs()
            {
                return this.orbs;
            }

            public override void Enable(int width, int height, int orbQuantity, int orbRadius)
            {
                DataApi.CreateScene(width, height, orbQuantity, orbRadius);
                foreach (Orb orb in DataApi.GetOrbs())
                {
                    this.orbs.Add(new OrbLogic(orb));
                    orb.PropertyChanged += Update;
                }
            }

            public override void Disable()
            {
                DataApi.Disable();
                this.orbs.Clear();
            }

            public override bool IsEnabled()
            {
                return enabled;
            }

            private void Update(object sender, PropertyChangedEventArgs ev)
            {
                Orb orb = (Orb)sender;
                if (ev.PropertyName == "Position")
                {
                    CheckCollision(orb);
                }

            }

            private void CheckCollision(Orb orb)
            {
                AreaCollision(orb);
                OrbCollision(orb);
            }

            private void AreaCollision(Orb orb)
            {
                if ((orb.X + orb.Radius) >= DataApi.Scene.Width)
                {
                    orb.XSpeed = -orb.XSpeed;
                    orb.X = DataApi.Scene.Width - orb.Radius;
                }
                if ((orb.X - orb.Radius) <= 0)
                {
                    orb.XSpeed = -orb.XSpeed;
                    orb.X = orb.Radius;
                }
                if ((orb.Y + orb.Radius) >= DataApi.Scene.Height)
                {
                    orb.YSpeed = -orb.YSpeed;
                    orb.Y = DataApi.Scene.Height - orb.Radius;
                }
                if ((orb.Y - orb.Radius) <= 0)
                {
                    orb.YSpeed = -orb.YSpeed;
                    orb.Y = orb.Radius;
                }
            }

            private void OrbCollision(Orb orb)
            {
                foreach (Orb o in DataApi.GetOrbs())
                {
                    if (o == orb)
                    {
                        continue;
                    }
                    double xDiff = o.X - orb.X;
                    double yDiff = o.Y - orb.Y;
                    double distance = Math.Sqrt((xDiff * xDiff) + (yDiff * yDiff));
                    if (distance <= (orb.Radius + o.Radius))
                    {
                        double newSpeed = ((o.XSpeed * (o.Weight - orb.Weight) + (orb.Weight * orb.XSpeed * 2)) / (o.Weight + orb.Weight));
                        orb.XSpeed = ((orb.XSpeed * (orb.Weight - o.Weight) + (o.Weight * o.XSpeed * 2)) / (o.Weight + orb.Weight));
                        o.XSpeed = newSpeed;

                        newSpeed = ((o.YSpeed * (o.Weight - orb.Weight)) + (orb.Weight * orb.YSpeed * 2) / (o.Weight + orb.Weight));
                        orb.YSpeed = ((orb.YSpeed * (orb.Weight - o.Weight)) + (o.Weight * o.YSpeed * 2) / (o.Weight + orb.Weight));
                        o.YSpeed = newSpeed;
                    }
                }
            }
        }
    }
}
