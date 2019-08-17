using ITSolution.Framework.Mensagem;
using System;
using System.Linq;

namespace ITSolution.Framework.Util
{

    /// <summary>

    /// </summary>
    public class ParseUtil
    {

        /// <summary>
        /// Converter a string em número inteiro
        /// </summary>
        /// <param colName="o"></param>
        /// <returns></returns>
        public static int ToInt(object stringValue)
        {
            if (IsValidText(stringValue))
            {
                try
                {
                    if (stringValue.ToString().Contains(","))
                        stringValue = stringValue.ToString().Split(',')[0];
                    return Convert.ToInt32(stringValue);
                }

                catch (OverflowException ex)
                {
                    LoggerUtilIts.ShowExceptionLogs(ex);
                }
                catch (FormatException ex)
                {
                    LoggerUtilIts.ShowExceptionMessage(ex);
                    return -1;
                }
                catch (Exception ex)
                {
                    LoggerUtilIts.ShowExceptionLogs(ex);
                }
            }
            return 0;

        }

        /// <summary>
        /// Converter a string em número inteiro (long)
        /// </summary>
        /// <param colName="o"></param>
        /// <returns></returns>
        public static long ToLong(object stringValue)
        {
            if (IsValidText(stringValue))
            {
                try
                {
                    return Convert.ToInt64(stringValue);
                }
                catch (OverflowException ex)
                {
                    LoggerUtilIts.ShowExceptionLogs(ex);
                }
                catch (FormatException ex)
                {
                    LoggerUtilIts.ShowExceptionLogs(ex);
                    return -1;
                }
                catch (Exception ex)
                {
                    LoggerUtilIts.ShowExceptionLogs(ex);
                }
            }
            return 0;
        }

        /// <summary>
        /// Converter uma string em Float
        /// </summary>
        /// <param colName="o"></param>
        /// <returns></returns>
        public static Single ToFloat(object stringValue)
        {
            if (IsValidText(stringValue))
            {
                try
                {
                    //stringValue = stringValue.ToString().Replace(".", ",");
                    stringValue = prepareStringToConvertDecimal(stringValue);
                    return Convert.ToSingle(stringValue);
                }
                catch (OverflowException ex)
                {
                    LoggerUtilIts.ShowExceptionLogs(ex);
                }
                catch (FormatException ex)
                {
                    LoggerUtilIts.ShowExceptionLogs(ex);
                }
            }
            return 0.0f;
        }

        /// <summary>
        /// Converter uma string em Double
        /// </summary>
        /// <param colName="o"></param>
        /// <returns></returns>
        public static Double ToDouble(object stringValue)
        {
            if (IsValidText(stringValue))
            {
                try
                {
                    stringValue = stringValue.ToString().Replace(".", ",");
                    return Convert.ToDouble(stringValue);
                }
                catch (OverflowException ex)
                {
                    LoggerUtilIts.ShowExceptionLogs(ex);
                }
                catch (FormatException ex)
                {
                    LoggerUtilIts.ShowExceptionLogs(ex);
                }
            }
            return 0.0d;
        }

        /// <summary>
        /// Converter a string em número decimal
        /// </summary>
        /// <param colName="o"></param>
        /// <returns></returns>
        public static Decimal ToDecimal(object stringValue)
        {

            if (IsValidText(stringValue))
            {
                try
                {
                    stringValue = prepareStringToConvertDecimal(stringValue);

                    return Convert.ToDecimal(stringValue);
                }
                catch (OverflowException ex)
                {
                    LoggerUtilIts.ShowExceptionLogs(ex);
                }
                catch (InvalidCastException ex)
                {
                    XMessageIts.ExceptionMessage(ex, "Objeto informado não pode ser convertido em decimal\nInforme um texto", "Falha crítica de cast");

                }
                catch (FormatException ex2)
                {
                    Console.WriteLine(ex2.InnerException);
                }
            }
            return 0.000m;
        }

        /// <summary>
        /// Converter a string em número decimal
        /// </summary>
        /// <param colName="o"></param>
        /// <returns></returns>
        public static Decimal ToDecimal(object stringValue, int scale = 4)
        {
            if (IsValidText(stringValue))
            {
                try
                {
                    //stringValue = stringValue.ToString().Replace(".", ",");
                    stringValue = prepareStringToConvertDecimal(stringValue);
                    var round = Math.Round(Convert.ToDecimal(stringValue), scale);
                    return round;
                }
                catch (OverflowException ex)
                {
                    LoggerUtilIts.ShowExceptionLogs(ex);
                }
                catch (InvalidCastException ex)
                {
                    XMessageIts.ExceptionJustMessage(ex, "Objeto informado não pode ser convertido em decimal");

                }
                catch (FormatException ex2)
                {
                    Console.WriteLine(ex2.InnerException);
                }
            }
            return 0.000m;
        }/// <summary>
         /// Converter a string em data
         /// </summary>
         /// <param name="value"></param>
         /// <returns></returns>

        public static DateTime ToDate(object value)
        {
            if (IsValidText(value) && InstanceOfString(value))
            {
                if (value.GetType() == typeof(DateTime))
                {
                    try
                    {
                        return Convert.ToDateTime(value);
                    }
                    catch (FormatException ex)
                    {
                        LoggerUtilIts.ShowExceptionLogs(ex);
                    }
                }
            }
            return new DateTime(1900, 1, 1);
        }

        /// <summary>
        /// Converter a string em data
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime? ToDateOrNull(object value)
        {
            if (IsValidText(value) && InstanceOfString(value))
            {
                if (value.GetType() == typeof(DateTime))
                {
                    try
                    {
                        return Convert.ToDateTime(value);
                    }
                    catch (FormatException ex)
                    {
                        LoggerUtilIts.ShowExceptionLogs(ex);
                    }
                }
            }
            return null;
        }

        public static String ToString(object value)
        {
            return IsValidText(value) ? value.ToString() : null;

        }

        /// <summary>
        /// Verifica se a string é valida. Uma string é válida quando não é nula, vazia ou so contém espaços.
        /// </summary>
        /// <param colName="o"></param>
        /// <returns></returns> true válida caso contrário false
        public static bool IsValidText(object o)
        {
            if (o == null) return false;

            return string.IsNullOrWhiteSpace(o.ToString()) == true ? false : true;

        }

        /// <summary>
        /// Verifica o tipo do objeto
        /// </summary>
        /// <param colName="value">Valor a ser verificado</param>
        /// <param colName="type">O tipo a ser checado</param>
        /// <returns></returns> O tipo especificado
        public static bool InstanceOfInt(object value)
        {
            if (value != null)
            {
                if (value.GetType() == typeof(Int32))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica o tipo do objeto
        /// </summary>
        /// <param colName="value">Valor a ser verificado</param>
        /// <param colName="type">O tipo a ser checado</param>
        /// <returns></returns> O tipo especificado
        public static bool InstanceOfLong(object value)
        {
            if (value != null)
            {
                if (value.GetType() == typeof(Int64))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica o tipo do objeto
        /// </summary>
        /// <param colName="value">Valor a ser verificado</param>
        /// <param colName="type">O tipo a ser checado</param>
        /// <returns></returns> O tipo especificado
        public static bool InstanceOfFloat(object value)
        {
            if (value != null)
            {
                if (value.GetType() == typeof(Single))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica o tipo do objeto
        /// </summary>
        /// <param colName="value">Valor a ser verificado</param>
        /// <param colName="type">O tipo a ser checado</param>
        /// <returns></returns> O tipo especificado
        public static bool InstanceOfDouble(object value)
        {
            if (value != null)
            {
                if (value.GetType() == typeof(Double))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica o tipo do objeto
        /// </summary>
        /// <param colName="value">Valor a ser verificado</param>
        /// <param colName="type">O tipo a ser checado</param>
        /// <returns></returns> O tipo especificado
        public static bool InstanceOfDecimal(object value)
        {
            if (value != null)
            {
                if (value.GetType() == typeof(Decimal))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica o tipo do objeto
        /// </summary>
        /// <param colName="value">Valor a ser verificado</param>
        /// <param colName="type">O tipo a ser checado</param>
        /// <returns></returns> O tipo especificado
        public static bool InstanceOfDateTime(object value)
        {
            if (value != null)
            {
                if (value.GetType() == typeof(DateTime))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica o tipo do objeto
        /// </summary>
        /// <param colName="value">Valor a ser verificado</param>
        /// <param colName="type">O tipo a ser checado</param>
        /// <returns></returns> O tipo especificado
        public static bool InstanceOfString(object value)
        {
            if (value != null)
            {
                if (value.GetType() == typeof(String))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Converte um tipo DateTime para TimeSpan
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        /// /// <summary>
        public static TimeSpan ToTimeSpan(DateTime date)
        {
            TimeSpan span = date.TimeOfDay;

            return span;
        }

        /// <summary>
        /// Converte um tipo TimeSpan DateTime utiliza a hora do timespan
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        /// /// <summary>
        public static DateTime ToDate(TimeSpan ts)
        {
            return new DateTime(ts.Ticks);
        }


        /// <summary>
        /// Prepara a string para conversão de número flutante.
        /// <p>
        /// Remove:
        /// <ul>
        /// <li> "." ponto
        /// <li> "," vírgula
        /// <li> "-" hífen
        /// <li> " " espaço
        /// <li> "(" paratenses
        /// <li> ")" paratenses
        /// </ul>
        /// </summary>
        /// <param name="stringValue">Valor em String</param>
        /// <returns>Um String pronta pra conversão em de números decimais.</returns>
        private static String prepareStringToConvertDecimal(object value)
        {

            String stringValue = value == null ? "0" : value.ToString();
            if (stringValue == null || string.IsNullOrEmpty(stringValue) || stringValue.CompareTo("0") == 0)
            {
                return ("0.00");
            }

            if (stringValue.Contains(","))
            {
                //remover espaço
                stringValue = stringValue.Replace(".", "");

                //remove o espaço de inicio meio ou fim
                stringValue = stringValue.Trim();

                stringValue = stringValue.Replace("R$", "");
            }
            else
            {
                int pCount = stringValue.Count(s => s.ToString().Equals("."));

                if (pCount > 1)
                {

                    //quebra a string
                    var split = stringValue.Split('.');
                    //quebra onde tem ponto
                    string scale = split[split.Length - 1];

                    string newValue = "";

                    //Ex
                    //123.456.789 => {.789} sera as casas decimais
                    //entao vou percorrer ate  => 456
                    for (int i = 0; i < stringValue.Length - scale.Length; i++)
                    {
                        //primeiro caracter tamanho 1
                        //faz isso
                        //0
                        //1
                        //2 ...
                        string substring = stringValue.Substring(i, 1);

                        if (!substring.Equals("."))
                        {
                            newValue = newValue + substring;
                        }
                    }
                    //coloca a scale e esta contem o ponto
                    stringValue = newValue + scale;
                }
                else
                {
                    //no brasil tem que usar a virgula
                    stringValue = stringValue.ToString().Replace(".", ",");
                    //Teste
                    //var x = ParseUtil.ToDecimal("1.456,78");                    
                    //x = ParseUtil.ToDecimal("1456.78");                    
                    //Saida
                    //1.456,78
                    //145.678,00
                }

            }

            //garante que nao ouve cagada
            //verificacao final
            if (string.IsNullOrEmpty(stringValue))
            {
                return "0.0";
            }

            return stringValue;

        }
    }
}

