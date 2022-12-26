using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Impresoras3D.App.Dominio;
using Impresoras3D.App.Persistencia;
namespace Impresoras3D.App.Frontend.Pages
{
    public class ListarTecnicosModel : PageModel
    {
        private static IRepositorioTecnico _repoTecnico = new RepositorioTecnico(new Impresoras3D.App.Persistencia.AppContext());
        public IEnumerable<Tecnicos>tecnico{get;set;}
        public ListarTecnicosModel()
        {}
        public void OnGet()
        {
            tecnico = _repoTecnico.GetAllTecnico();
        }
    }
}
