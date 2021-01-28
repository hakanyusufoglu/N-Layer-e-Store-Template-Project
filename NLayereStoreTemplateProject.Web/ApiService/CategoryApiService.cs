using Newtonsoft.Json;
using NLayereStoreTemplateProject.Web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Web.ApiService
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;
        public CategoryApiService(HttpClient httpclient)
        {
            _httpClient = httpclient;
        }
        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            IEnumerable<CategoryDto> categoryDtos;
            var response = await _httpClient.GetAsync("categories");
            if (response.IsSuccessStatusCode)
            {
                categoryDtos = JsonConvert.DeserializeObject<IEnumerable<CategoryDto>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                categoryDtos=null;
            }
            return categoryDtos;
        }
        public async Task<CategoryWithProductsDto> GetCategoryWithProductsAsync(int id)
        {

            var response = await _httpClient.GetAsync($"categories/{id}/products");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<CategoryWithProductsDto>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }
    }
}
