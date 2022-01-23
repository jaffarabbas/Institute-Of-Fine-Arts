using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Institute_Of_Fine_Arts_Database_Models;
using Web_Institute_Of_Fine_Arts_Database_Layer.DatabaseOperations;

namespace Web_Institute_Of_Fine_Arts.Controllers
{
    public class StaffController : Controller
    {
        public static int stfId;

        StaffDBHandler dBHandler;
        public StaffController()
        {
            dBHandler = StaffDBHandler.GetDBHandler();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public ActionResult Index()
        {
            if (Session["StaffID"] != null)
            {
                StaffController.stfId = Convert.ToInt32(Session["StaffID"]);
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        #region Compition Controllers

        public ActionResult Create_Compitition()
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
        public ActionResult Create_Compitition(COMPITITION_MODEL compitition)
        {
            try
            {
                int data = dBHandler.AddCompitition(compitition);
                if (data > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('Compitition Inserted')</script>";
                    return RedirectToAction("CompititionList", "Staff");
                }
                else
                {
                    if (data == -1)
                    {
                        TempData["errorMessage"] = "<script>alert('End Date must me greater then Start Date')</script>";
                    }
                    else
                    {
                        TempData["errorMessage"] = "<script>alert('Compitition is not inserted')</script>";
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return View();
        }

        public ActionResult CompititionList()
        {
            try
            {
                //int stfId = Convert.ToInt32(Session["StaffID"]);
                var data = dBHandler.GetAllCompitition(StaffController.stfId);
                return View(data);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return View();
        }

        public ActionResult WorkCompititonChecking(int id)
        {
            try
            {
                //get compition detitals for spesific result card
                var data = dBHandler.GetAllPendingWorkCompitition(id);
                return View(data);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return View();
        }

        public PartialViewResult CheckedResultCard()
        {
            try
            {
                var data = dBHandler.GetAllResult(StaffController.stfId);
                return PartialView(data);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return PartialView();
        }

        public ActionResult CheckedResultList()
        {
            try
            {
                var data = dBHandler.GetAllResult(StaffController.stfId);
                return View(data);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return View();
        }

        public ActionResult CompletedWorkCompititon(int id)
        {
            try
            {
                //get compition detitals for spesific result card
                var data = dBHandler.GetAllCompletedWorkCompitition(id);
                return View(data);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return View();
        }
        #endregion

        //#region Result Controllers

        public PartialViewResult ResultCard()
        {
            try
            {
                var data = dBHandler.GetAllResult(StaffController.stfId);
                return PartialView(data);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return PartialView();
        }

        public ActionResult StudentResultList()
        {
            try
            {
                var data = dBHandler.GetAllResult(StaffController.stfId);
                return View(data);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return View();
        }

        public ActionResult StudentResult(int id, int comId)
        {
            try
            {
                TempData["ResId"] = comId;
                TempData["ResWorkComId"] = id;
                return View();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return View();
        }

        [HttpPost]

        public ActionResult StudentResult(RESULT_ENTRIES_MODEL resultEntries)
        {
            try
            {
                int resWorkId = Convert.ToInt32(TempData["ResWorkComId"].ToString());
                int regId = Convert.ToInt32(TempData["ResId"].ToString());
                int data = dBHandler.AddResult(resWorkId, regId, resultEntries);
                if (data > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('Result Inserted')</script>";
                    return RedirectToAction("StudentResultList", "Staff");
                }
                else
                {
                    TempData["InsertMessage"] = "<script>alert('Error In Insertion')</script>";
                }
        }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return View();
        }

        //#endregion
    }
}