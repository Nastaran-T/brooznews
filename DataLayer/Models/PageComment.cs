using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    [Table("CommentNews")]
    public class PageComment
    {
        public PageComment()
        {

        }

        [Key]
        public int CommentId { get; set; }


        [Display(Name = "خبر")]
        public int PageId { get; set; }



        [Display(Name = "نام کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string UserName { get; set; }




        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Email { get; set; }



        [Display(Name = "وب سایت")]
        public string Website { get; set; }



        [Display(Name = "متن پیام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500)]
        public string CommentText { get; set; }



        [Display(Name = "ایجاد پیام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DisplayFormat(DataFormatString = "{0:yyyy/mm/dd}")]
        public DateTime CreateComment { get; set; }

        //NavigationProperty
        public virtual Page Page { get; set; }
    }
}

