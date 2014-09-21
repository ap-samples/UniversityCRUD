using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityCRUD.BO
{
    public class Student : BaseEntity
    {
        [StringLength(60)]
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime EnrollmentDate { get; set; }


        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
