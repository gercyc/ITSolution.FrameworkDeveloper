using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using ITSolution.Framework.Mensagem;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace ITSolution.Framework.GuiUtil
{
    //Classe a ser reformulada
    public class ComponenteUtil
    {
        private enum ActionPerfomace
        {

            Visible = 0,
            Enable = 1,
            ReadyOnly = 2

        }
        /// <summary>
        /// TextEdit
        /// TextBox
        /// RadioGroup
        /// CheckBox
        /// ComboBox
        /// CheckEdit
        /// ComboEdit
        /// MemoEdit
        /// Componentes do Windows.Forms sera desativados pois nao possuem o metodo EditValue
        /// </summary>
        /// <param name="componentes"></param>
        /// <param name="action"></param>
        public static void HabilitarDesabilitar(Component[] componentes, bool action)
        {
            foreach (var comp in componentes)
            {
                if (comp != null)
                {
                    if (comp.GetType() == typeof(TextEdit))
                    {
                        TextEdit c = comp as TextEdit;
                        c.Enabled = action;
                    }

                    else if (comp.GetType() == typeof(TextBox))
                    {
                        TextBox c = comp as TextBox;
                        c.Enabled = action;
                    }
                    else if (comp.GetType() == typeof(Label))
                    {
                        Label c = comp as Label;
                        c.Enabled = action;
                    }

                    else if (comp.GetType() == typeof(RadioGroup))
                    {
                        RadioGroup c = comp as RadioGroup;
                        c.Enabled = action;
                    }
                    else if (comp.GetType() == typeof(GroupControl))
                    {
                        GroupControl c = comp as GroupControl;
                        c.Enabled = action;
                    }

                    else if (comp.GetType() == typeof(Button))
                    {
                        Button c = comp as Button;
                        c.Enabled = action;
                    }

                    else if (comp.GetType() == typeof(SimpleButton))
                    {
                        SimpleButton c = comp as SimpleButton;
                        c.Enabled = action;
                    }
                    else if (comp.GetType() == typeof(CheckBox))
                    {
                        CheckBox c = comp as CheckBox;
                        c.Enabled = action;
                    }

                    else if (comp.GetType() == typeof(CheckEdit))
                    {
                        CheckEdit c = comp as CheckEdit;
                        c.Enabled = action;
                    }

                    else if (comp.GetType() == typeof(System.Windows.Forms.ComboBox))
                    {
                        System.Windows.Forms.ComboBox c = comp as System.Windows.Forms.ComboBox;
                        c.Enabled = action;
                    }

                    else if (comp.GetType() == typeof(ComboBoxEdit))
                    {
                        ComboBoxEdit c = comp as ComboBoxEdit;
                        c.Enabled = action;
                    }
                    else if (comp.GetType() == typeof(DateEdit))
                    {
                        DateEdit c = comp as DateEdit;
                        c.Enabled = action;
                    }
                    else if (comp.GetType() == typeof(DateTimePicker))
                    {
                        DateTimePicker c = comp as DateTimePicker;
                        c.Enabled = action;
                    }

                    else if (comp.GetType() == typeof(TableLayoutPanel))
                    {
                        var c = comp as TableLayoutPanel;
                        c.Enabled = action;
                    }
                    else if (comp.GetType() == typeof(RibbonControl))
                    {
                        var c = comp as RibbonControl;
                        c.Enabled = action;
                    }
                    else if (comp.GetType() == typeof(BarButtonItem))
                    {
                        var c = comp as BarButtonItem;
                        c.Enabled = action;
                    }
                    else if (comp.GetType() == typeof(MemoEdit))
                    {
                        var c = comp as MemoEdit;
                        c.Enabled = action;
                    }
                    else if (comp.GetType() == typeof(TimeEdit))
                    {
                        var c = comp as TimeEdit;
                        c.Enabled = action;
                    }
                    else if (comp.GetType() == typeof(RichTextBox))
                    {
                        var c = comp as RichTextBox;
                        c.Enabled = action;
                    }
                    else if (comp.GetType() == typeof(LabelControl))
                    {
                        var c = comp as LabelControl;
                        c.Enabled = action;
                    }
                    else if (comp.GetType() == typeof(GroupBox))
                    {
                        var c = comp as GroupBox;
                        c.Enabled = action;
                    }
                    else
                    {
                        Trace.WriteLine("Tipo de componente a ser desabilitado desconhecido " + comp.GetType());
                    }
                }
            }
        }

        public static void HabilitarComponentes(params Component[] componentes)
        {
            HabilitarDesabilitar(componentes, true);

        }

        public static void DesabilitarComponentes(params Component[] componentes)
        {
            HabilitarDesabilitar(componentes, false);

        }

        /// <summary>
        /// Torna visible ou invisivel
        /// TextEdit
        /// TextBox
        /// RadioGroup
        /// CheckBox
        /// ComboBox
        /// CheckEdit
        /// ComboEdit
        /// MemoEdit
        /// </summary>
        /// <param name="componentes"></param>
        /// <param name="action"></param>
        public static void ShowHideComponentes(Component[] componentes, bool action)
        {
            foreach (var comp in componentes)
            {
                if (comp != null)
                {
                    if (comp.GetType() == typeof(TextEdit))
                    {
                        TextEdit c = comp as TextEdit;
                        c.Visible = action;
                    }

                    else if (comp.GetType() == typeof(TextBox))
                    {
                        TextBox c = comp as TextBox;
                        c.Visible = action;
                    }
                    else if (comp.GetType() == typeof(Label))
                    {
                        Label c = comp as Label;
                        c.Visible = action;
                    }

                    else if (comp.GetType() == typeof(RadioGroup))
                    {
                        RadioGroup c = comp as RadioGroup;
                        c.Visible = action;
                    }
                    else if (comp.GetType() == typeof(GroupControl))
                    {
                        GroupControl c = comp as GroupControl;
                        c.Visible = action;
                    }

                    else if (comp.GetType() == typeof(Button))
                    {
                        Button c = comp as Button;
                        c.Visible = action;
                    }

                    else if (comp.GetType() == typeof(SimpleButton))
                    {
                        SimpleButton c = comp as SimpleButton;
                        c.Visible = action;
                    }
                    else if (comp.GetType() == typeof(CheckBox))
                    {
                        CheckBox c = comp as CheckBox;
                        c.Visible = action;
                    }

                    else if (comp.GetType() == typeof(CheckEdit))
                    {
                        CheckEdit c = comp as CheckEdit;
                        c.Visible = action;
                    }

                    else if (comp.GetType() == typeof(System.Windows.Forms.ComboBox))
                    {
                        System.Windows.Forms.ComboBox c = comp as System.Windows.Forms.ComboBox;
                        c.Visible = action;
                    }

                    else if (comp.GetType() == typeof(ComboBoxEdit))
                    {
                        ComboBoxEdit c = comp as ComboBoxEdit;
                        c.Visible = action;
                    }
                    else if (comp.GetType() == typeof(DateEdit))
                    {
                        DateEdit c = comp as DateEdit;
                        c.Visible = action;
                    }
                    else if (comp.GetType() == typeof(DateTimePicker))
                    {
                        DateTimePicker c = comp as DateTimePicker;
                        c.Visible = action;
                    }
                    else if (comp.GetType() == typeof(MemoEdit))
                    {
                        MemoEdit c = comp as MemoEdit;
                        c.Visible = action;
                    }
                }
            }

        }


        public static void ReadyOnly(bool action, params Component[] componentes)
        {
            foreach (var comp in componentes)
            {
                if (comp != null)
                {
                    if (comp.GetType() == typeof(TextEdit))
                    {
                        TextEdit c = comp as TextEdit;
                        c.ReadOnly = action;
                    }

                    else if (comp.GetType() == typeof(RadioGroup))
                    {
                        RadioGroup c = comp as RadioGroup;
                        c.ReadOnly = action;
                    }

                    else if (comp.GetType() == typeof(DateEdit))
                    {
                        DateEdit c = comp as DateEdit;
                        c.ReadOnly = action;
                    }

                    else if (comp.GetType() == typeof(ComboBoxEdit))
                    {
                        ComboBoxEdit c = comp as ComboBoxEdit;
                        c.ReadOnly = action;
                    }
                    else if (comp.GetType() == typeof(MemoEdit))
                    {
                        var c = comp as MemoEdit;
                        c.ReadOnly = action;
                    }
                    else if (comp.GetType() == typeof(TimeEdit))
                    {
                        var c = comp as TimeEdit;
                        c.ReadOnly = action;
                    }
                    else if (comp.GetType() == typeof(RichTextBox))
                    {
                        var c = comp as RichTextBox;
                        c.ReadOnly = action;
                    }
                    else
                    {
                        MessageBoxBlack.Show("Ready only for " + comp.GetType() + " not implemented or not supported.");
                    }
                }
            }

        }

    }
}
