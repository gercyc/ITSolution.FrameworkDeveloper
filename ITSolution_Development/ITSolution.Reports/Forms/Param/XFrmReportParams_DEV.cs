using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.Parameters;
using ITSolution.Framework.Beans.ProgressBar;
using DevExpress.XtraSplashScreen;
using ITSolution.Framework.GuiUtil;

namespace ITSolution.Reports.Forms.Param
{
    public partial class XFrmReportParams_DEV : DevExpress.XtraEditors.XtraForm
    {
        private ParameterCollection _parameterCollection;
        public ParameterCollection NewParametros = new ParameterCollection();
        public bool _isCanceled;

        public XFrmReportParams_DEV()
        {
            InitializeComponent();
            FormsUtil.AddShortcutEscapeOnDispose(this);
        }

        public XFrmReportParams_DEV(ParameterCollection parameterCollection)
        {
            InitializeComponent();
            this._parameterCollection = parameterCollection;

            //RepositoryItemLookUpEdit riLookup = new RepositoryItemLookUpEdit();
            //riLookup.DataSource = parameterCollection["IDCliente"].LookUpSettings;
            //riLookup.ValueMember = "IdClifor";
            //riLookup.DisplayMember = "NomeCliFor";

            //gridViewParams.Columns["Value"].ColumnEdit = riLookup;

            var q = from p in parameterCollection.AsEnumerable<Parameter>()
                    select new Parametros
                    {
                        Name = p.Name,
                        Description = p.Description,
                        Value = p.Value
                    };

            gridControlParams.DataSource = q.ToList();
            FormsUtil.AddShortcutEscapeOnDispose(this);
        }

        private void taskReport()
        {
            this._isCanceled = false;

            this.NewParametros.Clear();

            for (int i = 0; i < _parameterCollection.Count; i++)
            {
                #region processo
                Parameter parameter = new Parameter();
                parameter.Name = gridViewParams.GetRowCellValue(i, "Name").ToString();
                //(string)gridParametros[0, i].Value;

                // Specify other parameter properties.
                parameter.Type = _parameterCollection[i].Type;

                parameter.Value = gridViewParams.GetRowCellValue(i, "Value");
                //Convert.ChangeType(gridParametros[2, i].EditedFormattedValue,
                //parameter.Type, System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));
                parameter.Description = gridViewParams.GetRowCellValue(i, "Description").ToString();
                //(string)gridParametros[1, i].Value;
                parameter.Visible = true;

                NewParametros.Add(parameter);

                #endregion
            }

            this.BeginInvoke(new Action(() =>
            {
                this.Dispose();
            }));
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            XFrmWait.StartTask(Task.Run(() => taskReport()), "Gerando relatório...");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this._isCanceled = true;
            this.Dispose();
        }

        /// <summary>
        /// Gera o relatório passando os parametros pelo metodo, sem necessidade de exibir a tela.
        /// </summary>
        /// <param name="parameterCollection"></param>
        /// <param name="parameters"></param>
        public void GerarRelatorio(ParameterCollection parameterCollection, params object[] parameters)
        {
            this._isCanceled = false;
            XFrmWait.ShowSplashScreen("Gerando relatório ");

            //fechada a tela de paramentros
            //agora chame a barra de progresso
            SplashScreenManager.ShowForm(typeof(XFrmWait));

            NewParametros.Clear();
            int i = 0;
            foreach (var p in parameterCollection)
            {

                Parameter parameter = new Parameter();
                parameter.Name = p.Name; // gridViewParams.GetRowCellValue(i, "Name").ToString();

                // Specify other parameter properties.
                parameter.Type = p.Type; // parameterCollection[i].Type;
                //Convert.ChangeType(gridParametros[2, i].EditedFormattedValue,
                //parameter.Type, System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));
                parameter.Description = p.Description;
                //(string)gridParametros[1, i].Value;
                parameter.Visible = true;

                #region processo
                parameter.Value = parameters[i];
                NewParametros.Add(parameter);
                #endregion
                i++;
            }


            SplashScreenManager.CloseForm();
        }

        #region Classe interna

        internal class Parametros
        {
            public String Name { get; set; }
            public String Description { get; set; }
            public Object Value { get; set; }

        }

        #endregion Classe interna

        private void XFrmReportParams_DEV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _isCanceled = true;
            }
        }
    }
}