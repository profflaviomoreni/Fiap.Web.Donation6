using Fiap.Web.Donation6.Controllers.Filters;
using Fiap.Web.Donation6.Data;
using Fiap.Web.Donation6.Models;
using Fiap.Web.Donation6.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.Donation6.Controllers
{

    
    public class ProdutoController : BaseController
    {

        private readonly ProdutoRepository _produtoRepository;

        private readonly CategoriaRepository _categoriaRepository;

        public ProdutoController(DataContext dataContext)
        {
            _produtoRepository = new ProdutoRepository(dataContext);
            _categoriaRepository = new CategoriaRepository(dataContext);
        }


        public IActionResult Index()
        {
            //var produtos = _produtoRepository.FindAll();
            var produtos = _produtoRepository.FindAllWithCategoriaAndUsuario();
            //var produtos = _produtoRepository.FindAllWithCategoriaAndUsuarioByName("14");
            return View(produtos);
        }


        [Autenticado]
        [HttpGet]
        public IActionResult Create()
        {
            CarregarCategorias();
            return View();
        }


        [Autenticado]
        [HttpPost]
        public IActionResult Create(ProdutoModel produtoModel)
        {
            produtoModel.UsuarioId = UsuarioLogado.UsuarioId; // Vamos apagar no futuro

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


        [Autenticado]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var produto = _produtoRepository.FindById(id);
            CarregarCategorias();

            return View(produto);
        }

        [Autenticado]
        [HttpPost]
        public IActionResult Edit(ProdutoModel produtoModel)
        {
            produtoModel.UsuarioId = UsuarioLogado.UsuarioId; // Vamos apagar no futuro

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

        [Autenticado]
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
