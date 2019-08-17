using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITSolution.Framework.Beans.ProgressBar;
using ITSolution.Framework.Dao.Contexto;
using ITSolution.Framework.Entities;
using ITSolution.Framework.GuiUtil;
using ITSolution.Framework.Mensagem;

namespace ITSolution.Framework.Forms
{
    public sealed partial class XFrmAgendaContatos : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private List<Contato> contatos;
        public XFrmAgendaContatos()
        {
            InitializeComponent();
        }


        private async Task carregarAgenda()
        {
            using (var ctx = new ITSolutionContext())
            {
                //performance em ate 60% mais rapido
                this.contatos = await ctx.Contatos
                    .ToListAsync();

                gridView1.FindFilterText = "";
                gridControlContato.DataSource = contatos;

            }
        }

        #region Eventos
        private void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XFrmWait.StartTask(carregarAgenda(), "Carregando Contatos");

        }

        private void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var xFrmCliFor = new XFrmContato();
            xFrmCliFor.ShowDialog();

            if (xFrmCliFor.IsUpdate)
            {
                this.contatos.Add(xFrmCliFor.Contato);
                gridView1.RefreshData();
            }
        }

        private void barBtnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.IsSelectOneRowWarning())
            {
                var c = gridView1.GetFocusedRow() as Contato;

                var frm = new XFrmContato(c);
                frm.ShowDialog();

                if (frm.IsUpdate)
                {
                    c.Update(frm.Contato);
                }
            }
        }

        private void barBtnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.IsSelectOneRowWarning())
            {
                var c = gridView1.GetFocusedRow() as Contato;

                var op = XMessageIts.Confirmacao("Deseja apagar o contato " + c.NomeContato + " da agenda ?");
                if (op == DialogResult.Yes)
                {
                    using (var ctx = new ITSolutionContext())
                    {
                        var contato = ctx.ContatoDao.Find(c.IdContato);
                        ctx.ContatoDao.Delete(contato);
                    }
                }
            }
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            barBtnEdit_ItemClick(null, null);
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                barBtnRefresh_ItemClick(null, null);
        }

     

        private void XFrmAgendaContato_Shown(object sender, EventArgs e)
        {
            barBtnRefresh_ItemClick(null, null);
        }

      
        #endregion

        #region Search Control
        private void searchControl1_EditValueChanged(object sender, EventArgs e)
        {
            string search = "" + searchControl1.EditValue;

            if (string.IsNullOrEmpty(search))
            {
                barBtnRefresh_ItemClick(null, null);

            }
        }

        private async void searchControl1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string pesquisa = "" + searchControl1.EditValue;
                if (!string.IsNullOrEmpty(pesquisa))
                {

                    using (var ctx = new ITSolutionContext())
                    {


                        //carregando apenas os clientes
                        var lista = await ctx.Contatos.ToListAsync();

                        gridControlContato.DataSource = lista;
                        this.gridView1.FindFilterText = pesquisa;
                    }
                }

            }
        }

        #endregion


    }
}