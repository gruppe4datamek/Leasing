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
        private int _udlejningsId;
        private int _datoFra;
        private int _DatoTil;
        private int _maxKilometerTal;
        private string _addresse;
        private bool _serviceAftale;
        private int mCPRNummer;
        private int kCPRNummer;
        private int nummerplade;
       
        private ObservableCollection<bool> serviceAftale;

        

        public Leasing1(int udlejningsId, int datofra, int datotil, int maxKilometerTal, string addresse, bool serviceAftale)
        {
            _udlejningsId = udlejningsId;
            _datoFra = datofra;
            _DatoTil = datotil;
            _maxKilometerTal = maxKilometerTal;
            _addresse = addresse;
            _serviceAftale = serviceAftale;
        }

        public int MaxKilometerTal
        {
            get { return _maxKilometerTal;}
            set { _maxKilometerTal = value; }
        }
        public int MCPRNummer
        {
            get { return mCPRNummer; }
            set { mCPRNummer = value; }
        }
        public int KCPRNummer
        {
            get { return kCPRNummer; }
            set { kCPRNummer = value; }
        }
        public int Nummerplade
        {
            get { return nummerplade; }
            set { nummerplade = value; }
        }

        public string Addresse
        {
            get { return _addresse; }
            set { _addresse = value; }
        }

        public bool ServiceAftale
        {
            get { return _serviceAftale; }
            set { _serviceAftale = value; }
        }
        public int UdlejningsId
        {
            get { return _udlejningsId; }
            set { _udlejningsId = value; }
        }
        public int DatoFra
        {
            get { return _datoFra; }
            set { _datoFra = value; }
        }
        public int DatoTil
        {
            get { return _DatoTil; }
            set { _DatoTil = value; }
        }
        
    }
}
