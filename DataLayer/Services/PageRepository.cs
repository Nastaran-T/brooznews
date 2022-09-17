using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageRepository : IPageRepository
    {
        //NewsContext db = new NewsContext();

            //Dependency enjection cunstructor
        private NewsContext db;
        public PageRepository(NewsContext context)
        {
            db = context;
        }

        public IEnumerable<Page> GetAllNews()
        {
           return db.Pages.ToList();
        }

        public Page GetNewsById(int PageId)
        {
            return db.Pages.Find(PageId);
        }

        public bool InsertNews(Page Page)
        {
            try
            {
                db.Pages.Add(Page);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateNews(Page Page)
        {
            try
            {
                db.Entry(Page).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteNews(Page Page)
        {
            try
            {
                db.Entry(Page).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteNews(int PageId)
        {
            try
            {
                var News = GetNewsById(PageId);
                DeleteNews(News);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<Page> GetTopNews(int take = 4)
        {
            return db.Pages.OrderByDescending(x => x.Visit).Take(take);
        }

        public IEnumerable<Page> GetNewsInSlider()
        {
            return db.Pages.Where(x=>x.ShowSlider==true).ToList();
        }

        public IEnumerable<Page> GetLastNews()
        {
            return db.Pages.OrderByDescending(x => x.CreatePage).Take(4);
        }

        public IEnumerable<Page> GetNewByGroupId(int id)
        {
            return db.Pages.Where(x => x.GroupId == id).ToList();
        }

        public IEnumerable<Page> GetNewsBySearch(string search)
        {
            return db.Pages.Where(x => x.Title.Contains(search) || x.ShortDescription.Contains(search) || x.Text.Contains(search) || x.Tags.Contains(search)).Distinct();
        }
    }
}
