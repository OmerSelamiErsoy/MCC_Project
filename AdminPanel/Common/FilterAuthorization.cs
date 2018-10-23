using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility.Methods;

namespace AdminPanel.Common
{
	public class FilterAuthorization : FilterAttribute, IAuthorizationFilter
	{
		private int _PAGEID = 0;
		public FilterAuthorization()
		{	  
		}
		public FilterAuthorization(Enumeration.enum_PageID PageEnum)
		{
			_PAGEID = PageEnum.ToInt32(); 
		}
		public void OnAuthorization(AuthorizationContext filterContext)
		{
			if (BasePage.LoginUserInf == null)
			{
				filterContext.Result = new RedirectResult("/Authority/Login");					 
			}
			else
			{
				if (_PAGEID > 0 && BasePage.LoginUserBlockList != null && BasePage.LoginUserBlockList.Count() > 0)
				{
					if (BasePage.LoginUserBlockList.Exists(x => x.TYPEID == (int)Enumeration.enum_UserBlockListType.PAGE && x.PAGEID_OR_OBJECTID == _PAGEID))
					{
						filterContext.Result = new RedirectResult("/AdminAuthority/Unauthorized");
					}
				}
			}
			 
		}

		public static bool PageControl(Enumeration.enum_PageID PageEnum)
		{
			bool result = true;
			if (BasePage.LoginUserBlockList != null && BasePage.LoginUserBlockList.Count() > 0)
			{
				if (BasePage.LoginUserBlockList.Exists(x => x.TYPEID == (int)Enumeration.enum_UserBlockListType.PAGE && x.PAGEID_OR_OBJECTID == PageEnum.ToInt32()))
				{
					result = false;
				}
			}

			return result;
		}
		public static bool ObjectControl(int OBJECTID)
		{
			bool result = true;
			if (OBJECTID > 0 && BasePage.LoginUserBlockList != null && BasePage.LoginUserBlockList.Count() > 0)
			{
				if (BasePage.LoginUserBlockList.Exists(x => x.TYPEID == (int)Enumeration.enum_UserBlockListType.PAGEOBJECT && x.PAGEID_OR_OBJECTID == OBJECTID))
				{
					result = false;
				}
			}  

			return result;
		}
	}
}