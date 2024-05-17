using IgrtecPrueba.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IgrtecPrueba.ApplicationServices.Aspirantes
{
    public interface IAspirantesAppService
    {
        Task<List<Aspirante>>  GetAspirantesAsync();

        Task<Aspirante> GetAspiranteById(int idAspirante);

        Task<bool> SaveAspiranteAsync(Aspirante aspirante);
        Task<bool> EditAspiranteAsync(Aspirante aspirante);
        Task<bool> DeleteAspiranteAsync(Aspirante aspirante);
    }
}
