using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace Module_4
{
    public class ApiService
    {
        private HttpClient _client;
        public ApiService() {
            _client = new HttpClient();
        }    

        public async Task<string> GetDataFromApi()
        {
            string url = "http://localhost:4444/TransferSimulator/inn";

            try
            {
                string json = await _client.GetStringAsync(url);

                var result = JsonConvert.DeserializeObject<JsonResponse>(json);
                return result.Value;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Ошибка запроса: {ex.Message}");
                return null;
            }
        }
        }
    }

