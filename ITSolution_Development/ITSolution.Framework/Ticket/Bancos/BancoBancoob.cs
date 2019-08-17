using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.Framework.Ticket.Bancos
{
    public class BancoBancoob : AbstractBank
    {

        public override short CodigoBanco
        {
            get
            {
                return 756;
            }
        }

        public BancoBancoob()
            :base("BANCO COOPERATIVO DO BRASIL S A BANCOOB")
        {
            this.Carteira = "02";

        }
    }
}
