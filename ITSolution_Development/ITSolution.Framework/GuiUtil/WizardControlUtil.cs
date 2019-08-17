using System.Windows.Forms;

namespace ITSolution.Framework.GuiUtil
{
    public static class WizardControlUtil
    {

        /// <summary>
        /// Foca o botão next do wizard control
        /// </summary>
        /// <param name="wizardControl"></param>
        /// <returns></returns>
        public static void FocusButtonNext(this DevExpress.XtraWizard.WizardControl wizardControl)
        {
            var btnNext = GetButtonNext(wizardControl);

            if (btnNext != null)
                btnNext.Focus();
        }

        /// <summary>
        /// Foca o botão next do wizard control
        /// </summary>
        /// <param name="wizardControl"></param>
        /// <returns></returns>
        private static Control GetButtonNext( DevExpress.XtraWizard.WizardControl wizardControl)
        {
            foreach (Control c in wizardControl.Controls)
            {
                if (c.Text == wizardControl.NextText) return c;
            }
            return null;
        }

    }
}
