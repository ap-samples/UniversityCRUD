using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityCRUD.BO
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime EnrollmentDate { get; set; }


        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
