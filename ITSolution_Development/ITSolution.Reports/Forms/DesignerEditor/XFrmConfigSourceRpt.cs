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
using ITSolution.Framework.GuiUtil;
using ITSolution.Reports.Forms.ConsultasSQL;
using ITSolution.Reports.Repositorio;
using ITSolution.Framework.Beans.Forms;
using DevExpress.XtraReports.UI;
using ITSolution.Framework.ConnectionFactory;
using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.ConnectionParameters;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Forms;
using ITSolution.Framework.Common.BaseClasses.Reports;

namespace ITSolution.Reports.Forms.DesignerEditor
{
    public partial class XFrmConfigSourceRpt : DevExpress.XtraEditors.XtraForm
    {
        public DataSet dsConsultasReport { get; set; }
        private XtraReport report;
        private ReportImage reportImageAnt;
        private List<ReportDataSource> sourceReport;

        public XFrmConfigSourceRpt()
        {
            InitializeComponent();
        }

        public XFrmConfigSourceRpt(XtraReport report, ReportImage reportImageAnt) : this()
        {
            this.reportImageAnt = reportImageAnt;
            this.report = report;

            //se for um relatório novo que está sendo criado...
            if (reportImageAnt.Datasources.Count == 0)
            {
                this.sourceReport = new List<ReportDataSource>();
            }
            else //edicao
            {
                this.sourceReport = reportImageAnt.Datasources.ToList();
            }
            gridControl1.DataSource = this.sourceReport;
        }

        //Adicionar uma consulta ao datasource do relatorio que esta sendo criado/editado
        private void btnAddConsulta_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var ctx = new ReportContext())
            {
                ctx.LazyLoading(false);
                var paramsFind = new ParamsFindEntity()
                {
                    Context = ctx,
                    Columns = new string[] { "CodigoQuery", "NomeQuery" },
                    Title = "Localizar consulta SQL:",
                    DynamicObject = null
                };

                var selected = XFrmFindEntity.ShowDialogFindEntity<SqlQueryIts>(paramsFind);

                if (selected != null)
                {
                    //recuperando os valores do objeto dinamico
                    //pego o tipo, dps a propriedade que quero, em seguida o valor

                    var codigo = selected.GetType().GetProperty("CodigoQuery").GetValue(selected, null);
                    var nome = selected.GetType().GetProperty("NomeQuery").GetValue(selected, null);
                    //acima, os dados da query

                    var query = ctx.SqlQueryItsDao.Where(c => c.CodigoQuery == codigo).FirstOrDefault();

                    ReportDataSource rptSource = new ReportDataSource()
                    {
                        IdDataSource = Guid.NewGuid().ToString(),
                        Consulta = query,
                        IdQuery = query.IdQuery,
                        IdReport = reportImageAnt.IdReport
                    };

                    sourceReport.Add(rptSource);

                    gridControl1.DataSource = sourceReport;
                    gridControl1.Update();
                    gridView1.RefreshData();
                }
            }
        }

        //aqui vai gerar as consultas..
        private void btnOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.dsConsultasReport = initDsConsultas();
            //adicionando as fontes de dados ao relatorio em edicao
            foreach (var rptSource in sourceReport)
            {
                this.reportImageAnt.Datasources.Add(rptSource);
            }
            this.Close();            
        }

        //Inicializa o dataset com as consultas que pertencem ao relatorio
        private DataSet initDsConsultas()
        {
            try
            {
                using (var ctx = new ReportContext())
                {
                    this.dsConsultasReport = new DataSet("dsReport");
                    ConnectionFactoryIts conn = new ConnectionFactoryIts(ctx.NameOrConnectionString, 90);

                    foreach (var item in sourceReport)
                    {
                        var myTable = new DataTable();
                        myTable = conn.ExecuteQueryDataTable(item.Consulta.CorpoQuery);
                        myTable.TableName = "table_" + item.Consulta.CodigoQuery;
                        dsConsultasReport.Tables.Add(myTable);
                    }

                    return dsConsultasReport;
                }
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessage(ex);
                return null;
            }
            
        }

        private void btnEditConsulta_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var selectedSource = gridView1.GetFocusedRow<ReportDataSource>();

            if (selectedSource != null)
            {
                using (var ctx = new ReportContext())
                {
                    var queryFull = ctx.SqlQueryItsDao
                        .Where(q => q.CodigoQuery == selectedSource.Consulta.CodigoQuery).FirstOrDefault();

                    FormsUtil.ShowDialog(new XFrmAddConsultaSQL(queryFull));
                }
                
            }
        }
    }
}