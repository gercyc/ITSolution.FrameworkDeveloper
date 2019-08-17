using System;

namespace ITSolution.Framework.Ticket.Bancos
{
    public class BancoSafra : AbstractBank
    {

        public override short CodigoBanco
        {
            get { return 422; }
        }

        public BancoSafra()
        {
            this.NossoNumero = "02592082835";
            this.NumeroDocumento = "1008073";

        }
    }
}
