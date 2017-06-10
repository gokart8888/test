using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PrismUnityApp2.Services
{
    public class DataService
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient(new HttpClientHandler());
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        #region Post
        public async Task<T> PostAsync<T>(T authUser, string api)
        {
            using (HttpClient client = GetClient())
            {
                HttpResponseMessage httpResponseMessage = await client.PostAsync(api,
                new StringContent(
                    JsonConvert.SerializeObject(authUser, _jsonSerializerSettings),
                    Encoding.UTF8, "application/json"));
                httpResponseMessage.EnsureSuccessStatusCode();
                string content = await httpResponseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
        }
        #endregion
    }
}
