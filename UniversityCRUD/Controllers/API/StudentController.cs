using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UniversityCRUD.BO;
using UniversityCRUD.DA.Repositories;

namespace UniversityCRUD.Controllers.API
{
    [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {
        [HttpGet]
        public List<Student> GetStudents()
        {
            List<Student> res = StudentsRepository.Instance.GetWhere(s => true);

            return res;
        }

        [HttpGet]
        [Route("testAddition")]
        public void TestStudentAddition()
        {
            Random rand = new Random();
            Student st = new Student() { Age = rand.Next(16,100), EnrollmentDate = DateTime.Now.AddYears(-10), Name = "Basil" };

            StudentsRepository.Instance.Add(st);
        }
    }
}
