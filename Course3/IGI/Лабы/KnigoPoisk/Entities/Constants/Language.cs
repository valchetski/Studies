using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Entities.Constants
{
    public static class Language
    {
        public static string Russian = "русский";
        public static string France = "французский";

        public static List<SelectListItem> Languages = new List<SelectListItem>
        {
            new SelectListItem() {Text = Russian},
            new SelectListItem() {Text = France}
        };

    }
}
