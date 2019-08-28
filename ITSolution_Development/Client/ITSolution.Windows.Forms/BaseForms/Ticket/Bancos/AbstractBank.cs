using BoletoNet;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using System;
using System.Collections.Generic;

namespace ITSolution.Framework.Ticket.Bancos
{
    public abstract class AbstractBank
    {
        //Metodo que deve ser reescrito
        public abstract short CodigoBanco { get;  }
        public string NossoNumero { get; set; }
        public string NumeroDocumento { get; set; }
        public string Carteira { get; set; }
        public Instrucao Instrucao { get; private set; }
        public EspecieDocumento  EspecieDocumento { get; set; }
        //protected Boleto Boleto { get; set; }

        //protected BoletoBancario BoletoBancario { get; set; }

        public List<BoletoBancario> BoletosBancario { get; }
        public string RazaoSocial { get; set; }

        public AbstractBank()
        {
            this.Instrucao = new Instrucao(CodigoBanco);
            this.BoletosBancario = new List<BoletoBancario>();

        }

        public AbstractBank(string razaoSocial):this()
        {

        }

        public AbstractBank(string nossoNumero, 
            string numeroDocumento):this()
        {

        }
        /// <summary>
        /// Cria o boleto
        /// </summary>
        /// <param name="vencimento"></param>
        /// <param name="valorBoleto"></param>
        /// <param name="carteira"></param>
        /// <param name="nossoNumero"></param>
        /// <param name="cedente"></param>
        /// <returns>Boleto Bancário</returns>
        public BoletoBancario CreateBoleto(DateTime vencimento, decimal valorBoleto,
            string nossoNumero, string numeroDocumento, Cedente cedente, 
            Sacado sacado, string descricaoInstrucao)
        {
            var boletoBancario = new BoletoBancario();

            var boleto = new Boleto(vencimento, valorBoleto, this.Carteira, nossoNumero, cedente);
            boleto.NumeroDocumento = numeroDocumento;
            boleto.Sacado = sacado;

            // use os valores da classe
            if (!string.IsNullOrEmpty(this.NossoNumero))
                boleto.NossoNumero = this.NossoNumero;

            if (!string.IsNullOrEmpty(this.NumeroDocumento))
                boleto.NumeroDocumento = this.NumeroDocumento;

            this.Instrucao.Descricao = descricaoInstrucao;

            if (this.EspecieDocumento != null)
                boleto.EspecieDocumento = this.EspecieDocumento;
            //usa a instrução
            boleto.Instrucoes.Add(this.Instrucao);

            try
            {
                //use o codigo
                boletoBancario.CodigoBanco = this.CodigoBanco;
                boletoBancario.Boleto = boleto;
                boletoBancario.Boleto.Valida();


                return boletoBancario;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Boleto inválido " + ex.GetType());
                string msg = ex.Message;

                if (ex.InnerException != null)
                    msg = msg + "\n\n" + ex.InnerException.Message;

                XMessageIts.Erro(msg, "Boleto inválido, verifique os dados!");

                throw new Exception(msg, ex);
            }
        }

        /// <summary>
        /// Cria uma lista de boletos.
        /// </summary>
        /// <param name="vencimento"></param>
        /// <param name="valorBoleto"></param>
        /// <param name="carteira"></param>
        /// <param name="nossoNumero"></param>
        /// <param name="cedente"></param>
        public void CreateBoletos(int qtde, DateTime vencimento, decimal valorBoleto,
            string nossoNumero, string numeroDocumento, Cedente cedente, Sacado sacado, string descricaoInstrucao)
        {
            //var boletosBancarios = new List<BoletoBancario>();

            for (int i = 0; i < qtde; i++)
            {
                try
                {
                    var boletoBancario = CreateBoleto(vencimento, valorBoleto,
                        nossoNumero, numeroDocumento, cedente, sacado, descricaoInstrucao);

                    BoletosBancario.Add(boletoBancario);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Boletos inválido " + ex.GetType());
                    throw ex;
                }
            }
        }
    }
}
