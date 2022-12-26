using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Impresoras3D.App.Dominio;
using Impresoras3D.App.Persistencia;

namespace Impresoras3D.App.Frontend.Pages
{
    public class CrearOperarioModel : PageModel
    {
        private static IRepositorioOperario _repoOperario = new RepositorioOperario(new Impresoras3D.App.Persistencia.AppContext()); 
        [BindProperty]
        public Operarios operario{get; set;}
       public CrearOperarioModel()
        {}
        public ActionResult OnGet()
        {
            return Page();
        }
         public ActionResult OnPost()
        {
            try
            {
                Operarios operarioAdicionado = _repoOperario.AddOperario(operario);
                return RedirectToPage("/Impresoras/ListarImpresoras");
            }
            catch (System.Exception e)
            {
                ViewData["Error"] = e.Message;
                return Page();
            }
        }
    }
}

