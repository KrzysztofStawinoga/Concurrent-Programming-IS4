using Logika;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Model
{
    public class Circle : INotifyPropertyChanged
    {
        private int x;
        private int y;
        private int radius;

        public Circle(Orb orb)
        {
            this.x = orb.X;
            this.y = orb.Y;
            this.radius = orb.Radius;
            orb.PropertyChanged += Update;
        }

        private void Update(object source, PropertyChangedEventArgs key)
        {
            Orb sourceOrb = (Orb)source;
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

        public int X 
        { 
            get { return x; }
            set 
            { 
                x = value;
                OnPropertyChanged("X");
            }
        }

        public int Y
        {
            get { return y; }
            set
            {
                y = value;
                OnPropertyChanged("Y");
            }
        }

        public int Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                OnPropertyChanged("Radius");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
