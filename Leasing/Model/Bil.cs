using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leasing.Model
{
   public class Bil
    {
        //konstruktør
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

        

        //f
    }
}
