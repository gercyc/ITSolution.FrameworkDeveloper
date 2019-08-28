using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
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




        private static void showResultBuilder(StringBuilder sb)
        {
            Console.WriteLine(sb);
            var file = FileManagerIts.DeskTopPath + "\\out.txt";
            FileManagerIts.DeleteFile(file);
            FileManagerIts.AppendLines(file, sb.ToString());
            FileManagerIts.OpenFromSystem(file);
        }
    }
}