using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Pagina
    {
        private string sqlConn()
        {
            return ConfigurationManager.AppSettings["sqlConnection"];
        }

        public DataTable Lista()
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from pagina";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public void Salvar(int id, string nome, string conteudo, DateTime data)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = $"INSERT INTO Pagina (Nome, Data, Conteudos) values('{nome}','" + data + $"','{conteudo}'); ";
                if(id != 0)
                {
                    queryString = $"update Pagina set nome='{nome}', data='"+ data +$"', conteudos='{conteudo}' where id ='{id}'; ";
                }
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Excluir(int id)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = $"DELETE FROM Pagina WHERE Id = {id}; ";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public DataTable BucarPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = $"select * from pagina where id={id}";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }
    }
}
