using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NvtK22CNT1Lesson11.ModelViews;
using TvcK22CNT1Lesson11.Models;

namespace NvtK22CNT1Lesson11.Controllers
{
    public class NvtTaiKhoansController : Controller
    {
        private NvtLesson11DbsEntities db = new NvtLesson11DbsEntities();

        // GET: NvtTaiKhoans
        public ActionResult Index()
        {
            return View(db.NvtTaiKhoans.ToList());
        }

        // GET: NvtTaiKhoans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NvtTaiKhoan NvtTaiKhoan = db.NvtTaiKhoans.Find(id);
            if (NvtTaiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(NvtTaiKhoan);
        }

        // GET: NvtTaiKhoans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NvtTaiKhoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NvtId,NvtUserName,NvtPassword,NvtFullName,NvtAge,NvtEmail,NvtPhone,NvtStatus")] NvtTaiKhoan NvtTaiKhoan)
        {
            if (ModelState.IsValid)
            {
                db.NvtTaiKhoans.Add(NvtTaiKhoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(NvtTaiKhoan);
        }

        // GET: NvtTaiKhoans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NvtTaiKhoan NvtTaiKhoan = db.NvtTaiKhoans.Find(id);
            if (NvtTaiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(NvtTaiKhoan);
        }

        // POST: NvtTaiKhoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NvtId,NvtUserName,NvtPassword,NvtFullName,NvtAge,NvtEmail,NvtPhone,NvtStatus")] NvtTaiKhoan NvtTaiKhoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(NvtTaiKhoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(NvtTaiKhoan);
        }

        // GET: NvtTaiKhoans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NvtTaiKhoan NvtTaiKhoan = db.NvtTaiKhoans.Find(id);
            if (NvtTaiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(NvtTaiKhoan);
        }

        // POST: NvtTaiKhoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NvtTaiKhoan NvtTaiKhoan = db.NvtTaiKhoans.Find(id);
            db.NvtTaiKhoans.Remove(NvtTaiKhoan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // Form đăng nhập hệ thống
        public ActionResult NvtLogin()
        {
            var NvtModel = new NvtLoginModel();
            return View(NvtModel);
        }

        [HttpPost]
        public ActionResult NvtLogin(NvtLoginModel NvtModel)
        {
            // khi người dùng nhấn nút đăng nhập; xử lý và tìm kiến, so sanh trong db

            var NvtCheckLogin = db.NvtTaiKhoans.Where(x => x.NvtUserName.Equals(NvtModel.NvtUserName) && x.NvtPassword.Equals(NvtModel.NvtPassword)).FirstOrDefault();
            if(NvtCheckLogin != null)
            {
                //Lưu trữ session
                Session["NvtMember"] = NvtCheckLogin;

                return Redirect("/");
            }
            return View(NvtModel);
        }
        public ActionResult Logout()
        {
            Session.Remove("NvtMember");
            return Redirect("/");
        }
    }
}
