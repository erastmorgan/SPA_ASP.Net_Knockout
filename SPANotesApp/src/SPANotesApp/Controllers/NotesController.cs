using Microsoft.AspNetCore.Mvc;
using SPANotesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPANotesApp.Controllers
{
    [Route("api/[controller]")]
    public class NotesController : Controller
    {
        private NoteRepository repo = NoteRepository.Instance;

        [HttpGet]
        public IEnumerable<Note> Get()
        {
            return repo.GetAll();
        }

        [HttpGet("{id}")]
        public Note Get(int id)
        {
            return repo.Get(id);
        }
        
        [HttpPost]
        public Note Post([FromBody]Note value)
        {
            return repo.Add(value);
        }
    }
}
