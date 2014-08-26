using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCRUD.BO.Enums;

namespace UniversityCRUD.BO
{
    public class Enrollment : BaseEntity
    {
        public Guid CourseID { get; set; }

        public Guid StudentID { get; set; }

        public Grade CourseGrade { get; set; }


        public virtual Student Student { get; set; }

        public virtual Course Course { get; set; }
    }
}
