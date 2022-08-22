using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvC.Controllers
{
    public class PaginasController : Controller
    {
        public ActionResult Cadastro()
        {
            ViewBag.Paginas = new Pagina().Lista();

            return View();
        }

        public ActionResult NovoCadastro()
        {
            return View();
        }

        [HttpPost]
        public void Criar()
        {
            DateTime data;
            DateTime.TryParse(Request["data"], out data);
            var pagina = new Pagina();

            pagina.Nome = Request["nome"];
            pagina.Data = data;
            pagina.Conteudo = Request["conteudos"];
            pagina.Save();

            Response.Redirect("/Paginas");
        }
        public void Excluir(int id)
        {
            Pagina.Excluir(id);
            Response.Redirect("/Paginas");
        }


        public ActionResult Alterar(int id)
        {
            var pagina = Pagina.BuscarPorId(id);
            ViewBag.Pagina = pagina;
            return View();
        }

        [HttpPost]
        public void Alterando(int id)
        {
            try 
            {
                var pagina = Pagina.BuscarPorId(id);

                DateTime data;
                DateTime.TryParse(Request["data"], out data);

                pagina.Nome = Request["nome"];
                pagina.Data = data;
                pagina.Conteudo = Request["conteudos"];
                pagina.Save();

                TempData["sucesso"] = "Pagina Alterada com Sucesso";
            }
            catch
            {
                TempData["erro"] = "Pagina não pode alterada";
            }

            Response.Redirect("/Paginas");
        }
    }
}