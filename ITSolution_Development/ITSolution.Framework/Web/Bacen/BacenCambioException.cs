
using System;

namespace ITSolution.Framework.Web.Bacen
{
    public class BacenCambioException : BacenException
    {
        public BacenCambioException(Exception ex, string message) : base(ex, message)
        {
            if (ex.GetType() == typeof(System.ServiceModel.FaultException))
                this.Error = "Servidor do bacen não respondeu ou o período de pesquisa não foi refinado.\n"
                    +"Tente refinar o período de pesquisa ou aguarde alguns instantes e tente novamente!";
        }

        public BacenCambioException(Exception ex)
            : base(ex, "Não foi possível recuperar a cotação!\n\n"
                        + "O acesso a base do banco central não respondeu ou não está disponível!")
        {
        }

    }
}
