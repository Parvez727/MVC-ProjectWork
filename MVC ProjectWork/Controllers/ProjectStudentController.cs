using MVC_ProjectWork.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjectWork.Controllers
{
    //[Authorize]
    public class ProjectStudentController : Controller
    {

        // GET: ProjectStudent
        private MVC_ProjectEntities2 db = new MVC_ProjectEntities2();
        List<Mystudent> a = new List<Mystudent>();
        
        public ActionResult Index()
        {
            foreach (var d in db.Students.ToList())
            {
                a.Add(new Mystudent() { studentid = d.studentid, studentname = d.studentname,
                    @class = d.@class , gender = d.gender, date = d.date, image_path = d.image_path });
            }

            return View(a);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Mystudent myst)
        {
            string FileName1 = Path.GetFileName(myst.ImageFile.FileName);
            Student a = new Student();
            a.studentid = myst.studentid;
            a.studentname = myst.studentname;
            a.@class = myst.@class;
            a.gender = myst.gender;
            a.date = myst.date;
            a.image_path = FileName1;
           
            
            if (ModelState.IsValid == true)
            {
                string fileName = Path.GetFileNameWithoutExtension(myst.ImageFile.FileName);
                string extension = Path.GetExtension(myst.ImageFile.FileName);
                HttpPostedFileBase postedFile = myst.ImageFile;
                int length = postedFile.ContentLength;

                if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                {
                    if (length <= 1000000)
                    {
                        fileName = fileName + extension;
                        myst.image_path = "~/images/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/images/"),fileName);
                        myst.ImageFile.SaveAs(fileName);
                        db.Students.Add(a);
                        int b = db.SaveChanges();
                        if (b > 0)
                        {
                            TempData["CreateMessage"] = "<script>alert('Data Inserted Successfully')</script>";
                            ModelState.Clear();
                            return RedirectToAction("Index","ProjectStudent");

                        }
                        else
                        {
                            TempData["CreateMessage"] = "<script>alert('Data Not Inserted ')</script>";

                        }

                    }
                    else
                    {
                        TempData["SizeMessage"] = "<script>alert('Image Size should be less than 1 MB')</script>";
                    }
                }
                else
                {
                    TempData["ExtensionMessage"] = "<script>alert('Format Not Supported')</script>";
                }


                //try
                //{


                //    db.Students.Add(a);
                //    db.SaveChanges();
                //    TempData["msg"] = "Successfully inserted";

                //}
                //catch (Exception ex)
                //{
                //    ViewBag.error = ex.Message.ToString();

                //}
                // return View("AddStudents", myst);
                // return View("Index");
                
            }
            return View();

        }


        public ActionResult Edit(int id)//select-Edit
        {
           
            Mystudent st1 = new Mystudent();
            //string FileName1 = Path.GetFileName(st1.ImageFile.FileName);
            var st = db.Students.Find(id);//linq code
                                          //from model1(edmx) to viewmodel
            
            st1.studentid = st.studentid;
            st1.studentname = st.studentname;
            st1.@class = st.@class;
            st1.gender = st.gender;
            st1.date = st.date;
            st1.image_path = st.image_path;
            //Session["Image"] = st1.image_path;
            return View(st1);//st1 is a viewmodel that is passed from controller to the view
        }
        public ActionResult ChangePicture(int id)//select-Edit
        {

            Mystudent st1 = new Mystudent();
            //string FileName1 = Path.GetFileName(st1.ImageFile.FileName);
            var st = db.Students.Find(id);//linq code
                                          //from model1(edmx) to viewmodel

            st1.studentid = st.studentid;
            st1.image_path = st.image_path;
            //Session["Image"] = st1.image_path;
            return View(st1);//st1 is a viewmodel that is passed from controller to the view
        }

        [HttpPost]
        public ActionResult ChangePicture(Mystudent myst)//Post-Button Click
        {
            //string FileName1 = Path.GetFileName(myst.ImageFile.FileName);
              try
                {
                    string FileName = Path.GetFileName(myst.ImageFile.FileName);
string FilePath = Path.Combine(Server.MapPath("~/images"), FileName);

myst.ImageFile.SaveAs(FilePath);
                    Student st = db.Students.Find(myst.studentid);
                st.image_path = FileName;

                    db.SaveChanges();




                    //Student item = null;
                    //item = (from c in db.Students where c.studentid == myst.studentid select c).FirstOrDefault();
                    //if (item == null)
                    //{
                    //    ViewBag.error = $"Item with id {myst.studentid} was not found";
                    //}

                    //TryUpdateModel(item);
                    //db.SaveChanges();

                    TempData["msg"] = $"Successfully Updated the record: {myst.studentid}";
                    return RedirectToAction("Index");
                }


                catch (Exception ex)
                {
                    ViewBag.error = ex.Message.ToString();

                }
                      return View(myst);
        }



        [HttpPost]
        public ActionResult Edit(Mystudent myst)//Post-Button Click
        {
            //string FileName1 = Path.GetFileName(myst.ImageFile.FileName);
            if (ModelState.IsValid == true)
            {
                //if (myst.ImageFile != null)
                //{
                //    string fileName = Path.GetFileNameWithoutExtension(myst.ImageFile.FileName);
                //    string extension = Path.GetExtension(myst.ImageFile.FileName);
                //    HttpPostedFileBase postedFile = myst.ImageFile;
                //    int length = postedFile.ContentLength;

                //    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                //    {
                //        if (length <= 1000000)
                //        {
                //            fileName = fileName + extension;
                //            myst.image_path = "~/images/" + fileName;
                //            fileName = Path.Combine(Server.MapPath("~/images/"), fileName);
                //            myst.ImageFile.SaveAs(fileName);
                //            db.Entry(myst).State = EntityState.Modified;
                //            int b = db.SaveChanges();
                //            if (b > 0)
                //            {
                //                TempData["UpdatedMessage"] = "<script>alert('Data Updated Successfully')</script>";
                //                ModelState.Clear();
                //                return RedirectToAction("Index", "ProjectStudent");

                //            }
                //            else
                //            {
                //                TempData["UpdatedMessage"] = "<script>alert('Data Not Updated ')</script>";

                //            }

                //        }
                //        else
                //        {
                //            TempData["SizeMessage"] = "<script>alert('Image Size should be less than 1 MB')</script>";
                //        }
                //    }
                //    else
                //    {
                //        TempData["ExtensionMessage"] = "<script>alert('Format Not Supported')</script>";
                //    }

                //}
                try
                {
                    Student item = null;
                    item = (from c in db.Students where c.studentid == myst.studentid select c).FirstOrDefault();
                    if (item == null)
                    {
                        ViewBag.error = $"Item with id {myst.studentid} was not found";
                    }

                    TryUpdateModel(item);
                    db.SaveChanges();

                    TempData["msg"] = $"Successfully Updated the record: {myst.studentid}";
                    return RedirectToAction("Index");
                }


                catch (Exception ex)
                {
                    ViewBag.error = ex.Message.ToString();

                }
            }
            return View(myst);
        }


   //     [HttpPost]
        public ActionResult Delete(int id)
        {
            Student student;
            student = (from st1 in db.Students where st1.studentid == id select st1).FirstOrDefault();

            db.Students.Attach(student);
            db.Entry(student).State = EntityState.Deleted;
            db.SaveChanges();
            TempData["msg"] = $"Succesfully deleted {id}";
            return RedirectToAction("Index");
        }

    }
}