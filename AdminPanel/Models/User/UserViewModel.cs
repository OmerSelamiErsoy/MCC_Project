using AdminPanel.Models.Abstract;
using Object_Layer;
using System.Collections.Generic;

namespace AdminPanel.Models.User
{
	public class UserViewModel	: IResultState,IObjectState
	{
		public List<TBL_USERS> List_USERS { get; set; }
								 
		public TBL_USERS USERS { get; set; }

		public bool ISPROCCESS { get; set; } = false;
		public bool ISSUCCESSFUL { get; set; }
		public string MESSAGE { get; set; }
		public string ERROR_MESSAGE { get; set; }

		public bool ISINSERT_BLOCK { get; set; } = false;
		public bool ISUPDATE_BLOCK { get; set; } = false;
		public bool ISDELETE_BLOCK { get; set; } = false;
	}
}