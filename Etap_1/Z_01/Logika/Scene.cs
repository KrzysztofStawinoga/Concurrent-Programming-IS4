using System;
using System.Collections.Generic;
using System.Text;

namespace Logika
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

        public Scene(int width, int height)
        {
            this.width = width;
            this.height = height;

        }

        public void GenerateOrbList(int orbQuantity, int orbRadius)
        {
            orbs.Clear();
            Random rng = new Random();
            for (int i = 0; i < orbQuantity; i++)
            {
                int x = rng.Next(orbRadius, width - orbRadius);
                int y = rng.Next(orbRadius, height - orbRadius);
                this.orbs.Add(new Orb(x, y, orbRadius));
            }
        }
    }
}
