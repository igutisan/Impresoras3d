using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Impresoras3D.App.Dominio;
using Impresoras3D.App.Persistencia;

namespace Impresoras3D.App.Frontend.Pages
{
    public class ListadoRevisionesModel : PageModel
    {
        private static IRepositorioImpresora _repoImpresora = new RepositorioImpresora(new Impresoras3D.App.Persistencia.AppContext()); 
        private static IRepositorioRevision _repoRevision = new RepositorioRevision(new Impresoras3D.App.Persistencia.AppContext());
        //[BindProperty]
        //public IEnumerable<Impresora3D> impresora{get; set;}
        [BindProperty]
        public Impresora3D impresora3D {get; set;}
        [BindProperty]
        public IEnumerable<Revisiones> revision{get; set;}
       
        public ListadoRevisionesModel()
        {}
        public void OnGet(int? Id)
        {
            //TempData["Usuario"] = this.LoginUsuario;
            TempData.Keep("Usuario");
            if (Id.HasValue)
            {
                impresora3D = _repoImpresora.GetImpresoras(Id.Value);
            }
            if (impresora3D  == null)
            {
                RedirectToPage("./NotFound");
            }
            else
            {
                revision = _repoRevision.GetrevId(Id.Value);
            }
        }

        public ActionResult OnPost(int IdRevision)
        {            
            revision = _repoRevision.GetrevId(IdRevision);
            return Page();        
        }
    }
}
