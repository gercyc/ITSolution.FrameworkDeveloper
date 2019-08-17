using System;
using System.Linq;
using DevExpress.XtraReports.Parameters;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Beans.ProgressBar;

namespace ITSolution.Reports.Forms.Param
{
    public partial class XFrmReportParams : DevExpress.XtraEditors.XtraForm
    {
        private ParameterCollection _parameterCollection;
        private ParameterCollection _newParametros = new ParameterCollection();
        public bool isCanceled;

        public XFrmReportParams()
        {
            InitializeComponent();
            
        }

        public XFrmReportParams(DevExpress.XtraReports.Parameters.ParameterCollection parameterCollection)
        {
            InitializeComponent();

            this._parameterCollection = parameterCollection;

            var q = from p in parameterCollection.AsEnumerable<Parameter>()
                    select new Parametros
                    {
                        Name = p.Name,
                        Description = p.Description,
                        Value = p.Value
                    };

            gridParametros.DataSource = q.ToList();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.isCanceled = false;

            //fechada a tela de paramentros
            //agora chame a barra de progresso
            XFrmWait.ShowSplashScreen("Gerando relatório...");

            _newParametros.Clear();

            for (int i = 0; i < _parameterCollection.Count; i++)
            {
                #region processo
                Parameter parameter = new Parameter();
                parameter.Name = (string)gridParametros[0, i].Value;

                // Specify other parameter properties.
                parameter.Type = _parameterCollection[i].Type;

                parameter.Value = Convert.ChangeType(gridParametros[2, i].EditedFormattedValue,
                    parameter.Type, System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));
                parameter.Description = (string)gridParametros[1, i].Value;
                parameter.Visible = true;

                _newParametros.Add(parameter);

                #endregion
            }


            XFrmWait.CloseSplashScreen();
            this.Close();

        }
     
        private void btnCancel_Click(object sender, EventArgs e)
        {
            XMessageIts.Advertencia("Geração cancelada pelo usuário");
            this.isCanceled = true;
            this.Close();
        }

        #region Classe interna

        internal class Parametros
        {
            public String Name { get; set; }
            public String Description { get; set; }
            public Object Value { get; set; }

        }

        #endregion Classe interna

    }
}