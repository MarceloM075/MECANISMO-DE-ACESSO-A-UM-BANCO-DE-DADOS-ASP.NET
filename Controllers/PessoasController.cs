using Microsoft.AspNetCore.Mvc;
using PIM_VIII_SQLSERVER.Models;
using PIM_VIII_SQLSERVER.Daos;

namespace PIM_VIII_SQLSERVER.Controllers
{
    public class PessoasController : Controller
    {
        private readonly IPessoaDaos _pessoaRepositorio;
        public PessoasController(IPessoaDaos pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }

        //Menu "Lista de Pessoas":
        public IActionResult Index()
        {
            List<Pessoa> pessoas =_pessoaRepositorio.BuscarTodos();
            return View(pessoas);
        }


        //Página "Adicionar pessoa":
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Pessoa pessoa)
        {
            _pessoaRepositorio.Adicionar(pessoa);

            return RedirectToAction("Index");
        }


        //Filtro de busca:
        [HttpGet]
        public IActionResult Buscar(long cpf)
        {
            Pessoa pessoa = _pessoaRepositorio.BuscaPorCpf(cpf);
            return View(pessoa);
        }


        //Página de edição de dados:
        public IActionResult Editar(int id)
        {
            Pessoa pessoa = _pessoaRepositorio.ListarPorId(id);
            return View(pessoa);
        }

        [HttpPost]
        public IActionResult Editar(Pessoa pessoa)
        {
            _pessoaRepositorio.Editar(pessoa);

            return RedirectToAction("Index");
        }


        //Página de confirmação da exclusão dos dados do DB:
        public IActionResult Apagar(int id)
        {
            Pessoa pessoa = _pessoaRepositorio.ListarPorId(id);
            return View(pessoa);
        }

        public IActionResult ApagarDoDB(int id)
        {
            _pessoaRepositorio.Apagar(id);
            return RedirectToAction("index");
        }
    }
}
