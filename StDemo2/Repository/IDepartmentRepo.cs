using StDemo2.Data;
using StDemo2.Models;

namespace StDemo2.Repository
{
    public interface IDepartmentRepo
    {
        public List<Department> GetAll();
        public Department GetById(int id);
        public void Add(Department department);
        public void Update(Department department);
        public void DeleteById(int id);
    }
    public class DepartmentRepo : IDepartmentRepo
    {
        ITIContext db = new ITIContext();



        public void Add(Department department)
        {
            db.Add(department);
            db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var dept = db.Departments.FirstOrDefault(a => a.DeptId == id);
            db.Departments.Remove(dept);
            db.SaveChanges();

        }

        public List<Department> GetAll()
        {
            return db.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return db.Departments.FirstOrDefault(a => a.DeptId == id);
        }

        public void Update(Department department)
        {
            db.Departments.Update(department);
            db.SaveChanges();
        }
    }
    public class DepartmentRepo2 : IDepartmentRepo
    {
        List<Department> db = new List<Department>();
        public void Add(Department department)
        {
            db.Add(department);
        }

        public void DeleteById(int id)
        {
            var dept=db.FirstOrDefault(a => a.DeptId == id);
            db.Remove(dept);
        }

        public List<Department> GetAll()
        {
            return db;
        }

        public Department GetById(int id)
        {
            return db.FirstOrDefault(a => a.DeptId == id);
        }

        public void Update(Department department)
        {

            //db.Update(department);
        }
    }

}
