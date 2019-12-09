using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leasing.Model
{
    class Leasing1
    {
        //instance field
        private int _leasingId;
       
        private DateTimeOffset _datoFra;
        private DateTimeOffset _DatoTil;
        private int _maxKilometerTal;
        private string _addresse;
        private bool _serviceAftale;
        private int _mid;
        private int _kid;
        private int _pid;
       
        private ObservableCollection<bool> serviceAftale;

        

        public Leasing1(int leasingId, DateTimeOffset datofra, DateTimeOffset datotil, int maxKilometerTal, string addresse, bool serviceAftale, int mid, int kid, int nplade )
        {
           
            _datoFra = datofra;
            _DatoTil = datotil;
            _maxKilometerTal = maxKilometerTal;
            _addresse = addresse;
            _serviceAftale = serviceAftale;
            _mid = mid;
            _kid = kid;
            _pid = nplade;
            _leasingId = leasingId;
        }

        public int Max_Kilometer
        {
            get { return _maxKilometerTal;}
            set { _maxKilometerTal = value; }
        }
        public int Medarbejder_id
        {
            get { return _mid; }
            set { _mid = value; }
        }
        public int Kunde_id
        {
            get { return _kid; }
            set { _kid = value; }
        }
        public int Bil_id
        {
            get { return _pid; }
            set { _pid = value; }
        }

        public string Addresse
        {
            get { return _addresse; }
            set { _addresse = value; }
        }

        public bool Service_Aftale
        {
            get { return _serviceAftale; }
            set { _serviceAftale = value; }
        }
       
        public DateTimeOffset Dato_Fra
        {
            get { return _datoFra; }
            set { _datoFra = value; }
        }
        public DateTimeOffset Dato_Til
        {
            get { return _DatoTil; }
            set { _DatoTil = value; }
        }
        
    }
}
