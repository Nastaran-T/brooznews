using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace DataLayer
{
    [Table("News")]
    public class Page
    {
       
        public Page()
        {

        }

        [Key]
        public int PageId { get; set; }

        [Display(Name = "دسته بندی")]
        public int GroupId { get; set; }


        [Display(Name = " عنوان خبر")]
        [MaxLength(250)]
        public string Title { get; set; }


        [Display(Name = "متن کوتاه ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350)]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }



        [Display(Name = "متن کامل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Text { get; set; }



        [Display(Name = "تصویر")]
        public string ImageName { get; set; }


        [Display(Name = "تاریخ ایجاد")]
        [DisplayFormat(DataFormatString = "{0:yyyy/mm/dd}")]
        public DateTime CreatePage { get; set; }


        [Display(Name = "کلمات کلیدی")]
        public string Tags { get; set; }

        [Display(Name = "تعداد بازدید")]
        public int Visit { get; set; }



        [Display(Name = "نمایش در اسلایدر")]
        public bool ShowSlider { get; set; }


        //NavigationProperty
        public virtual PageGroup PageGroup { get; set; }

        public virtual List<PageComment> PageComments { get; set; }

    }
}

