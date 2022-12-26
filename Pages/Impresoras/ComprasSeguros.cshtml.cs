using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Impresoras3D.App.Persistencia;
using Impresoras3D.App.Dominio;

namespace Impresoras3D.App.Frontend.Pages
{
    public class ComprasSegurosModel : PageModel
    {
         private static IRepositorioImpresora _repoImpresora = new RepositorioImpresora(new Impresoras3D.App.Persistencia.AppContext());
        private static IRepositorioSeguros _repoSeguro = new RepositorioSeguros(new Impresoras3D.App.Persistencia.AppContext());
     
        [BindProperty]
        public IEnumerable<Impresora3D> impresoralst{get; set;}
        [BindProperty]
        public PolizasDeSeguro seguro{get; set;}
        public ComprasSegurosModel()
        {

        }
        public ActionResult OnGet()
        {
            impresoralst = _repoImpresora.GetAllImpresora();
            //TempData["Usuario"] = this.LoginUsuario;
            TempData.Keep("Usuario");
            return Page();
        }
        public ActionResult OnPost()
        {
            try
            {
                
                
                PolizasDeSeguro compraAdicionada = _repoSeguro.AddSeguro(seguro);
                return RedirectToPage("/Encargados/ListarOperarios");
            }
            catch (System.Exception e)
            {
                ViewData["Error"]= e.Message;
                return Page();
                
            }
        }
    }
}
