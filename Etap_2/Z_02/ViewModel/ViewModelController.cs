using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace ViewModel
{
    public class ViewModelController : INotifyPropertyChanged
    {
        public ViewModelController (AbstractModelApi ModelApi = null)
        {
            SignalEnable = new Signal(Enable);
            SignalDisable = new Signal(Disable);
            if (ModelApi == null)
            {
                this.modelApi = AbstractModelApi.CreateApi();
            }
            else
            {
                this.modelApi = ModelApi;
            }
        }
        public ViewModelController() : this(null) {}

        public ICommand SignalEnable
        {
            get;
            set;
        }
        public ICommand SignalDisable
        {
            get;
            set;
        }

        private AbstractModelApi modelApi;
        
        private int orbQuantity = 4;

        public string OrbQuantity
        {
            get
            {
                return Convert.ToString(orbQuantity);
            }
            set
            {
                orbQuantity = Convert.ToInt32(value);
                OnPropertyChanged("OrbQuantity");
            }
        }

        private ObservableCollection<Circle> orbList;
        public ObservableCollection<Circle> OrbList
        {
            get { return orbList; }
            set
            {
                if (value.Equals(this.orbList)) return;
                orbList = value;
                OnPropertyChanged("OrbList");
            }
        }

        private bool isEnabled = true;
        public bool IsEnabled
        {
            get { return isEnabled; }
            set 
            { 
                isEnabled = value;
                OnPropertyChanged("IsEnabled");
                OnPropertyChanged("IsDisabled");
            }
        }
        public bool IsDisabled 
        { 
            get
            {
                return !isEnabled;
            }
        }

        private void Enable()
        {
            modelApi.Enable(orbQuantity);
            isEnabled = true;
            OrbList = modelApi.GetAllCircles();
        }

        private void Disable()
        {
            modelApi.Disable();
            IsEnabled = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
