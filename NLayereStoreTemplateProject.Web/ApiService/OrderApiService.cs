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
        public async Task<OrderDto> GetAllById(int orderId)
        {
            var response = await _httpClient.GetAsync($"orders/{orderId}");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<OrderDto>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }
        public async Task<OrderDto> AddAsync(OrderDto orderDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(orderDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("orders",stringContent);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<OrderDto>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }
        public async Task<bool> Update(OrderDto orderDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(orderDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("orders", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<IEnumerable<OrderDto>> AddRangeAsync(IEnumerable<OrderDto> orderDtos )
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(orderDtos), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("orders/ordernow", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<IEnumerable<OrderDto>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }
        public async Task<bool> Remove(int id)
        {
            var response = await _httpClient.DeleteAsync($"orders/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<int> GetCount()
        {
            var response = await _httpClient.GetAsync("orders/count");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());

            }
            return -1;
        }
    }
}
