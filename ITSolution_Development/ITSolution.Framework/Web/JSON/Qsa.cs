using System.ComponentModel;
using Newtonsoft.Json;

namespace ITSolution.Framework.Web.JSON
{
    //[DataContract]
    public class QsaModel
    {
        [DisplayName("Função")]
        [JsonProperty("qual")]
        public string Qual { get; set; }

        [DisplayName("Nome")]
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [DisplayName("Representante Legal")]
        [JsonProperty("qual_rep_legal")]
        public string RepresentanteLegal { get; set; }

        [DisplayName("Nome Representante Legal ")]
        [JsonProperty("nome_rep_legal ")]
        public string NomeRepresentanteLegal { get; set; }

    }
}
