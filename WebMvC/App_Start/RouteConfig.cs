using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebMvC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "sobre_jonatas_parametro",
                "sobre/{id}/jonatas",
                new { controller = "Home", action = "about", id = 0 }
            );
            
            routes.MapRoute(
                "sobre",
                "sobre",
                new { controller = "Home", action = "about" }
            );
            
            routes.MapRoute(
                "contato",
                "contato",
                new { controller = "Home", action = "contact" }
            );

            routes.MapRoute(
                "paginas",
                "paginas",
                new { controller = "Paginas", action = "Cadastro" }
            );

            routes.MapRoute(
                "paginas_criar",
                "paginas/criar",
                new { controller = "Paginas", action = "Criar" }
            );

            routes.MapRoute(
                "paginas_alterar",
                "paginas/{id}/alterar",
                new { controller = "Paginas", action = "Alterar", id= 0 }
            );
            
            routes.MapRoute(
                "paginas_excluir",
                "paginas/{id}/excluir",
                new { controller = "Paginas", action = "Excluir", id= 0 }
            );

            routes.MapRoute(
                "paginas_alterando",
                "paginas/{id}/alterando",
                new { controller = "Paginas", action = "Alterando", id = 0 }
            );

            routes.MapRoute(
                "paginas_preview",
                "paginas/{id}/preview",
                new { controller = "Paginas", action = "Preview", id=0 }
            );

            routes.MapRoute(
                "paginas_novocadastro",
                "paginas/novocadastro",
                new { controller = "Paginas", action = "NovoCadastro" }
            );

            routes.MapRoute(
                 "consulta_cep",
                 "consulta_cep",
                 new { controller = "Cep", action = "CepIndex" }
             );

            routes.MapRoute(
                "api_consulta_cep",
                "api/consulta-cep/{cep}",
                new { controller = "Cep", action = "Consulta", cep = "" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
