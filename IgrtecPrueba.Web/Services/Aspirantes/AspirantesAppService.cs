using IgrtecPrueba.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IgrtecPrueba.Web.Aspirantes
{
    public class AspirantesAppService : IAspirantesAppService
    {
        private static string _baseUrl = "https://api-aspirantesweb.igrtecapi.site/api/Aspirantes/";
        private readonly HttpClient _httpClient;
        public AspirantesAppService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Aspirante>> GetAspirantesAsync()
        {
            List<Aspirante> result = new List<Aspirante>();

           
            var response = await _httpClient.GetAsync(_baseUrl);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<Aspirante>>(responseBody);
                if(list != null) result = list;
            }
            return result;
        }

        public async Task<Aspirante> GetAspiranteById(int idAspirante)
        {
            try
            {
                Aspirante aspirante = new Aspirante();
                HttpResponseMessage response = await _httpClient.GetAsync($"{_baseUrl}{idAspirante}");

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                var item = JsonConvert.DeserializeObject<Aspirante>(responseBody);
                if (item != null) aspirante = item;
                return aspirante;
            }
            catch (HttpRequestException e)
            {
                return null;
            }
        }
        

        public async Task<Aspirante> EditAspiranteAsync(Aspirante aspirante)
        {
            try
            {
                var jsonContent = new StringContent(JsonConvert.SerializeObject(aspirante), Encoding.UTF8, "application/json");
              
                HttpResponseMessage response = await _httpClient.PutAsync(_baseUrl, jsonContent);

                response.EnsureSuccessStatusCode();


                string responseBody = await response.Content.ReadAsStringAsync();

                Aspirante editedAspirante = new Aspirante();
                var editedItem = JsonConvert.DeserializeObject<Aspirante>(responseBody);
                if (editedItem != null) editedAspirante = editedItem;
                
               

                return editedAspirante;
            }
            catch (HttpRequestException e)
            {
                return null;
            }
        }

        public async Task<Aspirante> SaveAspiranteAsync(Aspirante aspirante)
        {
            try
            {
                var jsonContent = new StringContent(JsonConvert.SerializeObject(aspirante), Encoding.UTF8, "application/json");
                _httpClient.BaseAddress = new Uri(_baseUrl);
                HttpResponseMessage response = await _httpClient.PostAsync("", jsonContent);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                Aspirante createdAspirante = new Aspirante();
                var createdItem = JsonConvert.DeserializeObject<Aspirante>(responseBody);
                if(createdItem != null) createdAspirante = createdItem;
                return createdAspirante;
            }
            catch (HttpRequestException e)
            {
                return null;
            }
        }

        public async Task<bool> DeleteAspiranteAsync(int idAspirante)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"{_baseUrl}{idAspirante}");

                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException e)
            {
                return false;
            }
        }
    }
}
