using System;
using ITSolution.Framework.Dao.Contexto;
using ITSolution.Framework.Entities;

namespace ITSolution.Framework.Forms
{
    public sealed partial class XFrmLembrete : DevExpress.XtraEditors.XtraForm
    {
        public Lembrete Lembrete { get; private set; }
        public bool IsUpdate { get; private set; }

        public XFrmLembrete()
        {
            InitializeComponent();
        }

        public XFrmLembrete(Lembrete lembrete) : this()
        {
            this.Lembrete = lembrete;

            this.txtNome.Text = lembrete.NomeLembrete;
            this.memoEditLembrete.Text = lembrete.Texto;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var lembrete = indexarLembrete();

            if (new LembreteDaoManager().SaveUpdate(lembrete))
            {
                this.IsUpdate = true;

                this.Lembrete = lembrete;
                this.Dispose();
            }
        }


        private Lembrete indexarLembrete()
        {
            var lembrete = new Lembrete(txtNome.Text, memoEditLembrete.Text);

            if (this.Lembrete != null)
                lembrete.IdLembrete = this.Lembrete.IdLembrete;

            return lembrete;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void XFrmLembrete_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Modifiers == System.Windows.Forms.Keys.Control && e.KeyCode == System.Windows.Forms.Keys.S)
                btnSalvar_Click(null, null);
        }
    }
}