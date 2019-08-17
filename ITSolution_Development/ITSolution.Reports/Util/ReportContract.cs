using DevExpress.XtraReports.UI;
using ITSolution.Framework.Arquivos;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using ITSolution.Reports.Forms.ListView;
using ITSolution.Reports.Forms.Param;
using ITSolution.Reports.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using ITSolution.Framework.Common.BaseClasses.Reports;
using ITSolution.Framework.Common.BaseClasses.Reports.Enumeradores;

namespace ITSolution.Reports.Util
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class ReportContract : IReportContract
    {
        public List<ReportImage> GetAllReports()
        {
            using (var ctx = new ReportContext())
            {
                ctx.Configuration.ProxyCreationEnabled = false;

                var result = ctx.ReportImages.Include("Grupo").ToList();
                return result;
            }
        }

        public XtraReport GetReport(int idReport)
        {
            using (var ctx = new ReportContext())
            {
                var current = ctx.ReportImageDao.Find(idReport);
                string reportDir = Path.GetTempPath().Replace("Temp", "Reports");
                string path = Path.Combine(reportDir, current.ReportName + ".repx");
                //var pathPrnx = Path.Combine(Application.StartupPath, "Reports", current.ReportName + ".prnx");

                //carregue a estrutura do relatório
                XtraReport xreport = new XtraReport();

                if (!File.Exists(path))
                {
                    FileManagerIts.WriteBytesToFile(path, current.ReportImageData);
                }
                xreport.LoadLayout(path);
                //var rpt = (ItsXtraReport)xreport;

                return xreport;
            }
        }

        public void PrintReport(int idreport)
        {
            ReportUtil.PrintReportAndGenerateSpool(idreport);
        }

        public void PrintReportCustomById(int idReport)
        {
            try
            {
                using (var ctx = new ReportContext())
                {
                    var imageReport = ctx.ReportImageDao.Find(idReport);
                    var path = FileManagerIts.DeskTopPath + "\\temp.repx";

                    //download do *.repx do banco
                    FileManagerIts.WriteBytesToFile(path, imageReport.ReportImageData);

                    //carregue a estrutura do relatório
                    XtraReport report = XtraReport.FromFile(path, true);

                    //tela personalizado de parametros
                    var parameters = new XFrmReportParams_DEV(report.Parameters);

                    //se o relatorio tem parametros....
                    if (report.Parameters.Count >= 1)
                    {
                        //cancele os parametros nativos
                        report.RequestParameters = false;

                        //chame a tela de parametros
                        parameters.ShowDialog();

                        //limpar os parametros atuais
                        report.Parameters.Clear();

                        //add os novos parametros
                        foreach (var p in parameters.NewParametros)
                        {
                            report.Parameters.Add(p);
                        }
                    }

                    //se a geração nao foi cancelada em 
                    if (parameters._isCanceled == false)
                    {
                        //criar o documento
                        ReportPrintTool reportPrintTool = new ReportPrintTool(report);
                        report.CreateDocument();

                        //exibe o relatorio
                        report.ShowPreview();

                        //Remova o relatorio temporario
                        FileManagerIts.DeleteFile(path);
                    }
                    else
                        XMessageIts.Mensagem("Relatório cancelado.");

                }
                //se não passar pelo if, a geração foi cancelada, então Task<bool> = false
            }
            catch (Exception ex)
            {
                LoggerUtilIts.ShowExceptionLogs(ex);
                throw ex;

            }
        }

        public void ShowReportList()
        {
            var lst = new XFrmReportList(TypeGroupUser.Administrador);
            lst.Show();
        }
    }
}
