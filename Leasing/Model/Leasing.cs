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
        private string _kontrakt;
        public Leasing(int udlejningsId, int datoFra, int datoTil, string kontrakt)
        {
            _udlejningsId = udlejningsId;
            _datoFra = datoFra;
            _DatoTil = datoTil;
            _kontrakt = kontrakt;
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
        public string Kontrakt
        {
            get { return _kontrakt; }
            set { _kontrakt = value; }
        }
    }
}
