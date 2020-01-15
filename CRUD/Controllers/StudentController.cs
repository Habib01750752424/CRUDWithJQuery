using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD.Models;
using CRUD.Model.Model;
using AutoMapper;
using CRUD.BLL.BLL;

namespace CRUD.Controllers
{
    public class StudentController : Controller
    {
        StudentManager _studentManager = new StudentManager();

        //***************Add Student*****************
        // GET: Student
        public ActionResult Add()
        {
            StudentViewModel studentViewModel = new StudentViewModel();
            studentViewModel.Students = _studentManager.GetAll();
            return View(studentViewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentViewModel studentViewModel)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                Student student = Mapper.Map<Student>(studentViewModel);
                //studentViewModel.Students = _studentManager.GetAll();

                //bool isExistCategoryCode = _categoryManager.ExistCategoryCode(category);
                //if (isExistCategoryCode)
                //{
                //    ViewBag.existDuplicate = "Code is Already Exist..";

                //    return View(categoryViewModel);
                //}

                //bool isExistCategoryName = _categoryManager.ExistCategoryName(category);
                //if (isExistCategoryName)
                //{
                //    ViewBag.existDuplicate = "Name is Already Exist..";

                //    return View(categoryViewModel);
                //}

                if (_studentManager.Add(student))
                {
                    message = "Saved Successfully..";
                }
                else
                {
                    message = "Not Saved";
                }
            }
            else
            {
                ViewBag.InvalidModel = "ModelState is invalied!";
            }

            ViewBag.Message = message;
            studentViewModel.Students = _studentManager.GetAll();
            return View(studentViewModel);
        }


        //***************Update Student*****************
        public ActionResult EditStudent(int id)
        {
            var student = _studentManager.GetById(id);

            StudentViewModel studentViewModel = Mapper.Map<StudentViewModel>(student);
            studentViewModel.Students = _studentManager.GetAll();
            return View(studentViewModel);
        }

        [HttpPost]
        public ActionResult EditStudent(StudentViewModel studentViewModel)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                Student student = Mapper.Map<Student>(studentViewModel);
                studentViewModel.Students = _studentManager.GetAll();
             
                if (_studentManager.Update(student))
                {
                    message = "Updated Successfully..";
                }
                else
                {
                    message = "No Change Your Update Information";
                }
            }
            else
            {
                ViewBag.InvalidModel = "ModelState is invalied!";
                ViewBag.existDuplicate = "";
                return View(studentViewModel);
            }

            ViewBag.Message = message;
            return View(studentViewModel);
        }

        //***************Delete Student*****************
        public ActionResult DeleteStudent(int id)
        {
            var student = _studentManager.GetById(id);
            StudentViewModel studentViewModel = Mapper.Map<StudentViewModel>(student);
            //studentViewModel.Students = _studentManager.GetAll();
            return View(studentViewModel);
        }

        [HttpPost]
        public ActionResult DeleteStudent(int id, FormCollection collection)
        {
            StudentViewModel studentViewModel = new StudentViewModel();
            var student = _studentManager.Delete(id);
            //studentViewModel.Students = _studentManager.GetAll();
            return RedirectToAction("Add");
            //return View(studentViewModel);
        }
    }
}