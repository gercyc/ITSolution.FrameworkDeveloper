using DevExpress.XtraEditors;
using ITSolution.Framework.Entities;
using System;
using System.Collections.Generic;

namespace ITSolution.Framework.Beans.Forms
{
    public partial class XFrmClienteView : XtraForm
    {
        public object ClienteFocused { get; private set; }
        private List<AbstractClient> clientes;

        public XFrmClienteView(List<AbstractClient> clientes)
        {
            InitializeComponent();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            this.clientes = clientes;
        }

        private void barBtnSelecionarCliente_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = gridViewCliFor.GetFocusedRow();

            if (row != null)
                this.ClienteFocused = row as AbstractClient;

        }

        private void XFrmInfoCliente_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Escape)
            {
                this.ClienteFocused = null;
                this.Dispose();
            }
        }

        private void gridViewCliFor_DoubleClick(object sender, EventArgs e)
        {
            barBtnSelecionarCliente_ItemClick(null, null);
        }

        private void gridViewCliFor_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            barBtnSelecionarCliente_ItemClick(null, null);
        }
    }
}