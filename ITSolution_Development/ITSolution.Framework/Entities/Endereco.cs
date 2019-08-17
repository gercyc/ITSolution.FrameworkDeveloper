
using ITSolution.Framework.Util;
/**
* Copyright (c) 2013, Filipe Rezende Campos. Todos os direitos reservados. ITSolution
* SOFTWARE/CONFIDENCIAL. O Uso está sujeito aos termos.
*
* 
*
*/
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace ITSolution.Framework.Entities
{
    /// <summary>
    /// Classe de endereço
    ///  @author Filipe
    /// Usada como Embeddable
    /// Um classe Embeddable é usada para facilitar a manutenção e organização do código
    /// Essa estratégia implica em uma tabela com vários atributos
    /// A classe que utilizar outra classe como Embeddable poderá utilizar seus atributos todosos atributos 
    /// User a propriedade virtual na classe alvo para utilizar a mesma
    /// </summary>
    public class Endereco
    {

        //[Required]
        [Column("NomeEndereco")]
        [Display(Name = "Nome Endereço")]
        [StringLength(200, MinimumLength = 0)]
        public string NomeEndereco { get; set; }


        //Marcação caso o endereço não tenha número = S/N
        //[Required]
        [Column("NumeroEndereco")]
        [Display(Name = "Número do endereço")]
        [StringLength(20, MinimumLength = 0)]
        public string NumeroEndereco { get; set; }

        //[Required]
        [Column("Bairro")]
        [StringLength(200, MinimumLength = 0)]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        //[Required]
        [Column("Complemento")]
        [StringLength(100, MinimumLength = 0)]
        public string Complemento { get; set; }

        //[Required]
        [Display(Name = "Cep")]
        [Column("Cep")]
        [StringLength(10, MinimumLength = 0,
            ErrorMessage = "Cep deve conter 8 ou nove digítos\nEx: 00000-000\n00000000")]
        public string Cep { get; set; }

        //[Required]
        [Column("Uf")]
        [StringLength(10, MinimumLength = 0)]
        [Display(Name = "Estado")]
        public string Uf { get; set; }

        //[Required]
        [StringLength(100, MinimumLength = 0)]
        [Column("Cidade")]
        public string Cidade { get; set; }

        //[Required]
        [Display(Name = "Tipo de endereço")]
        [StringLength(50, MinimumLength = 0)]
        [Column("TipoEndereco")]
        public string TipoEndereco { get; set; }

        //[Required]
        [StringLength(50, MinimumLength = 0)]
        [Column("Pais")]
        public string Pais { get; set; }

        /// <summary>
        ///Construtor padrão sem args
        /// Classe utilizada como embutida deve obrigatoriamente ter um construtor padrão sem args
        /// </summary>
        public Endereco() { }

        public Endereco(string endereco, string numeroEndereco, string bairro, string complemento)
        {
            this.NomeEndereco = endereco;
            this.NumeroEndereco = numeroEndereco;
            this.Bairro = bairro;
            this.Complemento = complemento;
        }

        public Endereco(string endereco, string numeroEndereco, string bairro,
            string complemento, string cep, string uf, string cidade, string tipoEndereco)
        {
            this.NomeEndereco = endereco;
            this.NumeroEndereco = numeroEndereco;
            this.Bairro = bairro;
            this.Complemento = complemento;
            this.Cep = string.IsNullOrWhiteSpace(cep) ? null : StringUtilIts.FixString(cep);
            this.Uf = uf;
            this.Cidade = cidade;
            this.TipoEndereco = tipoEndereco;
        }

        public Endereco Clone()
        {
            return (Endereco)this.MemberwiseClone();
        }

        /// <summary>
        /// Atualiza os dados de endereço com um endereço informado
        /// </summary>
        /// <param name="endereco"></param>
        public void Update(Endereco endereco)
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
        //Nao contem a cidade nem a UF
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.NomeEndereco);

            if (!string.IsNullOrEmpty(this.NumeroEndereco))
            {
                sb.Append(", ");
                sb.Append(this.NumeroEndereco);
            }

            if (!string.IsNullOrEmpty(this.Bairro))
            {
                sb.Append(", ");
                sb.Append(this.Bairro);
            }
            if (!string.IsNullOrEmpty(this.Complemento))
            {
                sb.Append(", ");
                sb.Append(this.Complemento);
            }

            if (!string.IsNullOrEmpty(this.Cidade))
            {
                sb.Append(", ");
                sb.Append(this.Cidade);
            }

            if (!string.IsNullOrEmpty(this.Uf))
            {
                sb.Append(" - ");
                sb.Append(this.Uf);
            }
            return sb.ToString();
        }
    }

}

