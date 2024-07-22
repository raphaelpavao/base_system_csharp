using Microsoft.AspNetCore.Mvc;
using WebApplication1.Enums;
using WebApplication1.Helper;
using WebApplication1.Models;
using WebApplication1.Repositorio;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            if(_sessao.BuscarSessaoUsuario() != null) return RedirectToAction("Index","Home");
            return View();
        }

         public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();
            return RedirectToAction("Index","Login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorEmail(loginModel.Email);
                    if(usuario != null && usuario.Senha == loginModel.Senha)
                    {
                        _sessao.CriarSessaoUsuario(usuario);
                        return RedirectToAction("Index","Home");
                    }
                    TempData["MensagemErro"] = $"Usuário ou senha inválidos";                   
                }
                return View("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Falha ao logar. Erro: {erro.Message}";
                 return RedirectToAction("Index");
            }
        }
    }
}