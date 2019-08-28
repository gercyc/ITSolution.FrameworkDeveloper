using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using ITSolution.Framework.BaseClasses;
using ITSolution.Framework.BaseInterfaces;
using ITSolution.Framework.Common.BaseClasses;
using ITSolution.Framework.Dao.Contexto;
using ITSolution.Framework.Entities;
using ITSolution.Framework.Forms;
using ITSolution.Framework.Listeners;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITSolution.Framework.Windows.BaseForms
{
    public partial class ITSAncestorDesktop : XtraForm, IITSDesktop
    {
        ITSApplication application;
        public DialogResult ResultLogin { get; private set; } = DialogResult.Cancel;
        public IITSTools ITSTools { get { return application; } }
        public RibbonControl Ribbon { get; set; }
        public ITSAncestorDesktop()
        {
            InitializeComponent();

            if (!this.DesignMode)
            {
                application = (ITSApplication)Activator.CreateInstance(GetApplicationObj(), this);
                //ShowLoginForm();
            }
        }
        
        public Type GetApplicationObj()
        {
            return typeof(ITSApplication);
        }
        public IITSDesktop Desktop
        {
            get
            {
                return this;
            }
        }

        protected virtual Type GetLoginForm()
        {
            return typeof(XFrmLogin);
        }
        protected virtual void ShowLoginForm()
        {
            var loginForm = (Form)Activator.CreateInstance(GetLoginForm(), application);

            if (loginForm is XFrmLogin _xFrmLogin)
            {
                _xFrmLogin.ShowDialog();
                if (_xFrmLogin.IsLogin)
                {
                    ResultLogin = DialogResult.OK;
                }
                if (!_xFrmLogin.IsLogin)
                    Environment.Exit(0);
            }

            if (!loginForm.IsDisposed)
                loginForm.ShowDialog();

        }

        #region IITSDesktop implementation
        public FormWindowState SetFormWindowState(FormWindowState formWindowState)
        {
            this.WindowState = formWindowState;
            return formWindowState;
        }


        public virtual void SetMenu(RibbonControl ribbonControl)
        {
            if (ribbonControl != null)
            {
                this.Ribbon = ribbonControl;
                //ribbonStatusBar1.Ribbon = this.Ribbon;
                //ribbonStatusBar1.Visible = true;
            }
        }
        #endregion

    }
}