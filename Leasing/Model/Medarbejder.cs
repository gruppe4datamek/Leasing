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

        private string _email;
        private string _navn;
        private int _id;

        public Medarbejder(string email, string navn, int id)
        {

            _navn = navn;
            _id = id;
            _email = email;
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
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

    }
}
