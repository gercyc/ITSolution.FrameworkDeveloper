using DevExpress.XtraReports.UserDesigner;
using ITSolution.Framework.Arquivos;
using ITSolution.Framework.Common.BaseClasses.Reports;
using ITSolution.Framework.Dao.Contexto;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using ITSolution.Reports.Repositorio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ITSolution.Reports.DaoManager
{
    public class ReportDaoManager
    {
        private string _reportDir;

        public ReportDaoManager()
        {
            //path da instalação tera uma pasta chamada reports
            //this._dashboardDir = Path.Combine(Application.StartupPath, "Dashboards");
            this._reportDir = Path.GetTempPath().Replace("Temp", "Reports");

            if (!Directory.Exists(_reportDir))
                Directory.CreateDirectory(_reportDir);
        }

        /// <summary>
        /// Salva o relatorio que está aberto no banco
        /// </summary>
        /// <param name="reportDesigner"></param>
        /// <param name="report"></param>
        public ReportImage SaveReport(XRDesignMdiController reportDesigner, ReportImage report)
        {
            try
            {
                using (var ctx = new ReportContext())
                {
                    //objeto designer do relatório
                    var xtraReport = reportDesigner.ActiveDesignPanel.Report;

                    //nome setado no relatório
                    //report.DefaultName = xtraReport.Name;

                    //gera um nome aleatorio utilizando o nome setado no dashboard
                    string reportPath = generatePath(report, ctx);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        //salva o relatorio
                        reportDesigner.ActiveDesignPanel.SaveReport(reportPath);

                        //salva o layout em memoria
                        xtraReport.SaveLayout(ms);

                        xtraReport.SaveLayoutToXml(reportPath+".xml");

                        //salva o relatorio no disco em formato repx
                        xtraReport.SaveLayout(reportPath);

                        //obtem os bytes do relatorio
                        var bytes = ms.GetBuffer();

                        //gerar os bytes do arquivo
                        report.ReportImageData = bytes;

                        if (ctx.ReportImageDao.Save(report))
                            return report;
                    }
                }
            }
            catch (Exception ex)
            {
                XMessageIts.Advertencia("Houve um erro ao salvar relatório.\n\n"
                                        + ex.Message);

                LoggerUtilIts.GenerateLogs(ex);
            }

            return null;
        }

        /// <summary>
        /// Atualiza o relatorio que está sendo editado
        /// </summary>
        /// <param name="reportDesigner"></param>
        /// <param name="report"></param>
        public bool UpdateReport(XRDesignMdiController reportDesigner, ReportImage report)
        {
            try
            {

                using (var ctx = new ReportContext())
                {

                    //objeto designer do relatório
                    var xtraReport = reportDesigner.ActiveDesignPanel.Report;

                    //nome setado no relatório
                    //report.DefaultName = xtraReport.Name;

                    //gera um nome aleatorio utilizando o nome setado no relatório
                    string reportPath = generatePath(report, ctx);

                    using (MemoryStream ms = new MemoryStream())
                    {

                        //salva o layout em memoria
                        xtraReport.SaveLayout(ms);

                        //salva o relatorio no disco em formato repx (Fica serializado)
                        xtraReport.SaveLayout(reportPath);

                        ////salva pro xml
                        //xtraReport.SaveLayoutToXml(reportPath + ".xml");

                        //obtem os bytes do relatório
                        var bytes = ms.GetBuffer();

                        //AppConfigDefaultManager.Configuration.ChangeConnectionStringRuntime
                        //    ("ITS", AppConfigManager.Configuration.AppConfig.ConnectionString);

                        //passa o objeto para o contexto
                        var current = ctx.ReportImageDao.Find(report.IdReport);

                        //atualiza o relatorio
                        report.ReportImageData = bytes;

                        //passa pro objeto do contexto
                        current.Update(report);

                        report.Update(current);

                        //persiste a atualização no banco
                        return ctx.ReportImageDao.Update(current);

                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void ClearCache()
        {
            var reports = FileManagerIts.ToFiles(_reportDir, new string[] { "", ".repx" });
 
            foreach (var f in reports)
            {
                File.Delete(f);
            }
        }

        /// <summary>
        /// Localiza um relatorio no banco e carrega para um arquivo temporario
        /// Este cache irá ser salvo no banco
        /// </summary>
        /// <param name="reportID"></param>
        public string LoadToCache(ReportImage report)
        {
            try
            {
                using (var ctx = new ReportContext())
                {
                    //recupera o objeto do banco para alteração dos campos
                    report = ctx.ReportImageDao.Find(report.IdReport);

                    //caminho do relatorio
                    string reportPath = string.Format("{0}\\{1}", _reportDir, report.ReportName + ".repx");

                    //gera o arquivos atraves dos bytes salvo no banco
                    if (!File.Exists(reportPath))
                        FileManagerIts.WriteBytesToFile(reportPath, report.ReportImageData);

                    return reportPath;
                }
            }
            catch (Exception)
            {
                return null;
            }

        }

        /// <summary>
        /// Remove o relatório do banco
        /// </summary>
        /// <param name="report"></param>Relatório a ser removido
        /// <returns></returns>
        public bool RemoveReport(ReportImage report)
        {
            var ctx = new ReportContext();
            report = ctx.ReportImageDao.Find(report.IdReport); //recuperar o objeto para o contexto.

            if (report != null)
            {
                if (ctx.ReportImageDao.Delete(report))
                {
                    return true;
                }
                else
                {
                    XMessageIts.Erro("Não foi possível remover o relatório!");
                    return false;
                }
            }
            else
                return false;
        }

        public List<ReportImage> GetReportGrpVendas()
        {

            using (var ctx = new ReportContext())
            {
                try
                {

                    var grpVenda = ctx.ReportGroupDao
                        .Where(g => g.GroupDescription.Equals("Vendas")).First();

                    //todos os relatorios do grupo vendas
                    return ctx.ReportImages.Where(r => r.IdGrpReport == grpVenda.IdGrpReport).ToList();
                }
                catch (Exception ex)
                {
                    LoggerUtilIts.ShowExceptionLogs(ex);
                    return null;
                }
            }
        }

        public ReportImage FindReportByName(string rptName)
        {
            using (var ctx = new ReportContext())
            {
                try
                {
                   return  ctx.ReportImageDao.Where(r => r.ReportName == rptName).First();

                }
                catch (Exception ex)
                {
                    throw new Exception("Relatório \"" + rptName + "\"\n\n" + ex.Message);
                }
            }
        }

        private string generatePath(ReportImage report, ReportContext ctx)
        {
            //O nome do relatorio so pode ser setado pelo design
            var result = ctx.ReportImageDao.Last();
            result = result == null ? new ReportImage() : result;
            int num = result.IdReport + 1;

            //se nao tem um nome gere
            if (string.IsNullOrEmpty(report.ReportName))
            {
                report.ReportName = string.Format("{0}{1}", "Report", num);
            }

            var path = string.Format("{0}\\{1}{2}", _reportDir, report.ReportName, ".repx");

            return path;

        }

    }
}
