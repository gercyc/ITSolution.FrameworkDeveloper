using System;
using BoletoNet;

namespace ITSolution.Framework.Ticket.Bancos
{
    public class BancoCaixa : AbstractBank
    {
        

        public override short CodigoBanco
        {
            get
            {
                return 104;
            }
        }


        public BancoCaixa() 
        {
            //Instrucao_Caixa item1 = new Instrucao_Caixa(9, 5);
            //Instrucao_Caixa item2 = new Instrucao_Caixa(81, 10);
            this.Carteira = "SR";
        }

    }
}
