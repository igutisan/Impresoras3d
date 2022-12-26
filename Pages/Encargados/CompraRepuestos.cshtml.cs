using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Impresoras3D.App.Dominio;
using Impresoras3D.App.Persistencia;

namespace Impresoras3D.App.Frontend.Pages
{
    public class CompraRepuestosModel : PageModel
    {
         private static IRepositorioImpresora _repoImpresora = new RepositorioImpresora(new Impresoras3D.App.Persistencia.AppContext()); 
        private static IRepositorioCompras _repoCompras = new RepositorioCompras(new Impresoras3D.App.Persistencia.AppContext());
        [BindProperty]
        public Compras compras{get;set;}
        [BindProperty]
        public IEnumerable<Impresora3D>impresoralst{get;set;}
        public Impresora3D impresora{get; set;}
        public CompraRepuestosModel()
        {}
         public void OnGet( int id)
        {
           // impresora=_repoImpresora.GetImpresoras(id);
           impresoralst=_repoImpresora.GetAllImpresora();
            
            
        }
         public ActionResult OnPost()
        {
            try
            {
                //compras.Impresora3DId=impresora.Id;
                Compras CompraAdicionada = _repoCompras.AddCompras(compras);
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
