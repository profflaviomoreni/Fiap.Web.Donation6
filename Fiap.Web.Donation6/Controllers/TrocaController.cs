using Fiap.Web.Donation6.Data;
using Fiap.Web.Donation6.Models;
using Fiap.Web.Donation6.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.Donation6.Controllers
{
    public class TrocaController : BaseController
    {


        private readonly ProdutoRepository _produtoRepository;

        private readonly TrocaRepository _trocaRepository;


        public TrocaController(DataContext dataContext)
        {
            _produtoRepository = new ProdutoRepository(dataContext);
            _trocaRepository = new TrocaRepository(dataContext);
        }


        [HttpGet]
        public IActionResult Index(int id)
        {
            // Dados do produto escolhido
            var produtoEscolhido = _produtoRepository.FindById(id);
            var trocaModel = new TrocaModel();
            trocaModel.ProdutoEscolhido = produtoEscolhido;

            var meusProdutos = _produtoRepository.FindAllAvailablesWithCategoriaAndUsuarioByUserId(UsuarioLogado.UsuarioId);
            ViewBag.MeusProdutos = new SelectList(meusProdutos, "ProdutoId", "NomeProduto");

            return View(trocaModel);
        }

        [HttpPost]
        public IActionResult Index(TrocaModel trocaModel)
        {
            try
            {

                var produtoMeu = _produtoRepository.FindById(trocaModel.ProdutoIdMeu);
                var produtoEscolhido = _produtoRepository.FindById(trocaModel.ProdutoIdEscolhido);


                if ( ! produtoEscolhido.Disponivel)
                {
                    throw new Exception("Produto escolhido não está mais disponível");
                }

                if (!produtoMeu.Disponivel)
                {
                    throw new Exception("O seu produto não está mais disponível");
                }

                if ( (produtoMeu.Valor / produtoEscolhido.Valor) < 0.9 )
                {
                    throw new Exception("Os valores dos produtos não podem passar de 10% de diferença");
                }

                if (produtoMeu.Usuario.UsuarioId != UsuarioLogado.UsuarioId)
                {
                    throw new Exception("Possível fraude, vc escolheu um produto que não pertence a você");
                }

                produtoMeu.Disponivel = false;
                _produtoRepository.Update(produtoMeu);

                produtoEscolhido.Disponivel = false;
                _produtoRepository.Update(produtoEscolhido);


                trocaModel.TrocaStatus = TrocaStatus.Iniciado;
                _trocaRepository.Insert(trocaModel);

                TempData["MensagemSucesso"] = "Troca efetuado com sucesso";

            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = ex.ToString();
            }

            return RedirectToAction(nameof(Index),"Home");
        }
    }
}
