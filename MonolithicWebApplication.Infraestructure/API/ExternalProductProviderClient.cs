using MonolithicWebApplication.Infraestructure.API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MonolithicWebApplication.Infraestructure.API
{
    public class ExternalProductProviderClient : IExternalProductProviderClient
    {
        private HttpClient _apiClient;
        public ExternalProductProviderClient(HttpClient client)
        {
            _apiClient = client;
        }

        public async Task<List<ExternalProduct>> GetProducts()
        {
            var externalProducts = new List<ExternalProduct>();
            string error="";

            try {
                string uri = "http://localhost:14428/API/ProductController";
                var response = await _apiClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    externalProducts = JsonConvert.DeserializeObject<List<ExternalProduct>>(result);
                }
            }
            catch (Exception e) {
                error= e.Message;
            }

            return externalProducts;

        }
    }
}
