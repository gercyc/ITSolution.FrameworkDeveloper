using System;
using System.Linq;
using ITSolution.Framework.Entities;
using ITSolution.Framework.Enumeradores;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;

namespace ITSolution.Framework.Dao.Contexto
{
    public class ParametroManager
    {
      


        /// <summary>
        /// Recupera o parametro pelo código
        /// </summary>
        /// <param name="codParametro"></param>
        /// <returns></returns>
        public static bool GetStatusParamByCodigo(string codParametro)
        {
            try
            {
                using (var ctx = new ITSolutionContext())
                {
                    var param = ctx.ParametroDao.Where(p => p.CodigoParametro == codParametro).First();

                    return param != null ? param.StatusParametro : false;
                }

            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// Recupera o valor parametro pelo código
        /// </summary>
        /// <param name="typeparam"></param>
        /// <returns></returns>
        public static Parametro FindParamByTypeParametro(TypeParametro typeparam)
        {
            try
            {
                using (var ctx = new ITSolutionContext())
                {
                    var param = ctx.ParametroDao.Where(p => p.CodigoParametro == typeparam.ToString()).First();
                    return param;
                }
            }
            catch
            {
                return new Parametro("Desconhecido", "0");
            }
        }


        /// <summary>
        /// Recupera o valor parametro pelo código
        /// </summary>
        /// <param name="codParametro"></param>
        /// <returns></returns>
        public static string GetValorParamByCodigo(string codParametro)
        {
            try
            {
                using (var ctx = new ITSolutionContext())
                {
                    var param = ctx.ParametroDao.Where(p => p.CodigoParametro == codParametro).First();

                    return param != null ? param.ValorParametro : String.Empty;
                }

            }
            catch
            {
                return String.Empty;
            }
        }

    }
}
