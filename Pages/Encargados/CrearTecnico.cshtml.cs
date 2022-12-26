using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Impresoras3D.App.Dominio;
using Impresoras3D.App.Persistencia;

namespace Impresoras3D.App.Frontend.Pages
{
    public class CrearTecnicoModel : PageModel
    {
        private static IRepositorioImpresora _repoImpresora = new RepositorioImpresora(new Impresoras3D.App.Persistencia.AppContext());
        private static IRepositorioTecnico _repoTecnico = new RepositorioTecnico(new Impresoras3D.App.Persistencia.AppContext()); 
        [BindProperty]
        public Impresora3D impresora{get;set;}
        [BindProperty]
        public IEnumerable<Impresora3D>impresoralst{get;set;}
        [BindProperty]
        public Tecnicos tecnico{get; set;}
       public CrearTecnicoModel()
        {}
        public ActionResult OnGet()
        {
            

            return Page();
        }
         public ActionResult OnPost()
        {
            try
            {
                Tecnicos TecnicoAdicionado = _repoTecnico.AddTecnico(tecnico);
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

