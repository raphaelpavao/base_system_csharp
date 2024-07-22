using Microsoft.AspNetCore.Mvc;
using WebApplication1.Enums;
using WebApplication1.Repositorio;

namespace WebApplication1.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
      

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            
        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                _usuarioRepositorio.Apagar(id);
                TempData["MensagemSucesso"] = "Usuário apagado com sucesso.";
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Falha ao apagar usuário. Erro: {erro.Message}";
                return RedirectToAction("index");
            }
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso.";
                    return RedirectToAction("index");
                }
                return View(usuario);                
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Falha no cadastrado. Erro: {erro.Message}";
                return RedirectToAction("index");
            }          
        }

        [HttpPost]
        public IActionResult Alterar(UsuarioModel usuario)
        {
            var usuarioExistente = _usuarioRepositorio.ListarPorId(usuario.Id);
            usuario.Senha = usuarioExistente.Senha;
            usuario.Email = usuarioExistente.Email;
            try
            {
                if(ModelState.IsValid)           {                                        
                    _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuario alterado com sucesso.";
                    return RedirectToAction("index");
                }
                return View("Editar",usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Falha ao alterar cadastro de Usuário. Erro: {erro.Message}";
                return RedirectToAction("index");
            }
        }
    }
}