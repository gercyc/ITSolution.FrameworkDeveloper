using System;
using System.Threading.Tasks;
using DevExpress.XtraBars;
using ITSolution.Admin.Entidades.DaoManager;
using ITSolution.Admin.Entidades.EntidadesBd;
using ITSolution.Admin.Enumeradores;
using ITSolution.Admin.Forms.View;
using ITSolution.Admin.Reports;
using ITSolution.Framework.Beans.ProgressBar;
using ITSolution.Framework.Enumeradores;
using ITSolution.Framework.GuiUtil;

namespace ITSolution.Admin.Forms.ListView
{
    public partial class XFrmPackageManager : DevExpress.XtraEditors.XtraForm
    {
        private PackageDaoManager pkgManager;

        public XFrmPackageManager()
        {
            InitializeComponent();
            this.pkgManager = new PackageDaoManager();
        }

        #region Metodos 

        private async Task carregarPacotes()
        {
            //this.Invoke(new MethodInvoker(delegate {

            //existe outra thread
            //gridControlPackages.Invoke(new MethodInvoker(delegate
            //{
            //}));
            gridControlPackages.DataSource = await pkgManager.FindAllPackagesNoData();

        }

        private Package isPackage()
        {
            if (gridViewPackages.IsSelectOneRowWarning())
            {
                var dto = gridViewPackages.GetFocusedRow<PackageDTO>();
                return pkgManager.FindPackage(dto.IdPacote);
            }
            return null;
        }

        public void RefreshItemClick()
        {
            ITSolution.Framework.Beans.ProgressBar.XFrmWait.StartTask(carregarPacotes(), "Carregando pacotes");
        }

        #endregion

        #region Eventos

        private void btnNovoPacote_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormsUtil.ShowDialog(new XFrmAddPackage());
        }

        private void btnEditarPacote_ItemClick(object sender, ItemClickEventArgs e)
        {
            var pacote = gridViewPackages.GetFocusedRow() as PackageDTO;
            if (pacote != null)
            {
                //traz o objeto completo (isso evita eu trazer todos os dados de todos os pacotes
                var pkg = pkgManager.FindPackage(pacote.IdPacote);
                FormsUtil.ShowDialog(new XFrmAddPackage(pkg));

                pkg = pkgManager.FindPackage(pacote.IdPacote);
                pacote.Update(pkg);
            }
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshItemClick();
        }

        private void XFrmPackageManager_Shown(object sender, EventArgs e)
        {
            RefreshItemClick();
            gridViewPackages.FocusedRowHandle = 0;
        }

        private void gridViewPackages_DoubleClick(object sender, EventArgs e)
        {
            btnEditarPacote_ItemClick(null, null);
        }

        private void btnReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            var pkg = isPackage();

            if (pkg != null)
            {
                new RptPackageInfo(pkg).Run();

            }
        }

        private void btnPublicarPacote_ItemClick(object sender, ItemClickEventArgs e)
        {
            var pkg = isPackage();

            if (pkg != null)
            {
                if (pkgManager.PublicarPacote(pkg) && pkg.DataPublicacao.HasValue)
                {
                    //atualiza o objeto do grid
                    var dto = gridViewPackages.GetFocusedRow<PackageDTO>();
                    dto.DataPublicacao = pkg.DataPublicacao;
                    dto.Status = pkg.Status;
                    //desativa a permissao
                    btnPublicarPacote.Enabled = false;
                }
            }
        }

        private void btnSaveFile_ItemClick(object sender, ItemClickEventArgs e)
        {
            var pkg = isPackage();
            if (pkg != null)
            {
                pkgManager.SaveFilePacote(pkg);
            }
        }

        private void gridViewPackages_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //atencao a casca (nao eh um pacote)
            var pkg = gridViewPackages.GetFocusedRow<PackageDTO>();

            if (pkg != null)
            {
                //ativa ou nao o botão de salvar arquivo.
                //se o pacote foi publicado, deixar salvar. senão desativa o botao
                if (pkg.Status == TypeStatusPackage.Publicado)
                    btnSaveFile.Enabled = true;
                else 
                    btnSaveFile.Enabled = false;

                //publicar o pacote somente se ele tiver o status de criado, senão nao deixa publicar de novo.
                if (pkg.Status == TypeStatusPackage.Criado)
                    btnPublicarPacote.Enabled = true;
                else
                    btnPublicarPacote.Enabled = false;
            }else
            {
                btnPublicarPacote.Enabled = false;
            }
        }

        #endregion

        private void btnExcluirPacote_ItemClick(object sender, ItemClickEventArgs e)
        {
            //??
        }
    }
}
