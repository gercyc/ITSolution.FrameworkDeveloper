
using System;

namespace ITSolution.Framework.Ticket.Bancos
{
    public class BancoHSBC : AbstractBank
    {

        public override short CodigoBanco
        {
            get { return 399; }
        }
        public BancoHSBC()
        {
            this.Carteira = "CNR";
            this.NossoNumero = "0000321585";
            this.NumeroDocumento = "0000032548956"; 
        }
    }
}
