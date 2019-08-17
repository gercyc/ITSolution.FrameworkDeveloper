using System;
using System.IO;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars;
using ITSolution.Admin.Entidades.TaskManager;
using ITSolution.Admin.Forms.ContextUtil;
using ITSolution.Admin.Forms.ListView;
using ITSolution.Framework.GuiUtil;
using ITSolution.Admin.Forms.Util;
using ITSolution.Admin.Launcher;
using ITSolution.Framework.Arquivos;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Forms;
using ITSolution.Framework.Dao.Contexto;
using ITSolution.Reports.Forms.ListView;
using ITSolution.Framework.Common.BaseClasses.Reports.Enumeradores;
using ITSolution.Framework.BaseInterfaces;
using DevExpress.XtraBars.Ribbon;
using ITSolution.Framework.BaseClasses;

namespace ITSolution.Admin.Forms.Menu
{
    public partial class XFrmAdminMenu : DevExpress.XtraEditors.XtraForm, IITSDesktop
    {
        private XFrmReportList _xFrmReportList;
        private XFrmDashboardListView _xFrmDashboardList;
        private XFrmLicenseManager _xFrmLicenseManager;
        ITSApplication _application;

        #region IITSDesktop Implementation
        public DialogResult ResultLogin
        {
            get
            {
                return DialogResult.OK;
            }
        }

        public IITSDesktop Desktop
        {

            get { return this; }
        }
        public IITSTools ITSTools
        {
            get
            {
                return _application;
            }
        }

        public void SetMenu(RibbonControl ribbonControl)
        {

        }

        public FormWindowState SetFormWindowState(FormWindowState formWindowState)
        {
            return FormWindowState.Maximized;
        }

        public Type GetApplicationObj()
        {
            return typeof(ITSApplication);
        }

        #endregion
        public XFrmAdminMenu()
        {
            InitializeComponent();
            dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
        }
        public XFrmAdminMenu(ITSApplication _pITSApplication) : this()
        {
            _application = _pITSApplication;
            _application.AncestorDesktop = this;

        }

        #region Arquivo

        private void barMnSair_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Version Control

        private void barMnPackages_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormsUtil.Show(new XFrmPackageManager(), this);
        }

        private void barMnPkgInstaled_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormsUtil.Show(new XFrmUpdateManager(), this);
        }

        #endregion

        #region Tools

        private void barMnApplyPkg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormsUtil.ShowDialog(new XFrmApplyPackage());
        }

        private void barMnNavSql_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormsUtil.Show(new XFrmQueryEditor(), this);
        }

        private void barBtnAppConfig_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormsUtil.Show(new XFrmContextUtil(), this);
        }


        private void barBtnUpdateDll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog { Filter = "ITE Solution|*.exe" };

            try
            {
                if (op.ShowDialog() == DialogResult.OK && op.FileName.EndsWith("ITE.Forms.exe"))
                {
                    string tarjet = Path.GetDirectoryName(op.FileName);
                    //diretorio do diretorio
                    new TaskUpdateManager().UpdateSystemDLLs(null, tarjet);

                    XMessageIts.Mensagem("Atualização terminada !", "DLLs Atualizadas");
                }
                else
                {
                    XMessageIts.Advertencia("Selecione o executavél do programa ITE Solution", "Atenção");
                }
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessage(ex);
            }
        }

        private void barBtnBackup_ItemClick(object sender, ItemClickEventArgs e)
        {
            new XFrmBackupSql(AppConfigManager.Configuration.AppConfig).ShowDialog();

        }

        private void barBtnRestauracao_ItemClick(object sender, ItemClickEventArgs e)
        {
            new XFrmRestoreBackupSql().ShowDialog();
        }

        #endregion

        #region Data Dictionaries


        #endregion

        #region Audits



        #endregion

        private void XFrmAdminMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            //UserLookAndFeel.Default.ActiveSkinName returns a currently applied skin name.
            //The UserLookAndFeel.Default.StyleChanged event fires in response to changing an active skin.

            var skin = UserLookAndFeel.Default.ActiveSkinName;
            string file = AdminMenuUtil.PREFERENCIAS;
            if (!File.Exists(file))
                FileManagerIts.CreateFile(file);
            FileManagerIts.OverWriteOnFile(file, skin);
        }

        private void barBtnReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (FormsUtil.isFormDisposedOrNull(_xFrmReportList))
            {
                this._xFrmReportList = new XFrmReportList(TypeGroupUser.Administrador);
            }
            FormsUtil.Show(_xFrmReportList, this);

        }

        private void barBtnDashboard_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (FormsUtil.isFormDisposedOrNull(_xFrmDashboardList))
            {
                this._xFrmDashboardList = new XFrmDashboardListView(TypeGroupUser.Administrador);
            }
            FormsUtil.Show(this._xFrmDashboardList, this);
        }

        private void barBtnLicManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (FormsUtil.isFormDisposedOrNull(_xFrmLicenseManager))
            {
                this._xFrmLicenseManager = new XFrmLicenseManager();
            }
            FormsUtil.Show(this._xFrmLicenseManager, this);
        }

        private void barBtnTransaction_ItemClick(object sender, ItemClickEventArgs e)
        {

        }


    }
}