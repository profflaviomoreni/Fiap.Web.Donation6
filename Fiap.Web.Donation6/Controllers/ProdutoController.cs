using Fiap.Web.Donation6.Data;
using Fiap.Web.Donation6.Models;
using Fiap.Web.Donation6.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation6.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly ProdutoRepository _produtoRepository;
        public ProdutoController(DataContext dataContext)
        {
            _produtoRepository = new ProdutoRepository(dataContext);
        }


        public IActionResult Index()
        {
            var produtos = _produtoRepository.FindAll();
            return View(produtos);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
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
                TempData["SuccessMessage"] = $"Produto {produtoModel.NomeProduto} atualizado com sucesso!";
                return RedirectToAction(nameof(Index));

            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var produto = ListarProdutosMock().Where(p => p.ProdutoId == id).FirstOrDefault();
            return View(produto);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var produto = ListarProdutosMock().Where(p => p.ProdutoId == id).FirstOrDefault();

            // DELETE from PRODUTOS WHERE ProdutoID = id

            TempData["SuccessMessage"] = $"Produto {produto.NomeProduto} removido com sucesso!";
            return RedirectToAction(nameof(Index));
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
