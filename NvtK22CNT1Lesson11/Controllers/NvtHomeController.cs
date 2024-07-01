using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TvcK22CNT1Lesson11.Models;

namespace NvtK22CNT1Lesson11.Controllers
{
    public class NvtHomeController : Controller
    {
        public ActionResult NvtIndex()
        {
            // lấy thông tin từ session
            //ViewBag["NvtTaiKhoan"] = "";
            if (Session["NvtMember"] != null)
            {
                ViewBag.NvtTaiKhoan = ((NvtTaiKhoan)Session["NvtMember"]).NvtFullName;
            }
            return View();
        }

        public ActionResult NvtAbout()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult NvtContact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}