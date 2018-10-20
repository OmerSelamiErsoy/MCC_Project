using AdminPanel.Models.Abstract;	 
using Object_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPanel.Models.Category
{
	public class CategoryViewModel: IResultState
	{
		public List<TBL_CATEGORIES> List_CATEGORIES { get; set; }	 

		public string CATEGORYNAME { get; set; }

		public bool ISACTIVE { get; set; }	 
		public bool ISINSERT { get; set; }


		public bool ISPROCCESS { get; set; } = false;
		public bool ISSUCCESSFUL { get; set; }
		public string MESSAGE { get; set; }
		public string ERROR_MESSAGE { get; set; }
	}
}