using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace WebMvC.Controllers
{
    public class CepController : Controller
    {
        public ActionResult CepIndex()
        {
            ViewBag.Cep = Business.Cep.Busca("04421130");
            return View();
        }

        public string Consulta(string cep)
        {
            var cepObj = Business.Cep.Busca(cep);
            return new JavaScriptSerializer().Serialize(cepObj);
        }

        public ActionResult About(int id)
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}