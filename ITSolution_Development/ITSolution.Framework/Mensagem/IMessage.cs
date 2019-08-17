using System.Drawing;
using System.Windows.Forms;

namespace ITSolution.Framework.Mensagem
{
    public interface IMessage
    {
        void Show(string message);

        void Show(string message, string title);

        DialogResult Show(string message, string title, MessageBoxButtons buttons);

        DialogResult Show(string message, string title, MessageBoxButtons buttons, Icon icon);

        DialogResult Show(string message, string title, Buttons buttons, Icone icon, AnimateStyle style);
    }
}
