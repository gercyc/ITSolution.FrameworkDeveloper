using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ITSolution.Framework.Web.JSON
{
    public class ModelLayout
    {
        [StringLength(20)]
        [JsonProperty("code")]
        [DisplayName("Código da Atividade")]
        public string Codigo { get; set; }

        [JsonProperty("text")]
        [DisplayName("Descrição da Atividade")]
        [StringLength(300)]
        public string Descricao { get; set; }

        public ModelLayout()
        {
        }

        public ModelLayout(string descricao, string codigo)
        {
        }

        public void Update(ModelLayout m)
        {
            this.Codigo = m.Codigo;
            this.Descricao = m.Descricao;
        }
    }
}
