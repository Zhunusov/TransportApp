using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using TransportApp.WEB.Models;

namespace TransportApp.WEB.Helpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks (this HtmlHelper html, 
            PageInfo pageInfo, Func<int, MvcForm> ajaxAction)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pageInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("input");
                tag.MergeAttribute("value", i.ToString());
                tag.MergeAttribute("type", "submit");
                //tag.InnerHtml = i.ToString();

                if (i == pageInfo.PadeNumber)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}