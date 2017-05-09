using Microsoft.AspNetCore.Mvc;
using SPANotesApp.Helpers;
using SPANotesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPANotesApp.Controllers
{
    [Route("api/[controller]")]
    public class ExpTimeTypesController : Controller
    {
        public IEnumerable<ExpTimeTypeDTO> Get()
        {
            return new List<ExpTimeTypeDTO>
            {
                new ExpTimeTypeDTO(ExpTimeType.None),
                new ExpTimeTypeDTO(ExpTimeType.TenMinutes),
                new ExpTimeTypeDTO(ExpTimeType.OneHour),
                new ExpTimeTypeDTO(ExpTimeType.OneDay),
                new ExpTimeTypeDTO(ExpTimeType.OneWeek),
                new ExpTimeTypeDTO(ExpTimeType.OneMonth)
            };
        }
    }
}
