using Object_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Product
{
	public class ProductViewModel
	{
		public List<TBL_PRODUCTS> LIST_PRODUCTS { get; set; }
		public TBL_PRODUCTS PRODUCTS { get; set; }
		public List<TBL_CATEGORIES> LIST_CATEGORIES { get; set; }

		public string SELECTEDCATEGORY { get; set; }
	}
}