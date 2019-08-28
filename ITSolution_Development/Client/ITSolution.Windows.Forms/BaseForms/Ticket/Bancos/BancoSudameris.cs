using System;

namespace ITSolution.Framework.Ticket.Bancos
{
    public class BancoSudameris : AbstractBank
    {
        public override short CodigoBanco
        {
            get
            {
                return 347;
            }
        }
        public BancoSudameris()
        {
            //Nosso número com 7 dígitos
            this.NossoNumero = "0003020";
            //numero doc
            this.NumeroDocumento = "1008073";
        }

    }
}
