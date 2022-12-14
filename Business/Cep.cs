using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Business
{
    public class Cep
    {
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }


        public static Cep Busca(string Cep)
        {
            var cepObj = new Cep();
            var url = "https://apps.widenet.com.br/busca-cep/api/cep.json?code=" + Cep;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            string json = string.Empty;
            using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using(Stream stream = response.GetResponseStream()) 
            using(StreamReader streamReader = new StreamReader(stream)) 
            {
                json = streamReader.ReadToEnd();
            }

            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            JsonCepObject cepJson = json_serializer.Deserialize<JsonCepObject>(json);

            cepObj.CEP = cepJson.code;
            cepObj.Endereco = cepJson.address;
            cepObj.Bairro = cepJson.district;
            cepObj.Cidade = cepJson.city;
            cepObj.Estado = cepJson.state;

            return cepObj;
        }
    }
    public class JsonCepObject
    {
        public string code { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string address { get; set; }
    }
}
