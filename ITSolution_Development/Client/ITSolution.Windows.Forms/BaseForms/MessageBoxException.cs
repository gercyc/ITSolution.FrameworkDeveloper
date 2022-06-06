﻿using ITSolution.Framework.GuiUtil;
using System;
using System.Reflection;

namespace ITSolution.Framework.Mensagem
{
    public partial class MessageBoxException : DevExpress.XtraEditors.XtraForm
    {
        public MessageBoxException()
        {
            FormsUtil.AddShortcutEscapeOnDispose(this);
            InitializeComponent();
        }
        public static void ShowException(string messagem, Exception exception, string title = null)
        {
            MessageBoxException messageBoxException = new MessageBoxException();

            if (title != null)
                messageBoxException.Text = title;

            messageBoxException.lblMsg.Text = messagem;
            messageBoxException.txtException.Text = exception.Message + Environment.NewLine;

            if(exception is ReflectionTypeLoadException)
            {
                ReflectionTypeLoadException loadException = ((ReflectionTypeLoadException)exception);
                if (loadException.LoaderExceptions != null)
                {
                    foreach (var item in loadException.LoaderExceptions)
                    {
                        messageBoxException.txtException.Text += item.Message + Environment.NewLine;
                    }
                }
            }

            if (exception.InnerException != null)
                messageBoxException.txtInner.Text = exception.InnerException.Message
                    + "\n" + exception.InnerException.StackTrace;

            messageBoxException.txtStack.Text = exception.StackTrace;
            messageBoxException.ShowDialog();
        }
      
        private void btnDispose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lblMsg_TextChanged(object sender, EventArgs e)
        {
            if (lblMsg.Text.Length > 90)

            {
                int size = 25;
                xtraTabControl1.Height -= size;
                this.Height -= size;
            }
        }
    }
}
