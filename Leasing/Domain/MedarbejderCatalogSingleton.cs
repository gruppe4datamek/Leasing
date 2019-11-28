using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leasing.Model;
using Leasing.Persistency;

namespace Leasing.Domain
{
    class MedarbejderCatalogSingleton
    {

        private MedarbejderPersistency mp;

        public MedarbejderCatalogSingleton()
        {

            mp = new MedarbejderPersistency();
        }

        private static MedarbejderCatalogSingleton _instance;
        public static MedarbejderCatalogSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MedarbejderCatalogSingleton();
                }
                return _instance;
            }
        }



        private int _count;
        private List<Medarbejder> _medarbejders;

        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
            }
        }

        public List<Medarbejder> MedarbejderList
        {
            get { return _medarbejders; }
            set
            {
                _medarbejders = value;

            }
        }


        public async void addMedarbejder(Medarbejder medarbejder)
        {
            await mp.AddMedarbejderAsync(medarbejder);
        }
    }
}
