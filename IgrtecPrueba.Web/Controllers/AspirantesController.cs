using IgrtecPrueba.Web.Aspirantes;
using IgrtecPrueba.Web.Models;
using Microsoft.AspNetCore.Mvc;
//using IgrtecPrueba.ApplicationServices;
namespace IgrtecPrueba.Web.Controllers
{
    public class AspirantesController : Controller
    {
        private readonly IAspirantesAppService _aspirantesAppService;
        public AspirantesController(IAspirantesAppService aspirantesAppService)
        {
            _aspirantesAppService = aspirantesAppService;

        }
        // GET: AspirantesController
        public async Task<ActionResult> Index(string? buscarItem)
        {
            var aspirantes = await _aspirantesAppService.GetAspirantesAsync();

            if (!string.IsNullOrEmpty(buscarItem))
            {
               aspirantes = aspirantes.Where(x => x.Nombre.ToLower().Contains(buscarItem.ToLower()) || x.Apellido.ToLower().Contains(buscarItem.ToLower())).ToList();
            }
            return View(aspirantes);
        }

        // GET: AspirantesController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: AspirantesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AspirantesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Aspirante newAspirante)
        {
            try
            {
                var createdAspirante = await _aspirantesAppService.SaveAspiranteAsync(newAspirante);

                if (createdAspirante != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Handle the error
                    ModelState.AddModelError(string.Empty, "Unable to create aspirante.");
                    return View(newAspirante);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: AspirantesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
           
            var aspirante = await _aspirantesAppService.GetAspiranteById(id);
            if (aspirante == null)
            {
                return NotFound();
            }
            return View(aspirante);
        }

        // POST: AspirantesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Aspirante aspirante)
        {
            try
            {
                var updatedAspirante = await _aspirantesAppService.EditAspiranteAsync(aspirante);

                if (updatedAspirante != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Handle the error
                    ModelState.AddModelError(string.Empty, "Unable to edit aspirante.");
                    return View(aspirante);
                }
            }
            catch
            {
                return View();
            }
        }

        // DELETE: AspirantesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _aspirantesAppService.DeleteAspiranteAsync(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
