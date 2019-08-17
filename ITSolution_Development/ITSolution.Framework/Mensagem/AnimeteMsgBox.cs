using ITSolution.Framework.Mensagem;
using System.Drawing;

namespace ITSolution.Framework.Mensagem
{

    public class AnimateMsgBox
    {
        public Size FormSize;
        public AnimateStyle Style;

        public AnimateMsgBox(Size formSize, AnimateStyle style)
        {
            this.FormSize = formSize;
            this.Style = style;
        }
    }
}
