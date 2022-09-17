using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace News
{
    public static class ConvertToShamsi
    {
        public static string ToShamsi(this DateTime dateTime)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(dateTime) + "/" + pc.GetMonth(dateTime).ToString("00") + "/" + pc.GetDayOfMonth(dateTime).ToString("00");

        }
    }
}



