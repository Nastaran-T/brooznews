using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageGroupRepository : IPageGroupRepository
    {
        private NewsContext db;
        public PageGroupRepository(NewsContext context)
        {
            db = context;
        }

        public IEnumerable<PageGroup> GetAllNewsGroup()
        {
            return db.PageGroups.ToList();
        }

        public PageGroup GetNewsGroupById(int PageGroupId)
        {
            return db.PageGroups.Find(PageGroupId);
        }

        public bool InsertNewsGroup(PageGroup PageGroup)
        {
            try
            {
                db.PageGroups.Add(PageGroup);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateNewsGroup(PageGroup PageGroup)
        {
            try
            {
                db.Entry(PageGroup).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteNewsGroup(PageGroup PageGroup)
        {
            try
            {
                db.Entry(PageGroup).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteNewsGroup(int PageGroupId)
        {
            try
            {
                var NewsGroup = GetNewsGroupById(PageGroupId);
                DeleteNewsGroup(NewsGroup);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<ShowGroupViewModel> GetShowGroups()
        {
            return db.PageGroups.Select(x => new ShowGroupViewModel() {

                GroupId=x.GroupId,
                GroupTitle=x.GroupTitle,
                NewsCount=x.Pages.Count

            });
        }
    }
}
