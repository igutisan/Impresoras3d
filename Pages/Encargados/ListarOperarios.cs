using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Impresoras3D.App.Dominio;
using Impresoras3D.App.Persistencia;
namespace Impresoras3D.App.Frontend.Pages
{
    public class ListarOperariosModel : PageModel
    {
        private static IRepositorioOperario _repoOperario = new RepositorioOperario(new Impresoras3D.App.Persistencia.AppContext());
        public IEnumerable<Operarios>operario{get;set;}
        public ListarOperariosModel()
        {}
        public void OnGet()
        {
            operario = _repoOperario.GetAllOperario();
        }
    }
}