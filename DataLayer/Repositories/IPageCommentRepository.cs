using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageCommentRepository
    {
        IEnumerable<PageComment> GetAllNewsComment();
        PageComment GetNewsCommentById(int PageCommentId);
        bool InsertNewsComment(PageComment PageComment);
        bool UpdateNewsComment(PageComment PageComment);
        bool DeleteNewsComment(PageComment PageComment);
        bool DeleteNewsComment(int PageCommentId);
        IEnumerable<PageComment> GetCommentByNewsId(int pageId);
    }
}

