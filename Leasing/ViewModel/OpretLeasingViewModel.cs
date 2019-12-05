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
        OpretKundeViewModel okvm = new OpretKundeViewModel();
        OpretMedarbejderViewModel omvm = new OpretMedarbejderViewModel();
        private ObservableCollection<bool> _serviceAftale;
        private int udlejningsId;
        private DateTimeOffset datofra;
        private DateTimeOffset datotil;
        private int maxKilometerTal;
        private string addresse;
        private int mCPRNummer;
        private int kCPRNummer;
        private int nummerplade;

        //private leasingCatalogSingleton singleton;
        private ObservableCollection<Model.Leasing> _leasings;
        private Model.Leasing _selected;
        public LeasingViewModel()
        {
            //_selected = new Bil();h
            AddCommand = new RelayCommand(tilføjLeasing);
            //singleton = new CarCatalogSingleton();
            Leasings = new ObservableCollection<Model.Leasing>();
            _bilIds = new ObservableCollection<int>();
            _kundeIds = new ObservableCollection<int>();
            _medarbejderIds = new ObservableCollection<int>();
            _serviceAftale = new ObservableCollection<bool>();
            _serviceAftale.Add(true);
            _serviceAftale.Add(false);
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

        public int MCPRNummer
        {
            get { return mCPRNummer;}
            set {mCPRNummer= value; }
        }

        public int KCPRNummer
        {
            get { return kCPRNummer;}
            set { kCPRNummer = value; }
        }

        public int Nummerplade
        {
            get { return nummerplade; }
            set { nummerplade = value; }
        }
        public int MaxKilometerTal
        {
            get { return maxKilometerTal; }
            set { maxKilometerTal = value; }
        }

        public string Addresse
        {
            get { return addresse; }
            set { addresse = value; }
        }

        public DateTimeOffset Datofra
        {
            get { return datofra; }
            set { datofra = value; OnPropertyChanged(nameof(datofra)); }
        }
        public DateTimeOffset Datotil
        {
            get { return datotil; }
            set { datotil = value; OnPropertyChanged(nameof(Datotil)); }
        }
        public int UdlejningsId
        {
            get { return udlejningsId; }
            set { udlejningsId = value; OnPropertyChanged(nameof(udlejningsId)); }
        }

        public ObservableCollection<bool> ServiceAftale
        {
            get { return _serviceAftale; }
            set { _serviceAftale = value; OnPropertyChanged(nameof(ServiceAftale)); }
        }

        public ObservableCollection<Model.Leasing> Leasings
        {
            get { return _leasings; }
            set { _leasings = value; OnPropertyChanged(nameof(Leasings)); }
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
        private ObservableCollection<int> _kundeIds;
        public ObservableCollection<int> KundeIds
        {
            get
            {
                ObservableCollection<Kunde> mylist = okvm.Kundes;
                ObservableCollection<int> KundeIdList = new ObservableCollection<int>();
                foreach (var Kunde in mylist)
                {
                    KundeIdList.Add(Kunde.CPRNummer);

                }

                return KundeIdList;
            }
            set { _kundeIds = value; }
        }

        private ObservableCollection<int> _medarbejderIds;
        public ObservableCollection<int> MedarbejderIds
        {
            get
            {
                ObservableCollection<Medarbejder> mylist = omvm.Medarbejders;
                ObservableCollection<int> MedarbejderIdList = new ObservableCollection<int>();
                foreach (var Medarbejder in mylist)
                {
                    MedarbejderIdList.Add(Medarbejder.CPRNummer);

                }

                return MedarbejderIdList;
            }
            set { _medarbejderIds = value; }
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
