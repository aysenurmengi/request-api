using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Abstract;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Concrete
{
    public class DataService : IDataService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DataService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<MyDataModel>> GetFilteredDataAsync(DateTime startDate, DateTime endDate, FilterTypeEnum type)
        {
            var client = _httpClientFactory.CreateClient(); // httpClient oluşturuyoruz
            client.BaseAddress = new Uri("https://localhost:7265"); // workerdaki api url'i

            // api'den veri almak için gerekli olan url
            var url = $"/api/watcher/filter?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}&type={type}";

            var response = await client.GetAsync(url); // önceki api'ye istek

            if (response.IsSuccessStatusCode) //başarı kontrol ve sonucu dönderme
            {
                return await response.Content.ReadFromJsonAsync<List<MyDataModel>>();
            }

            throw new Exception("veri alırken bir hata oluştu: " + response.ReasonPhrase);

        }

    }

}

