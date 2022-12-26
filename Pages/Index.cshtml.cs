using System;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Impresoras3D.App.Persistencia;
using Impresoras3D.App.Dominio;

namespace Impresoras3D.App.Frontend.Pages
{
    public class IndexModel : PageModel
    {
        private static IRepositorioUsysUsuarios _repoUsuario = new RepositorioUsysUsuarios(new Impresoras3D.App.Persistencia.AppContext());
        private static IRepositorioOperario _repoOperario = new RepositorioOperario(new Impresoras3D.App.Persistencia.AppContext());
        private static IRepositorioTecnico _repoTecnico = new RepositorioTecnico(new Impresoras3D.App.Persistencia.AppContext());

        [BindProperty]
        public string LoginUser { get; set; }
        [BindProperty]
        public string Pass { get; set; }
        [BindProperty]
        public string Rol { get; set; }
        [BindProperty]
        public IEnumerable<Tecnicos> tecnico{get; set;}
        [BindProperty]
        public IEnumerable<Operarios> operario{get; set;}
        [BindProperty]
        public IEnumerable<UsysUsuarios> user{get; set;} 
        
        private readonly ILogger<IndexModel> _logger;
        
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public ActionResult OnGet()
        {
            TempData.Remove("TipoUsuario");
            TempData.Remove("Nombre");
            TempData.Remove("Id");
            return Page();
         }

        public ActionResult OnPost()
        {
            try
            {
                UsysUsuarios user = _repoUsuario.GetUsuarioLogin(LoginUser,
                    Pass);
                if(user != null)
                {
                    TempData["Nombre"] = user.NombresApellidos;
                    TempData["Id"] = user.Id.ToString();
                    TempData["TipoUsuario"] = "Auxiliar";
                    TempData.Keep();
                    return RedirectToPage("./Impresoras/ListarImpresoras");
                }
                else
                {
                    Tecnicos tecnico = _repoTecnico.GetTecnicoLogin(LoginUser, Pass);
                    if(tecnico != null)
                    {
                        TempData["Nombre"] = tecnico.Nombres;
                        TempData["Id"] = tecnico.Id.ToString();
                        TempData["TipoUsuario"] = "Tecnico";
                        TempData.Keep();
                        return RedirectToPage("./Encargados/ListarTecnicos");  
                    }
                    else
                    {
                        Operarios operario = _repoOperario.GetOperarioLogin(LoginUser, Pass);
                        if(operario != null)
                        {
                            TempData["Nombre"] = operario.Nombres;
                            TempData["Id"] = operario.Id.ToString();
                            TempData["TipoUsuario"] = "Operario";
                            TempData.Keep();
                            return RedirectToPage("./Encargados/ListarOperarios");  
                        }
                        else
                        {
                            ViewData["Error"] = "Usuario No encontrado";
                            return Page();
                        }                        
                    }
                }
            }
            catch (System.Exception e)
            {
                return Page();
            }                             
        }
    }
}

