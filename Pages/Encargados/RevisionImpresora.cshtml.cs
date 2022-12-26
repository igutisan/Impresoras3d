using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Impresoras3D.App.Persistencia;
using Impresoras3D.App.Dominio;

namespace Impresoras3D.App.Frontend.Pages
{
    public class RevisionImpresoraModel : PageModel
    {  
        private static IRepositorioImpresora _repoImpresora = new RepositorioImpresora(new Impresoras3D.App.Persistencia.AppContext());
        private static IRepositorioRevision _repoRevision = new RepositorioRevision(new Impresoras3D.App.Persistencia.AppContext());
        private static IRepositorioTecnico _repoTecnico = new RepositorioTecnico(new Impresoras3D.App.Persistencia.AppContext());

        [BindProperty]
        public Impresora3D impresora3D{get; set;}
        [BindProperty]
        public Tecnicos tecnicos{get; set;}
        //[BindProperty]
        //public IEnumerable<Impresora3D> impresoralst{get; set;}
        [BindProperty]
        public Revisiones revision{get; set;}
        public RevisionImpresoraModel()
        {}
        public void OnGet(int id)
        {
            
            //TempData["Usuario"] = this.LoginUsuario;
            TempData.Keep("Usuario");
            impresora3D=_repoImpresora.GetImpresoras(id);
            tecnicos=_repoTecnico.GetTecnicosXId(id);            
            //revision=_repoRevision.GetRevision(id);
           
        }
        public ActionResult OnPost()
        {
            try
            {
                
      
       

        
                revision.Impresora3DId=impresora3D.Id;
                Revisiones revisionAdicionada = _repoRevision.AddRevision(revision);
                return RedirectToPage("/Impresoras/ListarImpresoras");
            }
            catch (System.Exception e)
            {
                ViewData["Error"]= e.Message;
                return Page();
            }
        }
    }
}
