using Dane;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Logika
{
    public class OrbLogic : INotifyPropertyChanged
    {
        private Orb orb;

        public OrbLogic(Orb orb)
        {
            this.orb = orb;
            orb.PropertyChanged += Update;
        }

        private void Update(object source, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "X")
            {
                OnPropertyChanged("X");
            }
            else if (e.PropertyName == "Y")
            {
                OnPropertyChanged("Y");
            }
            else if (e.PropertyName == "Radius")
            {
                OnPropertyChanged("Radius");
            }

        }
        public double X
        {
            get { return orb.X; }
            set
            {
                orb.X = value;
                OnPropertyChanged("X");
            }
        }
        public double Y
        {
            get { return orb.Y; }
            set
            {
                orb.Y = value;
                OnPropertyChanged("Y");
            }
        }
        public double Radius
        {
            get { return orb.Radius; }
            set
            {
                orb.Radius = value;
                OnPropertyChanged("Radius");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
