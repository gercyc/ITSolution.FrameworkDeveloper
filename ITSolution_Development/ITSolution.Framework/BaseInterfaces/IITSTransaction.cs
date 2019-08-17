using ITSolution.Framework.Common.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITSolution.Framework.BaseInterfaces
{
    /// <summary>
    /// Interface criada para reutilizar os forms ja existentes
    /// </summary>
    public interface IITSTransaction
    {
        string TransactionShortcut { get; }
        TransactionInfo TransactionInfo { get; set; }
        string GetTransactionText();
        void Show();
        DialogResult ShowDialog();
        Form MdiParent { get; set; }
        IITSTools ITSTools { get; set; }
    }
}
