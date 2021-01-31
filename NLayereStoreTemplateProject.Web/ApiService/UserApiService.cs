using Newtonsoft.Json;
using NLayereStoreTemplateProject.Web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    }
}
