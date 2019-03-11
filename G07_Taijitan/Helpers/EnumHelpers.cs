using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace G07_Taijitan.Helpers {
    public static class EnumHelpers {
        public static string GetDisplayName<TEnum>(this TEnum enumValue) {
            return typeof(TEnum).GetMember(enumValue.ToString())[0]
                           .GetCustomAttribute<DisplayAttribute>()?
                           .Name ?? enumValue.ToString();
        }
    }
}
