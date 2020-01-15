using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.DatabaseContext.DatabaseContext;
using CRUD.Model.Model;

namespace CRUD.Repository.Repository
{
    public class StudentRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();

        public bool Add(Student student)
        {
            _dbContext.Students.Add(student);
            return _dbContext.SaveChanges() > 0;
        }

        public List<Student> GetAll()
        {
            List<Student> students = _dbContext.Students.ToList();
            return students;
        }

        public Student GetById(int id)
        {
            Student student = _dbContext.Students.FirstOrDefault(c => c.Id == id);
            return student;
        }

        public bool Update(Student student)
        {
            Student aStudent = _dbContext.Students.FirstOrDefault(c => c.Id == student.Id);
            if (aStudent != null)
            {
                aStudent.Name = student.Name;
                aStudent.Email = student.Email;
            }
            else
            {
                return false;
            }
            return _dbContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            Student singleStudent = _dbContext.Students.FirstOrDefault(c => c.Id == id);
            if (singleStudent != null)
            {
                _dbContext.Students.Remove(singleStudent);
                return _dbContext.SaveChanges() > 0;
            }
            return false;
        }
    }
}
