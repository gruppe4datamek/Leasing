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
    class OpretKundeViewModel:INotifyPropertyChanged
    { //F
        private string fornavn;
        private string efternavn;
        private int cprnummer;
        private string email;

        private KundeCatalogSingleton singleton;
        private ObservableCollection<Kunde> _kundes;
        private Kunde _selected;

        public OpretKundeViewModel()
        {
            AddCommand = new RelayCommand(tilføjKunde);
            singleton = new KundeCatalogSingleton();
            Kundes = new ObservableCollection<Kunde>();

            if (HentKunder() != null)
                foreach (Kunde k in HentKunder())
                {
                    Kundes.Add(k);
                }
        }
        public RelayCommand AddCommand { get; set; }
        public void tilføjKunde()
        {
            
            Kunde k1 = new Kunde(fornavn,efternavn,cprnummer,email);
            singleton.addKunde(k1);

            OnPropertyChanged(nameof(tilføjKunde));
        }
        public string Fornavn
        {
            get { return fornavn; }
            set { fornavn = value; }
        }

        public string Efternavn
        {
            get { return efternavn; }
            set { efternavn = value; }
        }
        public int CPRNummer
        {
            get { return cprnummer; }
            set { cprnummer = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public ObservableCollection<Kunde> Kundes
        {
            get { return _kundes; }
            set { _kundes = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged
            ([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new
                PropertyChangedEventArgs(propertyName));
        }
        public IEnumerable<Kunde> HentKunder()
        {
            try
            {
                var kunde = WebApiKundeAsync.GetKunde("api/Kundes/");
                //var carlist = JsonConvert.DeserializeObject<List<Bil>>("val");
                //foreach (var m in carlist)
                //{
                //    Console.WriteLine(m);
                //}3
                return kunde;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return null;
            }
        }
    }

}
