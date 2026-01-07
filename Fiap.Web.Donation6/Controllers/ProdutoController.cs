using Fiap.Web.Donation6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation6.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            var produtos = ListarProdutosMock();
            return View(produtos);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // SELECT * FROM produto WHERE ProdutoId = id
            // Carregar no objeto ProdutoModel os dados banco
            var produto = ListarProdutosMock().Where(p => p.ProdutoId == id).FirstOrDefault();

            return View(produto);
        }


        [HttpPost]
        public IActionResult Edit(ProdutoModel produtoModel)
        {
            
            if (string.IsNullOrEmpty(produtoModel.SugestaoTroca))
            {
                ViewBag.ErrorMessage = "A sugestão de troca é obrigatória.";
                return View(produtoModel);

            } else
            {
                // UPDATE produto SET ... WHERE ProdutoId = produtoModel.ProdutoId
                // Criar uma mensagem de sucesso
                // Exibir a tela dizendo que tivemos sucesso

                ViewBag.SuccessMessage = $"Produto {produtoModel.NomeProduto} atualizado com sucesso!";

                var produtos = ListarProdutosMock();

                return View("Index", produtos);

            }


        }



        private List<ProdutoModel> ListarProdutosMock()
        {
            // SELECT * FROM produtos ...

            var produtos = new List<ProdutoModel>{
                new ProdutoModel()
                {
                    ProdutoId = 1,
                    NomeProduto = "Iphone 11",
                    SugestaoTroca = "Descrição da troca",
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
