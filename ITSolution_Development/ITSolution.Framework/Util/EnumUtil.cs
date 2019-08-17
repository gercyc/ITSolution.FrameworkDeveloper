using ITSolution.Framework.Entities.Embedded;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace ITSolution.Framework.Util
{
    //http://blog.spontaneouspublicity.com/associating-strings-with-enums-in-c

    public static class EnumUtil
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
        /// <summary>
        /// Cria uma classe com base no T. T deve ser um Enum caso contrário lança exceção.
        /// </summary>
        /// <typeparam name="T">Tipo de enumerador</typeparam>
        /// <returns>A lista de EnumClassType</returns>
        public static List<EnumTypeClazz> GetEnumListDescription<T>()
        {
            var enumList = EnumToList<T>();
            var enumListDescription = new List<EnumTypeClazz>();

            foreach (var e in enumList)
            {
                //string description = GetEnumDescription(e as Enum);
                enumListDescription.Add(new EnumTypeClazz(e));
            }

            return enumListDescription;
        }


        /// <summary>
        /// Obtém todos os enumerados da classe T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> EnumToList<T>()
        {
            Type enumType = typeof(T);

            // Can't use generic type constraints on value types,
            // so have to do check like this
            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("T must be of type System.Enum");

            Array enumValArray = Enum.GetValues(enumType);
            List<T> enumValList = new List<T>(enumValArray.Length);

            foreach (int val in enumValArray)
            {
                enumValList.Add((T)Enum.Parse(enumType, val.ToString()));
            }

            return enumValList;
        }

        public static Array GetEnumValues(Type type)
        {
            var values = Enum.GetValues(type);

            return values;
        }

    }
}
