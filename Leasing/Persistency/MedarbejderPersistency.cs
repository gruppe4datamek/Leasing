using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leasing.Model;

namespace Leasing.Persistency
{
    class MedarbejderPersistency
    {
        public async Task AddMedarbejderAsync(Medarbejder m)
        {
            await WebApiMedarbejderAsync.PostItem(ServerUrl, m);
        }
        private const string ServerUrl = "http://localhost:60458";
    }

}