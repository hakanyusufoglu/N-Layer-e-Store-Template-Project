using Newtonsoft.Json;
using NLayereStoreTemplateProject.Web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Web.ApiService
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;
        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            IEnumerable<ProductDto> productDtos;
            var response = await _httpClient.GetAsync("products");
            if (response.IsSuccessStatusCode)
            {
                productDtos = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                productDtos = null;
            }
            return productDtos;
        }
        public async Task<ProductDto> GetByIdAsync(int id)
        {
          
            var response = await _httpClient.GetAsync($"products/{id}");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ProductDto>(await response.Content.ReadAsStringAsync());
            }
            else { 
                     return null;
            }
        }
        public async Task<int> GetCount()
        {
            var response = await _httpClient.GetAsync("products/count");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());

            }
            return -1;
        }
        public async Task<bool> Update(ProductDto productDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(productDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("products", stringContent);
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
            var response = await _httpClient.DeleteAsync($"products/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<ProductWithCategoryDto> GetProductWithCategoryAsync(int id)
        {
     
            var response = await _httpClient.GetAsync($"products/{id}/category");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ProductWithCategoryDto>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }
        public async Task<IEnumerable<ProductWithCategoryAndBrandDto>> GetAllProductwithCategoryAsync()
        {
            var response = await _httpClient.GetAsync($"products/category");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<IEnumerable<ProductWithCategoryAndBrandDto>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }
        public async Task<IEnumerable<ProductDto>> SearchByName(string name) //not yet used
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(name), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"products/search/{name}", stringContent);
            if (response.IsSuccessStatusCode)
            {
                var products = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(await response.Content.ReadAsStringAsync());
                return products;
            }
            else
            {
                return null;
            }
        }
    }
}
