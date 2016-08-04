using SimplyNewsPortal.Models;
using SimplyNewsPortal.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SimplyNewsPortal.Helpers
{
    // фейковый вариант 
    // нужно переделать 
    // оставлено для тестов 
    // 
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, IndexViewModel pageInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 1; i <= pageInfo.Pager.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                // если текущая страница, то выделяем ее,
                // например, добавляя класс
                if (i == pageInfo.Pager.CurrentPage)
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


//<div class="btn-group">
//    @Html.PageLinks(Model.BlogPosts, x => Url.Action("List",new { page = x}))
//</div>

