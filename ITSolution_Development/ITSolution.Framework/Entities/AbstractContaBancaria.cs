using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITSolution.Framework.Enumeradores;

namespace ITSolution.Framework.Entities
{
    public class AbstractContaBancaria
    {
        [Display(Name = "Código Conta")]
        [StringLength(200, MinimumLength = 1)]
        [Column(TypeName = "varchar")]
        public string CodigoContaBancaria { get; set; }


        [Required]
        [Display(Name = "Descrição Conta Bancária")]
        [StringLength(100, MinimumLength = 3)]
        //Restrição UNIQUE
        [Index(IsUnique = true)]
        [Column(TypeName = "varchar")]
        public String DescricaoContaBancaria { get; set; }

        [Required]
        [Display(Name = "Data Abertura")]
        [Column]
        public DateTime DataAbertura { get; set; }

        public decimal SaldoInicial { get; set; }

        [StringLength(20, MinimumLength = 0)]
        public string Agencia { get; set; }

        //Restrição UNIQUE
        [Index(IsUnique = true)]
        [StringLength(40, MinimumLength = 0)]
        public string NumeroConta { get; set; }

        [StringLength(100, MinimumLength = 0)]
        public string NomeBanco { get; set; }

        [Range(0,2,ErrorMessage ="Informe o tipo de conta a ser aberta")]
        public TypeContaBancaria TipoConta { get; set; }

        public AbstractContaBancaria()
        {
            this.DataAbertura = DateTime.Now;
            this.TipoConta = TypeContaBancaria.Corrente;
        }
        public AbstractContaBancaria(string codigoContaBancaria, string descricaoContaBancaria,
           decimal saldoInicial) : this()
        {
            this.CodigoContaBancaria = codigoContaBancaria;
            this.DescricaoContaBancaria = descricaoContaBancaria;
            this.SaldoInicial = saldoInicial;

        }

        public AbstractContaBancaria(string codigoContaBancaria, string descricaoContaBancaria,
            decimal saldoInicial, DateTime dataAbertura) : this()
        {
            this.CodigoContaBancaria = codigoContaBancaria;
            this.DescricaoContaBancaria = descricaoContaBancaria;
            this.SaldoInicial = saldoInicial;
            this.DataAbertura = dataAbertura;

        }

        public override string ToString()
        {
            return this.Agencia + " / " + NumeroConta;
        }
        public virtual void Update(AbstractContaBancaria conta)
        {
            this.Agencia = conta.Agencia;
            this.NomeBanco = conta.NomeBanco;
            this.CodigoContaBancaria = conta.CodigoContaBancaria;
            this.NumeroConta = conta.NumeroConta;
            this.DataAbertura = conta.DataAbertura;
            this.DescricaoContaBancaria = conta.DescricaoContaBancaria;
            this.SaldoInicial = conta.SaldoInicial;

        }

    }
}

