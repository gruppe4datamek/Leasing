using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Leasing.Model;
using Leasing.ViewModel;
using Newtonsoft.Json;


namespace Leasing.Persistency
{
    class BilPersistency
    {
        private const string ServerUrl = "http://localhost:50171";

      

        public async Task AddBilAsync(Bil b)
        {
            await WebApiBilAsync.PostItem(ServerUrl, b); 
        }
        
    }

    
}

