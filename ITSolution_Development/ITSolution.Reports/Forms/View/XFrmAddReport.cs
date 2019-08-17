using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITSolution.Framework.Beans.ProgressBar;
using ITSolution.Framework.Common.BaseClasses.Reports;
using ITSolution.Framework.Common.BaseClasses.Reports.Enumeradores;
using ITSolution.Framework.GuiUtil;
using ITSolution.Framework.Mensagem;
using ITSolution.Reports.Repositorio;

namespace ITSolution.Reports.Forms.View
{
    /// <summary>
    /// Pré criaçaõ do relatório
    /// </summary>
    public partial class XFrmAddReport : DevExpress.XtraEditors.XtraForm
    {
        private TypeReport _typeReport;
        /// <summary>
        /// Dados do relatório criado/editado
        /// </summary>
        public ReportImage ReportImage { get; private set; }

        /// <summary>
        /// Dados do dashboard criado/editado
        /// </summary>
        public DashboardImage DashboardImage { get; private set; }

        public bool IsCancelado { get; set; }

        private XFrmAddReport()
        {
            InitializeComponent();
            this.ActiveControl = txtDescricaoRelatorio;
            this.txtDescricaoRelatorio.Focus();
        }

        /// <summary>
        /// Criar/Alterar um ReportImage
        /// </summary>
        /// <param name="reportImage"></param>
        public XFrmAddReport(ReportImage reportImage) : this()
        {
            this.DashboardImage = null;
            this.ReportImage = reportImage;
            this.cbGrupoRelatorio.Properties.Items.Add(reportImage.Grupo);
            this.cbGrupoRelatorio.SelectedIndex = 0;
            this.txtDescricaoRelatorio.Text = reportImage.ReportDescription;
        }

        /// <summary>
        /// Criar/Alterar o DashboardImage
        /// </summary>
        /// <param name="dashboardImage"></param>
        public XFrmAddReport(DashboardImage dashboardImage) : this()
        {
            this.ReportImage = null;
            this.DashboardImage = dashboardImage;
            this.cbGrupoRelatorio.Properties.Items.Add(dashboardImage.Grupo);
            this.cbGrupoRelatorio.SelectedIndex = 0;
            this.txtDescricaoRelatorio.Text = dashboardImage.ReportDescription;
        }

        /// <summary>
        /// Construtores para criar um novo relatório
        /// </summary>
        /// <param name="typeReport"></param>Tipo de relatório a ser gerado
        public XFrmAddReport(TypeReport typeReport) : this()
        {
            btnRefreshGroup_Click(null, null);
            this._typeReport = typeReport;
        }

        #region Metodos

        public ReportImage CreateReport()
        {

            btnCriarEstrutura_ItemClick(null, null);
            return ReportImage;
        }
        public DashboardImage CreateDashboard()
        {
            btnCriarEstrutura_ItemClick(null, null);
            return this.DashboardImage;
        }

        /// <summary>
        /// Alterar ou cria o relatorio
        /// </summary>
        /// <param name="grupo"></param>Grupo de relatorio
        private void showReport(ReportGroup grupo)
        {
            //crie o relatório
            if (this.ReportImage == null)
            {
                this.ReportImage = new ReportImage(txtDescricaoRelatorio.Text, grupo);

            }//altere o relatorio
            else
            {
                //atualiza
                ReportImage.ReportDescription = txtDescricaoRelatorio.Text;
                ReportImage.IdGrpReport = grupo.IdGrpReport;
            }
        }

        /// <summary>
        /// Alterar ou cria o dashboard
        /// </summary>
        /// <param name="grupo"></param>Grupo do relatório
        private void showDashboard(ReportGroup grupo)
        {
            //crie o dashboard
            if (this.DashboardImage == null)
            {
                this.DashboardImage = new DashboardImage(txtDescricaoRelatorio.Text, grupo);

            }//altere o dashboard
            else
            {
                //atualiza
                DashboardImage.ReportDescription = txtDescricaoRelatorio.Text;
                DashboardImage.IdGrpReport = grupo.IdGrpReport;
            }
        }

        #endregion 

        #region Eventos
        private void btnCriarEstrutura_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isValidReport())
            {
                var grupo = cbGrupoRelatorio.SelectedItem as ReportGroup;

                if (_typeReport == TypeReport.Report)

                    XFrmWait.StartTask(Task.Run(() => showReport(grupo)),
                        "Carregando imagem do relatório");
                //seta o dashboard
                else
                {
                    XFrmWait.StartTask(Task.Run(() => showDashboard(grupo)),
                        "Carregando imagem do relatório");
                }
                //chama outra tela
                this.IsCancelado = false;
                this.Dispose();
            }
            else
            {
                XMessageIts.Erro("Usuário sem permissão para editar do grupo Sistema");
                this.IsCancelado = true;
            }
        }

        private void btnRefreshGroup_Click(object sender, EventArgs e)
        {
            using (var ctx = new ReportContext())
            {
                //carrega os grupos na caixa de combinação
                ctx.ReportGroupDao.FillComboBoxEdit(cbGrupoRelatorio, "Carregando grupos...");
                this.btnRefreshGroup.Enabled = false;
            }
        }

        private bool isValidReport()
        {
            var grupo = cbGrupoRelatorio.SelectedItem as ReportGroup;

            if (grupo == null)
            {
                XMessageIts.Mensagem("Selecione o grupo !");
                return false;
            }
            if (txtDescricaoRelatorio.Text.Length < 5)
            {
                XMessageIts.Mensagem("Informe a descrição do relatório", "Tamanho minímo 5");
                return false;
            }

            return true;
        }

        private void barBtnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.IsCancelado = true;
            this.Dispose();
        }

        private void txtDescricaoRelatorio_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCriarEstrutura_ItemClick(null, null);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void barBtnAlterarNome_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var ctx = new ReportContext())
            {
                int idGrpRpt = cbGrupoRelatorio.GetSelectedItem<ReportGroup>().IdGrpReport;
                if (this.ReportImage != null)
                {
                    var r = ctx.ReportImageDao.Find(ReportImage.IdReport);
                    r.ReportDescription = txtDescricaoRelatorio.Text;
                    r.IdGrpReport = idGrpRpt; ctx.ReportImageDao.Update(r);
                    this.ReportImage.Update(r);
                }
                else if (this.DashboardImage != null)
                {
                    var d = ctx.DashboardImageDao.Find(DashboardImage.IdReport);

                    d.ReportDescription = txtDescricaoRelatorio.Text;
                    d.IdGrpReport = idGrpRpt;

                    ctx.DashboardImageDao.Update(d);
                    this.DashboardImage.Update(d);
                }
                else
                {
                    XMessageIts.Erro("Alteração não efetivada !", "Erro");
                }


            }
            this.IsCancelado = true;
            this.Close();
            this.Dispose();
        }

        #endregion

        private void XFrmAddReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.IsCancelado = true;
            }
        }
    }
}