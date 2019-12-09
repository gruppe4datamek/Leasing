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
        private int _mId;

        private string _email;
        private string _navn;
        private int _cprnummer;

        public Medarbejder()
        {

        }

        public Medarbejder(int Id, string email, string navn, int cprnummer)
        {

            _navn = navn;
            _cprnummer = cprnummer;
            _email = email;
            _mId = Id;
        }
        
        public int Medarbejder_id
        {
            get { return _mId; }
            set { _mId = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Navn
        {
            get { return _navn; }
            set { _navn = value; }
        }
        public int CPRNummer    
        {
            get { return _cprnummer; }
            set { _cprnummer = value; }
        }

    }
}
