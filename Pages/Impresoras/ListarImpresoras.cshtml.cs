using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Impresoras3D.App.Dominio;
using Impresoras3D.App.Persistencia;

namespace Impresoras3D.App.Frontend.Pages
{
    public class ListarImpresorasModel : PageModel
    {
        private static IRepositorioImpresora _repoImpresora = new RepositorioImpresora(new Impresoras3D.App.Persistencia.AppContext());

        [BindProperty]
        public IEnumerable<Impresora3D> impresoralst{get; set;}

        public ListarImpresorasModel()
        {}
        
        public void OnGet()
        {
            //TempData["Usuario"] = this.LoginUsuario;
            TempData.Keep("Usuario");
            impresoralst = _repoImpresora.GetAllImpresora();
        }
        public ActionResult OnPost(string PlacaInventario)
        {           
            if (PlacaInventario != null){
            impresoralst = _repoImpresora.GetImpresoraPlaca(PlacaInventario);
            return Page();
            }else
            {
                return RedirectToPage("./NotFund");
            }
            return Page();
        }
    }
}
