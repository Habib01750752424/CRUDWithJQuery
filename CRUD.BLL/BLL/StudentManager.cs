using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.Repository.Repository;
using CRUD.Model.Model;

namespace CRUD.BLL.BLL
{
    public class StudentManager
    {
        StudentRepository _studentRepository = new StudentRepository();
        public bool Add(Student student)
        {
            return _studentRepository.Add(student);
        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        public Student GetById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public bool Update(Student student)
        {
            return _studentRepository.Update(student);
        }

        public bool Delete(int id)
        {
            return _studentRepository.Delete(id);
        }
    }
}
