using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SPANotesApp.Models
{
    public class Note
    {
        public int NoteId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public ExpTimeType? ExpTimeType { get; set; }

        public DateTime ExpirationDateTime { get; set; }
    }
}
