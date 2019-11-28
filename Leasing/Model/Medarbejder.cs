using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leasing.Model
{
    class Medarbejder
    {
        //instance field
        private int _login;
        private string _navn;
        private int _ID;
        public Medarbejder(int login, string navn, int ID)
        {
            _login = login;
            _navn = navn;
            _ID = ID;
        }
        public int Login
        {
            get { return _login; }
            set { _login = value; }
        }
        public string Navn
        {
            get { return _navn; }
            set { _navn = value; }
        }
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

    }
}
