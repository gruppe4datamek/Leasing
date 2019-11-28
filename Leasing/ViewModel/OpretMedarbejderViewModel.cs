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
    class OpretMedarbejderViewModel
    {
        private ObservableCollection<Medarbejder> _medarbejder;
        private Medarbejder _selected;
        private MedarbejderCatalogSingleton singleton;

        private string  email;
        private string  navn;
        private int  id;



        public RelayCommand AddCommand { get; set; }
        public void tilføjMedarbejder()
        {
           
            Medarbejder m1 = new Medarbejder(email,navn,id);
            singleton.addMedarbejder(m1);

            OnPropertyChanged(nameof(tilføjMedarbejder));
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Navn
        {
            get { return navn; }
            set { navn = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged
            ([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new
                PropertyChangedEventArgs(propertyName));
        }

        public IEnumerable<Medarbejder> HentmeMedarbejder()
        {
            try
            {
                var medarbejder = WebApiMedarbejderAsync.GetMedarbejder("api/Medarbejders/");
                //var carlist = JsonConvert.DeserializeObject<List<Bil>>("val");
                //foreach (var m in carlist)
                //{
                //    Console.WriteLine(m);
                //}3
                return medarbejder;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return null;
            }

        }
    }
}

