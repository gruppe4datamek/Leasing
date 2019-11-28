using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leasing.Model;
using Leasing.Persistency;

namespace Leasing.Domain
{
    class KundeCatalogSingleton
    {
        private KundePersistency kp;

        public KundeCatalogSingleton()
        {

            kp = new KundePersistency();
        }

        private static KundeCatalogSingleton _instance;
        public static KundeCatalogSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new KundeCatalogSingleton();
                }
                return _instance;
            }
        }



        private int _count;
        private List<Kunde> _kundes;

        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
            }
        }
        // det er en kommentar
        public List<Kunde> KundeList
        {
            get { return _kundes; }
            set
            {
                _kundes = value;

            }
        }


        public async void addKunde(Kunde kunde)
        {
            await kp.AddKundeAsync(kunde);
        }

    }
}
    
