using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Impresoras3D.App.Persistencia;
using Impresoras3D.App.Dominio;

namespace Impresoras3D.App.Frontend.Pages
{
    public class ListaImpresorasXTecnicoModel : PageModel
    {
        private static IRepositorioImpresora _repoImpresora = new RepositorioImpresora(new Impresoras3D.App.Persistencia.AppContext());
        [BindProperty]
        public Impresora3D impresora{get;set;} 
       [BindProperty]
        public IEnumerable<Impresora3D>impresoralst{get;set;}
        public ListaImpresorasXTecnicoModel()
        {}
        public void OnGet(int? Id)
        {
            //TempData["Usuario"] = this.LoginUsuario;
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
                impresoralst = _repoImpresora.ImpresorasXTecnico(Id.Value);
            }
        }

        public ActionResult OnPost(int Id)
        {            
            impresoralst = _repoImpresora.ImpresorasXTecnico(Id);
            return Page();        
        }
    }
    }

