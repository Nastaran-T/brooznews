using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageGroupRepository
    {
        IEnumerable<PageGroup> GetAllNewsGroup();
        PageGroup GetNewsGroupById(int PageGroupId);
        bool InsertNewsGroup(PageGroup PageGroup);
        bool UpdateNewsGroup(PageGroup PageGroup);
        bool DeleteNewsGroup(PageGroup PageGroup);
        bool DeleteNewsGroup(int PageGroupId);
        IEnumerable<ShowGroupViewModel> GetShowGroups();
        
    }
}
