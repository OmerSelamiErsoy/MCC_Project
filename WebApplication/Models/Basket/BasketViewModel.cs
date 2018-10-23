using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Common;
using WebApplication.Models.Abstract;

namespace WebApplication.Models.Basket
{
	public class BasketViewModel : IResultState
	{
		public BasketModelList BASKET { get; set; }

		public bool ISPROCCESS { get; set; } = false;
		public bool ISSUCCESSFUL { get; set; }
		public string MESSAGE { get; set; }
		public string ERROR_MESSAGE { get; set; }
	}
}