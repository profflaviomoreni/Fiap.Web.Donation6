using Fiap.Web.Donation6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Fiap.Web.Donation6.Controllers
{
    public class BaseController : Controller
    {

        protected UsuarioModel? UsuarioLogado { 
            get {
                var usuarioJson = HttpContext.Session.GetString("usuarioLogado");
                if ( ! string.IsNullOrEmpty(usuarioJson))
                {
                    return JsonSerializer.Deserialize<UsuarioModel>(usuarioJson);
                } else
                {
                    return null;
                }
            } 
        }

        public bool Autenticado => UsuarioLogado != null;
    }
}
