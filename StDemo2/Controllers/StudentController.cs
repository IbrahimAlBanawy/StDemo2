using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StDemo2.Data;
using StDemo2.Models;
using StDemo2.Repository;

namespace StDemo2.Controllers
{

    public class StudentController : Controller
    {


        //ITIContext db = new ITIContext();
        IStudentRepo stdRep = new StudentRepo();
        IDepartmentRepo departmentRepo = new DepartmentRepo();
        //private readonly IStudentRepo _stdRep;
        //private readonly IDepartmentRepo _departmentRepo;

        
        //public StudentController(IStudentRepo stdRep, IDepartmentRepo departmentRepo)
        //{
        //    _stdRep = stdRep;
        //    _departmentRepo = departmentRepo;
        //}

        public IActionResult Index()
        {
            var res = stdRep.GetAll();        //db.Students.Include(s=>s.Department).ToList();
            return View(res);
        }
        public IActionResult Create()
        {

            ViewBag.depts = departmentRepo.GetAll();      //db.Departments.ToList();
            return View();
            
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            //var emailChecker = stdRep.EmailChecker(student);     
            //var emailChecker = db.Students.SingleOrDefault(s => s.Email == student.Email);
            
            if (ModelState.IsValid) //&& emailChecker == null)
            {
                //Student student = new Student() { Name=name ,Age=age, DeptNo=deptno};
                //db.Students.Add(student);
                //db.SaveChanges();
                stdRep.Add(student);
                //stdRep.EmailChecker(student);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Email", "Email is already in use.");
                ViewBag.depts = departmentRepo.GetAll();       //db.Departments.ToList();
                return View(student);
            }
        }

        public IActionResult ReadData(int? id)
        {

            //var dept = db.Departments.SingleOrDefault(de => de.DepId == id);
            //if (dept != null)
            //{
            //    string details = $"{dept.DepId}\t{dept.Name}\t{dept.Capacity}";
            //    return details;
            //}
            //return "ID not found";

            if (id == null)
                return BadRequest();
            Student student = stdRep.GetById(id.Value);       //db.Students.SingleOrDefault(a=>a.Id==id);
            if(student == null)
                return NotFound();
            return View(student);
            

            //string str = $"{student.Id}:{student.Name}:{student.Age}:{student.DeptNo}";
            
            //return RedirectPermanent("http://www.google.com");
            
            //return Redirect("http://www.google.com");
            //return Content(str);
            //return File("TextFile.txt", "text/plain","ibrahim.txt");

        }
        
        
        public IActionResult Delete(int id)
        {
            var student = stdRep.GetById(id);    //db.Students.SingleOrDefault(a => a.Id == id);
            //db.Students.Remove(student);
            //db.SaveChanges();
            stdRep.DeleteById(student.Id);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var student = stdRep.GetById(id);      //db.Students.SingleOrDefault(a => a.Id==id);
            ViewBag.depts = departmentRepo.GetAll();//db.Departments.ToList();
            return View(student);
        }
        [HttpPost]
        public IActionResult Update(Student std)
        {
            var student = stdRep.GetById(std.Id);      //db.Students.SingleOrDefault(a => a.Id == std.Id);
            if (ModelState.IsValid && student != null)
            {
                
                    stdRep.Update(std);
                    //student.Name = std.Name;
                    //student.Age = std.Age;
                    //student.DeptNo = std.DeptNo;
                    //db.SaveChanges();
                    return RedirectToAction("Index");
                
            }
            else
            {
                ViewBag.depts = departmentRepo.GetAll();         //db.Departments.ToList();
                return View(std);
            }
            

        }

        //public async Task<JsonResult> CheckEmail(string email)
        //{
        //    var emailExists = await db.Students.AnyAsync(a => a.Email == email);


        //    return Json(!emailExists);

        //}
    }
}
