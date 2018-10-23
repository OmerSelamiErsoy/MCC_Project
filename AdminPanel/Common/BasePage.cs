using Object_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using Utility.Methods;  

namespace AdminPanel.Common
{
	public class BasePage
	{
		static string SessionAuthorityName = "UserAuthority";
		static string SessionAuthorityBlockListName = "UserAuthorityBlockList";

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

		public static List<TBL_USERBLOCKLIST> LoginUserBlockList
		{
			get
			{
				if (HttpContext.Current.Session[SessionAuthorityBlockListName] == null)
				{
					return null;
				}
				else
				{
					return (List<TBL_USERBLOCKLIST>)HttpContext.Current.Session[SessionAuthorityBlockListName];
				}

			}
		}

		public static void LoginSessionUpdate(TBL_USERS USERINF)
		{
			HttpContext.Current.Session[SessionAuthorityName] = USERINF;
		}
		public static void LoginSessionAddUserAuthority(TBL_USERS USERINF,List<TBL_USERBLOCKLIST> USERBLOCKLIST)
		{
			HttpContext.Current.Session[SessionAuthorityName] = USERINF;
			HttpContext.Current.Session[SessionAuthorityBlockListName] = USERBLOCKLIST;
		}
		public static void LoginSessionDelUserAuthority()
		{
			HttpContext.Current.Session[SessionAuthorityName] = null;
			HttpContext.Current.Session[SessionAuthorityBlockListName] = null;
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


		public static string ImgUpload(WebImage img, string UploadDirectory, string UploadFolder, string defaultName = "foto", int? MaxWidth = null, int? MaxHeight = null)
		{
			string CurrentImgPath = "";
			int _MaxWidth = 0;
			int _MaxHeight = 0;
			if (MaxWidth != null && MaxHeight != null)
			{
				_MaxWidth = MaxWidth.ToInt32();
				_MaxHeight = MaxHeight.ToInt32();
			}
			else
			{
				_MaxWidth = ConfigManager.ProductImgMaxWidth;
				_MaxHeight = ConfigManager.ProductImgMaxHeight;
			}


			if (img.Height > _MaxHeight || img.Width > _MaxWidth)
			{
				int Width = 0;
				int Height = 0;

				if (img.Width > img.Height)
				{
					Height = img.Height * (int)_MaxWidth / img.Width;
					Width = _MaxWidth;

				}
				else if (img.Width < img.Height)
				{
					Width = img.Width * (int)_MaxHeight / img.Height;
					Height = _MaxHeight;

				}
				else
				{
					Width = _MaxWidth;
					Height = _MaxWidth;
				}

				img.Resize(Width, Height);
			}
			string RondomCode = MethodBase.CreateUniqPassword(5);
			string filename = defaultName + $"_{RondomCode}.{img.ImageFormat}";
			if (!System.IO.Directory.Exists($"{UploadDirectory}/{UploadFolder}"))
				System.IO.Directory.CreateDirectory($"{UploadDirectory}/{UploadFolder}");

			img.Save($"{UploadDirectory}/{UploadFolder}/{filename}");
			CurrentImgPath = $"{UploadFolder.Replace(@"\", "/")}{filename}";

			return CurrentImgPath;
		}
	}

}