using Newtonsoft.Json;
using NLayereStoreTemplateProject.Web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Web.ApiService
{
    public class OrderApiService
    {
        private readonly HttpClient _httpClient;
        public OrderApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<OrderWithProductsAndUserDto>> GetAllOrderWithProductUserAsync()
        {
            var response = await _httpClient.GetAsync("orders/products/user");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<IEnumerable<OrderWithProductsAndUserDto>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }
    }
}
