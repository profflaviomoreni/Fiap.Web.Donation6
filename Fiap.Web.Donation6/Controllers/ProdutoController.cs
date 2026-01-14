using Fiap.Web.Donation6.Data;
using Fiap.Web.Donation6.Models;
using Fiap.Web.Donation6.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.Donation6.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly int UserId = 1;

        private readonly ProdutoRepository _produtoRepository;

        private readonly CategoriaRepository _categoriaRepository;

        public ProdutoController(DataContext dataContext)
        {
            _produtoRepository = new ProdutoRepository(dataContext);
            _categoriaRepository = new CategoriaRepository(dataContext);
        }


        public IActionResult Index()
        {
            var produtos = _produtoRepository.FindAll();
            return View(produtos);
        }


        [HttpGet]
        public IActionResult Create()
        {
            CarregarCategorias();
            return View();
        }


        [HttpPost]
        public IActionResult Create(ProdutoModel produtoModel)
        {
            produtoModel.UsuarioId = UserId; // Vamos apagar no futuro

            if (ModelState.IsValid)
            {
                _produtoRepository.Insert(produtoModel);
                TempData["SuccessMessage"] = $"Produto {produtoModel.NomeProduto} cadastrado com sucesso!";
                return RedirectToAction(nameof(Index));
            } 
            else
            {                
                CarregarCategorias();

                ViewBag.ErrorMessage = "Campos inválidos";
                return View(produtoModel);
            }
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var produto = _produtoRepository.FindById(id);
            CarregarCategorias();

            return View(produto);
        }


        [HttpPost]
        public IActionResult Edit(ProdutoModel produtoModel)
        {
            produtoModel.UsuarioId = UserId; // Vamos apagar no futuro

            if (! ModelState.IsValid)
            {
                CarregarCategorias();

                ViewBag.ErrorMessage = "Campos inválidos";
                return View(produtoModel);
            }
            else
            {
                _produtoRepository.Update(produtoModel);
                TempData["SuccessMessage"] = $"Produto {produtoModel.NomeProduto} alterado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            var produto = _produtoRepository.FindById(id);
            return View(produto);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var produto = _produtoRepository.FindById(id);

            _produtoRepository.Delete(produto.ProdutoId);

            TempData["SuccessMessage"] = $"Produto {produto.NomeProduto} removido com sucesso!";
            return RedirectToAction(nameof(Index));
        }


        private void CarregarCategorias()
        {
            var categorias = _categoriaRepository.FindAll();
            var selectCategorias = new SelectList(categorias, "CategoriaId", "NomeCategoria");
            ViewBag.Categorias = selectCategorias;
        }



    }
}
