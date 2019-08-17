using System;
using System.Globalization;

namespace ITSolution.Framework.Entities.Embedded
{
    public class CalendarMonth
    {

        public int Month { get; set; }


        public string MonthName { get; set; }

        public string MaskMonth { get; set; }

        public static int Year { get; set; }

        public CalendarMonth[] CalendarMonths { get; private set; }

        private static CalendarMonth instance;

        public static CalendarMonth Calendar
        {
            get
            {
                if (instance == null)
                    instance = new CalendarMonth();

                return instance;
            }

        }

        private CalendarMonth()
        {
            Year = DateTime.Now.Year;
            this.CalendarMonths = new CalendarMonth[12];

            for (int i = 1; i < 13; i++)
            {
                //o vetor eh indexado a partir do 0
                this.CalendarMonths[i - 1] = new CalendarMonth(i);
            }


            //forma procedural
            //calendar.Add(1, "Janeiro");
            //calendar.Add(2, "Fevereiro");
            //calendar.Add(3, "Março");
            //calendar.Add(4, "Abril");
            //calendar.Add(5, "Maio");
            //calendar.Add(6, "Junho");
            //calendar.Add(7, "Julho");
            //calendar.Add(8, "Agosto");
            //calendar.Add(9, "Setembro");
            //calendar.Add(10, "Outubro");
            //calendar.Add(11, "Novembro");
            //calendar.Add(12, "Dezembro");
        }
        private CalendarMonth(int month)
        {
            this.Month = month;

            //vem em minusculo
            string monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month).ToLower();
            monthName = char.ToUpper(monthName[0]) + monthName.Substring(1);
            //seta a mascara 
            this.MonthName = monthName;

            if (month < 10)
                this.MaskMonth =  this.MonthName + "/" + Year;
            else
                this.MaskMonth = this.MonthName + "/" + Year;
        }

        public CalendarMonth this[int index]
        {
            get
            {
                if (index > -1 && index < 12)
                    return CalendarMonths[index];
                return null;
            }
        }

        /// <summary>
        /// A data inicial do mês.
        /// </summary>
        public DateTime DateTime
        {
            get
            {
                return new DateTime( Year, this.Month, 1);
            }
        }
        public override string ToString()
        {
            return this.MaskMonth;
        }
    }
}
