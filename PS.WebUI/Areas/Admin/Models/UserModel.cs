using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PS.WebUI.Areas.Admin.Models
{
	public class UserModel
	{
		[Required]
		public string Name { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}