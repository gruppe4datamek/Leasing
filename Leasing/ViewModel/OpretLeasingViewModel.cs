﻿using System;
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
    class OpretLeasingViewModel : INotifyPropertyChanged
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
        private bool serviceAftale;

        private LeasingCatalogSingleton singleton;
        private ObservableCollection<Leasing1> _leasings;
        private Leasing1 _selected;
        public OpretLeasingViewModel()
        {
            //_selected = new Bil();h
            AddCommand = new RelayCommand(tilføjLeasing);
            singleton = new LeasingCatalogSingleton();
            Leasings = new ObservableCollection<Leasing1>();
            _bilIds = new ObservableCollection<int>();
            _kundeIds = new ObservableCollection<int>();
            _medarbejderIds = new ObservableCollection<int>();
            _serviceAftale = new ObservableCollection<bool>();
            _serviceAftale.Add(true);
            _serviceAftale.Add(false);
            if (HentLeasings() != null)
                foreach (Leasing1 l in HentLeasings())
                {
                    Leasings.Add(l);
                }
        }

        public static DateTime DateTimeOffsetAndTimeSetToDateTime(DateTimeOffset date, TimeSpan time)
        {
            return new DateTime(date.Year, date.Month, date.Day, time.Hours, time.Minutes, 0);
        }



        public RelayCommand AddCommand { get; set; }
        public void tilføjLeasing()
        {
     
            Leasing1 k1 = new Leasing1(udlejningsId, datofra, datotil, maxKilometerTal, addresse, ServiceAftale);
            singleton.addleasing(k1);
            OnPropertyChanged(nameof(tilføjLeasing));
        }

        public bool ServiceAftale
        {
            get { return serviceAftale; }
            set { serviceAftale = value; }
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


        public ObservableCollection<Model.Leasing1> Leasings
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
