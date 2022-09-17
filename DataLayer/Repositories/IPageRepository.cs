using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageRepository
    {
        IEnumerable<Page> GetAllNews();
        Page GetNewsById(int PageId);
        bool InsertNews(Page Page);
        bool UpdateNews(Page Page);
        bool DeleteNews(Page Page);
        bool DeleteNews(int PageId);
        IEnumerable<Page> GetTopNews(int take=4);
        IEnumerable<Page> GetNewsInSlider();
        IEnumerable<Page> GetLastNews();
        IEnumerable<Page> GetNewByGroupId(int id);
        IEnumerable<Page> GetNewsBySearch(string search);

    }
}
