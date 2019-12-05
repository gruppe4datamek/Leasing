using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leasing.Persistency;
using Leasing.Model;

namespace Leasing.Domain
{
    class LeasingCatalogSingleton
    {
        private LeasingPersistency lp;

        public LeasingCatalogSingleton()
        {

            lp = new LeasingPersistency();
        }

        private static LeasingCatalogSingleton _instance;
        public static LeasingCatalogSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LeasingCatalogSingleton();
                }
                return _instance;
            }
        }



        private int _count;
        private List<Leasing1> _leasings;

        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
            }
        }

        public List<Leasing1> LeaisngList
        {
            get { return _leasings; }
            set
            {
                _leasings = value;

            }
        }


        public async void addleasing(Leasing1 leasing)
        {
            await lp.AddLeasingAsync(leasing);
        }
    }
}

