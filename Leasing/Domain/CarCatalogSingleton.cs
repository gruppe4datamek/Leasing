using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leasing.Model;

namespace Leasing.Domain
{
    class CarCatalogSingleton
    {
        private List<Bil> _students;

        public CarCatalogSingleton()
        {
            _bils = new List<Bil>();
            _bils.Add(new Bil("Toyota"));
            _bils.Add(new Bil("BMW"));
        }

        private static CarCatalogSingleton _instance;
        public static CarCatalogSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CarCatalogSingleton();
                }
                return _instance;
            }
        }



        private int _count;
        private List<Bil> _bils;

        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
            }
        }

        public List<Bil> CarList
        {
            get { return _bils; }
            set
            {
                _bils = value;

            }
        }


        public void addCar(Bil bil)
        {
            _bils.Add(bil);
        }

    }
}
