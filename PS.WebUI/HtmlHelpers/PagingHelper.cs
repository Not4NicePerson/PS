using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using PS.Domain.Entities;
using PS.WebUI.Models;

namespace PS.WebUI.HtmlHelpers
{
	public static class PagingHelper
	{
		public static MvcHtmlString PageLinks(
			this HtmlHelper helper, Func<int, string> pageUrl, PageInfoModel pageInfo)
		{
			TagBuilder ul = new TagBuilder("ul");
			ul.AddCssClass("pagination");
			StringBuilder ulContent = new StringBuilder();

			for (int i = 1; i <= pageInfo.TotalPages; i++)
			{
				TagBuilder li = new TagBuilder("li");
				if (i == pageInfo.CurrentPage)
				{
					li.AddCssClass("active");
				}

				TagBuilder a = new TagBuilder("a")
				{
					InnerHtml = i.ToString(),
					Attributes =
					{
						new KeyValuePair<string, string>("href", pageUrl(i))
					}
				};

				li.InnerHtml = a.ToString();
				ulContent.Append(li);
			}
			ul.InnerHtml = ulContent.ToString();
			return new MvcHtmlString(ul.ToString());
		}

		//public static MvcHtmlString CreateDeleteButton(
		//	this HtmlHelper helper, Func<string, RouteValueDictionary, string> action, string actionName, in )
		//{
		//	TagBuilder a = new TagBuilder("a");
		//	a.MergeAttribute("href", );
		//}
	}
}