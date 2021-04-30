using Newtonsoft.Json;
using NLayereStoreTemplateProject.Web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Web.ApiService
{
    public class BasketApiService
    {
        private readonly HttpClient _httpClient;
        public BasketApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<BasketandProductsUserDto>>GetAllAsyncByUserId(int userId)
        {
            var response = await _httpClient.GetAsync($"baskets/{userId}/products/user");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<IEnumerable<BasketandProductsUserDto>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }
        public async Task<BasketDto> AddAsync(BasketDto basketDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(basketDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("baskets",stringContent);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<BasketDto>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }

        }
        public async Task<bool> Uptade(BasketDto basketDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(basketDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("baskets", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            { 
                return false; 
            }
        }
        public async Task<bool> Remove(int id)
        {
            var response = await _httpClient.DeleteAsync($"baskets/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            { 
                return false; 
            }
        }

        //for try purpose
        public async Task<IEnumerable<BasketDto>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("baskets");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<IEnumerable<BasketDto>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }

        }
    }
}
