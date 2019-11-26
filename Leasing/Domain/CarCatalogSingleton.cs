using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leasing.Model;
using Leasing.Persistency;

namespace Leasing.Domain
{
    class CarCatalogSingleton
    {
        private BilPersistency bp;

        public CarCatalogSingleton()
        {

            bp = new BilPersistency();
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


        public async void addCar(Bil bil)
        {
            await bp.AddBilAsync(bil);
        }

    }
}
