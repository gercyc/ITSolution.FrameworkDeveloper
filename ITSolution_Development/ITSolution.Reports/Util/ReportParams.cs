using System;
using ITSolution.Framework.Common.BaseClasses.Reports;
using ITSolution.Framework.Dao.Contexto;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using ITSolution.Reports.DaoManager;

namespace ITSolution.Reports.Util
{
    /// <summary>
    /// Classe para fazer o controle de impressao dos relatorios com base nos parâmetros do sistema.
    /// </summary>
    public class ReportParams
    {
        public static void PrintReportWithParams(ReportImage rptImage)
        {
            try
            {
                /*
                Forma de geração do relatório. 

                1 = Gera e visualiza sem gravar no spool, 
                2 = Gera e visualiza gravando no spool, 
                3 = Gera somente em spool.
                */
                var param = ParametroManager.GetValorParamByCodigo("report_eng");

                if (param == "1")
                {
                    //new ReportSpoolDaoManager().PrintReportSpool(rptSelected.IdReport);
                    //usar esse aqui no azure pq nao tenho espaco pro spool por enquanto
                    //acho q faz mais sentido salvar a ref do relatorio gerado 
                    //do q os bytes do relatorio uma vez que o relatorio ja existe
                    //entao so a pk dele ja seria o suficiente
                    ReportUtil.PrintReport(rptImage);
                }
                else if (param == "2")
                {
                    new ReportSpoolDaoManager().PrintReportSpool(rptImage.IdReport);
                }
                else if (param == "3")
                {
                    new ReportSpoolDaoManager().PrintReportSpool(rptImage.IdReport, false);
                }

                else
                    LoggerUtilIts.GenerateLogs(new Exception("Paramentro report_eng não existe."));
                
                //nao acontece nada
                //nao podemos impedir a rotina de funcionar


            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionJustMessage(ex, "Falha ao gerar o relatório.");
            }


        }
    }
}
