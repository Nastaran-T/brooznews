using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    [Table("NewsGroups")]
    public class PageGroup
    {
        public PageGroup()
        {

        }

        [Key]
        public int GroupId { get; set; }

        [Display(Name = "نام گروه")]
        public string GroupTitle { get; set; }

        //NavigationProperty
        public virtual List<Page> Pages { get; set; }
    }
}
