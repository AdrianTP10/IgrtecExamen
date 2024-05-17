using IgrtecPrueba.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IgrtecPrueba.ApplicationServices.Aspirantes
{
    public class AspirantesAppService : IAspirantesAppService
    {
        private static string _baseUrl = "https://api-aspirantesweb.igrtecapi.site/api/Aspirantes/";

        public async Task<List<Aspirante>> GetAspirantesAsync()
        {
            List<Aspirante> result = new List<Aspirante>();

            var client = new HttpClient();
            client.BaseAddress = new Uri ( _baseUrl );
            var response = await client.GetAsync("");

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<List<Aspirante>>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            return result;
        }

        public Task<Aspirante> GetAspiranteById(int idAspirante)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteAspiranteAsync(Aspirante aspirante)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAspiranteAsync(Aspirante aspirante)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAspiranteAsync(Aspirante aspirante)
        {
            throw new NotImplementedException();
        }
    }
}
