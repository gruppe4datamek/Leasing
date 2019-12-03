using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leasing.Model
{
    class Leasing
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
        public Leasing(int udlejningsId, int datoFra, int datoTil, int maxKilometer, string addresse, bool serviceAftale)
        {
            _udlejningsId = udlejningsId;
            _datoFra = datoFra;
            _DatoTil = datoTil;
            _maxKilometerTal = maxKilometer;
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
