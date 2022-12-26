using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Impresoras3D.App.Dominio;
using Impresoras3D.App.Persistencia;

namespace Impresoras3D.App.Frontend.Pages
{
    public class CrearImpresoraModel : PageModel
    {
         private static IRepositorioTecnico _repoTecnico = new RepositorioTecnico(new Impresoras3D.App.Persistencia.AppContext());
        private static IRepositorioOperario _repoOperario = new RepositorioOperario(new Impresoras3D.App.Persistencia.AppContext());
        private static IRepositorioImpresora _repoImpresora = new RepositorioImpresora(new Impresoras3D.App.Persistencia.AppContext());

        [BindProperty]
        public Impresora3D impresora3D{get;set;}
        [BindProperty]  
        public IEnumerable<Tecnicos> tecnico{get; set;}
        [BindProperty]
        public IEnumerable<Operarios> operario{get; set;}      
        public CrearImpresoraModel()
        {}

        public ActionResult OnGet()
        {
            tecnico =  _repoTecnico.GetAllTecnico();
            operario = _repoOperario.GetAllOperario();
            TempData.Keep("Usuario");
            return Page();
        }

        public ActionResult OnPost()
        {
            try
            {
                Impresora3D impresoraAdicionada = _repoImpresora.AddImpresora(impresora3D);
                return RedirectToPage("./ListarImpresoras");
            }
            catch (System.Exception e)
            {
                ViewData["Error"] = e.Message;
                return Page();
            }
        }
    }
}