using Fiap.Web.Donation6.Data;
using Fiap.Web.Donation6.Models;
using Fiap.Web.Donation6.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Fiap.Web.Donation6.Controllers
{
    public class LoginController : Controller
    {

        private readonly UsuarioRepository _usuarioRepository;

        public LoginController(DataContext dataContext)
        {
            _usuarioRepository = new UsuarioRepository(dataContext);                
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UsuarioModel usuarioModel)
        {

            try
            {
                if ( !string.IsNullOrEmpty(usuarioModel.Email) && ! string.IsNullOrEmpty(usuarioModel.Senha)  )
                {

                    var usuario = _usuarioRepository.FindByEmailAndSenha(usuarioModel.Email, usuarioModel.Senha);

                    if (usuario != null)
                    {
                        // gravar os dados não
                        usuario.Senha = string.Empty;
                        var usuarioJson = JsonSerializer.Serialize(usuario);

                        HttpContext.Session.SetString("usuarioLogado", usuarioJson);

                        return RedirectToAction("Index", "Home");
                    } else
                    {
                        throw new Exception("Usuário e senha inválidos.");
                    }

                } else
                {
                    throw new Exception("Usuário e senha são obrigatórios.");
                }

            }
            catch (Exception ex)
            {
                ViewBag.Mensagem = ex.Message;
                return View(nameof(Index), usuarioModel);
            }


            
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("usuarioLogado",string.Empty);
            HttpContext.Session.Clear();

            return RedirectToAction( nameof(Index) );
        }

    }
}
