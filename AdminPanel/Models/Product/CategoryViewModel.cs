using Object_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPanel.Models.Product
{
	public class CategoryViewModel
	{
		public List<TBL_CATEGORIES> List_CATEGORIES { get; set; }   

		public string CATEGORYNAME { get; set; }
	}
}