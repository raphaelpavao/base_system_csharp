using Microsoft.AspNetCore.Mvc;
using WebApplication1.Migrations;
using WebApplication1.Repositorio;

namespace WebApplication1.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                _contatoRepositorio.Apagar(id);
                TempData["MensagemSucesso"] = "Contato apagado com sucesso.";
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Falha ao apagar cadastro. Erro: {erro.Message}";
                return RedirectToAction("index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso.";
                    return RedirectToAction("index");
                }
                return View(contato);                
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Falha no cadastrado. Erro: {erro.Message}";
                return RedirectToAction("index");
            }          
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso.";
                    return RedirectToAction("index");
                }
                return View("Editar",contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Falha ao alterar cadastro. Erro: {erro.Message}";
                return RedirectToAction("index");
            }
        }
    }
}