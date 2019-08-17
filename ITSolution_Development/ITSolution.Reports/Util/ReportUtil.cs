using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ITSolution.Framework.Arquivos;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using ITSolution.Reports.Repositorio;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraReports.UI;
using ITSolution.Framework.Beans.ProgressBar;
using ITSolution.Framework.Dao.Contexto;
using ITSolution.Reports.DaoManager;
using ITSolution.Reports.Forms.Param;
using DevExpress.DataAccess.Sql;
using ITSolution.Framework.Entities;
using DevExpress.DataAccess.ConnectionParameters;
using ITSolution.Framework.Common.BaseClasses.Reports;
using ITSolution.Framework.Common.BaseClasses.Reports.Enumeradores;

namespace ITSolution.Reports.Util
{
    public class ReportUtil
    {
        private static readonly string DashboardFilter = "IT Solution Dashboard | *.itsdsh";
        private static readonly string ReportFilter = "IT Solution Report | *.itsrpt";


        /// <summary>
        /// Gera o relatorio e gera o spool se o parametro foi setado.
        /// </summary>
        /// <param name="rptImage"></param>
        public static void PrintReportAndGenerateSpool(ReportImage rptImage)
        {
            try
            {
                /*
                Forma de geração do relatório. 

                1 = Gera e visualiza sem gravar no spool, 
                2 = Gera e visualiza gravando no spool, 
                3 = Gera somente em spool.
                */
                var param = ParametroManager.FindParamByTypeParametro(Framework.Enumeradores.TypeParametro.report_engine);

                if (param.ValorParametro == "2")
                    new ReportSpoolDaoManager().PrintReportSpool(rptImage.IdReport);
                else if (param.ValorParametro == "3")
                    new ReportSpoolDaoManager().PrintReportSpool(rptImage.IdReport, false);
                else
                    //usar esse pq no azure nao tenho espaco pro spool por enquanto
                    PrintReport(rptImage, false);
                //nao podemos impedir a rotina de funcionar
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionJustMessage(ex, "Falha ao gerar o relatório.");
            }


        }
        public static void PrintReportAndGenerateSpool(int IdrptImage)
        {
            try
            {
                /*
                Forma de geração do relatório. 

                1 = Gera e visualiza sem gravar no spool, 
                2 = Gera e visualiza gravando no spool, 
                3 = Gera somente em spool.
                */
                var param = ParametroManager.FindParamByTypeParametro(Framework.Enumeradores.TypeParametro.report_engine);

                if (param.ValorParametro == "2")
                    new ReportSpoolDaoManager().PrintReportSpool(IdrptImage);
                else if (param.ValorParametro == "3")
                    new ReportSpoolDaoManager().PrintReportSpool(IdrptImage, false);
                else
                    //usar esse pq no azure nao tenho espaco pro spool por enquanto
                    PrintReport(IdrptImage, false);
                //nao podemos impedir a rotina de funcionar
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionJustMessage(ex, "Falha ao gerar o relatório.");
            }


        }
        public static bool IsEditReport(AbstractReportImage report, TypeGroupUser group)
        {
            var idGrpReport = (TypeReport)report.IdGrpReport;

            //outros grupos
            if (idGrpReport != TypeReport.Sistema ||
                //grupo Sistema somente adminstrador
                idGrpReport == TypeReport.Sistema && ReportUtil.IsAdmin(group))
                return true;
            else
            {
                //senão, exibe mensagem informando da falta de permissao
                XMessageIts.Erro("Você não possue permissão para editar relatórios do sistema!");
                return false;
            }
        }

        /// <summary>
        /// Visualiza um relatório usando a interface XtraForm.
        /// </summary>
        /// <param name="report"></param>
        /// <param name="requestParameters"></param>
        /// <param name="visibleParameters"></param>
        public static void PrintReport(ReportImage report, bool requestParameters = true, bool visibleParameters = true)
        {
            printReport(report, requestParameters, visibleParameters, false);
        }
        public static void PrintReport(int report, bool requestParameters = true, bool visibleParameters = true)
        {
            printReport(report, requestParameters, visibleParameters, false);
        }

        /// <summary>
        /// Visualiza um relatório usando a inteface RibbonForm.
        /// </summary>
        /// <param name="report"></param>
        /// <param name="requestParameters"></param>
        /// <param name="visibleParameters"></param>
        public static void PrintReportRibbon(ReportImage report, bool requestParameters = true, bool visibleParameters = true)
        {
            printReport(report, requestParameters, visibleParameters, true);
        }

        /// <summary>
        /// Gera um relatório pelo ID
        /// </summary>
        /// <param name="id">ID do relatório</param>
        /// <param name="requestParameters"></param>
        /// <param name="visibleParameters"></param>
        /// <param name="ribbon"></param>
        /// <returns></returns>
        public static void PrintReportById(int id, bool requestParameters = true, bool visibleParameters = true, bool ribbon = false)
        {
            try
            {
                using (var ctx = new ReportContext())
                {
                    var current = ctx.ReportImageDao.Find(id);

                    printReport(current, requestParameters, visibleParameters, ribbon);

                }
            }
            catch (Exception ex)
            {
                XMessageIts.Advertencia("Relatório não encontrado !");
                LoggerUtilIts.GenerateLogs(ex, "Method: PrintReportById");

            }
        }

        /// <summary>
        /// Gera um relatório para o Spool de relatórios
        /// </summary>
        /// <param name="reportName"></param>
        /// <param name="requestParameters"></param>
        /// <param name="visibleParameters"></param>
        /// <param name="ribbon"></param>
        /// <returns></returns>
        public static void PrintReportByName(string reportName, bool requestParameters = true, bool visibleParameters = true,
            bool ribbon = false)
        {
            try
            {
                ReportImage report = new ReportDaoManager().FindReportByName(reportName);
                printReport(report, requestParameters, visibleParameters, ribbon);
            }
            catch (Exception ex)
            {
                XMessageIts.Erro(ex.Message + "", "Atenção - Contate o administrador !!!");
            }
        }

        /// <summary>
        /// Gera um relatório usando a tela de parametros personalizada.
        /// <br>
        /// O relatório sempre será escrito e removido do disco.
        /// </br>
        /// </summary>
        /// <param name="id">ID do relatório</param>
        /// <returns></returns>
        public static void PrintReportCustomById(int id)
        {
            try
            {
                using (var ctx = new ReportContext())
                {
                    var imageReport = ctx.ReportImageDao.Find(id);
                    var path = Application.StartupPath + "\\temp.repx";

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

        /// <summary>
        /// Visualiza um relatório.
        /// <br>
        /// O relatório sempre será escrito no disco.
        /// </br>
        /// O designer é montando manualmente.
        /// </summary>
        /// <param name="report"></param>
        public static void PrintReportOverwrite(ReportImage report)
        {
            try
            {
                using (var ctx = new ReportContext())
                {

                    var current = ctx.ReportImageDao.Find(report.IdReport);
                    string path = Path.Combine(Application.StartupPath, "Reports", current.ReportName + ".repx");

                    FileManagerIts.WriteBytesToFile(path, current.ReportImageData);

                    //carregue a estrutura do relatório
                    XtraReport xreport = XtraReport.FromFile(path, true);

                    //objeto para gerar a tela de parametros
                    ReportPrintTool reportPrintTool = new ReportPrintTool(xreport);

                    //chama a tela de parametros
                    xreport.CreateDocument();

                    //gera o relatorio
                    PrintPreviewFormEx preview = new PrintPreviewFormEx();
                    preview.PrintingSystem = xreport.PrintingSystem;
                    //exibe o relatorio
                    preview.ShowDialog();

                }

            }
            catch (Exception ex)
            {
                XMessageIts.Erro("Falha gerar relatório\n\n" + ex.Message, "Atenção!!!");
                LoggerUtilIts.GenerateLogs(ex);

            }
        }

        /// <summary>
        /// Cria um XtraReport a partir do nome do relatório salvo no banco.
        /// </summary>
        /// <param name="reportName"></param>
        /// <param name="showParams"></param>
        /// <returns></returns>
        public static XtraReport CreateReportByName(string reportName, bool showParams = true)
        {
            using (var ctx = new ReportContext())
            {
                try
                {
                    var current = ctx.ReportImageDao.First(r => r.ReportName == reportName);
                    string dir = Path.GetTempPath().Replace("Temp", "Reports");

                    FileManagerIts.CreateDirectory(dir);

                    string path = Path.Combine(dir, current.ReportName + ".repx");

                    //salva o report no disco
                    FileManagerIts.WriteBytesToFile(path, current.ReportImageData);

                    //carregue a estrutura do relatório
                    XtraReport report = XtraReport.FromFile(path, true);


                    if (showParams == false)
                    {
                        //nao exibe
                        foreach (var p in report.Parameters)
                        {
                            p.Visible = false;
                        }
                    }

                    //objeto para chamar a tela de parametros
                    ReportPrintTool reportPrintTool = new ReportPrintTool(report);

                    ReportUtil.SetParamDataSource(report.DataSource as SqlDataSource, AppConfigManager.Configuration.AppConfig);
                    //criar o documento
                    report.CreateDocument();

                    //libera memoria da ferramenta
                    reportPrintTool.Dispose();

                    //retorna o relatorio
                    return report;
                }
                catch (Exception ex)
                {
                    XMessageIts.ExceptionMessageDetails(ex, "Impossível gerar relatório !", "Falha ao gerar relatório");
                    LoggerUtilIts.GenerateLogs(ex);
                    return null;
                }
            }
        }

        /// <summary>
        /// Exibe o relatório informado.
        /// </summary>
        /// <param name="xreport"></param>
        /// <param name="ribbon"></param>
        public static void ShowPreviewReport(XtraReport xreport, bool ribbon = false)
        {
            //call progressbar
            XFrmWait.ShowSplashScreen("Gerando relatório...");

            //chama a tela de parametros
            xreport.CreateDocument();

            //close a progressbar
            XFrmWait.CloseSplashScreen();

            if (ribbon)
                xreport.ShowRibbonPreview();

            xreport.ShowPreview();

        }

        public static bool IsGerente(TypeGroupUser group)
        {
            return group == TypeGroupUser.Gerente;
        }

        public static bool IsAdmin(TypeGroupUser group)
        {
            return group == TypeGroupUser.Administrador;
        }

        //Metodo refeito para melhoria na performace na geração do relatorio
        //Chamado internamanete
        private static void printReport(ReportImage report, bool requestParameters = true, 
            bool visibleParameters = true, bool ribbon = false)
        {
            try
            {
                using (var ctx = new ReportContext())
                {
                    var current = ctx.ReportImageDao.Find(report.IdReport);
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
                    
                    var ds = xreport.DataSource as SqlDataSource;
                    var appConf = AppConfigManager.Configuration.AppConfig;

                    if (ds == null)
                        ds = new SqlDataSource(appConf.ServerName);

                    SetParamDataSource(ds, appConf);

                    ds.Connection.CreateConnectionString();

                    ds.RebuildResultSchema();

                    //objeto para gerar a tela de parametros
                    ReportPrintTool reportPrintTool = new ReportPrintTool(xreport);

                    //permissao para solicitar os parametros
                    xreport.RequestParameters = requestParameters;


                    //permissao para exibir os parametros
                    if (visibleParameters == false)
                    {
                        foreach (var p in xreport.Parameters)
                        {
                            p.Visible = false;
                        }
                    }

                    //chama a tela de parametros
                    xreport.CreateDocument();

                    //libera memoria da ferramenta
                    reportPrintTool.Dispose();

                    if (ribbon)
                        //chama o ribbon para exibir o relatório
                        xreport.ShowRibbonPreview();
                    else
                        xreport.ShowPreview();

                    ////carregando o relatório manualmente
                    ////salva o documento gerado em prnx
                    //xreport.PrintingSystem.SaveDocument(pathPrnx);

                    //// Create a PrintingSystem instance.
                    //PrintingSystem ps = new PrintingSystem();

                    //// Load the document from a file.
                    //ps.LoadDocument(pathPrnx);

                    ////ribbon form para visualizar o relatório
                    //PrintPreviewRibbonFormEx preview = new PrintPreviewRibbonFormEx();
                    //preview.PrintingSystem = ps;
                    ////xtraform para visualizar o relatório
                    //PrintPreviewFormEx prev = new PrintPreviewFormEx();
                    //prev.PrintingSystem = ps;
                    ////exibe o relatorio
                    //preview.ShowDialog(); 
                }
            }
            catch (Exception ex)
            {
                XMessageIts.Erro("Falha gerar relatório\n\n" + ex.Message, "Atenção!!!");
                LoggerUtilIts.GenerateLogs(ex);

            }
        }
        private static void printReport(int idreport, bool requestParameters = true,
    bool visibleParameters = true, bool ribbon = false)
        {
            try
            {
                using (var ctx = new ReportContext())
                {
                    var current = ctx.ReportImageDao.Find(idreport);
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

                    var ds = xreport.DataSource as SqlDataSource;
                    var appConf = AppConfigManager.Configuration.AppConfig;

                    if (ds == null)
                        ds = new SqlDataSource(appConf.ServerName);

                    SetParamDataSource(ds, appConf);

                    ds.Connection.CreateConnectionString();

                    ds.RebuildResultSchema();

                    //objeto para gerar a tela de parametros
                    ReportPrintTool reportPrintTool = new ReportPrintTool(xreport);

                    //permissao para solicitar os parametros
                    xreport.RequestParameters = requestParameters;


                    //permissao para exibir os parametros
                    if (visibleParameters == false)
                    {
                        foreach (var p in xreport.Parameters)
                        {
                            p.Visible = false;
                        }
                    }

                    //chama a tela de parametros
                    xreport.CreateDocument();

                    //libera memoria da ferramenta
                    reportPrintTool.Dispose();

                    if (ribbon)
                        //chama o ribbon para exibir o relatório
                        xreport.ShowRibbonPreview();
                    else
                        xreport.ShowPreview();

                    ////carregando o relatório manualmente
                    ////salva o documento gerado em prnx
                    //xreport.PrintingSystem.SaveDocument(pathPrnx);

                    //// Create a PrintingSystem instance.
                    //PrintingSystem ps = new PrintingSystem();

                    //// Load the document from a file.
                    //ps.LoadDocument(pathPrnx);

                    ////ribbon form para visualizar o relatório
                    //PrintPreviewRibbonFormEx preview = new PrintPreviewRibbonFormEx();
                    //preview.PrintingSystem = ps;
                    ////xtraform para visualizar o relatório
                    //PrintPreviewFormEx prev = new PrintPreviewFormEx();
                    //prev.PrintingSystem = ps;
                    ////exibe o relatorio
                    //preview.ShowDialog(); 
                }
            }
            catch (Exception ex)
            {
                XMessageIts.Erro("Falha gerar relatório\n\n" + ex.Message, "Atenção!!!");
                LoggerUtilIts.GenerateLogs(ex);

            }
        }
        private static XtraReport printReportXtra(int idreport, bool requestParameters = true,
bool visibleParameters = true, bool ribbon = false)
        {
            try
            {
                using (var ctx = new ReportContext())
                {
                    var current = ctx.ReportImageDao.Find(idreport);
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

                    var ds = xreport.DataSource as SqlDataSource;
                    var appConf = AppConfigManager.Configuration.AppConfig;

                    if (ds == null)
                        ds = new SqlDataSource(appConf.ServerName);

                    SetParamDataSource(ds, appConf);

                    ds.Connection.CreateConnectionString();

                    ds.RebuildResultSchema();

                    //objeto para gerar a tela de parametros
                    //ReportPrintTool reportPrintTool = new ReportPrintTool(xreport);

                    //permissao para solicitar os parametros
                    xreport.RequestParameters = requestParameters;


                    //permissao para exibir os parametros
                    if (visibleParameters == false)
                    {
                        foreach (var p in xreport.Parameters)
                        {
                            p.Visible = false;
                        }
                    }
                    return xreport;

                    //chama a tela de parametros
                    //xreport.CreateDocument();

                    //libera memoria da ferramenta
                    //reportPrintTool.Dispose();

                    //if (ribbon)
                    //    //chama o ribbon para exibir o relatório
                    //    xreport.ShowRibbonPreview();
                    //else
                    //    xreport.ShowPreview();

                    ////carregando o relatório manualmente
                    ////salva o documento gerado em prnx
                    //xreport.PrintingSystem.SaveDocument(pathPrnx);

                    //// Create a PrintingSystem instance.
                    //PrintingSystem ps = new PrintingSystem();

                    //// Load the document from a file.
                    //ps.LoadDocument(pathPrnx);

                    ////ribbon form para visualizar o relatório
                    //PrintPreviewRibbonFormEx preview = new PrintPreviewRibbonFormEx();
                    //preview.PrintingSystem = ps;
                    ////xtraform para visualizar o relatório
                    //PrintPreviewFormEx prev = new PrintPreviewFormEx();
                    //prev.PrintingSystem = ps;
                    ////exibe o relatorio
                    //preview.ShowDialog(); 
                }
            }
            catch (Exception ex)
            {
                XMessageIts.Erro("Falha gerar relatório\n\n" + ex.Message, "Atenção!!!");
                LoggerUtilIts.GenerateLogs(ex);
                return null;
            }
        }

        #region Export/Import - Relatórios

        public static void DuplicateReport(ReportImage rpt)
        {
            var op = XMessageIts.Confirmacao("Certeza que deseja criar uma cópia do relatório selecionado?");

            if (op == DialogResult.Yes)
            {
                using (var ctx = new ReportContext())
                {

                    //novo
                    var novo = new ReportImage();
                    //gera um novo
                    novo.Update(rpt);

                    var count = ctx.ReportImageDao.Where(r => r.ReportName == novo.ReportName).Count();

                    novo.ReportName = novo.ReportName + "Duplicado_" + count;
                    novo.ReportDescription = novo.ReportDescription + "(Duplicado)";

                    if (ctx.ReportImageDao.Save(novo))
                    {
                        XMessageIts.Mensagem("Relatório duplicado com sucesso!");
                    }
                    else
                    {
                        XMessageIts.Erro("Erro na cópia do relatório!");
                    }
                }
            }
        }

        public static void ExportReport(ReportImage rpt)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = ReportFilter;
            sfd.FileName = "Export_" + rpt.ReportName;
            var op = sfd.ShowDialog();

            //novo
            var novo = new ReportImage();
            //gera um novo
            novo.Update(rpt);

            //serializa p relatorio
            var bytes = SerializeIts.SerializeObject(novo);

            if (op == DialogResult.OK)
            {
                if (FileManagerIts.WriteBytesToFile(sfd.FileName, bytes))
                {
                    XMessageIts.Mensagem("Arquivo salvo com sucesso!");
                }
                else
                {
                    XMessageIts.Erro("Erro na exportação do relatório!");
                }
            }
        }

        public static void ExportReportList(List<ReportImage> reports)
        {
            string outReports = Path.Combine(FileManagerIts.DeskTopPath, "Reports ITS");

            if (!Directory.Exists(outReports))
                FileManagerIts.CreateDirectory(outReports);

            bool flag = false;
            foreach (var rpt in reports)
            {
                var novo = new ReportImage();
                //gera um novo
                novo.Update(rpt);

                string file = outReports + "\\" + rpt.ReportName + ".itsrpt";

                //serializa p relatorio
                var bytes = SerializeIts.SerializeObject(novo);
                flag = FileManagerIts.WriteBytesToFile(file, bytes);

            }
            if (flag)
                XMessageIts.Mensagem("Relatórios exportados com sucesso!");
            else
                XMessageIts.Erro("Relatórios exportados com erro!");

        }

        public static void ImportReport()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = ReportFilter;
            ofd.Multiselect = true;
            var op = ofd.ShowDialog();

            if (op == DialogResult.OK)
            {
                ImportReportFromFiles(ofd.FileNames);
            }
        }

        public static void ImportReportFromFiles(params string[] filesReports)
        {

            using (var ctx = new ReportContext())
            {
                try
                {
                    Dictionary<string, bool> importados = new Dictionary<string, bool>();

                    foreach (var file in filesReports)
                    {
                        var bytesFile = FileManagerIts.GetBytesFromFile(file);
                        var rptDeserializado = SerializeIts.DeserializeObject<ReportImage>(bytesFile);

                        var rptCreateUpdate = ctx.ReportImageDao.Where(r =>
                                            r.ReportName == rptDeserializado.ReportName)
                                            .FirstOrDefault();

                        //relatorio ja existe
                        if (rptCreateUpdate != null)
                        {
                            var msg = "O relatório selecionado já existe, deseja atualiza-lo?";
                            var confirm = XMessageIts.Confirmacao(msg);
                            if (confirm == DialogResult.Yes)
                            {
                                rptCreateUpdate.Update(rptDeserializado);

                                var traUpd = ctx.ReportImageDao.Update(rptCreateUpdate);
                                if (traUpd)
                                {
                                    XMessageIts.Mensagem("Relatório atualizado com sucesso!");
                                }
                            }
                        }
                        //relatorio nao existe, entao vai criar
                        else
                        {
                            var newReport = new ReportImage();
                            newReport.IdGrpReport = rptDeserializado.IdGrpReport;
                            newReport.ReportDescription = rptDeserializado.ReportDescription;
                            newReport.ReportImageData = rptDeserializado.ReportImageData;
                            newReport.ReportName = rptDeserializado.ReportName;
                            importados.Add(newReport.ReportName, ctx.ReportImageDao.Save(newReport));

                        }
                    }
                    if (importados.Where(i => i.Value == false).Count() == 0)
                    {
                        XMessageIts.Mensagem("Relatórios importado com sucesso!");
                    }
                    else
                    {
                        XMessageIts.Advertencia("Ocorreram erros ao importar o(s) dashboard(s) !");
                    }
                }
                catch (Exception ex)
                {
                    XMessageIts.ExceptionMessageDetails(ex, "Falha ao importar o relatório");
                }
            }
        }
        #endregion

        #region Export/Import - Dashboards

        public static void DuplicateDashboard(DashboardImage dsImage)
        {
            var op = XMessageIts.Confirmacao("Certeza que deseja criar uma cópia do dashboard selecionado?");

            if (op == DialogResult.Yes)
            {
                using (var ctx = new ReportContext())
                {

                    //novo
                    var novo = new DashboardImage();
                    //gera um novo
                    novo.Update(dsImage);

                    var count = ctx.DashboardImageDao.Where(r => r.ReportName == novo.ReportName).Count();

                    novo.ReportName = novo.ReportName + "_" + count;
                    novo.ReportDescription = novo.ReportDescription + "(Duplicado)";

                    if (ctx.DashboardImageDao.Save(novo))
                    {
                        XMessageIts.Mensagem("Dashboard duplicado com sucesso!");
                    }
                    else
                    {
                        XMessageIts.Erro("Erro na cópia do dashboard!");
                    }
                }
            }
        }

        public static void ExportDashaboard(DashboardImage dash)
        {
            var bytes = SerializeIts.SerializeObject(dash);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = DashboardFilter;
            sfd.FileName = "Export_" + dash.ReportDescription;
            var op = sfd.ShowDialog();

            if (op == DialogResult.OK)
            {
                //sfd.FileName = Path.ChangeExtension(sfd.FileName, "iteReport");

                if (FileManagerIts.WriteBytesToFile(sfd.FileName, bytes))
                {
                    XMessageIts.Mensagem("Arquivo salvo com sucesso!");
                }
                else
                {
                    XMessageIts.Erro("Erro");
                }
            }
        }

        public static void ExportDashboardList(List<DashboardImage> reports)
        {
            string outReports = Path.Combine(FileManagerIts.DeskTopPath, "Dashboards ITS");

            if (!Directory.Exists(outReports))
                FileManagerIts.CreateDirectory(outReports);

            bool flag = false;
            foreach (var rpt in reports)
            {
                var novo = new DashboardImage();
                //gera um novo
                novo.Update(rpt);


                string file = outReports + "\\" + rpt.ReportName + ".itsdsh";

                //serializa p relatorio
                var bytes = SerializeIts.SerializeObject(novo);
                flag = FileManagerIts.WriteBytesToFile(file, bytes);

            }
            if (flag)
                XMessageIts.Mensagem("Dashboards exportados com sucesso!");
            else
                XMessageIts.Erro("Dashboards exportados com erro!");

        }

        public static void ImportDashboard()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = DashboardFilter;
            ofd.Multiselect = true;

            var op = ofd.ShowDialog();

            if (op == DialogResult.OK)
            {
                ImportDashboardFromFiles(ofd.FileNames);
            }

        }

        public static void ImportDashboardFromFiles(params string[] filesReports)
        {
            using (var ctx = new ReportContext())
            {
                try
                {
                    Dictionary<string, bool> importados = new Dictionary<string, bool>();
                    foreach (var file in filesReports)
                    {

                        var bytesFile = FileManagerIts.GetBytesFromFile(file);
                        var dashDeserializado = SerializeIts.DeserializeObject<DashboardImage>(bytesFile);
                        var dashCreateUpdate = ctx.DashboardImageDao.Where(r =>
                                        r.ReportDescription == dashDeserializado.ReportDescription)
                                        .FirstOrDefault();

                        //relatorio ja existe
                        if (dashCreateUpdate != null)
                        {
                            var msg = "O dashboard selecionado já existe, deseja atualiza-lo?";
                            var confirm = XMessageIts.Confirmacao(msg);
                            if (confirm == DialogResult.Yes)
                            {
                                dashCreateUpdate.Update(dashDeserializado);

                                var traUpd = ctx.DashboardImageDao.Update(dashCreateUpdate);
                                if (traUpd)
                                {
                                    XMessageIts.Mensagem("Dashboard atualizado com sucesso!");
                                }
                            }
                        }
                        //relatorio nao existe, entao vai criar
                        else
                        {
                            var newDashboard = new DashboardImage();
                            newDashboard.IdGrpReport = dashDeserializado.IdGrpReport;
                            newDashboard.ReportDescription = dashDeserializado.ReportDescription;
                            newDashboard.ReportImageData = dashDeserializado.ReportImageData;
                            newDashboard.ReportName = dashDeserializado.ReportName;
                            importados.Add(newDashboard.ReportName, ctx.DashboardImageDao.Save(newDashboard));

                        }
                    }

                    if (importados.Where(i => i.Value == false).Count() == 0)
                    {
                        XMessageIts.Mensagem("Dashboard importado com sucesso!");
                    }
                    else
                    {
                        XMessageIts.Advertencia("Ocorreram erros ao importar o(s) dashboard(s) !");
                    }
                }
                catch (Exception ex)
                {
                    XMessageIts.ExceptionMessage(ex);
                }
            }

        }

        #endregion

        public static void SetParamDataSource(SqlDataSource sqs, AppConfigIts appConf)
        {
            var param = new DevExpress.DataAccess.ConnectionParameters.MsSqlConnectionParameters()
            {
                ServerName = appConf.ServerName,
                DatabaseName = appConf.Database,
                UserName = appConf.User,
                Password = appConf.Password
            };

            if (appConf.Password.IsNullOrEmpty())
                param.AuthorizationType = DevExpress.DataAccess.ConnectionParameters.MsSqlAuthorizationType.Windows;
            else
                param.AuthorizationType = DevExpress.DataAccess.ConnectionParameters.MsSqlAuthorizationType.SqlServer;

            sqs.ConnectionParameters = param;
        }
        /// <summary>
        /// Recupera o DataSource da string de conexão atual
        /// </summary>
        /// <returns></returns>
        public static MsSqlConnectionParameters GetParamDataSource()
        {
            AppConfigIts appConf = AppConfigManager.Configuration.AppConfig;
            var param = new DevExpress.DataAccess.ConnectionParameters.MsSqlConnectionParameters()
            {
                ServerName = appConf.ServerName,
                DatabaseName = appConf.Database,
                UserName = appConf.User,
                Password = appConf.Password
            };

            if (appConf.Password.IsNullOrEmpty())
                param.AuthorizationType = DevExpress.DataAccess.ConnectionParameters.MsSqlAuthorizationType.Windows;
            else
                param.AuthorizationType = DevExpress.DataAccess.ConnectionParameters.MsSqlAuthorizationType.SqlServer;

            return param;
        }
    }
}
