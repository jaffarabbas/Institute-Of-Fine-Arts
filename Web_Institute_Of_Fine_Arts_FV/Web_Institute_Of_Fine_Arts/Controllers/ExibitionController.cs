using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Institute_Of_Fine_Arts_Database_Layer.DatabaseOperations;

namespace Web_Institute_Of_Fine_Arts.Controllers
{
    public class ExibitionController : Controller
    {
        AdminDBHandler DBHandler;

        public ExibitionController()
        {
            DBHandler = AdminDBHandler.GetDBHandler();
        }
        public ActionResult Index()
        {
            return View();
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

        public PartialViewResult ExibitionStudentWorkCard(int id)
        {
            try
            {
                var data = DBHandler.GetAllExibitionItemData(id);
                return PartialView(data);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return PartialView();
        }

        public ActionResult ExibitionStudentWorkList(int id)
        {
            try
            {
                var data = DBHandler.GetAllExibitionItemData(id);
                return View(data);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return View();
        }
    }
}