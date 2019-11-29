using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leasing.Model;

namespace Leasing.Persistency
{
    class KundePersistency
    {
        private const string ServerUrl = "http://localhost:55492";

        public async Task AddKundeAsync(Kunde k)
        {
            await WebApiKundeAsync.PostItem(ServerUrl, k);
        }
    }
}
