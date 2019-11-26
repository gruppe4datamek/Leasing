using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Leasing.Persistency
{
    public class WebAPIAsync<T> : IWebAPIAsync<T> where T : class
    {


        #region Instance fields
        private string _serverURL;
        private string _apiPrefix;
        private string _apiID;
        private HttpClientHandler _httpClientHandler;
        private HttpClient _httpClient;
        #endregion

        #region Constructor
        public WebAPIAsync(string serverURL, string apiPrefix, string apiID)
        {
            _serverURL = serverURL;
            _apiID = apiID;
            _apiPrefix = apiPrefix;
            _httpClientHandler = new HttpClientHandler();
            _httpClientHandler.UseDefaultCredentials = true;
            _httpClient = new HttpClient(_httpClientHandler);
            _httpClient.BaseAddress = new Uri(_serverURL);
        }


        public async Task Create(T obj)
        {
            string url = _serverURL + "/" + _apiPrefix + "/" + _apiID;
        }


        #endregion


        public Task Update(int key, T obj)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int key)
        {
            HttpClient client = new HttpClient();
            string url = _serverURL + "/" + _apiPrefix + "/" + _apiID + "/" + key;
            HttpResponseMessage response1 = await client.DeleteAsync(url);
            response1.EnsureSuccessStatusCode();
        }

        public async Task<List<T>> Load()
        {
            HttpClient client = new HttpClient();
            string url = _serverURL + "/" + _apiPrefix + "/" + _apiID;
            HttpResponseMessage response = await client.GetAsync(url);
            if (response != null)
            {

                string s = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<T>>(s);
            }

            return null;
        }

        public async Task<T> Read(int key)
        {
            HttpClient client = new HttpClient();
            string url = _serverURL + "/" + _apiPrefix + "/" + _apiID + "/" + key;
            HttpResponseMessage response3 = await client.GetAsync(url);
            if (response3 != null)
            {

                string s = await response3.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(s);

            }

            return null;

        }


    }
}
