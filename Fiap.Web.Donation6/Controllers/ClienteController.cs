using Fiap.Web.Donation6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation6.Controllers
{
    public class ClienteController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(ClienteModel clienteModel)
        {
            // INSERT INTO CLIENTE VALUES ("");

            return View("Sucesso");
        }




        [HttpGet]
        public IActionResult Help()
        {
            return View();
        }

    }
}
