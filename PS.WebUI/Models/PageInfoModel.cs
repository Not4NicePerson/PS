using System;

namespace PS.WebUI.Models
{
	public class PageInfoModel
	{
		public int TotalItems { get; set; }
		public int PageSize { get; set; }
		public int CurrentPage { get; set; }

		public int TotalPages
		{
			get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
		}

	}
}