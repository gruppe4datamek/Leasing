using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leasing.Model
{
    public class Bil
    {
        //instance field
        private int _årgang;
        private string _model;
        private string _mærke;
        private int _kilometertal;
        private string _farve;

        public Bil(int årgang, string model, string mærke, int kilometertal, string farve)
        {
            _årgang = årgang;
            _model = model;
            _mærke = mærke;
            _kilometertal = kilometertal;
            _farve = farve;
        }


        public int Årgang
        {
            get { return _årgang; }
            set { _årgang = value; }
        }

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public string Mærke
        {
            get { return _mærke; }
            set { _mærke = value; }
        }

        public int Kilometertal
        {
            get { return _kilometertal; }
            set { _kilometertal = value; }
        }

        public string Farve
        {
            get { return _farve; }
            set { _farve = value; }
        }
    }
}

