using System;

namespace ITSolution.Framework.Ticket.Bancos
{
    public class BancoBrasil : AbstractBank
    {

        public override short CodigoBanco
        {
            get
            {
                return 1;
            }
        }
        public BancoBrasil()
        {
            this.Carteira = "18";
            this.NossoNumero = "12345678901";
            this.NumeroDocumento = "12345678901";
        }
    }
}
