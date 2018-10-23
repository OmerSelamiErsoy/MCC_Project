using AdminPanel.Models.Abstract;
using Object_Layer;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AdminPanel.Models.Product
{
	public class ProductViewModel : IResultState, IObjectState
	{

		public List<TBL_PRODUCTS> List_PRODUCTS{ get; set; }

		public TBL_PRODUCTS PRODUCTS { get; set; }

		public List<SelectListItem> List_CATEGORIES { get; set; }


		public string PRODUCTNAME { get; set; }
		public int CATEGORYID { get; set; }

		public bool ISPROCCESS { get; set; } = false;
		public bool ISSUCCESSFUL { get; set; }
		public string MESSAGE { get; set; }
		public string ERROR_MESSAGE { get; set; }

		public bool ISINSERT_BLOCK { get; set; } = false;
		public bool ISUPDATE_BLOCK { get; set; } = false;
		public bool ISDELETE_BLOCK { get; set; } = false;
	}
}