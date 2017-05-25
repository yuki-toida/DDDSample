using System;
using System.Collections.Generic;
using System.Linq;

namespace Sample.Infra.Core.Utility
{
    public static class EnumUtility<TEnum> where TEnum : struct
    {
        /// <summary>
        /// Enum配列を取得
        /// </summary>
        public static IEnumerable<TEnum> GetAll()
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
        }
    }
}
