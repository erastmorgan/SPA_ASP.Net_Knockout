using SPANotesApp.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SPANotesApp.Models
{
    public enum ExpTimeType
    {
        [Description("Never")]
        None,

        [Description("Ten minutes")]
        TenMinutes,

        [Description("One hour")]
        OneHour,

        [Description("One day")]
        OneDay,

        [Description("One week")]
        OneWeek,

        [Description("One month")]
        OneMonth
    }

    public class ExpTimeTypeDTO
    {
        public ExpTimeType Key { get; set; }

        public string Value
        {
            get
            {
                return EnumHelper.GetDescription(this.Key);
            }
        }

        public ExpTimeTypeDTO(ExpTimeType type)
        {
            this.Key = type;
        }
    }
}
