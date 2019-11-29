using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leasing.Model
{
    class Kunde
    {
        //instance field
        private string _fornavn;
        private string _efternavn;
        private int _cprnummer;
        private string _email;

        public Kunde(string fornavn, string efternavn, int cprnummer, string email)
        {
            _fornavn = fornavn;
            _efternavn = efternavn;
            _cprnummer = cprnummer;
            _email = email;
        }

        public string Fornavn
        {
            get { return _fornavn; }
            set { _fornavn = value; }
        }

        public string Efternavn
        {
            get { return _efternavn ; }
            set { _efternavn = value; }
        }

        public int CPRNummer
        {
            get { return _cprnummer; }
            set { _cprnummer= value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
    }
}

