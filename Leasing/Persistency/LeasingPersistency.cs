using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leasing.Model;

namespace Leasing.Persistency
{
    class LeasingPersistency
    {
        private const string ServerUrl = "http://localhost:60458";

        public async Task AddLeasingAsync(Leasing1 l)
        {
            await WebApiLeasingAsync.PostItem(ServerUrl, l);
        }
    }
}
