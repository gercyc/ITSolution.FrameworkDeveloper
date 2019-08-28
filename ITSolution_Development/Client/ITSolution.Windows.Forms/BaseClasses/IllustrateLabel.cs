using DevExpress.XtraEditors;
using ITSolution.Framework.Util;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ITSolution.Framework.GuiUtil
{
    public class IllustrateLabel
    {
        private Form form;
        private LabelControl lblInfo;
        public string TaskName { get; set; }
        public bool Running { get; set; }

        public IllustrateLabel(Form form, LabelControl lbl, string lblMsg)
        {
            this.form = form;
            this.lblInfo = lbl;
            this.TaskName = lblMsg;
            this.Running = true;
        }

        private delegate void SetTextCallback(string texto);

        private void infoMessage(string texto)
        {
            this.lblInfo.Text = texto;
            this.lblInfo.Visible = true;
        }

        /// <summary>
        /// Faz com o que o label fique piscando
        /// </summary>
        public void RunOscillate()
        {
            string texto = TaskName;

            while (Running)
            {
                try
                {

                    if (this.lblInfo.InvokeRequired)
                    {
                        SetTextCallback d = new SetTextCallback(infoMessage);
                        form.Invoke(d, new object[] { texto });
                    }

                    Thread.Sleep(350);

                    if (this.lblInfo.InvokeRequired)
                    {
                        SetTextCallback d = new SetTextCallback(infoMessage);
                        form.Invoke(d, new object[] { "" });
                    }
                    Thread.Sleep(350);

                    Console.WriteLine("Ilustrando ...");

                }
                catch (ObjectDisposedException ex)
                {
                    LoggerUtilIts.ShowExceptionLogs(ex);
                    //Não importa apenas termine o laço
                    return;
                }

            }
        }


        /// <summary>
        /// Faz com o que o label se move
        /// </summary>
        public void RunMoving()
        {
            if (this.form.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(infoMessage);
                form.Invoke(d, new object[] { TaskName });

                //1/5 do tamanho
                int volta = this.form.Width - lblInfo.Location.X + 100;

                //terminado dps
                while (Running)
                {
                    try
                    {
                        this.lblInfo.BeginInvoke(new Action(() =>
                        {
                        //se atravessou o label pro outro lado do form
                        if (this.lblInfo.Location.X >= volta)
                            //faz o primeiro caracter aparecer do outro lado do form
                            this.lblInfo.Location = new Point(-(volta / 2), this.lblInfo.Location.Y);

                        //faz o label se mover
                        this.lblInfo.Location = new Point(this.lblInfo.Location.X + 1, this.lblInfo.Location.Y);

                        }));
                        Thread.Sleep(10);

                    }
                    catch (ObjectDisposedException ex)
                    {
                        LoggerUtilIts.ShowExceptionLogs(ex);
                        //Não importa apenas termine o laço
                        return;
                    }
                }
            }
        }
    }
}
