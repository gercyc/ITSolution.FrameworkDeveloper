using ITSolution.Framework.Mensagem;
using System;

namespace ITSolution.Framework.Util
{
    public static class DataUtil
    {

        /// <summary>
        /// Data atual do sistema completa
        /// </summary>
        /// <returns></returns>
        public static DateTime GetCurrentDate()
        {
            return DateTime.Now;
        }

        public static DateTime GetCurrentDateShort()
        {
            //return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,0,0,0);
            //or
            return DateTime.Now.Date;
        }

        public static string[] GetMonthNames(int month = 0)
        {
            string[] months = new string[12];
            if (month != 0)
            {
                // Obtém o nome do mês por extenso
                string mesExtenso = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(month).ToLower();
                // retorna o nome do mês com a primeira letra em maiúscula
                months[0] = char.ToUpper(mesExtenso[0]) + mesExtenso.Substring(1);
            }
            else
            {
                for (int i = 1; i <= 12; i++)
                {
                    // Obtém o nome do mês por extenso
                    string mesExtenso = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(i).ToLower();
                    // retorna o nome do mês com a primeira letra em maiúscula
                    months[i] = char.ToUpper(mesExtenso[0]) + mesExtenso.Substring(1);
                }
            }
            return months;
        }

        /// <summary>
        /// Converter um string para um data formato dd/MM/yyyy
        /// </summary>
        /// <param name="dataString"></param>
        /// <returns></returns>
        public static DateTime ToDate(string dataString)
        {
            DateTime data = new DateTime(1, 1, 1);
            if (string.IsNullOrWhiteSpace(dataString))
                return data;

            try
            {
                data = Convert.ToDateTime(dataString);
                var dt = DateTime.Now;
                data = new DateTime(data.Year, data.Month, data.Day,
                    dt.Hour, dt.Minute, dt.Second);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return data;
        }
        
        /// <summary>
        /// Data atual no formatdo dd-MM-yyyy
        /// </summary>
        /// <returns></returns>
        public static string ToDateFormat()
        {
            DateTime data = DateTime.Now;
            try
            {
                return data.ToString("dd-MM-yyyy");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public static DateTime TruncateDate(DateTime data)
        {
            return new DateTime(data.Year, data.Month, data.Day, 0, 0, 0);
        }

        public static string ToDateShort(DateTime data)
        {
            return data.Date.ToShortDateString();
        }

        public static string ToDate(DateTime dtData)
        {
            DateTime data = new DateTime(1600, 1, 1); ;
            try
            {
                return dtData.ToString("dd/MM/yyyy");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return data.ToString("dd/MM/yyyy");
        }

        public static DateTime ToDateZerada(this DateTime dtData)
        {
            DateTime data = new DateTime(1600, 1, 1); ;
            try
            {
                //zera a hora
                return new DateTime(dtData.Year, dtData.Month, dtData.Day);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return data;
        }

        public static string ToDateHour(DateTime dtData)
        {
            DateTime data = new DateTime(1600, 1, 1); ;
            try
            {
                return dtData.ToString("dd/MM/yyyy HH:mm");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return data.ToString("dd/MM/yyyy HH:mm");
        }

        public static string ToHour(DateTime dtData)
        {
            DateTime data = new DateTime(1600, 1, 1); ;
            try
            {
                return dtData.ToString("HH:mm:ss");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return data.ToString("HH:mm:ss");
        }

        /// <summary>
        /// Converte uma string para um data formato yyyy-MM-dd
        /// </summary>
        /// <param name="dataString"></param>
        /// <returns></returns>
        public static string ToDateSql(string dataString)
        {
            DateTime data = new DateTime(1900, 1, 1); ;
            string dataSql = data.ToString("yyyy-MM-dd");
            try
            {
                data = Convert.ToDateTime(dataString);
                var dt = DateTime.Now;
                data = new DateTime(data.Year, data.Month, data.Day,
                    dt.Hour, dt.Minute, dt.Second);

                dataSql = data.ToString("yyyy-MM-dd");

            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dataSql;
        }

        /// <summary>
        /// Converte uma data para string formato yyyy-dd-MM
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ToDateSql()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        public static string ToDateSqlLong()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
        }

        /// <summary>
        /// Converte uma data para string formato yyyy-dd-MM
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ToDateSql(DateTime data)
        {
            string dataSql = null;
            try
            {
                dataSql = data.ToString("yyyy-MM-dd");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (dataSql == null)
            {
                return new DateTime(1900, 1, 1).ToString("yyyy-MM-dd");
            }
            return dataSql;
        }

        /// <summary>
        /// Obtém a primeira data do mês atual
        /// </summary>
        /// <returns></returns>A data inicial do mês
        public static DateTime GetDataInicialDoMesAtual()
        {
            DateTime dataAtual = DateTime.Now;
            int dia = 1;
            int mes = dataAtual.Month;
            int anos = dataAtual.Year;
            int hour = dataAtual.Hour;
            int minute = dataAtual.Minute;
            int second = dataAtual.Second;
            return new DateTime(anos, mes, dia, hour, minute, second);
        }

        /// <summary>
        /// Obtém a primeira data do mês atual
        /// </summary>
        /// <param name="mes"></param>Mês
        /// <returns></returns>A data inicial do mês
        public static DateTime GetDataInicialDoMes(int mes)
        {
            DateTime dataAtual = DateTime.Now;
            int year = dataAtual.Year;
            if (mes < 1)
            {
                mes = 12;
                year--;
            }
            else if (mes > 12)
            {
                mes = 1;
                year++;
            }
            //else

            //o mes ta certo

            return new DateTime(year, mes, 1);
        }

        /// <summary>
        /// Obtém a primeira data do mês a partir da data informada
        /// </summary>
        /// <param name="mes"></param>Mês
        /// <param name="dtData"></param>Data
        /// <returns></returns>A data inicial do mês
        public static DateTime GetDataInicialDoMes(DateTime dtData)
        {
            return new DateTime(DateTime.Now.Year, dtData.Month, 1);
        }

        /// <summary>
        /// Obtém a última data do mês atual
        /// </summary>
        /// <returns></returns>A data
        public static DateTime GetDataFinalDoMesAtual()
        {
            return GetDataFinalDoMes(DateTime.Now);
        }

        /// <summary>
        /// Obtém a última data do mês a partir do mês informado
        /// </summary>
        /// <param name="mes"></param>Mês
        /// <returns></returns>A data final do mês
        public static DateTime GetDataFinalDoMes(int mes)
        {
            DateTime dataAtual = DateTime.Now;
            int year = dataAtual.Year;
            if (mes < 1)
            {
                mes = 12;
                year--;
            }
            else if (mes > 12)
            {
                mes = 12;
                year++;
            }
            //else
            //o mes ta certo

            try
            {
                int diasDoMes = DateTime.DaysInMonth(year, mes);
                return new DateTime(year, mes, diasDoMes);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("A data corrente nao tem 31 dias\n" + ex.Message);
            }

            return new DateTime(1900, 1, 1);
        }

        /// <summary>
        /// Obtém a última data do mês a partir da data informada
        /// </summary>
        /// <param name="dtData"></param>
        /// <returns></returns>
        public static DateTime GetDataFinalDoMes(DateTime dtData)
        {
            DateTime dataAtual = DateTime.Now;

            int anos = dtData.Year;
            int mes = dtData.Month;
            int hour = dataAtual.Hour;
            int minute = dataAtual.Minute;
            int second = dataAtual.Second;

            if (mes > 12)
            {
                mes = 1;
            }

            try
            {
                int diasDoMes = DateTime.DaysInMonth(anos, mes);
                return new DateTime(anos, mes, diasDoMes);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("A data corrente nao tem 31 dias\n" + ex.Message);
            }

            return new DateTime(1900, 1, 1);
        }

        /// <summary>
        /// Obtém o dia da data atual
        /// </summary>
        /// <returns></returns>Dias
        public static int GetDiaDataAtual()
        {
            return DateTime.Now.Day;
        }

        /// <summary>
        /// Obtém o mês da data atual
        /// </summary>
        /// <returns></returns>Mês
        public static int GetMesDataAtual()
        {
            return DateTime.Now.Month;
        }

        /// <summary>
        /// Obtém o ano da data atual
        /// </summary>
        /// <returns></returns>Anos
        public static int GetAnoDataAtual()
        {
            return DateTime.Now.Year;
        }

        /// <summary>
        /// Retorna a mesma data com um mês a frente
        /// </summary>
        /// <param name="mes"></param>
        /// <returns></returns>
        public static DateTime GetNextDate(DateTime dtData)
        {

            int dia = dtData.Day;

            int mes = dtData.Month;
            int anos = dtData.Year;
            int diasDoMes = DateTime.DaysInMonth(anos, mes);

            //se o mes for o ultimo então vai pra o primeiro
            if (mes == 12)
            {
                mes = 1; //va para o primeiro
                anos++;//incremente o ano
            }
            else
            {
                mes++;//um mês a frente
            }


            //tratamento para ver se o dia data informada 
            //se enquadra na proxima data
            try
            {
                var nextData = new DateTime(anos, mes, 1);

                int diaNextData = DateTime.DaysInMonth(anos, nextData.Month);

                if (dia > diaNextData)
                {
                    Console.WriteLine("Dia setado possui range diferente a data sua frente");
                    dia = diaNextData;
                }

                var data = new DateTime(anos, mes, dia);

                return data;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                if (dia == 31)
                {
                    dia = 1;
                }
                else
                {
                    dia++;
                }
                Console.WriteLine("A data corrente nao pode ter estar no dia " + dia);
                LoggerUtilIts.ShowExceptionLogs(ex);

            }
            return new DateTime(1900, 1, 1);
        }

        /// <summary>
        /// Calcula numero de dias existente entre as datas
        /// </summary>
        /// <param name="dataInicial"></param>Data inicial
        /// <param name="dataFinal"></param>Data final
        /// <returns></returns>O numero de dias
        public static int CalcularDias(DateTime dataInicial, DateTime dataFinal)
        {
            var data = dataFinal;

            try
            {
                dataInicial = TruncateDate(dataInicial);
                TimeSpan ts = data.Subtract(dataInicial);
                //arredonda pra cima
                double dias = Math.Round(ts.TotalDays, 0);
                return ParseUtil.ToInt(dias);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        /// <summary>
        /// Calcula numero de dias existente entre as datas
        /// </summary>
        /// <param name="dataInicial"></param>Data inicial
        /// <param name="dataFinal"></param>Data final
        /// <returns></returns>O numero de dias
        public static int CalcularDias(string dataInicial, string dataFinal)
        {
            DateTime dtInicial = ToDate(dataInicial);
            DateTime dtFinal = ToDate(dataFinal);

            return CalcularDias(dtInicial, dtFinal);

        }

        /// <summary>
        /// Obtém a data com prazo estipulado
        /// </summary>
        /// <param name="dataInicial"></param>
        /// <param name="dataFinal"></param>
        /// <returns></returns>A data 
        public static DateTime CalcularData(DateTime data, int prazo)
        {
            if (prazo > 0)
            {
                try
                {
                    data = TruncateDate(data);
                    //aumenta os dias na data
                    data = data.AddDays(prazo);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    XMessageIts.Mensagem(ex.Message.Replace("value", "Prazo: " + prazo));
                }

            }
            //retorna a data alterada
            return data;

        }

        /// <summary>
        /// Compara t1 com t2
        /// Retorna true se t1 eh maior que t2
        /// </summary>
        /// <param name="dtLancto"></param>
        /// <param name="dtVencimento"></param>
        /// <returns></returns> Menor do que zero = t1 é anterior à t2.
        ///Zero = t1 é o mesmo que t2.
        ///Maior que zero = t1 é posterior a t2. 
        public static bool CompararMaiorData(DateTime t1, DateTime t2)
        {
            int result = DateTime.Compare(t1, t2);
            if (result > 0)
                return true;
            return false;
        }

        /// <summary>
        /// Compara t1 com t2
        /// Retorna true se t1 eh menor que t2
        /// </summary>
        /// <param name="dtLancto"></param>
        /// <param name="dtVencimento"></param>
        /// <returns></returns> Menor do que zero = t1 é anterior à t2.
        ///Zero = t1 é o mesmo que t2.
        ///Maior que zero = t1 é posterior a t2. 
        public static bool CompararMenorData(DateTime t1, DateTime t2)
        {
            int result = DateTime.Compare(t1, t2);
            if (result < 0)
                return true;
            return false;
        }

        /// <summary>
        /// Verifica o valor da data informada é válido
        /// Uma data pode ser inválida se o valor 01/01/0001
        /// </summary>
        /// <param name="date"></param>
        public static Nullable<DateTime> ValidateDate(this DateTime date)
        {
            if (date == new DateTime(1, 1, 1).Date)
                return null;
            return date;
        }

        /// <summary>
        /// Verifica o valor da data informada é válido
        /// Uma data pode inválida mesmo sendo diferente de null
        /// Ex: 01/01/0001
        /// </summary>
        /// <param name="date"></param>
        public static Nullable<DateTime> ValidateDate(this Nullable<DateTime> date)
        {
            if (date == null || date == new DateTime(1, 1, 1))
                return null;
            return date;
        }


        public static bool IsValidDate(this Nullable<DateTime> date)
        {
            if (date == null || date == new DateTime(1, 1, 1))
                return false;

            return true;
        }
    }

    /*[Obsolete]        /// <summary>
        /// Obtém a data com o último dia do mês
        /// </summary>
        /// <param name="dtData"></param>
        /// <returns></returns>
        public static DateTime GetDataFinalMesOld(DateTime dtData)
        {
            DateTime dataAtual = DateTime.Now;

            //maior dia do mes
            int dia = 31;

            int mes = dtData.Month;

            int anos = dataAtual.Year;
            int hour = dataAtual.Hour;
            int minute = dataAtual.Minute;
            int second = dataAtual.Second;
            bool isData = false;

            //caso os dias seja menor q 31 
            while (!isData)
            {
                try
                {
                    dataAtual = new DateTime(anos, mes, dia, hour, minute, second);

                    isData = true;
                }
                catch (ArgumentOutOfRangeException)
                {
                    //decrementa um dia
                    dia--;
                    dataAtual = new DateTime(1900, 1, 1);
                    continue;
                }
            }
            return dataAtual;
        }*/

}
