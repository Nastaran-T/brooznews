using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageCommentRepository : IPageCommentRepository
    {
        private NewsContext db;
        public PageCommentRepository(NewsContext context)
        {
            db = context;
        }

        public IEnumerable<PageComment> GetAllNewsComment()
        {
            return db.PageComments.ToList();
        }

        public PageComment GetNewsCommentById(int PageCommentId)
        {
            return db.PageComments.Find(PageCommentId);
        }

        public bool InsertNewsComment(PageComment PageComment)
        {
            try
            {
                db.PageComments.Add(PageComment);
                return true;
            }
            catch (Exception)
            {

                return false;
            }   
        }

        public bool UpdateNewsComment(PageComment PageComment)
        {
            try
            {
                db.Entry(PageComment).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteNewsComment(PageComment PageComment)
        {
            try
            {
                db.Entry(PageComment).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteNewsComment(int PageCommentId)
        {
            try
            {
                var NewsComment = GetNewsCommentById(PageCommentId);
                DeleteNewsComment(NewsComment);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<PageComment> GetCommentByNewsId(int pageId)
        {
            return db.PageComments.Where(x => x.PageId == pageId);
        }
    }
}
