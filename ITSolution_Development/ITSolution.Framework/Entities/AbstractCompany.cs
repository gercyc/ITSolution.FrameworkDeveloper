using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITSolution.Framework.Entities
{
    [Serializable]
    public abstract class AbstractCompany
    {
        #region Campos Mapeados pelo JSON

        [Required]
        [StringLength(200)]
        [Display(Name = "Razão Social")]
        [JsonProperty("nome")]//referencia pro JSON
        public string RazaoSocial { get; set; }

        [StringLength(200)]
        [Display(Name = "Nome Fantansia")]
        [JsonProperty("fantasia")]
        public string NomeFantasia { get; set; }

        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "CNPJ deve conter entre 11 e 14 digítos")]
        [StringLength(18)]
        [Index("Cnpj", 1, IsUnique = true)]//Restrição UNIQUE
        [JsonProperty("cnpj")]
        public string Cnpj { get; set; }

        [StringLength(100)]
        [Display(Name = "E-mail da empresa")]
        [JsonProperty("email")]
        public string Email { get; set; }

        [StringLength(20)]
        [Display(Name = "Telefone Principal")]
        [JsonProperty("telefone")]
        public string Telefone { get; set; }

        [StringLength(45)]
        [JsonProperty("data_situacao")]
        public string DataSituacao { get; set; }

        [StringLength(45)]
        [JsonProperty("situacao")]
        public string Situacao { get; set; }

        [StringLength(45)]
        [JsonProperty("abertura")]
        public string Abertura { get; set; }

        [StringLength(100)]
        [JsonProperty("natureza_juridica")]
        public string NaturezaJuridica { get; set; }

        [JsonProperty("ultima_atualizacao")]
        public Nullable<DateTime> UltimaAtualizacao { get; set; }

        [StringLength(45)]
        [JsonProperty("status")]
        public string Status { get; set; }

        [StringLength(45)]
        [JsonProperty("tipo")]
        public string Tipo { get; set; }

        [StringLength(45)]
        [JsonProperty("efr")]
        public string Efr { get; set; }

        [StringLength(45)]
        [JsonProperty("motivo_situacao")]
        public string MotivoSituacao { get; set; }

        [StringLength(45)]
        [JsonProperty("situacao_especial")]
        public string SituacaoEspecial { get; set; }

        [StringLength(45)]
        [JsonProperty("data_situacao_especial")]
        public string DataSituacaoEspecial { get; set; }

        [JsonProperty("capital_social")]
        public Nullable<decimal> CapitalSocial { get; set; }

        [Display(Name = "Nome Endereço")]
        [StringLength(200)]
        [JsonProperty("logradouro")]
        public string NomeEndereco { get; set; }

        [JsonProperty("numero")]
        //Marcação caso o endereço não tenha número = S/N
        [Display(Name = "Número do endereço")]
        [StringLength(200)]
        public string NumeroEndereco { get; set; }

        [JsonProperty("bairro")]
        [Display(Name = "Bairro")]
        [StringLength(200)]
        public string Bairro { get; set; }

        [JsonProperty("complemento")]
        [StringLength(100)]
        public string Complemento { get; set; }

        [JsonProperty("cep")]
        [Display(Name = "CEP")]
        [StringLength(9, ErrorMessage = "Cep deve conter 8 ou nove digítos\nEx: 00000-000\n00000000")]
        public string Cep { get; set; }

        [JsonProperty("uf")]
        [Display(Name = "Estado")]
        [StringLength(100)]
        public string Uf { get; set; }

        [JsonProperty("municipio")]
        [StringLength(100)]
        public string Cidade { get; set; }

        [StringLength(50)]
        public string Pais { get; set; }

        [Display(Name = "Tipo de endereço")]
        [StringLength(50)]
        public string TipoEndereco { get; set; }

        #endregion

        [StringLength(20)]
        [Display(Name = "Fax")]
        public string Fax { get; set; }

        [Display(Name = "Data Registro")]
        public Nullable<DateTime> DtRegtroJuntaCom { get; set; }

        [Display(Name = "Data do Cadastro")]
        public Nullable<DateTime> DtCadastro { get; set; }

        [StringLength(25)]
        [Display(Name = "Inscrição Estadual")]
        public string InscricaoEstadual { get; set; }

        [StringLength(25)]
        [Display(Name = "Inscrição Municipal")]
        public string InscricaoMunicipal { get; set; }

        public byte[] Logo { get; set; }

        public AbstractCompany()
        {

        }

        public AbstractCompany(string razaoSocial, string nomeFantasia, string cnpj,
            DateTime dtReg, DateTime dtCadastro)
        {
            this.RazaoSocial = razaoSocial;
            this.NomeFantasia = nomeFantasia;
            this.Cnpj = cnpj;
            this.DtRegtroJuntaCom = dtReg;
            this.DtCadastro = dtCadastro;
        }

        /// <summary>
        /// Seta os dados do endereço com um endereço informado
        /// </summary>
        /// <param name="endereco"></param>
        public void SetEndereco(Endereco endereco)
        {
            if (endereco != null)
            {
                this.NomeEndereco = endereco.NomeEndereco;
                this.NumeroEndereco = endereco.NumeroEndereco;
                this.TipoEndereco = endereco.TipoEndereco;
                this.Bairro = endereco.Bairro;
                this.Complemento = endereco.Complemento;
                this.Cidade = endereco.Cidade;
                this.Uf = endereco.Uf;
                this.Cep = endereco.Cep;
            }
        }

        public override string ToString()
        {
            return RazaoSocial;
        }

    }
}
