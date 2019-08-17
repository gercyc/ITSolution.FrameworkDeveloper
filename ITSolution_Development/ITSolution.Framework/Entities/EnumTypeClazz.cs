using ITSolution.Framework.Util;
using System;

namespace ITSolution.Framework.Entities.Embedded
{
    public sealed class EnumTypeClazz
    {
        public Enum EnumType { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }

        public EnumTypeClazz(object tEnum)
        {
            this.EnumType = tEnum as Enum;
            this.Value = Convert.ToInt32(tEnum);
            this.Description = EnumUtil.GetEnumDescription(EnumType);
        }

        public override string ToString()
        {
            return this.Description;
        }
    }
}
