using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Methods
{
	public class Enumeration
	{						 
		public enum enum_UserExecutive { EXECUTIVE = 1, NORMAL = 0 };
		public enum enum_UserBlockListType { PAGE = 1, PAGEOBJECT = 2 };
		public enum enum_myButtonType { DEFAULT = 0, PRIMARY = 1, SECONDARY = 2, INFO = 3, SUCCESS = 4, DANGER = 5, WARNING = 6 };
		public enum enum_myBasketProcess { CLEAR = 0, ADD_OR_UPDATE = 1, DELETE = 2};

		public enum enum_PageID { CategoryPage = 1, ProductPage = 2, UserPage = 3, UserBlockPage = 4 };

		 
	}
}
