using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityCRUD.BO
{
    public class Course : BaseEntity
    {
        public string Title { get; set; }

        public int Credits { get; set; }


        public ICollection<Enrollment> Enrollments { get; set; }

        public ICollection<Professor> Teachers { get; set; }
    }
}
