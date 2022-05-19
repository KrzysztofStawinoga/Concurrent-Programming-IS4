using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Logika;

namespace Model
{
    public abstract class AbstractModelApi
    {
        public static AbstractModelApi CreateApi(AbstractLogicApi abstractLogicApi = null)
        {
            return new ModelApi();
        }

        public abstract ObservableCollection<Circle> GetAllCircles();

        public abstract void Enable(int quantity);

        public abstract void Disable();

        public abstract bool IsEnabled();

        public sealed class ModelApi : AbstractModelApi
        {
            private AbstractLogicApi logicApi = AbstractLogicApi.CreateApi(null);

            private ObservableCollection<Circle> circles = new ObservableCollection<Circle>();

            public ObservableCollection<Circle> Circles
            {
                get 
                { 
                    return circles; 
                }
                set 
                { 
                    circles = value; 
                }
            }

            internal ModelApi(AbstractLogicApi abstractLogicApi = null)
            {
                if (abstractLogicApi == null)
                {
                    this.logicApi = AbstractLogicApi.CreateApi();
                }
                else
                {
                    this.logicApi = abstractLogicApi;
                }
            }

            public override void Enable(int quantity)
            {
                logicApi.Enable(700, 600, quantity, 20);
            }

            public override ObservableCollection<Circle> GetAllCircles()
            {
                List<OrbLogic> orbs = logicApi.GetOrbs();
                Circles.Clear();
                foreach (OrbLogic orb in orbs)
                {
                    Circles.Add(new Circle(orb));
                }
                return Circles;
            }

            public override void Disable()
            {
                logicApi.Disable();
            }

            public override bool IsEnabled()
            {
                return logicApi.IsEnabled();
            }
        }
    }
}
