using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnityEngine;

namespace Network {
    [Serializable]
    public class VideoLoader {
        [SerializeField] string contentServerAdress;

        string folder;

        HttpClient client = new HttpClient();

        public void Init() {
            folder = MakeGetRequest(contentServerAdress).ToString();
        }

        private async Task<string> MakeGetRequest(string url) {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            Debug.Log(responseBody);
            return responseBody;
        }

        private string ConvertXmlToJsonString(string xml) {
            var doc = XDocument.Parse(xml);

            return JsonConvert.SerializeXNode(doc, Formatting.Indented);
        }
    }
}