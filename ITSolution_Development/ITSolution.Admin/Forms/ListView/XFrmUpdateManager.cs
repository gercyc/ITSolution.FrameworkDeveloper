using System.Threading.Tasks;
using DevExpress.XtraBars;
using ITSolution.Admin.Repositorio;
using System.Linq;
using System.Data.Entity;
using ITSolution.Framework.Beans.ProgressBar;
using ITSolution.Framework.Beans.Forms;
using ITSolution.Admin.Entidades.EntidadesBd;
using ITSolution.Framework.GuiUtil;

namespace ITSolution.Admin.Forms.ListView
{
    public partial class XFrmUpdateManager : DevExpress.XtraEditors.XtraForm
    {
        public XFrmUpdateManager()
        {
            InitializeComponent();
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            XFrmWait.StartTask(carregarPacotes(), "Carregando pacotes instalados");
        }

        private async Task carregarPacotes()
        {
            using (var ctx = new AdminContext())
            {
                ctx.LazyLoading(false);

                var lista = await ctx.UpdateInfoDao.FindAllAsync();

                gridControlUpdates.DataSource = lista.OrderBy(p=>p.NumeroPacote);
            }
        }

        private void XFrmUpdateManager_Shown(object sender, System.EventArgs e)
        {
            btnRefresh_ItemClick(null, null);
        }

        private void gridViewUpdates_DoubleClick(object sender, System.EventArgs e)
        {
            var sel = gridViewUpdates.GetFocusedRow<UpdateInfo>();
            if (sel != null)
                XFrmOptionPane.ShowTextArea("LOG:", "Informações da aplicação do pacote", sel.LogAplicacao);
        }
    }
}