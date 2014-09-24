using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityCRUD.BO
{
    public class Professor : BaseEntity
    {
        public Professor() { CoursesTeached = new HashSet<Course>(); }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public uint PublicationCount { get; set; }

        public string ContactEmail { get; set; }


        public ICollection<Course> CoursesTeached { get; set; }
    }
}
