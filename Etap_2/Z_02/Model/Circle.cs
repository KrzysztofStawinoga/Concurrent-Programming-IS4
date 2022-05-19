using Logika;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Model
{
    public class Circle : INotifyPropertyChanged
    {
        private double x;
        private double y;
        private double radius;
        private double weight;

        public Circle(OrbLogic orb)
        {
            this.x = orb.X;
            this.y = orb.Y;
            this.radius = orb.Radius;
            orb.PropertyChanged += Update;
        }

        private void Update(object source, PropertyChangedEventArgs key)
        {
            OrbLogic sourceOrb = (OrbLogic)source;
            if(key.PropertyName == "X")
            {
                this.x = sourceOrb.X - sourceOrb.Radius ;
            }

            if(key.PropertyName == "Y")
            {
                this.y = sourceOrb.Y - sourceOrb.Radius ;
            }

            if(key.PropertyName == "Radius")
            {
                this.radius = sourceOrb.Radius ;
            }

        }

        public double X 
        { 
            get { return x; }
            set 
            { 
                x = value;
                OnPropertyChanged("X");
            }
        }

        public double Y
        {
            get { return y; }
            set
            {
                y = value;
                OnPropertyChanged("Y");
            }
        }

        public double Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                OnPropertyChanged("Radius");
            }
        }

        public double Weight
        {
            get { return weight; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
