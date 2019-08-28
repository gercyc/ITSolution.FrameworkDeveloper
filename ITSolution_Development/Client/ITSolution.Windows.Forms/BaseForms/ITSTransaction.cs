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
using ITSolution.Framework.BaseInterfaces;
using ITSolution.Framework.Common.BaseClasses;

namespace ITSolution.Framework.Windows.BaseForms
{
    public partial class ITSTransaction : DevExpress.XtraEditors.XtraForm, IITSTransaction
    {
        public TransactionInfo _transactionInfo { get; set; }
        

        public ITSTransaction()
        {
            InitializeComponent();
            this.Shown += DoShow;
        }
        public IITSTools ITSTools { get; set; }

        public string TransactionShortcut { get { return _transactionInfo.TransactionShortcut; } }

        public TransactionInfo TransactionInfo { get { return _transactionInfo; } set {  } }

        private void ITSTransaction_Load(object sender, EventArgs e)
        {

        }
        protected virtual void DoShow(object sender, EventArgs e)
        {
            this.Text = GetTransactionText();
        }

        public virtual string GetTransactionText()
        {
            if (_transactionInfo != null)
                return _transactionInfo.TransactionDescription;
            else
                return this.Text;
        }
    }
}