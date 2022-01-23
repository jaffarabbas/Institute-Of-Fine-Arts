using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Institute_Of_Fine_Arts_Database_Models;
using Web_Institute_Of_Fine_Arts_Database_Layer.DatabaseOperations;

namespace Web_Institute_Of_Fine_Arts.Controllers
{
    public class AdminController : Controller
    {
        AdminDBHandler DBHandler;
        public AdminController()
        {
            DBHandler = AdminDBHandler.GetDBHandler();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public ActionResult Index()
        {
            if (Session["AdminID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        #region Cource controllers
        ////courses

        public ActionResult Course_List()
        {
            try
            {
                var data = DBHandler.GetAllCourse();
                if (data != null)
                {
                    return View(data);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return View();
        }

        public ActionResult Create_Course()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create_Course(COURS_MODEL course)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    int data = DBHandler.AddCourses(course);
                    if (data > 0)
                    {
                        TempData["InsertMessage"] = "<script>alert('Cource Inserted')</script>";
                        return RedirectToAction("Course_List");
                    }
                    else
                    {
                        ViewBag.InsertMessage = "<script>alert('Error In Insertion')</script>";
                    }
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Data is Not Valid')</script>";
                }
            } catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return View(course);
        }

        #endregion
        ////Students
        #region Student controllers
        public ActionResult Students_List()
        {
            try
            {
                var studentList = DBHandler.GetAllStudents();
                return View(studentList);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return View();
        }

        public ActionResult Create_Student()
        {
            try
            {
                var courseList = DBHandler.GetAllCourse();
                ViewBag.courseList = new SelectList(courseList, "CR_ID", "  CR_NAME");
                return View();
            } catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create_Student(VW_SHOW_STUDENTS_ALL_DETIALS_MODEL stdDetials)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int data = DBHandler.AddStudents(stdDetials);
                    if (data > 0)
                    {
                        TempData["datamessage"] = "<script>alert('Data Inserted Succesfully')</script>";
                        return RedirectToAction("Students_List");
                    }
                    else
                    {
                        if (data == -1)
                        {
                            TempData["lengthmessage"] = "<script>alert('Length should be 10 mb')</script>";
                        }
                        else if (data == -2)
                        {
                            TempData["extentionmessage"] = "<script>alert('Format not Supported')</script>";
                        }
                        else
                        {
                            TempData["dtemessage"] = "<script>alert('Data Not Inserted')</script>";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return View();
        }

        //Register Student
        public ActionResult RegisterStudent()
        {
            try
            {
                var courseList = DBHandler.GetAllCourse();
                var studentList = DBHandler.GetAllUnRegisteredStudents();
                ViewBag.courseList = new SelectList(courseList, "CR_ID", "  CR_NAME");
                ViewBag.studentList = new SelectList(studentList, "STDL_ID", "STDL_NAME");
                return View();
            } catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return View();
        }
        [HttpPost]
        public ActionResult RegisterStudent(REGISTRATION_MODEL registration)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    int data = DBHandler.AddRegisterStudent(registration);
                    if (data > 0)
                    {
                        TempData["InsertMessage"] = "<script>alert('Register Successfully')</script>";
                        return RedirectToAction("RegisterStudentList");
                    }
                    else
                    {
                        TempData["errormessage"] = "<script>alert('Registration Failed')</script>";
                    }
                }
            } catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return View();
        }

        public ActionResult RegisterStudentList()
        {
            try
            {
                var stdData = DBHandler.GetAllStudentData();
                return View(stdData);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return View();
        }
        #endregion
        ////Staff
        #region Staff controllers
        public ActionResult Staff_List()
        {
            try
            {
                var data = DBHandler.GetAllStaff();
                return View(data);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return View();
        }

        public ActionResult Create_Staff()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Create_Staff(VW_SHOW_STAFF_ALL_DETIALS_MODEL stfDetials)
        {
            try
            {
                int data = DBHandler.AddStaff(stfDetials);
                if (data > 0)
                {
                    TempData["datamessage"] = "<script>alert('Data Inserted Succesfully')</script>";
                    ModelState.Clear();
                    return RedirectToAction("Staff_List");
                }
                else
                {
                    if (data == -1)
                    {
                        TempData["lengthmessage"] = "<script>alert('Length should be 10 mb')</script>";
                    }
                    else if (data == -2)
                    {
                        TempData["extentionmessage"] = "<script>alert('Format not Supported')</script>";
                    }
                    else
                    {
                        TempData["dtemessage"] = "<script>alert('Data Not Inserted')</script>";
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return View();
        }

        //Assigned Staff
        public ActionResult AssignedStaff()
        {
            try
            {
                var courseList = DBHandler.GetAllUnPopulatedCourse();
                var staffList = DBHandler.GetAllUnAssignedStaff();
                ViewBag.courseList = new SelectList(courseList, "CR_ID", "  CR_NAME");
                ViewBag.staffList = new SelectList(staffList, "STF_ID", "STF_NAME");
                return View();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return View();
        }
        [HttpPost]
        public ActionResult AssignedStaff(ASSIGNED_MODEL assigned)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    int data = DBHandler.AddAssignedStaff(assigned);
                    if (data > 0)
                    {
                        TempData["InsertMessage"] = "<script>alert('Assigned Successfully')</script>";
                        return RedirectToAction("AssignedStaffList");
                    }
                    else
                    {
                        TempData["errormessage"] = "<script>alert('Assigned Failed')</script>";
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return View();
        }

        public ActionResult AssignedStaffList()
        {
            try
            {
                var data = DBHandler.GetAllAssigend();
                return View(data);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return View();
        }
        #endregion

        #region Exibition Controller

        public ActionResult Create_Exibition()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create_Exibition(EXIBITION_MODEL exe)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    int data = DBHandler.AddExibition(exe);
                    if (data > 0)
                    {
                        TempData["InsertMessage"] = "<script>alert('Exibition Inserted')</script>";
                        return RedirectToAction("ExibitionList", "Admin");
                    }
                    else
                    {
                        ViewBag.InsertMessage = "<script>alert('Error In Insertion')</script>";
                    }
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Data is Not Valid')</script>";
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return View(exe);
        }


        public PartialViewResult ExibitionCard()
        {
            try
            {
                var data = DBHandler.GetAllExibition();
                return PartialView(data);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return PartialView();
        }

        public ActionResult ExibitionList()
        {
            try
            {
                var data = DBHandler.GetAllExibition();
                return View(data);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return View();
        }

        public ActionResult EligibleStudentList(int id)
        {
            try
            {
                TempData["ExibitionId"] = id;
                var data = DBHandler.GetAllEligibleStudentList();
                return View(data);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return View();
        }

        public ActionResult CreateExibitionEntries(int id)
        {
            try
            {
                TempData["StudentRegId"] = id;
                return View();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return View();
        }
        [HttpPost]
        public ActionResult CreateExibitionEntries(EXIBITION_ENTRIES_MODEL exeModel)
        {
            try
            {
                int regId = Convert.ToInt32(TempData["StudentRegId"].ToString());
                int exeId = Convert.ToInt32(TempData["ExibitionId"].ToString());
                if (ModelState.IsValid == true)
                {
                    int data = DBHandler.AddExibitionEntries(exeId, regId, exeModel);
                    if (data > 0)
                    {
                        TempData["InsertMessage"] = "<script>alert('Data of Exibition Inserted')</script>";
                        return RedirectToAction("ExibitionList","Admin");
                    }
                    else
                    {
                        ViewBag.InsertMessage = "<script>alert('Error In Insertion')</script>";
                    }
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Data is Not Valid')</script>";
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return View();
        }
        #endregion
    }
}
