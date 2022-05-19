using System;
using System.Collections.Generic;
using System.Text;

namespace Dane
{
    public class Scene
    {
        private readonly int width;
            public int Width
            {
                get { return width; }
            }

        private readonly int height;
            public int Height
            {
                get { return height; }
            }

        private bool enabled = false;
            public bool Enabled
            {
                get { return enabled; }
                set { enabled = value; }
            }

        private readonly List<Orb> orbs = new List<Orb>();
            public List<Orb> Orbs
            {
                get { return orbs; }
            }

        public Scene(int width, int height, int orbQuantity, int orbRadius)
        {
            this.width = width;
            this.height = height;
            GenerateOrbList(orbQuantity, orbRadius);
        }

        public Orb GenerateOrb(int radius)
        {
            Random random = new Random();
            bool valid = true;
            int x = radius, y = radius;
            do
            {
                valid = true;
                x = random.Next(radius, this.width - radius);
                y = random.Next(radius, this.height - radius);
                foreach (Orb b in this.Orbs)
                {
                    double distance = Math.Sqrt(((b.X - x) * (b.X - x)) + ((b.Y - y) * (b.Y - y)));
                    if (distance <= b.Radius + radius)
                    {
                        valid = false;
                        break;
                    };
                }
                if (!valid)
                {
                    continue;
                };
                valid = true;

            } while (!valid);
            double w = 1;
            return new Orb(x, y, w * radius, w);
        }

        public void GenerateOrbList(int orbQuantity, int orbRadius)
        {
            orbs.Clear();
            for (int i = 0; i < orbQuantity; i++)
            {
                Orb orb = GenerateOrb(orbRadius);
                this.orbs.Add(orb);
            }
        }
    }
}
