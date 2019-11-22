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
        private int _kundeID;
        private string _email;

        public Kunde(string fornavn, string efternavn, int kundeId, string email)
        {
            _fornavn = fornavn;
            _efternavn = efternavn;
            _kundeID = kundeId;
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

        public int KundeID
        {
            get { return _kundeID; }
            set { _kundeID = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
    }
}

