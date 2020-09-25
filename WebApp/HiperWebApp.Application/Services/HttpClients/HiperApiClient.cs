using HiperWebApp.Domain.Models;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HiperWebApp.Application.Services.HttpClients
{
    public class HiperApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _version = "1.0";
        private readonly string _uri;

        public HiperApiClient(HttpClient client)
        {
            _httpClient = client;
            _uri = $"api/v{_version}";
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            HttpResponseMessage resposta = await _httpClient.GetAsync($"{_uri}/Product");
            resposta.EnsureSuccessStatusCode();
            string response = await resposta.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Product>>(response);
        }

        public async Task PostProductAsync(List<Product> productList)
        {
            foreach (Product product in productList)
            {
                await SendProduct(product, HttpMethod.Post);
            }
        }

        public async Task PutProductAsync(List<Product> productList)
        {
            foreach (Product product in productList)
            {
                await SendProduct(product, HttpMethod.Put);
            }
        }

        private async Task SendProduct(Product product, HttpMethod method)
        {
            try
            {
                string json = JsonConvert.SerializeObject(product);

                StringContent data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpRequestMessage request = new HttpRequestMessage(method, $"{_uri}/Product")
                {
                    Content = data
                };

                HttpResponseMessage resposta = await _httpClient.SendAsync(request);
                resposta.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
            }
        }
    }
}
