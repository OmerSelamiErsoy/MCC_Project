using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanel.Common
{
	public class FilterAuthorization : FilterAttribute, IAuthorizationFilter
	{
		public void OnAuthorization(AuthorizationContext filterContext)
		{
			if (BasePage.LoginUserInf == null)
			{
				 
				 filterContext.Result = new RedirectResult("/Authority/Login");
				 
			}
			 
		}
	}
}