﻿using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YamlDeploymentWeb.Models;

namespace YamlDeploymentWeb.Services
{
    public class BikesService : IBikesService
    {
        private readonly IConfiguration configuration;
        private readonly HttpClient httpClient;

        public BikesService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            this.configuration = configuration;
            this.httpClient = httpClientFactory.CreateClient();
        }

        public async Task<List<BikeDto>> GetBikes()
        {
            var apiUrl = configuration.GetValue<string>("ApiUrl");
            HttpResponseMessage tokenResponse = await httpClient.GetAsync(apiUrl);
            var jsonContent = await tokenResponse.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<BikeDto>>(jsonContent);
        }

        public async Task AddBike(BikeDto bike)
        {
            await UpdateBike(bike);
        }

        public async Task UpdateBike(BikeDto bike)
        {
            var json = JsonConvert.SerializeObject(bike);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var apiUrl = configuration.GetValue<string>("ApiUrl");
            await httpClient.PostAsync(apiUrl, content);
        }

        public async Task RemoveBike(int id)
        {
            var apiUrl = configuration.GetValue<string>("ApiUrl");
            await httpClient.DeleteAsync(apiUrl + $"?id={id}");
        }
    }
}
