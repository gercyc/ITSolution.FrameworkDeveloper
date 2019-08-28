using DevExpress.XtraBars.Ribbon;
using ITSolution.Framework.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITSolution.Framework.BaseInterfaces
{
    public interface IITSDesktop
    {
        void SetMenu(RibbonControl ribbonControl);
        FormWindowState SetFormWindowState(FormWindowState formWindowState);
        bool IsMdiContainer { get; }
        DialogResult ResultLogin { get; }
        Type GetApplicationObj();
        IITSDesktop Desktop { get; }
        IITSTools ITSTools { get; }
    }
}
