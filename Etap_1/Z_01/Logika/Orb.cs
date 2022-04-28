using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Logika
{
    public class Orb : INotifyPropertyChanged
    {
        private int x;
        private int y;
        private int radius;

        public Orb(int x, int y, int radius)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }

        public int X //property
        { 
            get { return x; } 
            set 
            { 
                x = value;
                OnPropertyChanged("x");
            }
        }

        public int Y
        {
            get { return y; }
            set 
            { 
                y = value; 
                OnPropertyChanged("y");
            }
        }

        public int Radius
        {
            get { return radius; }
            set 
            { 
                radius = value;
                OnPropertyChanged("radius");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
