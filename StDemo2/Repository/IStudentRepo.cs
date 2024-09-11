using Microsoft.EntityFrameworkCore;
using StDemo2.Data;
using StDemo2.Models;

namespace StDemo2.Repository
{
    public interface IStudentRepo
    {
        public List<Student> GetAll();
        public Student GetById(int id);
        public void Add(Student student);
        public void Update(Student student);
        public void DeleteById(int id);
        //public void EmailChecker(Student student);
    }

    public class StudentRepo : IStudentRepo
    {
        ITIContext db = new ITIContext();
        public void Add(Student student)
        {
            db.Add(student);
            db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var std = db.Students.FirstOrDefault(a => a.Id == id);
            db.Students.Remove(std);
            db.SaveChanges();
        }

        public void EmailChecker(Student student)
        {

            var emailCheck = db.Students.SingleOrDefault(s => s.Email == student.Email);
            if (emailCheck == null)
            {
                db.Students.Add(student);
            }
        }

        public List<Student> GetAll()
        {
            return db.Students.Include(s => s.Department).ToList();
        }
        //public List GetAll2()
        //{
        //    return db.Students.Include(s=>s.Department).ToList();
        //}
        public Student GetById(int id)
        {
            return db.Students.FirstOrDefault(a => a.Id == id);
        }

        public void Update(Student student)
        {
            db.Students.Update(student);
            db.SaveChanges();
        }
    }
    public class StudentRepo2 : IStudentRepo
    {
        List<Student> db = new List<Student>();

        public void Add(Student student)
        {
            db.Add(student);
        }

        public void DeleteById(int id)
        {
            var std = db.FirstOrDefault(a => a.Id == id);
            db.Remove(std);
        }

        //public void EmailChecker(Student student)
        //{
        //    throw new NotImplementedException();
        //}

        public List<Student> GetAll()
        {
            return db;
        }

        public Student GetById(int id)
        {
             return db.FirstOrDefault(a => a.Id == id);
        }

        public void Update(Student student)
        {
            //throw new NotImplementedException();
        }
    }
}
