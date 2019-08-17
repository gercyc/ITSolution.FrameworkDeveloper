using BoletoNet;
using System;

namespace ITSolution.Framework.Ticket.Bancos
{
    public class BancoItau : AbstractBank
    {
        public override short CodigoBanco
        {
            get
            {
                return 341;
            }
        }

        public BancoItau()
        {
            this.Carteira = "198";
            this.EspecieDocumento =  new EspecieDocumento(341, "1");

            //TEST isso nao pode ficar aqui
            //nosso numero 
            this.NossoNumero = "00000865425";
            //numero documento 
            this.NumeroDocumento = "000032548";
        }


    }
}
