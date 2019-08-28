using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using ITSolution.Framework.Entities;
using ITSolution.Framework.Util;
using Newtonsoft.Json;

namespace ITSolution.Framework.Web.JSON
{
    [DataContract]
    public class LayoutReceitaWS
    {

        [JsonProperty("atividade_principal")]
        public List<ModelLayout> AtividadesPrincipais { get;  set; }

        [JsonProperty("atividades_secundarias")]
        public List<ModelLayout> AtividadesSecundarias { get; set; }

        [JsonProperty("data_situacao")]
        public string DataSituacao { get;  set; }

        [JsonProperty("nome")]
        public string Nome { get;  set; }

        [JsonProperty("uf")]
        public string Uf { get;  set; }

        [JsonProperty("telefone")]
        public string Telefone { get;  set; }

        [JsonProperty("qsa")]
        public List<QsaModel> Qsa { get;  set; }

        [JsonProperty("situacao")]
        public string Situacao { get;  set; }

        [JsonProperty("bairro")]
        public string Bairro { get;  set; }

        [JsonProperty("logradouro")]
        public string Logradouro { get;  set; }

        [JsonProperty("numero")]
        public string Numero { get;  set; }

        [JsonProperty("cep")]
        private string cep;

        public string Cep
        {
            get
            {
                if (string.IsNullOrWhiteSpace(cep))
                {
                    return "";
                }
                return cep.Replace(".", "");
            }
            set { this.cep = value; }
        }

        [JsonProperty("municipio")]
        public string Municipio { get;  set; }

        [JsonProperty("abertura")]
        public string Abertura { get;  set; }

        [JsonProperty("natureza_juridica")]
        public string NaturezaJuridica { get;  set; }

        [JsonProperty("fantasia")]
        public string Fantasia { get;  set; }

        [JsonProperty("cnpj")]
        public string Cnpj { get;  set; }

        [JsonProperty("ultima_atualizacao")]
        public Nullable<DateTime> UltimaAtualizacao { get;  set; }

        [JsonProperty("status")]
        public string Status { get;  set; }

        [JsonProperty("tipo")]
        public string Tipo { get;  set; }

        [JsonProperty("complemento")]
        public string Complemento { get;  set; }

        [JsonProperty("email")]
        public string Email { get;  set; }

        [JsonProperty("efr")]
        public string Efr { get;  set; }

        [JsonProperty("motivo_situacao")]
        public string MotivoSituacao { get;  set; }

        [JsonProperty("situacao_especial")]
        public string SituacaoEspecial { get;  set; }

        [JsonProperty("data_situacao_especial")]
        public string DataSituacaoEspecial { get;  set; }

        [JsonProperty("capital_social")]
        public decimal CapitalSocial { get;  set; }

        //ainda nao sei o q vem aqui dentro 
        //caso uma resposta gere essa prop eu vejo o q eu faço com ela
        [JsonProperty("extra")]
        public Extra Extra { get;  set; }


        private const string receitaWsUrl = @"https://www.receitaws.com.br/v1/cnpj/";

        public LayoutReceitaWS()
        {

            this.AtividadesPrincipais = new List<ModelLayout>();
            this.AtividadesSecundarias = new List<ModelLayout>();

        }
        /// <summary>
        /// Retorna todos os dados da empresa relacionados ao CNPJ informado
        /// </summary>
        /// <param name="cnpj"></param>CNPJ 
        /// <returns></returns>LayoutReceitaWS
        public static T GetDataFromCNPJTyped<T>(string cnpj) where T : class
        {
            cnpj = cnpj.FixString();
            String json = JSONHelper.GetJSONString(receitaWsUrl + cnpj);
            return JsonConvert.DeserializeObject<T>(json);
        }
        /// <summary>
        /// Retorna todos os dados da empresa relacionados ao CNPJ informado
        /// </summary>
        /// <param name="cnpj"></param>CNPJ 
        /// <returns></returns>LayoutReceitaWS
        public static LayoutReceitaWS GetDataFromCNPJ(string cnpj)
        {
            
            try
            {
                cnpj = cnpj.FixString();

                string json = JSONHelper.GetJSONString(receitaWsUrl + cnpj);

                LayoutReceitaWS r = JsonConvert.DeserializeObject<LayoutReceitaWS>(json);

                if (r.Status == "ERROR")
                    return null;

                return r;
            }
            catch (Exception ex)
            {
                Console.WriteLine("WS not responding " + ex.Message);
                LoggerUtilIts.ShowExceptionMessage(ex);
                LoggerUtilIts.GenerateLogs(ex);
                return null;
            }
            }/// <summary>
        /// Retorna todos os dados da empresa relacionados ao CNPJ informado
        /// </summary>
        /// <param name="cnpj"></param>CNPJ 
        /// <returns></returns>LayoutReceitaWS
        public static async Task<LayoutReceitaWS> GetDataFromCNPJAsync(string cnpj)
        {
            return await Task.Run(() => GetDataFromCNPJ(cnpj));
        }
       
        /// <summary>
        /// Espelhas o resultado do layout em um cliente
        /// </summary>
        /// <param name="e"></param>Cliente
        /// <returns></returns>AbstractClient
        public AbstractClient ToClient(AbstractClient e)
        {     

            if (!string.IsNullOrEmpty(this.Nome))
                    e.RazaoSocial = this.Nome;

            if (!string.IsNullOrEmpty(this.Uf))
                e.Uf = this.Uf;

            if (!string.IsNullOrEmpty(this.Telefone))
            {
                var tel = this.Telefone.Split('/');
                if (tel.Length > 0)
                {
                    e.Telefone  = tel[0].Trim();

                    if (tel.Length > 1)
                        e.TelefoneComercial = tel[1].Trim();

                }
            }

            if (!string.IsNullOrEmpty(this.Situacao))
                e.SituacaoJuridica = this.Situacao;

            if (!string.IsNullOrEmpty(this.Bairro))
                e.Bairro = this.Bairro;

            if (!string.IsNullOrEmpty(this.Logradouro))
                e.NomeEndereco = this.Logradouro;

            if (!string.IsNullOrEmpty(this.Numero))
                e.NumeroEndereco = this.Numero;

            if (!string.IsNullOrEmpty(this.Cep))
                e.Cep = this.Cep;

            if (!string.IsNullOrEmpty(this.Municipio))
                e.Cidade = this.Municipio;

            if (!string.IsNullOrEmpty(this.Abertura))
                e.Abertura = this.Abertura;

            if (!string.IsNullOrEmpty(this.NaturezaJuridica))
                e.NaturezaJuridica = this.NaturezaJuridica;

            if (!string.IsNullOrEmpty(this.Fantasia))
                e.NomeFantasia = this.Fantasia;

            //essa sera a entrada
            //c.CpfCnpj = this.Cnpj;

            
            if(this.UltimaAtualizacao.HasValue)
                e.UltimaAtualizacao = this.UltimaAtualizacao;

            if (!string.IsNullOrEmpty(this.Status))
                e.StatusCliente = this.Status;

            if (!string.IsNullOrEmpty(this.Tipo))
                e.Tipo = this.Tipo;

            if (!string.IsNullOrEmpty(this.Complemento))
                e.Complemento = this.Complemento;

            if (!string.IsNullOrEmpty(this.Email))
                e.Email = this.Email;

            if (!string.IsNullOrEmpty(this.Efr))
                e.Efr = this.Efr;

            if (!string.IsNullOrEmpty(this.MotivoSituacao))
                e.MotivoSituacao = this.MotivoSituacao;

            if (!string.IsNullOrEmpty(this.SituacaoEspecial))
                e.SituacaoEspecial = this.SituacaoEspecial;

            if (!string.IsNullOrEmpty(this.DataSituacaoEspecial))
                e.DataSituacaoEspecial = this.DataSituacaoEspecial;

            if (this.CapitalSocial != 0)
                e.CapitalSocial = this.CapitalSocial;


            return e;
        }

        /// <summary>
        /// Espelhas o resultado do layout em uma empresa
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public AbstractCompany ToCompany(AbstractCompany e)
        {


            if (!string.IsNullOrEmpty(this.Nome))
                e.RazaoSocial = this.Nome;

            if (!string.IsNullOrEmpty(this.Uf))
                e.Uf = this.Uf;

            if (!string.IsNullOrEmpty(this.Telefone))
            {
                var tel = this.Telefone.Split('/');
                if (tel.Length > 0)
                {
                    e.Telefone = tel[0].Trim();

                    if (tel.Length > 1)
                        e.Fax = tel[1].Trim();

                }
            }


            if (!string.IsNullOrEmpty(this.Situacao))
                e.Situacao = this.Situacao;

            if (!string.IsNullOrEmpty(this.Bairro))
                e.Bairro = this.Bairro;

            if (!string.IsNullOrEmpty(this.Logradouro))
                e.NomeEndereco = this.Logradouro;

            if (!string.IsNullOrEmpty(this.Numero))
                e.NumeroEndereco = this.Numero;

            if (!string.IsNullOrEmpty(this.Cep))
                e.Cep = this.Cep;

            if (!string.IsNullOrEmpty(this.Municipio))
                e.Cidade = this.Municipio;

            if (!string.IsNullOrEmpty(this.Abertura))
                e.Abertura = this.Abertura;

            if (!string.IsNullOrEmpty(this.NaturezaJuridica))
                e.NaturezaJuridica = this.NaturezaJuridica;

            if (!string.IsNullOrEmpty(this.Fantasia))
                e.NomeFantasia = this.Fantasia;

            //essa sera a entrada
            //c.CpfCnpj = this.Cnpj;
            e.UltimaAtualizacao = this.UltimaAtualizacao;

            if (!string.IsNullOrEmpty(this.Status))
                e.Status = this.Status;

            if (!string.IsNullOrEmpty(this.Tipo))
                e.Tipo = this.Tipo;

            if (!string.IsNullOrEmpty(this.Complemento))
                e.Complemento = this.Complemento;

            if (!string.IsNullOrEmpty(this.Email))
                e.Email = this.Email;

            if (!string.IsNullOrEmpty(this.Efr))
                e.Efr = this.Efr;

            if (!string.IsNullOrEmpty(this.MotivoSituacao))
                e.MotivoSituacao = this.MotivoSituacao;

            if (!string.IsNullOrEmpty(this.SituacaoEspecial))
                e.SituacaoEspecial = this.SituacaoEspecial;

            if (!string.IsNullOrEmpty(this.DataSituacaoEspecial))
                e.DataSituacaoEspecial = this.DataSituacaoEspecial;

            if (this.CapitalSocial != 0)
                e.CapitalSocial = this.CapitalSocial;

            return e;
        }

    }
}