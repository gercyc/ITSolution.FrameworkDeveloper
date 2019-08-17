using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ITSolution.Framework.Arquivos;
using ITSolution.Framework.Mensagem;

namespace ITSolution.Framework.Util
{
    /// <summary>
    /// Metódos por reflexão
    /// </summary>
    public static class ReflectionIts
    {
        //http://www.devmedia.com.br/trabalhando-com-reflection-em-c/26871


        //public Dictionary<string, object> TValue { get; set; }

        public static object CreateInstance(Type type)
        {
            return Activator.CreateInstance(type);
        }

        public static object CreateInstance(string classe)
        {
            var type = GetType(classe);
            return Activator.CreateInstance(type);
        }

        public static Type GetType(string className)
        {
            try
            {
                return Type.GetType(className);
            }
            catch (TypeLoadException tle)
            {
                var msg = String.Format("{0}: Não foi possível obter o tipo da classe relacionada ao processo!", tle.GetType().Name);
                XMessageIts.ExceptionMessageDetails(tle, msg, "TypeLoadException");
                return null;
            }
            catch (Exception e)
            {
                var msg = String.Format("{0}: Não foi possível criar a tarefa! Contate o administrador!", e.GetType().Name);
                XMessageIts.ExceptionMessageDetails(e, msg, "TypeLoadException");
                return null;
            }

        }

        public static PropertyInfo GetPropertie(this object instance, string methodName)
        {
            PropertyInfo property = instance.GetType().GetProperty(methodName);

            return property;

        }

        public static PropertyInfo[] GetProperties(this object instance)
        {
            PropertyInfo[] props = instance.GetType().GetProperties();
            //foreach (var propertyInfo in props)
            //   Console.WriteLine(propertyInfo.Name);
            return props;

        }

        /// <summary>
        /// Realiza um set por reflexão
        /// </summary>
        /// <param name="instance"></param>Objeto
        /// <param name="propName"></param>Nome da propriedade
        /// <param name="value"></param>
        /// <returns></returns>
        public static PropertyInfo SetPropertieValue(this object instance, string propName, object value)
        {

            PropertyInfo property = instance.GetType().GetProperty(propName);
            try
            {

                property.SetValue(instance, value, null);
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Falha ao setar o valor \"" + value + "\" na propriedade " + propName +
                    ".\n=>" + ex.Message);
            }
            return property;

        }

        /// <summary>
        ///Realiza um get por reflexão
        /// </summary>
        /// <param name="instance"></param>Objeto
        /// <param name="propName"></param>Nome da propriedade
        /// <returns></returns>
        public static object GetPropertieValue(this object instance, string propName)
        {
            try
            {
                PropertyInfo property = instance.GetType().GetProperty(propName);

                return property.GetValue(instance, null);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Propriedade \"" + propName + "\" não encontrada.\n" +
                                        "=>" + ex.Message);
            }
        }

        /// <summary>
        /// Invoca um metódo por reflexão
        /// </summary>
        /// <param name="instance"></param>Objeto
        /// <param name="methodName"></param>Nome do metódo
        /// <param name="values"></param>Argumentos
        public static void InvokeMethod(this object instance, string methodName, params object[] values)
        {
            var method = instance.GetType().GetMethod(methodName);
            method.Invoke(methodName, values);
        }

        /// <summary>
        /// Somente metodos com  parametros do tipo primitivo
        /// </summary>
        /// <param name="instance"></param>Objeto
        /// <param name="methodName"></param>Nome do metódo
        /// <param name="values"></param>Argumentos
        public static void InvokeMethodMember(this object instance, string methodName, params object[] value)
        {
            try
            {
                instance.GetType().InvokeMember(methodName, BindingFlags.InvokeMethod | BindingFlags.Instance |
                    BindingFlags.Public, null, instance, value);
            }
            catch (Exception)
            {
                throw new ArgumentException("Propriedade não encontrada ou não é um tipo primitivo");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public static ParameterInfo[] GetTypesMethodParameters(this object instance, string methodName)
        {
            var methodInfo = instance.GetType().GetMethod(methodName);

            return methodInfo.GetParameters();
        }

        /// <summary>
        /// Invo propriedades da classes para invocar o metodo
        /// </summary>
        /// <param name="instance"></param>Objeto
        /// <param name="methodName"></param>Nome do metódo
        /// <param name="values"></param>Argumentos
        public static void SetValues(this object instance, object[] values)
        {
            var props = instance.GetProperties();
            int i = 0;
            foreach (var prop in props)
            {
                if (i < values.Length)
                {
                    instance.SetPropertieValue(prop.Name, values[i]);
                }
                i++;
            }
        }

        /// <summary>
        /// Valores de todas as propriedades do objeto
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="methodName"></param>
        /// <param name="values"></param>
        public static object[] GetValues(this object instance)
        {
            var props = instance.GetProperties();
            var lista = new List<object>();
            foreach (var prop in props)
            {
                lista.Add(instance.GetPropertieValue(prop.Name));
            }
            return lista.ToArray();
        }

        /// <summary>
        /// Gera DTO de todos os componentes do Form
        /// </summary>
        /// <param name="form"></param>
        public static void ShowComponentsFromGroupControl(Form form, bool convertToDecimal = false)
        {
            var sb = new StringBuilder();

            foreach (var form_control in form.Controls)
            {
                if (form_control is DevExpress.XtraEditors.GroupControl)
                {
                    var group = form_control as DevExpress.XtraEditors.GroupControl;

                    foreach (var baseEdit in group.Controls)
                    {
                        if (baseEdit is DevExpress.XtraEditors.BaseEdit)
                        {
                            setPropStringBaseEdit(baseEdit, sb, convertToDecimal);
                        }
                    }
                }
              
                else if (form_control is DevExpress.XtraEditors.BaseEdit)
                {
                    setPropStringBaseEdit(form_control, sb, convertToDecimal);
                }
                else if (form_control is XtraUserControl)
                {
                    setPropXtraUserControl(form_control, sb);
                }
            }

            showResultBuilder(sb);

        }

        /// <summary>
        /// Gera DTO de todos os componentes do TabPane
        /// </summary>
        /// <param name="form"></param>
        public static void ShowComponentsFromTabPaneForm(Form form, bool convertToDecimal = false)
        {
            var sb = new StringBuilder();

            foreach (var form_control in form.Controls)
            {
                if (form_control is DevExpress.XtraBars.Navigation.TabPane)
                {
                    var tab = form_control as DevExpress.XtraBars.Navigation.TabPane;
                    foreach (var control in tab.Controls)
                    {
                        var navPage = control as DevExpress.XtraBars.Navigation.TabNavigationPage;

                        foreach (var nav in navPage.Controls)
                        {
                            if (nav is DevExpress.XtraEditors.BaseEdit)
                            {
                                setPropStringBaseEdit(nav, sb);
                            }
                        }
                    }
                }
                else if (form_control is XtraUserControl)
                {
                    setPropXtraUserControl(form_control, sb);
                }
                else if (form_control is DevExpress.XtraEditors.BaseEdit)
                {
                    setPropStringBaseEdit(form_control, sb, convertToDecimal);
                }

            }
            showResultBuilder(sb);

        }

        private static void showResultBuilder(StringBuilder sb)
        {
            Console.WriteLine(sb);
            var file = FileManagerIts.DeskTopPath + "\\out.txt";
            FileManagerIts.DeleteFile(file);
            FileManagerIts.AppendLines(file, sb.ToString());
            FileManagerIts.OpenFromSystem(file);
        }

        private static void setPropStringBaseEdit(object o, StringBuilder sb, bool convertToDecimal = false)
        {
            //chaves
            string[] keys = new string[] { "txt", "textEdit",
                                            "rd","radioGroup",
                                            "cb", "comboEdit",
                                                "checkEdit",
                                                "buttonEdit",
                                                "memoEdit",
                                                "spinneEdit" };

            var baseEdit = o as DevExpress.XtraEditors.BaseEdit;
            var name = baseEdit.Name;

            foreach (var key in keys)
            {
                name = name.Replace(key, "").FirstCharToLower();
            }

            //somente textEdit entra aqui
            if (convertToDecimal &&  o.GetType() == typeof( DevExpress.XtraEditors.TextEdit))
            {
                sb.Append("decimal ");
                sb.Append(name);
                sb.Append(" = ");
                sb.Append("ParseUtil.ToDecimal(");
                sb.Append(baseEdit.Name);
                sb.Append(".Text");
                sb.Append(")");
            }
            else if (o.GetType() == typeof( DevExpress.XtraEditors.CheckEdit))
            {
                sb.Append("bool ");
                sb.Append(name);
                sb.Append(" = ");
                sb.Append(baseEdit.Name);
                sb.Append(".Checked");
            }

            else if (o.GetType() == typeof(DevExpress.XtraEditors.RadioGroup))
            {
                sb.Append("int ");
                sb.Append(name);
                sb.Append(" = ");
                sb.Append(baseEdit.Name);
                sb.Append(".SelectedIndex");
            }
            else
            {
                sb.Append("string ");
                sb.Append(name);
                sb.Append(" = ");
                sb.Append(baseEdit.Name);
                sb.Append(".Text");
            }
            sb.Append(";\n");
        }

        private static void setPropXtraUserControl(object o, StringBuilder sb)
        {
            string[] keys = new string[] { "lookUp" };
            string[] nums = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            var comp = o as XtraUserControl;
            var name = comp.Name;
            var prop = name;

            foreach (var key in keys)
            {
                name = name.Replace(key, "").FirstCharToLower();
                prop = prop.Replace(key, "");
            }
            foreach (var n in nums)
            {
                name = name.Replace(n, "").FirstCharToLower();
                prop = prop.Replace(n, "");
            }
            sb.Append(prop);
            sb.Append(" ");
            sb.Append(name);
            sb.Append(" = ");
            sb.Append(comp.Name);
            sb.Append(".");
            sb.Append(prop);
            sb.Append(";\n");
        }

    }
}