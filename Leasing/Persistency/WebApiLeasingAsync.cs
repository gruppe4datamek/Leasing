﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Leasing.Model;
using Newtonsoft.Json;

namespace Leasing.Persistency
{
    class WebApiLeasingAsync
    {
        public static List<Leasing1> GetLeasing(string url)
            {
                HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = true };
                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri("http://localhost:60529/");
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    try
                    {
                        HttpResponseMessage response = client.GetAsync(url).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            string status = response.Content.ReadAsStringAsync().Result;
                            List<Leasing1> leasing = JsonConvert.DeserializeObject<List<Leasing1>>(status);
                            return leasing;
                        }

                        return new List<Leasing1>();
                    }
                    catch (Exception e)
                    {
                        //Console.WriteLine(e.Message);
                        return null;
                    }
                }
            }

            //public static string ServerUrl { get; set; }


            public static async Task<string> PostItem(string url, Leasing1 objectToPost)
            {
                HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = true };
                string serverUrl = url + "/" + "api" + "/" + "Leasings";
                using (var client = new HttpClient(handler))
                {

                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    try
                    {
                        var serializedString = JsonConvert.SerializeObject(objectToPost);
                        StringContent content = new StringContent(serializedString, Encoding.UTF8, "application/json");
                        HttpResponseMessage responseMessage = await client.PostAsync(serverUrl, content);

                        if (responseMessage.IsSuccessStatusCode)
                            return await responseMessage.Content.ReadAsStringAsync();

                        return null;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return null;
                    }
                }

            }


            public static async Task DeleteKunde(string url)
            {
                HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = true };
                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    try
                    {
                        HttpResponseMessage responseMessage = await client.DeleteAsync(url);
                        if (responseMessage.IsSuccessStatusCode)
                            await responseMessage.Content.ReadAsStringAsync();

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);

                    }
                }
            }

            public async static Task PutKunde(string url, Kunde objectToPut)
            {
                HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = true };
                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    try
                    {
                        var serializedString = JsonConvert.SerializeObject(objectToPut);
                        StringContent content = new StringContent(serializedString, Encoding.UTF8, "application/json");
                        HttpResponseMessage responseMessage = await client.PutAsync(url, content);
                        if (responseMessage.IsSuccessStatusCode) await responseMessage.Content.ReadAsStringAsync();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }
            }
        }
}
