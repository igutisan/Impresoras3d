using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Impresoras3D.App.Persistencia;
using Impresoras3D.App.Dominio;

namespace Impresoras3D.App.Frontend.Pages
{
    public class ListarImpresorasXOperarioModel : PageModel
    {
        private static IRepositorioImpresora _repoImpresora = new RepositorioImpresora(new Impresoras3D.App.Persistencia.AppContext());
        [BindProperty]
        public Impresora3D impresora{get;set;} 
       [BindProperty]
        public IEnumerable<Impresora3D>impresoralst{get;set;}
        public ListarImpresorasXOperarioModel()
        {}
        public void OnGet(int? Id)
        {
             TempData.Keep("Usuario");
            if (Id.HasValue)
            {
                impresora = _repoImpresora.GetImpresoras(Id.Value);
                
            }
            if (impresora  == null)
            {
                RedirectToPage("./NotFound");
            }
            else
            {
                impresoralst = _repoImpresora.ImpresorasXOperario(Id.Value);
            }
        }
        public ActionResult OnPost(int Id)
        {
            impresoralst = _repoImpresora.ImpresorasXOperario(Id);
            return Page();
        }
    }
}
