using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ITE.Entidades.Repositorio;
using ITSolution.Framework.Eventos.GridViewEvents;
using ITSolution.Framework.Beans.ProgressBar;
using ITE.Entidades.POCO.Base;
using ITSolution.Framework.Util;
using ITSolution.Framework.GuiUtil;
using ITSolution.Admin.Entidades.DaoManager;
using ITSolution.Framework.Mensagem;

namespace ITSolution.Admin.Forms.Util
{
    public partial class XFrmLicenseManager : DevExpress.XtraEditors.XtraForm
    {
        private readonly FocusRowChangedEvent _gridFocusUtil;
        private List<ItsMenu> menuSelected;
        private ItsLicense _selectedLicense;
        public XFrmLicenseManager()
        {
            InitializeComponent();
            this._gridFocusUtil = new FocusRowChangedEvent(gridViewLicenses);

        }
        private async Task FillData()
        {
            var ctx = new BalcaoContext();

            var licenses = await ctx.LicenseDao.FindAllAsync();

            this.Invoke(new MethodInvoker(delegate
            {
                gridControlLicenses.DataSource = licenses.ToList();
                this._gridFocusUtil.KeepFocusedRowChanged();
                this.gridViewLicenses.Focus();
            }));

            var menus = await ctx.ItsMenuDao.FindAllAsync();

            this.Invoke(new MethodInvoker(delegate
            {
                gridControlMenusAct.DataSource = menus.ToList();
                this._gridFocusUtil.KeepFocusedRowChanged();
            }));

        }

        private void XFrmLicenseManager_Shown(object sender, EventArgs e)
        {
            XFrmWait.StartTask(FillData(), "Carregando dados");
        }

        private void btnSaveLicense_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var mng = new LicenseDaoManager();
                if (mng.SaveOrUpdateLicense(indexarLicenca()))
                {
                    XMessageIts.Mensagem("Licença criada com sucesso!");
                    //atualiza..
                    XFrmLicenseManager_Shown(null, null);
                }
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessage(ex);
            }
           
        }
        private ItsLicense indexarLicenca()
        {
            var lic = new ItsLicense();

            var cliFor = new ITE.Entidades.POCO.CliFor()
            {
                //IdCliFor = lookUpCliFor1.CliFor.IdCliFor,
                //RazaoSocial = lookUpCliFor1.CliFor.RazaoSocial,
                //CpfCnpj = lookUpCliFor1.CliFor.CpfCnpj,
                //NomeEndereco = lookUpCliFor1.CliFor.NomeEndereco,
                //NumeroEndereco = lookUpCliFor1.CliFor.NumeroEndereco,
                //TipoEndereco = lookUpCliFor1.CliFor.TipoEndereco,
                //Complemento = lookUpCliFor1.CliFor.Complemento,
                //Bairro = lookUpCliFor1.CliFor.Bairro,
                //Cep = lookUpCliFor1.CliFor.Cep,
                //Cidade = lookUpCliFor1.CliFor.Cidade,
                //Classificacao = lookUpCliFor1.CliFor.Classificacao,
                //Email = lookUpCliFor1.CliFor.Email,
                //InscricaoEstadual = lookUpCliFor1.CliFor.InscricaoEstadual,
                //InscricaoMunicipal = lookUpCliFor1.CliFor.InscricaoMunicipal,
                //Uf = lookUpCliFor1.CliFor.Uf,
                //Celular = lookUpCliFor1.CliFor.Celular,
                //NomeFantasia = lookUpCliFor1.CliFor.NomeFantasia,
                //NaturezaJuridica = lookUpCliFor1.CliFor.NaturezaJuridica,
                //RG = lookUpCliFor1.CliFor.RG,
                //Pais = lookUpCliFor1.CliFor.Pais
            };

            var startDate = dtStartDate.DateTime;
            var endDate = dtEndDate.DateTime;

            this.menuSelected = new List<ItsMenu>();

            foreach (var menu in (List<ItsMenu>)gridViewMenusAct.DataSource)
            {
                var newMenu = new ItsMenu()
                {
                    IdMenu = menu.IdMenu,
                    MenuPai = menu.MenuPai,
                    MenuText = menu.MenuText,
                    MenuType = menu.MenuType,
                    NomeMenu = menu.NomeMenu,
                    Status = menu.Status
                };

                this.menuSelected.Add(newMenu);
            }

            lic.CustomerName = cliFor.RazaoSocial;
            lic.StartDate = startDate;
            lic.EndDate = endDate;

            //se selecionou nenhuma licenca e o id ja existir no banco
            if (this._selectedLicense != null && this._selectedLicense.IdLicense != 0)
            {
                lic.IdLicense = this._selectedLicense.IdLicense;
            }

            var licData = new ItsLicenseData()
            {
                Cliente = cliFor,
                DataInicioLic = startDate,
                DataFimLic = endDate,
                ActiveMenus = this.menuSelected
            };

            lic.LicenseData = SerializeIts.SerializeObject(licData);

            return lic;
        }

        //indexa o form com os dados da licença focused no grid
        private void gridViewLicenses_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            this._selectedLicense = gridViewLicenses.GetFocusedRow<ItsLicense>();
            indexarForm(this._selectedLicense);
        }

        //indexa o form com os dados da licença focused no grid
        private void indexarForm(ItsLicense itsLicense)
        {
            if (itsLicense != null)
            {
                var licData = SerializeIts.DeserializeObject<ItsLicenseData>(itsLicense.LicenseData);
                var clifor = licData.Cliente;
                var startDate = licData.DataInicioLic;
                var endDate = licData.DataFimLic;
                var activeMenus = licData.ActiveMenus;

                //lookUpCliFor1.FindSetCliFor(clifor.IdCliFor.ToString());
                dtStartDate.DateTime = startDate;
                dtEndDate.DateTime = endDate;
                gridControlMenusAct.DataSource = activeMenus;
            }
        }

        //pediu nova licença, zerar tudo do form...
        private void btnNewLicense_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this._selectedLicense = new ItsLicense();
            //lookUpCliFor1.CliFor = null;
            //lookUpCliFor1.LabelText = "";
            //lookUpCliFor1.TextCodCliFor.Text = "";
            dtStartDate.Text = "";
            dtEndDate.Text = "";
        }
    }
}