using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraReports.UI;
using ITSolution.Framework.Arquivos;
using ITSolution.Framework.Mensagem;
using System;
using System.Windows.Forms;
using ITSolution.Reports.Repositorio;
using ITSolution.Framework.Util;
using ITSolution.Reports.Forms.Param;
using ITSolution.Framework.Common.BaseClasses.Reports.Enumeradores;
using ITSolution.Framework.Common.BaseClasses.Reports;

namespace ITSolution.Reports.DaoManager
{
    public class ReportSpoolDaoManager
    {

        public bool GenerateSpoolFromReport(ReportImage report)
        {
            try
            {
                using (var ctx = new ReportContext())
                {
                    //zipar a imagem
                    var imageZipped = ZipUtil.ZipFromBytes(report.ReportImageData);

                    //criaçao do relatorio
                    var imgSave = new ReportSpool(DateTime.Now, report.ReportName, imageZipped);

                    return ctx.ReportSpoolDao.Save(imgSave);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Falha na geração do spool");
                LoggerUtilIts.GenerateLogs(ex, "Falha na geração do spool do relatório");
                return false;
            }

        }

        /// <summary>
        /// Visualizar ou salvar o relatório selecionado do spool
        /// </summary>
        /// <param name="idSpool">Id do spool</param>
        /// <param name="typeGeracaoSpool">Informar o tipo: Visualizar, ExpPdf ou ExpExcel</param>
        public void GerarRelatorioFromSpool(Int32 idSpool, TypeGeracaoSpool typeGeracaoSpool)
        {
            using (var ctx = new ReportContext())
            {
                try
                {

                    var sv = new SaveFileDialog();
                    //relatorio selecionado
                    var relat = ctx.ReportSpoolDao.Find(idSpool);
                    //caminho temporario
                    var path = Application.StartupPath + "\\temp.prnx";
                    //escreve os bytes do relatorio selecionado no arquivo
                    var reportImageUnzip = ZipUtil.UnzipFromBytes(relat.ReportSpoolImage);
                    FileManagerIts.WriteBytesToFile(path, reportImageUnzip);
                    // Create a PrintingSystem instance.
                    PrintingSystem ps = new PrintingSystem();

                    // Load the document from a file.
                    ps.LoadDocument(path);

                    // Create an instance of the preview dialog.
                    PrintPreviewRibbonFormEx preview = new PrintPreviewRibbonFormEx();

                    PrintPreviewFormEx prev = new PrintPreviewFormEx();
                    prev.PrintingSystem = ps;
                    // Load the report document into it.
                    //preview.PrintingSystem = ps;
                    if (typeGeracaoSpool == TypeGeracaoSpool.PreVisualizar)
                    {
                        // Show the preview dialog.
                        //preview.ShowDialog(); //ribbon

                        //não ribbon
                        prev.Show();
                    }
                    else if (typeGeracaoSpool == TypeGeracaoSpool.ExportarParaPdf)
                    {
                        sv.Filter = "Arquivo PDF | *.pdf";
                        sv.ShowDialog();
                        if (sv.FileName != "") ps.ExportToPdf(sv.FileName);
                    }
                    else if (typeGeracaoSpool == TypeGeracaoSpool.ExportarParaExcel)
                    {
                        sv.Filter = "Arquivo XLSX | *.xlsx";
                        sv.ShowDialog();
                        if (sv.FileName != "") ps.ExportToXlsx(sv.FileName);
                    }
                    //Remova o relatorio temporario
                    FileManagerIts.DeleteFile(path);
                }
                catch
                (Exception
                ex)
                {
                    LoggerUtilIts.ShowExceptionLogs(ex);
                }
            }

        }

        /// <summary>
        /// Remove um relatório do spool
        /// </summary>
        /// <param name="idSpool"></param>
        /// <returns></returns>
        public bool RemoveRelatorioFromSpool(Int32 idSpool)
        {
            using (var ctx = new ReportContext())
            {
                try
                {
                    var reportDelete = ctx.ReportSpoolDao.Find(idSpool);
                    return ctx.ReportSpoolDao.Delete(reportDelete);
                }
                catch (Exception ex)
                {
                    LoggerUtilIts.ShowExceptionLogs(ex);
                    return false;
                }
            }

        }


        /// <summary>
        /// Gera um relatório para o Spool de relatórios
        /// </summary>
        /// <param name="id">ID do relatório</param>
        /// <returns></returns>
        public void PrintReportSpool(int id, bool visualizar = true)
        {
            try
            {
                var ctx = new ReportContext();
                var imageReport = ctx.ReportImageDao.Find(id);
                var path = Application.StartupPath + "\\temp.repx";
                var pathPrnx = Application.StartupPath + "\\tempPrnx.prnx";
                var isCanceled = false;

                //download do *.repx do banco
                FileManagerIts.WriteBytesToFile(path, imageReport.ReportImageData);

                //carregue a estrutura do relatório
                XtraReport report = XtraReport.FromFile(path, true);

                //tela personalizado de parametros
                var parameters = new XFrmReportParams_DEV(report.Parameters);

                //se o relatorio tem parametros....
                if (report.Parameters.Count >= 1)
                {
                    report.RequestParameters = false;

                    //chame a tela de paramentros
                    parameters.ShowDialog();

                    report.Parameters.Clear();

                    foreach (var item in parameters.NewParametros)
                    {
                        report.Parameters.Add(item);
                    }

                    isCanceled = parameters._isCanceled;
                }

                #region Processamento do relatório
                //se a geração nao foi cancelada em 
                //XFrmReportParams, continue com a geração
                if (isCanceled == false)
                {
                    //criar o documento
                    ReportPrintTool reportPrintTool = new ReportPrintTool(report);
                    report.CreateDocument();

                    //salva o documento gerado em prnx
                    report.PrintingSystem.SaveDocument(pathPrnx);

                    //carrega o relatório gerado para bytes[]
                    var image = FileManagerIts.ReadBytesFromFile(pathPrnx);

                    //zipar a imagem
                    var imageZipped = ZipUtil.ZipFromBytes(image);

                    //criaçao do relatorio
                    var imgSave = new ReportSpool(DateTime.Now, report.DisplayName, imageZipped);
                    var result = ctx.ReportSpoolDao.Save(imgSave);


                    if (result && visualizar)
                    {
                        GerarRelatorioFromSpool(imgSave.IdSpool, TypeGeracaoSpool.PreVisualizar);
                    }
                    else if (result && !visualizar)
                    {
                        XMessageIts.Mensagem("Relatório gerado com sucesso!", "Sucesso");
                    }
                    else
                    {
                        XMessageIts.Advertencia("Falha ao gerar relatório.\n\n" +
                            "Contate o adminstrador do sistema", "Atenção");
                    }

                    //Remova o relatorio temporario
                    FileManagerIts.DeleteFile(path);
                    FileManagerIts.DeleteFile(pathPrnx);
                }

                #endregion

                //se não passar pelo if, a geração foi cancelada, então Task<bool> = false
            }
            catch (Exception ex)
            {
                LoggerUtilIts.ShowExceptionLogs(ex);
                throw ex;

            }
        }
    }
}
