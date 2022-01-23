using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Institute_Of_Fine_Arts_Database_Models;
using Web_Institute_Of_Fine_Arts_Database_Layer.DatabaseOperations;

namespace Web_Institute_Of_Fine_Arts.Controllers
{
    public class StudentsController : Controller
    {
        StudentDBHandler DBHandler;
        public StudentsController()
        {
            DBHandler = StudentDBHandler.GetDBHandler();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public ActionResult Index()
        {
            if (Session["StudentID"] != null)
            {
                StaffController.stfId = Convert.ToInt32(Session["StaffID"]);
                return View();
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }

        #region Compitition Controllers

        public PartialViewResult CompititionCard()
        {
            try
            {
                int id = Convert.ToInt32(Session["StudentID"]);
                var data = DBHandler.GetCompitionList(id);
                return PartialView(data);

            }catch (Exception ex)
            {
               Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return PartialView();
        }

        public ActionResult CompititionList()
        {
            try
            {
                int id = Convert.ToInt32(Session["StudentID"]);
                var data = DBHandler.GetCompitionList(id);
                return View(data);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return View();
        }

        public ActionResult WorkCompitition(int comID)
        {
            TempData["ComId"] = comID;
            return View();
        }
        [HttpPost]
        public ActionResult WorkCompitition(WORK_OF_COMPITITION_MODEL compitition)
        {
            try
            {
                int id = Convert.ToInt32(Session["StudentID"]);
                int comId = Convert.ToInt32(TempData["ComId"].ToString());
                int data = DBHandler.InsertWorkCompition(id,comId,compitition);

                if(data > 0)
                {
                    TempData["datamessage"] = "<script>alert('Data Inserted Succesfully')</script>";
                    return RedirectToAction("CompititionList");
                }
                else
                {
                    if(data == -1)
                    {
                        TempData["lengthmessage"] = "<script>alert('Length should be 10 mb')</script>";
                    }
                    else if(data == -2)
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
        #endregion
    }
}