using AdminPanel.Models.Abstract;
using Object_Layer;
using System.Collections.Generic;

namespace AdminPanel.Models.Category
{
	public class CategoryViewModel: IResultState,IObjectState
	{
		public List<TBL_CATEGORIES> List_CATEGORIES { get; set; }	 

		public string CATEGORYNAME { get; set; }

		public bool ISACTIVE { get; set; }	 
		public bool ISINSERT { get; set; }	 

		public bool ISPROCCESS { get; set; } = false;
		public bool ISSUCCESSFUL { get; set; }
		public string MESSAGE { get; set; }
		public string ERROR_MESSAGE { get; set; }

		public bool ISINSERT_BLOCK { get; set; } = false;
		public bool ISUPDATE_BLOCK { get; set; } = false;
		public bool ISDELETE_BLOCK { get; set; } = false;
	}
}