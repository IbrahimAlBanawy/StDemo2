using Microsoft.AspNetCore.Mvc;
using StDemo2.Data;
using StDemo2.Models;
using StDemo2.Repository;
using StDemo2.ViewModels;

namespace StDemo2.Controllers
{
    public class DepartmentController : Controller
    {
        //ITIContext db = new ITIContext();
        IDepartmentRepo deptRep = new DepartmentRepo();
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department dept) 
        {
            
            //db.Departments.Add(dept);
            //db.SaveChanges();
            deptRep.Add(dept);
            return RedirectToAction("Index");
        }

        public IActionResult ReadData(int? id)
        {


            //var dept = db.Departments.SingleOrDefault(de => de.DepId == id);
            //if (dept != null)
            //{
            //    string str = $"{dept.DepId}\t{dept.Name}\t{dept.Capacity}";
            //    return str;
            //}

           

            if (id == null)
                return BadRequest();

            Department dept = deptRep.GetById(id.Value);//db.Departments.SingleOrDefault(a => a.DeptId == id);

            if (dept == null)
                return NotFound();

            
            return View(dept);

        }
        public IActionResult Delete(int id)
        {
            
            var dept = deptRep.GetById(id); //db.Departments.SingleOrDefault(a => a.DeptId == id);
            //db.Departments.Remove(dept);
            //db.SaveChanges() ;
            deptRep.DeleteById(dept.DeptId);
            return RedirectToAction("Index");
        }
        
        //public IActionResult DeleteConfirm(int id)
        //{
        //    deptRep.DeleteById(id);
        //    return RedirectToAction("Index");
        //}


        public IActionResult Update(int id)
        {
            var dept = deptRep.GetById(id);//db.Departments.SingleOrDefault(a => a.DeptId == id);

            return View(dept);
        }
        [HttpPost]
        public IActionResult Update(Department dept)
        {
            //var department = db.Departments.SingleOrDefault(a => a.DeptId == dept.DeptId);
            //if (department != null)
            //{

            //    department.DeptName = dept.DeptName;
            //    department.Capacity = dept.Capacity;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            deptRep.Update(dept);
            return RedirectToAction("Index");

        }

        public IActionResult Index()
        {
            var res = deptRep.GetAll();//db.Departments.ToList();
            return View(res);
        }
        public ViewResult Show()
        {
            return View();
        }
    }
}
