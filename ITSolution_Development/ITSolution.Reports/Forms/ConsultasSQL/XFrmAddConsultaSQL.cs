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
using ITSolution.Reports.Repositorio;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Common.BaseClasses.Reports;

namespace ITSolution.Reports.Forms.ConsultasSQL
{
    public partial class XFrmAddConsultaSQL : DevExpress.XtraEditors.XtraForm
    {
        private SqlQueryIts selectedQuery;

        public XFrmAddConsultaSQL()
        {
            InitializeComponent();
        }

        public XFrmAddConsultaSQL(SqlQueryIts selectedQuery) : this()
        {
            this.selectedQuery = selectedQuery;
            indexarFormulario(selectedQuery);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private SqlQueryIts indexarConsulta()
        {
            SqlQueryIts cons = new SqlQueryIts()
            {
                CodigoQuery = txtCodQuery.Text,
                NomeQuery = txtNomeQuery.Text,
                CorpoQuery = memCorpoQuery.Text
            };

            return cons;
        }

        private void indexarFormulario(SqlQueryIts consulta)
        {
            if (consulta != null)
            {
                txtCodQuery.Text = consulta.CodigoQuery;
                txtNomeQuery.Text = consulta.NomeQuery;
                memCorpoQuery.Text = consulta.CorpoQuery;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //adicao de nova consulta
                if (this.selectedQuery == null)
                {
                    using (var ctx = new ReportContext())
                    {
                        var consultaSalvar = indexarConsulta();
                        //ID da consulta
                        consultaSalvar.IdQuery = Guid.NewGuid().ToString();
                        consultaSalvar.DataCriacao = DateTime.Now;

                        var result = ctx.SqlQueryItsDao.Save(consultaSalvar);
                        if (result)
                        {
                            XMessageIts.Mensagem("Consulta adicionada com sucesso!");
                            this.Dispose();
                        }
                    }
                }
                //edicao de consulta
                else
                {
                    using (var ctx = new ReportContext())
                    {
                        var consultaEdit = ctx.SqlQueryItsDao.Find(selectedQuery.IdQuery);
                        consultaEdit.Update(indexarConsulta());

                        var resultUpd = ctx.SqlQueryItsDao.Update(consultaEdit);
                        if (resultUpd)
                        {
                            XMessageIts.Mensagem("Consulta atualizada com sucesso!");
                            this.Dispose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessage(ex);
            }
        }
    }
}