using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnityEngine;

namespace Network {
    [Serializable]
    public class VideoLoader {
        [SerializeField] string contentServerAdress;

        string folder;
        string jsonString;
        JObject json;
        string[] urls;

        HttpClient client = new HttpClient();

        public string[] Execute() {
            folder = MakeGetRequest(contentServerAdress);

            jsonString = ConvertXmlToJsonString(folder);
            json = JObject.Parse(jsonString);
            urls = GetVideoUrls(json).ToArray();

            return urls;
        }

        private List<string> GetVideoUrls(JObject json) {
            List<string> urls = new List<string>();

            foreach (KeyValuePair<string, JToken> obj in json) {
                urls.Add(json[obj.Key.ToString()].ToString());
            }

            return urls;
        }

        private string MakeGetRequest(string url) {
            HttpResponseMessage response = client.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();

            string responseBody = response.Content.ReadAsStringAsync().Result;
            Debug.Log(responseBody);
            return responseBody;
        }

        private string ConvertXmlToJsonString(string xml) {
            var doc = XDocument.Parse(xml);

            return JsonConvert.SerializeXNode(doc, Formatting.Indented);
        }
    }
}