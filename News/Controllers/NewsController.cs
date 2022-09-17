using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.Controllers
{
    public class NewsController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        // GET: News
        public ActionResult ShowGroups()
        {
            return PartialView(unitOfWork.pageGroupRepository.GetShowGroups());
        }

        public ActionResult ShowGroupsMenu()
        {
            return PartialView(unitOfWork.pageGroupRepository.GetAllNewsGroup());
        }

        public ActionResult ShowTopNews()
        {
            return PartialView(unitOfWork.PageRepository.GetTopNews());
        }

        [Route("News/{id}/{Title}")]
        public ActionResult ShowNews(int id,string Title)
        {
            ViewBag.name = Title;
            var ShowNewsGroups = unitOfWork.PageRepository.GetNewByGroupId(id);

            //pagging
            // int take = 2;
            // int skip = (pageId-1)*take;
            // ViewBag.pageCount = ShowNewsGroups.Count() / take;
            //ShowNewsGroups.OrderByDescending(x => x.CreatePage).Skip(skip).Take(take).ToList()

            return View(ShowNewsGroups);

           
        }

        [Route("Archive")]
        public ActionResult ArchiveNews()
        {
            return View(unitOfWork.PageRepository.GetAllNews());
        }

        [Route("News/{id}")]
        public ActionResult ShowDetailNews(int id)
        {
            var news = unitOfWork.PageRepository.GetNewsById(id);
            if (news==null)
            {
                return HttpNotFound();
            }

            news.Visit += 1;
            unitOfWork.PageRepository.UpdateNews(news);
            unitOfWork.Save();

            return View(news);
        }

        [Route("Comment/{id}")]
        public ActionResult AddComment(int id,string name,string email,string comment)
        {
            PageComment pageComment = new PageComment() {
                CreateComment=DateTime.Now,
                PageId=id,
                UserName=name,
                Email=email,
                CommentText=comment
            };

            unitOfWork.pageCommentRepository.InsertNewsComment(pageComment);
            unitOfWork.Save();

            var Comment = unitOfWork.pageCommentRepository.GetCommentByNewsId(id);
            return PartialView("ShowComment", Comment);
        }
        //this Action for show Comment'sNews
        public ActionResult ShowComment(int id)
        {
            var Comment = unitOfWork.pageCommentRepository.GetCommentByNewsId(id);

            return PartialView(Comment);
        }

        #region Search
        [Route("Search")]
        public ActionResult SearchNews(string q)
        {
            ViewBag.name = q;
            return View(unitOfWork.PageRepository.GetNewsBySearch(q));
        }
        #endregion




    }
}