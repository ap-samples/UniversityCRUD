using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCRUD.BO;

namespace UniversityCRUD.DA.Repositories
{
    public class StudentsRepository : BaseRepository<Student>
    {
        public static StudentsRepository Instance = new StudentsRepository();


    }
}
