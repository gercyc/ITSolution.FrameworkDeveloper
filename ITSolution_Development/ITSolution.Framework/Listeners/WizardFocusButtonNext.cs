using DevExpress.XtraWizard;
using ITSolution.Framework.GuiUtil;

namespace ITSolution.Framework.Listeners
{
    //https://www.devexpress.com/Support/Center/Question/Details/Q248868/set-focus-to-next-button
    public static class WizardFocusButtonNext
    {
        //private readonly DevExpress.XtraWizard.WizardControl _wizardControl;

        //public WizardFocusButtonNext(WizardControl wizardControl)
        //{
        //    _wizardControl = wizardControl;
        //}

        /// <summary>
        /// Todas as paginas terão foco inicial no botão "next"
        /// </summary>
        private static void OnSelectedPageChanged(object sender, WizardPageChangedEventArgs e)
        {
            if (sender is WizardControl)
            {
                var wc = sender as WizardControl;

                wc.FocusButtonNext();
            }
            
        }

        /// <summary>
        /// Todas as paginas terão foco inicial no botão "Next" (Avançar)
        /// </summary>
        public static void EnableSelectedPageChanged(this WizardControl wizardControl)
        {
            //foreach (BaseWizardPage wpage in this._wizardControl.Pages)
            //{
            //    wpage.PageInit += this.Page_PageInit;
            //}
            wizardControl.SelectedPageChanged += OnSelectedPageChanged;
        }
        
        //private void Page_PageInit(object sender, EventArgs e)
        //{
        //    _wizardControl.GetButtonNext().Focus();
        //}

    }
}
