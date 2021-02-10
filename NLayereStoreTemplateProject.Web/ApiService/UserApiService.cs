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
    public class UserApiService
    {
        private readonly HttpClient _httpClient;
        public UserApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            IEnumerable<UserDto> userDtos;
            var response = await _httpClient.GetAsync("users");
            if (response.IsSuccessStatusCode)
            {
                userDtos = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(await response.Content.ReadAsStringAsync());
                
            }
            else
            {
                userDtos = null;
            }
            return userDtos;
        }

        public async Task<int> GetCount()
        {
            var response = await _httpClient.GetAsync("users/count");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());

            }
            return -1;
        }
        public async Task<UserDto> AddAsync(UserDto userDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("users", stringContent);
            if (response.IsSuccessStatusCode)
            {
                userDto = JsonConvert.DeserializeObject<UserDto>(await response.Content.ReadAsStringAsync());
                return userDto;
            }
            else
            {
                return null;
            }
        }
        public async Task<bool> Update(UserDto userDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("users", stringContent);
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
            var response = await _httpClient.DeleteAsync($"users/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<UserDto> GetByIdAsync(int id)
        {
            var response =await _httpClient.GetAsync($"users/{id}");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<UserDto>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }
        public async Task<IEnumerable<UserDto>> SearchByName(string name)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(name), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"users/search/{name}", stringContent);
            if (response.IsSuccessStatusCode)
            {
              var  userDto = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(await response.Content.ReadAsStringAsync());
                return userDto;
            }
            else
            {
                return null;
            }

        }
      
    }
}
