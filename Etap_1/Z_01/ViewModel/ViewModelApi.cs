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
    public class ViewModelApi : INotifyPropertyChanged
    {
        private AbstractModelApi modelApi/* = AbstractModelApi.CreateApi()*/;
        private int orbQuantity = 1;
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
        private int orbRadius = 25; //hardcoded for now

        public ICommand EnableSignal
        {
            get;
            set;
        }
        public ICommand DisableSignal
        {
            get;
            set;
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

        public ViewModelApi() : this(null){ }
        public ViewModelApi(AbstractModelApi modelApi = null)
        {
            EnableSignal = new Signal(enable);
            DisableSignal = new Signal(disable);
            if (modelApi == null)
            {
                this.modelApi = AbstractModelApi.CreateApi();
            }
            else
            {
                this.modelApi = modelApi;
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

        private void enable()
        {
            modelApi.CreateScene(orbQuantity, orbRadius);
            modelApi.Enable();
            isEnabled = true;
            OrbList = modelApi.GetAllCircles();
        }

        private void disable()
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
