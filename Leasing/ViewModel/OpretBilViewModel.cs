using Leasing.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.StartScreen;
using Leasing.Domain;
using Leasing.Model;

namespace Leasing.ViewModel
{
    class OpretBilViewModel : INotifyPropertyChanged
    {
       
        private string mærke;
        private string model;
        private int årgang;
        private int kilometertal;
        private string farve;
        private bool tilgængelig;
        private string nummerplade;

        private CarCatalogSingleton singleton;
        private ObservableCollection<Bil> _bils;
        private Bil _selected;
        public OpretBilViewModel()
        {
            _selected = new Bil();
            AddCommand = new RelayCommand(tilføjBil);
            singleton = new CarCatalogSingleton();
            _bils = new ObservableCollection<Bil>();


        }

        public RelayCommand AddCommand { get; set; }
        public void tilføjBil()
        {
            int np = Int32.Parse(nummerplade);
            Bil b1 = new Bil(np, årgang, model, mærke, kilometertal, farve, tilgængelig);
            singleton.addCar(b1);

            OnPropertyChanged(nameof(tilføjBil));
        }
        public string Nummerplade
        {
            get { return nummerplade; }
            set { nummerplade = value; }
        }

        public string Mærke
        {
            get { return mærke; }
            set { mærke = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Årgang
        {
            get { return årgang; }
            set { årgang = value; }
        }
        public int Kilometertal
        {
            get { return kilometertal; }
            set { kilometertal = value; }
        }
        public string Farve
        {
            get { return farve; }
            set { farve = value; }
        }
        public bool Tilgængelig
        {
            get { return tilgængelig; }
            set { tilgængelig = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged
            ([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new
                PropertyChangedEventArgs(propertyName));
        }
    }
   
}
