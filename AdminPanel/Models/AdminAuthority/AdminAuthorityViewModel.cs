using AdminPanel.Models.Abstract;
using Object_Layer;
using System.Collections.Generic;

namespace AdminPanel.Models.AdminAuthority
{
	public class AdminAuthorityViewModel  : IResultState
	{
		public List<TBL_PAGES> LIST_PAGES { get; set; }
		public List<TBL_PAGEOBJECTS> LIST_PAGEOBJECTS { get; set; }
		public List<TBL_USERBLOCKLIST> LIST_USERBLOCKLIST { get; set; }
		public TBL_USERS USER { get; set; }


		public bool ISPROCCESS { get; set; } = false;
		public bool ISSUCCESSFUL { get; set; }
		public string MESSAGE { get; set; }
		public string ERROR_MESSAGE { get; set; }
	}
}