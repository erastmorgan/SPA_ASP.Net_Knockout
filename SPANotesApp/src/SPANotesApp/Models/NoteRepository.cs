using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPANotesApp.Models
{
    public class NoteRepository
    {
        private static NoteRepository repo = new NoteRepository();

        private List<Note> notes = new List<Note>
        {
            new Note
            {
                NoteId = 0,
                Name = "Out of door",
                Description = "Do not forget to go to the lunch in a restaurant.",
                CreatedDateTime = DateTime.Now.AddHours(-1),
                ExpirationDateTime = DateTime.Now.AddMonths(1)
            },
            new Note
            {
                NoteId = 1,
                Name = "Sleeping",
                Description = "Do not forget to sleep tomorrow.",
                CreatedDateTime = DateTime.Now.AddHours(-2),
                ExpirationDateTime = DateTime.Now.AddMonths(1)
            },
            new Note
            {
                NoteId = 2,
                Name = "Watching movie",
                Description = "Do not forget about movie with friends.",
                CreatedDateTime = DateTime.Now.AddHours(-1),
                ExpirationDateTime = DateTime.Now.AddMonths(1)
            }
        };

        public static NoteRepository Instance
        {
            get
            {
                return repo;
            }
        }

        public Note Get(int id)
        {
            var item = this.notes.FirstOrDefault(x => x.NoteId == id);
            if (item != null && DateTime.Now < item.ExpirationDateTime)
            {
                return item;
            }

            return null;
        }

        public IEnumerable<Note> GetAll()
        {
            return this.notes.Where(x => DateTime.Now < x.ExpirationDateTime).OrderByDescending(x => x.CreatedDateTime);
        }

        public Note Add(Note item)
        {
            item.NoteId = notes.Count + 1;
            item.CreatedDateTime = DateTime.Now;
            switch (item.ExpTimeType)
            {
                case ExpTimeType.OneDay:
                    item.ExpirationDateTime = DateTime.Now.AddDays(1);
                    break;

                case ExpTimeType.OneHour:
                    item.ExpirationDateTime = DateTime.Now.AddHours(1);
                    break;

                case ExpTimeType.OneMonth:
                    item.ExpirationDateTime = DateTime.Now.AddMonths(1);
                    break;

                case ExpTimeType.OneWeek:
                    item.ExpirationDateTime = DateTime.Now.AddDays(7);
                    break;

                case ExpTimeType.TenMinutes:
                    item.ExpirationDateTime = DateTime.Now.AddMinutes(10);
                    break;
                    
                default:
                    item.ExpirationDateTime = DateTime.MaxValue;
                    break;
            }

            if (item.CreatedDateTime >= item.ExpirationDateTime)
            {
                throw new ArgumentOutOfRangeException("ExpirationDateTime", "ExpirationDateTime date/time should be more than CreatedDateTime");
            }

            this.notes.Add(item);
            return item;
        }
    }
}
