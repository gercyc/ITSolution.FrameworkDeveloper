using DevExpress.DashboardCommon;
using DevExpress.DashboardWin;
using ITSolution.Framework.Arquivos;
using ITSolution.Framework.Common.BaseClasses.Reports;
using ITSolution.Framework.Entities;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using ITSolution.Reports.Repositorio;
using ITSolution.Reports.Util;
using System;
using System.IO;

namespace ITSolution.Reports.DaoManager
{
    public class DashboardDaoManager
    {
        private readonly string _dashboardDir;

        public DashboardDaoManager()
        {
            //path da instalação tera uma pasta chamada Dashboards
            //this._dashboardDir = Path.Combine(Application.StartupPath, "Dashboards");
            this._dashboardDir = Path.GetTempPath().Replace("Temp", "Dashboards");
            if (!Directory.Exists(_dashboardDir))
                Directory.CreateDirectory(_dashboardDir);
        }

        public void LoadDashboard(DashboardImage _dashboardImage, DashboardViewer dashboardViewer1)
        {
            using (var ctx = new ReportContext())
            {
                string path = LoadToChache(_dashboardImage);

                Dashboard ds = new Dashboard();

                ds.LoadFromXml(path);

                DataSourceCollection dsCollection = ds.DataSources;

                var appConf = new AppConfigIts(ctx.NameOrConnectionString);

                foreach (DashboardSqlDataSource dsSql in dsCollection)
                {

                    ReportUtil.SetParamDataSource(dsSql, appConf);
                }

                dashboardViewer1.Dashboard = ds;
                dashboardViewer1.ReloadData();

            }
        }

        /// <summary>
        /// Salva o dashboard no banco
        /// </summary>
        /// <param name="dashboardDesigner">Designer do dashboard</param>
        /// <param name="dash">Dashboard a ser persistido</param>
        /// <returns>O Dashboard persistido no banco ou null</returns>
        public DashboardImage SaveDashboard(DashboardDesigner dashboardDesigner, DashboardImage dash)
        {
            try
            {
                using (var ctx = new ReportContext())
                {
                    //nome informado no dashboard
                    dash.DefaultName = dashboardDesigner.ActiveControl.Name;

                    //gera um nome aleatorio utilizando o nome setado no dashboard
                    string dashPath = generatePath(dash, ctx);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        //objeto designer do dashboard
                        var designer = dashboardDesigner.Dashboard;

                        //salva o layout em memoria
                        designer.SaveToXml(ms);

                        //salva o dashboard no disco em formato xml
                        designer.SaveToXml(dashPath);

                        //obtem os bytes do dashboard
                        var bytes = ms.GetBuffer();

                        //passa os bytes do dashboard pro objeto dashboard
                        dash.ReportImageData = bytes;

                        //persiste o objeto no banco
                        if (ctx.DashboardImageDao.Save(dash))
                            return dash;

                    }
                }
            }
            catch (Exception ex)
            {
                XMessageIts.Advertencia("Houve um erro ao salvar o dashboard.\n\n"
                                        + ex.Message);

                LoggerUtilIts.GenerateLogs(ex);
            }

            return null;
        }

        /// <summary>
        /// Atualiza o dashboard existente no banco
        /// </summary>
        /// <param name="dashboardDesigner">Designer do dashboard</param>
        /// <param name="dash">Dashboard a ser persistido</param>
        /// <returns>O Dashboard persistido no banco ou null</returns>
        public bool UpdateDashboard(DashboardDesigner dashboardDesigner, DashboardImage dash)
        {
            try
            {
                using (var ctx = new ReportContext())
                {
                    //nome padrão
                    dash.DefaultName = dashboardDesigner.ActiveControl.Name;

                    //gera um nome aleatorio utilizando o nome setado no dashboard
                    string dashPath = generatePath(dash, ctx);
                    // using (MemoryStream ms = new MemoryStream())

                    //objeto designer do dashboard
                    var designer = dashboardDesigner.Dashboard;

                    FileManagerIts.DeleteFile(dashPath);
                    //salva o layout em memoria
                    //designer.SaveToXml(ms);

                    //salva o dashboard no disco em formato xml
                    designer.SaveToXml(dashPath);

                    var bytes = FileManagerIts.GetBytesFromFile(dashPath); //ms.GetBuffer();

                    //passando objeto pro contexto
                    var current = ctx.DashboardImageDao.Find(dash.IdReport);

                    //atualiza o dashboard
                    current.Update(dash);
                    
                    //garante a atualização
                    current.ReportImageData = bytes;

                    //efetiva no banco
                    return ctx.DashboardImageDao.Update(current);

                }
            }
            catch (Exception ex)
            {
                XMessageIts.Advertencia("Houve um erro na atualização do dashboard.\n\n"
                                        + ex.Message);

                LoggerUtilIts.GenerateLogs(ex);
                return false;
            }

        }

        /// <summary>
        /// Remove os dashboard criados no disco
        /// <br>Todos .xml será apagado</br>
        /// </summary>
        /// <param name="dashboardAnt"></param>
        public void ClearCache()
        {
            var dashs = FileManagerIts.ToFiles(_dashboardDir, new string[] { "", ".xml" });

            foreach (var path in dashs)
            {
                FileManagerIts.DeleteFile(path);
            }
        }

        /// <summary>
        /// Remove o dashboard do banco 
        /// </summary>
        /// <param name="dashboard"></param>
        /// <returns></returns>
        public bool RemoveDashboard(DashboardImage dashboard)
        {
            using (var ctx = new ReportContext())
            {
                //remove o dash do banco
                var current = ctx.DashboardImageDao.Find(dashboard.IdReport);
                try
                {
                    return ctx.DashboardImageDao.Delete(current);
                }
                catch (Exception ex)
                {

                    XMessageIts.Erro("Não foi possível remover o dashboard!");
                    LoggerUtilIts.GenerateLogs(ex, "Falha ao remover dashboard!");
                    return false;
                }
            }
        }

        /// <summary>
        /// Carrega um .xml em disco
        /// </summary>
        /// <param name="dash"></param>Objeto DashboardImage
        /// <returns></returns>Obtém o path do dashboard no banco
        public string LoadToChache(DashboardImage dash, bool overwrite = false)
        {
            using (var ctx = new ReportContext())
            {
                try
                {
                    //recupera o objeto do banco para alteração dos campos
                    dash = ctx.DashboardImageDao.Find(dash.IdReport);

                    //caminho do dashboard
                    string dashboardPath = generatePath(dash, ctx);


                    if (overwrite)
                        FileManagerIts.DeleteFile(dashboardPath);

                    //gera o arquivo atraves dos bytes salvos no banco e gera um arquivo em disco
                    if (!File.Exists(dashboardPath))
                        FileManagerIts.WriteBytesToFile(dashboardPath, dash.ReportImageData);

                    //caso contrario vou carregar diretamente do disco

                    return dashboardPath;
                }
                catch (Exception)
                {
                    return null;
                }
            }

        }
        
        public DashboardImage FindDashboardByName(string dashName)
        {
            try
            {
                return new ReportContext().DashboardImageDao
                    .First(r => r.ReportName == dashName);

            }
            catch (Exception ex)
            {
                throw new Exception("Relatório \"" + dashName + "\"\n\n" + ex.Message);
            }
        }

        private string generatePath(DashboardImage dash, ReportContext ctx)
        {
            //acompanha o Pk do dashboard que nunca se repete
            if (dash.IdReport != 0)
            {
                dash.ReportName = "Dashboard" + dash.IdReport;
            }
            else
            {
                dash.ReportName = "Dashboard" + (ctx.DashboardImageDao.FindAll().Count + 1);
            }

            var path = string.Format("{0}\\{1}{2}", _dashboardDir, dash.ReportName, ".xml");

            return path;

        }

    }

}
