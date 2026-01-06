using Fiap.Web.Donation6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation6.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }




        private List<ProdutoModel> ListarProdutosMock()
        {
            // SELECT * FROM produtos ...

            var produtos = new List<ProdutoModel>{
                new ProdutoModel()
                {
                    ProdutoId = 1,
                    NomeProduto = "Iphone 11",
                    CategoriaId = 1,
                    Disponivel = true,
                    DataExpiracao = DateTime.Now,
                },
                new ProdutoModel()
                {
                    ProdutoId = 2,
                    NomeProduto = "Iphone 12",
                    CategoriaId = 2,
                    Disponivel = true,
                    DataExpiracao = DateTime.Now,
                },
                new ProdutoModel()
                {
                    ProdutoId = 3,
                    NomeProduto = "Iphone 13",
                    CategoriaId = 1,
                    Disponivel = true,
                    DataExpiracao = DateTime.Now,
                },
                new ProdutoModel()
                {
                    ProdutoId = 4,
                    NomeProduto = "Iphone 14",
                    CategoriaId = 1,
                    Disponivel = false,
                    DataExpiracao = DateTime.Now,
                },
            };

            return produtos;
        }



    }
}
