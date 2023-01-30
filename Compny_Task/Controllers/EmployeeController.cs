using Compny_Task.Dbcontex;
using Compny_Task.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Compny_Task.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult partial()
        {
            return View();
        }
        public ActionResult Report()
        {
            using (PracticalTestEntities Db = new PracticalTestEntities())
            {
                return View(Db.sp_Table().ToList());
            }
        }
        public ActionResult SaveorUpdate(Employee_model model)
        {
            using (PracticalTestEntities Db = new PracticalTestEntities())
            {


                string filename = Path.GetFileNameWithoutExtension(model.Imagefile.FileName);
                string extantion = Path.GetExtension(model.Imagefile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extantion;
                model.PhotoPath = "~/SaveImage/" + filename;
                filename = Path.Combine(Server.MapPath("~/SaveImage/"), filename);
                model.Imagefile.SaveAs(filename);
                try
                {
                    if (model.ID == 0)
                    {
                        Emp_Table Emp = new Emp_Table()
                        {
                            EmpNO = model.EmpNO,
                            EmpName = model.EmpName,
                            PhoneNo = model.PhoneNo,
                            Salary = model.Salary,
                            DOB = model.DOB,
                            Email = model.Email,
                            Emp_Photo = model.Emp_Photo,
                            PhotoPath = model.PhotoPath,
                            Qualification=model.Qualification
                        };
                        Db.Entry(Emp).State = EntityState.Added;
                        Db.SaveChanges();
                        TempData["message"] = "Your Data Save Successfuly..";

                    }
                    else
                    {
                        Emp_Table Emp = new Emp_Table()
                        {
                            EmpNO = model.EmpNO,
                            EmpName = model.EmpName,
                            PhoneNo = model.PhoneNo,
                            Salary = model.Salary,
                            DOB = model.DOB,
                            Email = model.Email,
                            Emp_Photo = model.Emp_Photo,
                            PhotoPath = model.PhotoPath,
                            Qualification = model.Qualification

                        };
                        Db.Entry(Emp).State = EntityState.Modified;
                        Db.SaveChanges();
                        TempData["message"] = "Your Data Update Successfuly";
                    }
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
                return RedirectToAction("Index");
            }
        }
        public ActionResult EditData(int id)
        {
            Employee_model model;
            using (PracticalTestEntities Db = new PracticalTestEntities())
            {
                var data = new Emp_Table();
                data = Db.Emp_Table.Where(x => x.ID == id).FirstOrDefault();

                model = new Employee_model()
                {
                    EmpNO = data.EmpNO,
                    EmpName = data.EmpName,
                    PhoneNo = data.PhoneNo,
                    Salary = data.Salary,
                    DOB = data.DOB,
                    Email = data.Email,
                    Emp_Photo = data.Emp_Photo,
                    PhotoPath = data.PhotoPath,
                    Qualification = data.Qualification,
                };
            }
            return PartialView("index", model);
        }

        public ActionResult Delete(int id)
        {
            using (PracticalTestEntities db = new PracticalTestEntities())
            {
                try
                {
                    Emp_Table obj = new Emp_Table()
                    {
                        ID  = id
                    };

                    db.Entry(obj).State = EntityState.Deleted;
                    db.SaveChanges();
                    TempData["Delete"] = "Data Delete Sucessfully!";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return RedirectToAction("index");
        }
    }
}