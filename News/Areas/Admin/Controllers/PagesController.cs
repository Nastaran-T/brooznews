using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;


namespace News.Areas.Admin.Controllers
{
    [Authorize]
    public class PagesController : Controller
    {
        UnitOfWork UnitOfWork = new UnitOfWork();
        #region Method
        private string SaveImage(HttpPostedFileBase ImageFile)
        {
                string ImageName = Guid.NewGuid() + Path.GetExtension(ImageFile.FileName);
                string ImagePath = Server.MapPath("/images/" + ImageName);
                ImageFile.SaveAs(ImagePath);
                return ImageName;
            
            
            

        }
        private void DeleteOldImage(string ImageFile)
        {
            System.IO.File.Delete(Server.MapPath("/images/" + ImageFile));
        }

        #endregion


        

        // GET: Admin/Pages
        public ActionResult Index()
        {
            var pages = UnitOfWork.PageRepository.GetAllNews();
            return View(pages.ToList());
        }

        // GET: Admin/Pages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = UnitOfWork.PageRepository.GetNewsById(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // GET: Admin/Pages/Create
        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(UnitOfWork.pageGroupRepository.GetAllNewsGroup(), "GroupId", "GroupTitle");
            return View();
        }

        // POST: Admin/Pages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PageId,GroupId,Title,ShortDescription,Text,ImageName,CreatePage,Visit,ShowSlider,Tags")] Page page,HttpPostedFileBase ImgUp)
        {
            if (ModelState.IsValid)
            {
                page.Visit = 0;
                page.CreatePage= DateTime.Now;

                if (ImgUp != null)
                {
                    page.ImageName = SaveImage(ImgUp);

                }
                else
                {
                    page.ImageName = "default.png";
                }

               

                UnitOfWork.PageRepository.InsertNews(page);
                UnitOfWork.Save();
                return RedirectToAction("Index");
            }

            ViewBag.GroupId = new SelectList(UnitOfWork.pageGroupRepository.GetAllNewsGroup(), "GroupId", "GroupTitle", page.GroupId);
            return View(page);
        }

        // GET: Admin/Pages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = UnitOfWork.PageRepository.GetNewsById(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupId = new SelectList(UnitOfWork.pageGroupRepository.GetAllNewsGroup(), "GroupId", "GroupTitle", page.GroupId);
            return View(page);
        }

        // POST: Admin/Pages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PageId,GroupId,Title,ShortDescription,Text,ImageName,CreatePage,Visit,ShowSlider,Tags")] Page page,HttpPostedFileBase ImgUp)
        {
            if (ModelState.IsValid)
            {
                if (ImgUp != null)
                {
                    if (page.ImageName != null)
                    {
                        DeleteOldImage(page.ImageName);
                    }


                    page.ImageName = SaveImage(ImgUp);
                }
              


                UnitOfWork.PageRepository.UpdateNews(page);
                UnitOfWork.Save();
                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(UnitOfWork.pageGroupRepository.GetAllNewsGroup(), "GroupId", "GroupTitle", page.GroupId);
            return View(page);
        }

        // GET: Admin/Pages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = UnitOfWork.PageRepository.GetNewsById(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // POST: Admin/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var page = UnitOfWork.PageRepository.GetNewsById(id);
            if (page.ImageName!=null)
            {
                DeleteOldImage(page.ImageName);
            }
            UnitOfWork.PageRepository.DeleteNews(id);
            UnitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UnitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
