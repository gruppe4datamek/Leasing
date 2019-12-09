using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Store.Preview.InstallControl;
using Leasing.Common;
using Leasing.Domain;
using Leasing.Model;
using Leasing.Persistency;


namespace Leasing.ViewModel
{
    class OpretLeasingViewModel : INotifyPropertyChanged
    {
        OpretBilViewModel obvm = new OpretBilViewModel();
        OpretKundeViewModel okvm = new OpretKundeViewModel();
        OpretMedarbejderViewModel omvm = new OpretMedarbejderViewModel();
        private ObservableCollection<string> _serviceAftale;
        private int udlejningsId;
        private DateTimeOffset datofra;
        private DateTimeOffset datotil;
        private int maxKilometerTal;
        private string addresse;
        private int mCPRNummer;
        private int kCPRNummer;
        private int nummerplade;
        

        private LeasingCatalogSingleton singleton;
        private ObservableCollection<Leasing1> _leasings;
        private Leasing1 _selected;
        public OpretLeasingViewModel()
        {
            //_selected = new Bil();h
            datofra = new DateTimeOffset();
            datotil = new DateTimeOffset();
            AddCommand = new RelayCommand(tilføjLeasing);
            singleton = new LeasingCatalogSingleton();
            Leasings = new ObservableCollection<Leasing1>();
            _bilIds = new ObservableCollection<int>();
            _kundeIds = new ObservableCollection<int>();
            _medarbejderIds = new ObservableCollection<int>();
            _serviceAftale = new ObservableCollection<string>();
            _serviceAftale.Add("true");
            _serviceAftale.Add("false");
            if (HentLeasings() != null)
                foreach (Leasing1 l in HentLeasings())
                {
                    Leasings.Add(l);
                }
        }

        public static DateTime DateTimeOffsetAndTimeSetToDateTime(DateTimeOffset date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }



        public RelayCommand AddCommand { get; set; }
        public void tilføjLeasing()
        {
            
            Leasing1 k1 = new Leasing1(Leasing_id, Dato_Fra, Dato_Til, Max_Kilometer, addresse, bool.Parse(SelectedServiceAftale), SelectedMID, SelectedKCPRNummer, SelectedNummerPlade );
            singleton.addleasing(k1);
            OnPropertyChanged(nameof(tilføjLeasing));
        }


        private int _mId;
        public int Medarbejder_id
        {
            get { return _mId; }
            set { _mId = value; }
        }

        private int _cprnummer;
        public int Kunde_id
        {
            get { return _cprnummer; }
            set { _cprnummer = value; }
        }

        private int _nummerplade;
        public int Bil_id
        {
            get { return _nummerplade; }
            set { _nummerplade = value; }
        }
        public int Max_Kilometer
        {
            get { return maxKilometerTal; }
            set { maxKilometerTal = value; }
        }

        public string Addresse
        {
            get { return addresse; }
            set { addresse = value; }
        }

        public DateTimeOffset Dato_Fra
        {
            get { return datofra; }
            set { datofra = value; OnPropertyChanged(nameof(Dato_Fra)); }
        }
        public DateTimeOffset Dato_Til
        {
            get { return datotil; }
            set { datotil = value; OnPropertyChanged(nameof(Dato_Til)); }
        }
        public int Leasing_id
        {
            get { return udlejningsId; }
            set { udlejningsId = value; OnPropertyChanged(nameof(Leasing_id)); }
        }


        public ObservableCollection<Leasing1> Leasings
        {
            get { return _leasings; }
            set { _leasings = value; OnPropertyChanged(nameof(Leasings)); }
        }




        public ObservableCollection<string> ServiceAftale
        {
            get
            {
                return _serviceAftale;


            }
            set { _serviceAftale = value; OnPropertyChanged(nameof(ServiceAftale)); }

        }

        private DateTimeOffset _selectedDatoFra;

        public DateTimeOffset SelectedDatoFra
        {
            get { return _selectedDatoFra; }
            set { _selectedDatoFra = value; OnPropertyChanged(nameof(SelectedDatoFra)); }
        }

        private DateTimeOffset _selectedDatoTil;
        public DateTimeOffset SelectedDatoTil
        {
            get { return _selectedDatoTil; }
            set { _selectedDatoTil = value; OnPropertyChanged(nameof(SelectedDatoTil)); }
        }

        private int _selectednummerPlade;

        public int SelectedNummerPlade
        {
            get { return _selectednummerPlade;}
            set { _selectednummerPlade = value; OnPropertyChanged(nameof(SelectedNummerPlade)); }
        }

        private int _selectedKCPRnummer;

        public int SelectedKCPRNummer
        {
            get { return _selectedKCPRnummer; }
            set { _selectedKCPRnummer = value; OnPropertyChanged(nameof(SelectedKCPRNummer)); }
        }

        private int _selectedmid;

        public int SelectedMID
        {
            get { return _selectedmid; }
            set { _selectedmid = value; OnPropertyChanged(nameof(SelectedMID)); }
        }



        private string _selectedServiceAftale;
        public string  SelectedServiceAftale
        {
            get { return _selectedServiceAftale; }
            set { _selectedServiceAftale = value;
                OnPropertyChanged(nameof(SelectedServiceAftale)); }
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
                    MedarbejderIdList.Add(Medarbejder.Medarbejder_id);

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
        public IEnumerable<Leasing1> HentLeasings()
        {
            try
            {
                var leasing = WebApiLeasingAsync.GetLeasing("api/Leasings/");
                //        //var carlist = JsonConvert.DeserializeObject<List<Bil>>("val");
                //        //foreach (var m in carlist)
                //        //{
                //        //    Console.WriteLine(m);
                //        //}3
                return leasing;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return null;
            }
        }

    }
}
