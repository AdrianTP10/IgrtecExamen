using IgrtecPrueba.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IgrtecPrueba.Web.Aspirantes
{
    public interface IAspirantesAppService
    {
        Task<List<Aspirante>>  GetAspirantesAsync();

        Task<Aspirante> GetAspiranteById(int idAspirante);

        Task<Aspirante> SaveAspiranteAsync(Aspirante aspirante);
        Task<Aspirante> EditAspiranteAsync(Aspirante aspirante);
        Task<bool> DeleteAspiranteAsync(int idAspirante);
    }
}
