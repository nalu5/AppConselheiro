using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using AppConselheiro.Model;

namespace AppConselheiro.Services
{
    internal class DataService
    {
        public static async Task<Conselho> getConselho()
        {
            string urlApi = "https://api.adviceslip.com/advice";

            dynamic resultado = await getDataFromService(urlApi).ConfigureAwait(false);

            if (resultado.slip != null)
            {
                Conselho conselho = new Conselho();

                conselho.Id = (int)resultado.slip.id;
                conselho.Texto = (string)resultado.slip.advice;

                return conselho;
            }
            else
            {
                return null;
            }
        }

        public static async Task<dynamic> getDataFromService(string queryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(queryString);

            dynamic data = null;
            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject(json);
            }
            return data;
        }
    }
}
