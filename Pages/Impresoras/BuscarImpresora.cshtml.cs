using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Impresoras3D.App.Dominio;
using Impresoras3D.App.Persistencia;

namespace Impresoras3D.App.Frontend.Pages
{
    public class BuscarImpresoraModel : PageModel
    {
        private static IRepositorioImpresora _repoImpresora = new RepositorioImpresora(new Impresoras3D.App.Persistencia.AppContext());
        //public Impresora3D impresora3D{get;set;}

        [BindProperty]
        public IEnumerable<Impresora3D> impresoralst{get; set;}
        public ActionResult OnGet(string PlacaInventario)
        {
            //TempData["Usuario"] = this.LoginUsuario;
            TempData.Keep("Usuario");
            if(PlacaInventario != null)
            {
                impresoralst = _repoImpresora.GetImpresoraPlaca(PlacaInventario);
            }
            return Page();
        }
        public ActionResult OnPost(string PlacaInventario)
        {
            if (PlacaInventario != null)
            {
                impresoralst = _repoImpresora.GetImpresoraPlaca(PlacaInventario);
            }
            return Page();
        }
    }
}
