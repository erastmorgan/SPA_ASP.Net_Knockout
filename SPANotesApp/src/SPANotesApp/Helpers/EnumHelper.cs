using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SPANotesApp.Helpers
{
    public static class EnumHelper
    {
        public static string GetDescription(Enum en)
        {
            var fi = en.GetType().GetField(en.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return en.ToString();
            }
        }
    }
}
