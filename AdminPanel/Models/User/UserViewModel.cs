using AdminPanel.Models.Abstract;
using Object_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPanel.Models.User
{
	public class UserViewModel	: IResultState
	{
		public List<TBL_USERS> List_USERS { get; set; }
								 
		public TBL_USERS USERS { get; set; }

		public bool ISPROCCESS { get; set; } = false;
		public bool ISSUCCESSFUL { get; set; }
		public string MESSAGE { get; set; }
		public string ERROR_MESSAGE { get; set; }
	}
}