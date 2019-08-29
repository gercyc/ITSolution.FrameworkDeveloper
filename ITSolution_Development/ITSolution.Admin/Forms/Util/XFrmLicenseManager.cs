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
using ITSolution.Framework.Eventos.GridViewEvents;
using ITSolution.Framework.Beans.ProgressBar;
using ITSolution.Framework.Util;
using ITSolution.Framework.GuiUtil;
using ITSolution.Admin.Entidades.DaoManager;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.BaseClasses.License;
using ITSolution.Framework.BaseClasses.License.POCO;
using ITSolution.Framework.Dao.Contexto;
using ITSolution.Framework.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITSolution.Framework.Common.BaseClasses.CommonEntities;

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
            var ctx = new ITSolutionContext();
            var genCtx = new GenericContextIts<Customer>(AppConfigManager.Configuration.ConnectionString);

            var licenses = await ctx.LicenseDao.FindAllAsync();
            var customers = await genCtx.Dao.FindAllAsync();

            

            this.Invoke(new MethodInvoker(delegate
            {
                gridControlLicenses.DataSource = licenses.ToList();
                this._gridFocusUtil.KeepFocusedRowChanged();
                this.gridViewLicenses.Focus();
            }));

            var menus = await ctx.MenuDao.FindAllAsync();

            this.Invoke(new MethodInvoker(delegate
            {
                gridControlMenusAct.DataSource = menus.ToList();
                this._gridFocusUtil.KeepFocusedRowChanged();

                cbCustomer.Properties.Items.AddRange(customers);

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
            Customer selCust = (Customer)cbCustomer.SelectedItem;
            var cliFor = new Customer
            {
                IdCliFor = selCust.IdCliFor,
                RazaoSocial = selCust.RazaoSocial,
                CpfCnpj = selCust.CpfCnpj,
                NomeEndereco = selCust.NomeEndereco,
                NumeroEndereco = selCust.NumeroEndereco,
                TipoEndereco = selCust.TipoEndereco,
                Complemento = selCust.Complemento,
                Bairro = selCust.Bairro,
                Cep = selCust.Cep,
                Cidade = selCust.Cidade,
                Email = selCust.Email,
                InscricaoEstadual = selCust.InscricaoEstadual,
                InscricaoMunicipal = selCust.InscricaoMunicipal,
                Uf = selCust.Uf,
                Celular = selCust.Celular,
                NomeFantasia = selCust.NomeFantasia,
                NaturezaJuridica = selCust.NaturezaJuridica,
                RG = selCust.RG,
                Pais = selCust.Pais
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
                    Status = menu.Status,
                    ActionController = menu.ActionController,
                    ControllerClass = menu.ControllerClass
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
            try
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
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessage(ex);
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