using DevExpress.XtraBars;
using System;
using System.Threading;
using System.Windows.Forms;

namespace ITSolution.Framework.GuiUtil
{
    public class IllustrateBarItem
    {
        private Form form;
        private BarItem barItem;
        private string TaskName;
        public int Intervalo { get; set; }
        public bool Running { get; set; }
        public IllustrateBarItem(Form form, BarItem barItem, String taskName = "Tarefa concluída")
        {
            this.form = form;
            this.barItem = barItem;
            this.TaskName = taskName;
            this.Running = true;
            this.Intervalo = 400;

        }

        private delegate void SetTextCallback(string texto);

        private void infoMessage(string texto)
        {
            this.barItem.Caption = texto;
            this.barItem.Visibility = BarItemVisibility.Always;
        }

        /// <summary>
        /// Exibe uma mensagem no label
        /// </summary>
        public void Run()
        {
            string texto = TaskName;

            while (Running)
            {
                try
                {

                    SetTextCallback d = new SetTextCallback(infoMessage);
                    form.Invoke(d, new object[] { texto });

                    Thread.Sleep(Intervalo);

                    d = new SetTextCallback(infoMessage);
                    form.Invoke(d, new object[] { "" });

                    Thread.Sleep(Intervalo/2);

                    Console.WriteLine("Ilustrando ...");

                }
                catch 
                {
                    //Não importa apenas termine o laço
                    return;
                }

            }
        }


    }
}
