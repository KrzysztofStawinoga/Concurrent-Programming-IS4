using System;
using System.Threading;
using System.Collections.Generic;

namespace Dane
{
    public abstract class AbstractDataApi
    {
        public abstract void CreateScene(int width, int height, int orbQuantity, int orbRadius);
        public abstract List<Orb> GetOrbs();

        public abstract void Disable();

        public abstract Scene Scene { get; }
        public static AbstractDataApi CreateApi()
        {
            return new DataApi();
        }

        internal sealed class DataApi : AbstractDataApi
        {
            private readonly object locked = new object();

            private readonly object barrier = new object();

            private int queue = 0;

            private bool enabled = false;

            private Scene scene;

            private Logger logger;

            public bool Enabled 
            {
                get { return enabled; }
                set { enabled = value; }
            }

            public override Scene Scene { 
                get { return scene; } 
            }

            public override void CreateScene(int width, int height, int orbQuantity, int orbRadius)
            {
                this.scene = new Scene(width, height, orbQuantity, orbRadius);
                this.Enabled = true;
                List<Orb> orbs = GetOrbs();
                logger = new Logger(orbs);

                foreach (Orb orb in orbs)
                {
                    Thread t = new Thread(() => {
                        while (this.Enabled)
                        {
                            lock (locked)
                            {
                                orb.move();
                            }

                            Thread.Sleep(5);
                        }
                    });
                    t.Start();
                }
            }

            public override List<Orb> GetOrbs()
            {
                return Scene.Orbs;
            }

            public override void Disable()
            {
                this.Enabled = false;
                this.logger.stop();
            }
        }
    }
}

