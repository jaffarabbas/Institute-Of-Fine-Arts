using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Institute_Of_Fine_Arts_Database_Models;
using Web_Institute_Of_Fine_Arts_Database_Layer.DatabaseOperations;

namespace Web_Institute_Of_Fine_Arts.Controllers
{
    public class LoginController : Controller
    {
        //single ton method
        LoginDBHandler DBHandler;
        public LoginController()
        {
            DBHandler = LoginDBHandler.GetDBHandler();
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //admin login
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminLogin(ADMIN_LOGIN_MODEL objUser)
        {
            var result = DBHandler.AdminLoginHandler(objUser);
            if (result != null)
            {
                Session["AdminID"] = result.AD_ID.ToString();
                Session["AdminName"] = result.AD_NAME.ToString();
                Session["AdminProfile"] = result.AD_PROFILE.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        //student login
        public ActionResult StudentLogin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StudentLogin(STUDENT_LOGIN_MODEL objUser)
        {
            var result = DBHandler.StudentLoginHandler(objUser);
            if (result != null)
            {
                Session["StudentID"] = result.STDL_ID.ToString();
                Session["StudentName"] = result.STDL_NAME.ToString();
                Session["StudentProfile"] = result.STDL_PROFILE.ToString();
                return RedirectToAction("Index", "Students");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        //faculty login
        public ActionResult FacultyLogin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FacultyLogin(STAFF_LOGIN_MODEL objUser)
        {
            var result = DBHandler.StaffLoginHandler(objUser);
            if (result != null)
            {
                Session["StaffID"] = result.STF_ID.ToString();
                Session["StaffName"] = result.STF_NAME.ToString();
                Session["StaffProfile"] = result.STF_PROFILE.ToString();
                return RedirectToAction("Index", "Staff");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}