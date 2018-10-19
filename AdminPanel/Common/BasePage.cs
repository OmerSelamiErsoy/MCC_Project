using Object_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPanel.Common
{
	public class BasePage
	{
		static string SessionAuthorityName = "UserAuthority";

		public static TBL_USERS LoginUserInf
		{
			get
			{
				if (HttpContext.Current.Session[SessionAuthorityName] == null)
				{
					return null;
				}
				else
				{
					return (TBL_USERS)HttpContext.Current.Session[SessionAuthorityName];
				}

			}
		}

		public static void LoginSessionUpdate(TBL_USERS USERINF)
		{
			HttpContext.Current.Session[SessionAuthorityName] = USERINF;
		}
		public static void LoginSessionAddUserAuthority(TBL_USERS USERINF)
		{
			HttpContext.Current.Session[SessionAuthorityName] = USERINF;
		}
		public static void LoginSessionDelUserAuthority()
		{
			HttpContext.Current.Session[SessionAuthorityName] = null;
		}



		public static void AddCookies(string KEY, string VALUE, DateTime? EXDATE = null)
		{

			DateTime CookieExDate = EXDATE ?? DateTime.Now.AddDays(7);
			HttpContext.Current.Response.Cookies[KEY].Value = VALUE;
			HttpContext.Current.Response.Cookies[KEY].Expires = CookieExDate;

		}

		public static string ReadCookies(string KEY)
		{

			string ReturnValue = "";

			if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies[KEY]?.Value))
			{
				ReturnValue = HttpContext.Current.Request.Cookies[KEY].Value.ToString();
			}

			return ReturnValue;

		}

		public static void DeleteCookies(string KEY)
		{

			if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies[KEY]?.Value))
			{
				HttpContext.Current.Response.Cookies[KEY].Value = null;
				HttpContext.Current.Response.Cookies[KEY].Expires = DateTime.Now.AddDays(-7);
			}


		}

	}

}