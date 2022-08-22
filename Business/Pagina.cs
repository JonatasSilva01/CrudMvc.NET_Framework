using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Pagina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Conteudo { get; set; }
        public DateTime Data { get; set; }

        public List<Pagina> Lista()
        {
            var lista = new List<Pagina>();
            var paginaDb = new Database.Pagina();
            foreach(DataRow row in paginaDb.Lista().Rows)
            {
                var pagina = new Pagina();
                pagina.Id = Convert.ToInt32(row["Id"]);
                pagina.Nome = row["Nome"].ToString();
                pagina.Conteudo = row["Conteudos"].ToString();
                pagina.Data = Convert.ToDateTime(row["Data"]);

                lista.Add(pagina);
            }

            return lista;
        }

        public static Pagina BuscarPorId(int id)
        {
            var pagina = new Pagina();
            var paginaDb = new Database.Pagina();
            foreach (DataRow row in paginaDb.BucarPorId(id).Rows)
            {
                pagina.Id = Convert.ToInt32(row["Id"]);
                pagina.Nome = row["Nome"].ToString();
                pagina.Conteudo = row["Conteudos"].ToString();
                pagina.Data = Convert.ToDateTime(row["Data"]);
            }

            return pagina;
        }

        public void Save()
        {
            new Database.Pagina().Salvar(this.Id, this.Nome, this.Conteudo, this.Data);
        }
    }
}
