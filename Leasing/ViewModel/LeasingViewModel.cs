using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Leasing.Common;
using Leasing.Domain;
using Leasing.Model;
using Leasing.Persistency;

namespace Leasing.ViewModel
{
    class LeasingViewModel : INotifyPropertyChanged
    {
        OpretBilViewModel obvm = new OpretBilViewModel();
        private int udlejningsId;
        private DateTime datofra;
        private DateTime datotil;
        private string kontrakt;
        
        //private leasingCatalogSingleton singleton;
        private ObservableCollection<Model.Leasing> _leasings;
        private Model.Leasing _selected;
        public LeasingViewModel()
        {
            //_selected = new Bil();h
            AddCommand = new RelayCommand(tilføjLeasing);
            //singleton = new CarCatalogSingleton();
            Leasings = new ObservableCollection<Model.Leasing>();
            BilIds = new ObservableCollection<int>();
            //if (HentLeasings() != null)
            //    foreach (Bil b in HentBiler())
            //    {
            //        Bils.Add(b);
            //    }
        }


        public RelayCommand AddCommand { get; set; }
        public void tilføjLeasing()
        {
          
            //singleton.addCar(b1);

            OnPropertyChanged(nameof(tilføjLeasing));
        }
        public string Kontrakt
        {
            get { return kontrakt; }
            set { kontrakt = value; }
        }

        public DateTime Datofra
        {
            get { return datofra; }
            set { datofra = value; }
        }
        public DateTime Datotil
        {
            get { return datotil; }
            set { datotil = value; }
        }
        public int UdlejningsId
        {
            get { return udlejningsId; }
            set { udlejningsId = value; }
        }
       
        public ObservableCollection<Model.Leasing> Leasings
        {
            get { return _leasings; }
            set { _leasings = value; }
        }

        private ObservableCollection<int> _bilIds;
        public ObservableCollection<int> BilIds
        {
            get
            {
               ObservableCollection<Bil> mylist = obvm.Bils; 
                ObservableCollection<int> BilIdList = new ObservableCollection<int>();
                foreach (var bil in mylist)
                {
                   BilIdList.Add(bil.Nummerplade);

                }

                return BilIdList;
            }
            set { _bilIds = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged
            ([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new
                PropertyChangedEventArgs(propertyName));
        }
        //public IEnumerable<Model.Leasing> HentLeasings()
        //{
        //    try
        //    {
        //        var leasing = WebApiBilAsync.GetCar("api/Leasings/");
        //        //var carlist = JsonConvert.DeserializeObject<List<Bil>>("val");
        //        //foreach (var m in carlist)
        //        //{
        //        //    Console.WriteLine(m);
        //        //}3
        //        return leasing;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("{0} Exception caught.", e);
        //        return null;
        //    }
        //}

    }
}
