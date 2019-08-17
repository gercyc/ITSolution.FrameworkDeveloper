namespace ITSolution.Framework.Ticket.Bancos
{
    public class BancoBradesco : AbstractBank
    {

        public override short CodigoBanco
        {
            get
            {
                return 237;
            }
        }

        public BancoBradesco()
        {
            this.Carteira = "02";
            //numero documento
            this.NumeroDocumento= "01000015235";
            //nosso numero 
            this.NossoNumero = "01000000001";
        }
    }
}
