/**
* Copyright (c) 2013, Filipe Rezende Campos. Todos os direitos reservados. ITSolution
* SOFTWARE/CONFIDENCIAL. O Uso está sujeito aos termos.
*
* 
*
*/
using ITSolution.Framework.Enumeradores;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ITSolution.Framework.Entities
{
    [Serializable]
    public abstract class AbstractClient
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
        
        //Somente essa linha q diverge
        [Display(Name = "CPF/CNPJ")]
        [StringLength(18, MinimumLength =0, ErrorMessage = "CNPJ deve conter entre 11 e 14 digítos")]
        //[Index("Cnpj", 1, IsUnique = true)]//Restrição UNIQUE
        [Index("CpfCnpj", 0, IsUnique = false)]//Restrição UNIQUE cancelada
        [JsonProperty("cnpj")]
        public string CpfCnpj { get; set; }

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
        public string SituacaoJuridica { get; set; }

        [StringLength(45)]
        [JsonProperty("abertura")]
        public string Abertura { get; set; }

        [StringLength(100)]
        [JsonProperty("natureza_juridica")]
        public string NaturezaJuridica { get; set; }

        [JsonProperty("ultima_atualizacao")]
        public Nullable<DateTime> UltimaAtualizacao { get; set; }

        [StringLength(45)]        
        public string StatusCliente { get; set; }

        [StringLength(45)]
        [JsonProperty("tipo")]
        //remove ou alterar esse campo (Pra q server isso ?)
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
        [StringLength(9, ErrorMessage = "Cep deve conter 8 ou 9 digítos\nEx: 00000-000\n00000000")]
        public string Cep { get; set; }

        [JsonProperty("uf")]
        [Display(Name = "Estado")]
        [StringLength(100)]
        public string Uf { get; set; }

        [JsonProperty("municipio")]
        [StringLength(100)]
        public string Cidade { get; set; }

        [Display(Name = "Tipo de endereço")]
        [StringLength(50)]
        public string TipoEndereco { get; set; }

        #endregion

        [Display(Name = "Tipo de Cliente")]
        public TypeCliente TipoCliente { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime? DataNascimento { get; set; }

        [Display(Name = "Documento Identidade (RG)")]
        [StringLength(20)]
        public string RG { get; set; }

        [StringLength(25)]
        [Display(Name = "Celular ")]
        public string Celular { get; set; }

        [StringLength(25)]
        [Display(Name = "Telefone Comercial")]
        public string TelefoneComercial { get; set; }

        [Display(Name = "Data Registro")]
        public Nullable<DateTime> DtRegtroJuntaCom { get; set; }

        [Display(Name = "Data Cadastro")]
        public Nullable<DateTime> DtCadastro { get; set; }

        [StringLength(25)]
        [Display(Name = "Inscrição Estadual")]
        public string InscricaoEstadual { get; set; }

        [StringLength(25)]
        [Display(Name = "Inscrição Municipal")]
        public string InscricaoMunicipal { get; set; }

        [StringLength(50)]
        public string Pais { get; set; }

        //indica se a consulta foi realizada com sucesso ou nao
        //[NotMapped]
        //[JsonProperty("status")]
        //public string StatusJSON { get; set; }

        protected AbstractClient()
        {
            this.TipoCliente = TypeCliente.Fisica;
        }

        protected AbstractClient(string nome)
        {
            this.RazaoSocial = nome;
        }

        protected AbstractClient(string nome, string rg, string cpfCnpj, DateTime? dtDataNasc, TypeCliente tipoCliente,
             string telefone, string celular, string telComercial)
            : this()
        {
            this.RazaoSocial = nome;
            this.RG = rg;
            this.CpfCnpj = cpfCnpj;
            this.DataNascimento = dtDataNasc;
            this.TipoCliente = tipoCliente;
            this.Telefone = telefone;
            this.Celular = celular;
            this.TelefoneComercial = telComercial;
        }

   
        /// <summary>
        /// Atualiza os dados Cliente com o Cliente informado
        /// </summary>
        /// <param name="cliente"></param>
        public virtual void Update(AbstractClient cliente)
        {
            this.RazaoSocial = cliente.RazaoSocial;
            this.RG = cliente.RG;
            this.CpfCnpj = cliente.CpfCnpj;
            this.DataNascimento = cliente.DataNascimento;
            this.Email = cliente.Email;
            this.Telefone = cliente.Telefone;
            this.Celular = cliente.Celular;
            this.TelefoneComercial = cliente.TelefoneComercial;
            this.TipoCliente = cliente.TipoCliente;
        }

        public override string ToString()
        {
            return RazaoSocial;
        }

    }
}