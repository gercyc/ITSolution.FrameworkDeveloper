using System;
using System.Collections.Generic;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using ITSolution.Framework.Web.JSON;

namespace ITSolution.Framework.Beans.Forms
{
    public partial class XFrmWebServiceCNPJ : DevExpress.XtraEditors.XtraForm
    {
        //base teste -> 27865757000102
        const string receitaWsUrl = @"https://www.receitaws.com.br/v1/cnpj/";
        private List<LayoutReceitaWS> lista = new List<LayoutReceitaWS>();
        /// <summary>
        /// Os dados da empresa atualizados pela receita federal
        /// </summary>
        public LayoutReceitaWS ResultValidation { get; private set; }

        public XFrmWebServiceCNPJ()
        {
            InitializeComponent();
        }

        private void barBtnSerialiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            object o = barEd.EditValue;
            string cnpj = o != null ? o.ToString() : "";

            if (!string.IsNullOrWhiteSpace(cnpj))
            {
                cnpj = StringUtilIts.FixString(cnpj);
                String json = JSONHelper.GetJSONString(receitaWsUrl + cnpj);
                //var r = JSONHelper.GetObjectFromJSONString<LayoutReceitaWS>(json);
                //JsonConvert.DeserializeObject<LayoutReceitaWS>(json);
                this.ResultValidation = LayoutReceitaWS.GetDataFromCNPJ(cnpj);//

                this.lista .Clear();
                this.lista.Add(ResultValidation);
                this.mEditJSON.Text = json;
                this.gridControl1.DataSource = lista;
                this.gridViewSerializable.RefreshData();
            }else
            {
                MessageBoxBlack.Show("CNPJ " + cnpj + " inválido !");
            }
        }

        private void barBtnOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBoxTick.Show("Thank you for using!", "Bye xD", 5);
            this.Dispose();
        }
    }
}