using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Xml;

namespace Utility.Methods
{
	public class MethodBase
	{

		/// <summary>
		/// Bu fonksiyon istenen xml doküman içeriğini string olarak döner.
		/// </summary>
		public static string GetString(string strKey, string FilePath, string xPath, string strValue)
		{
			string Result = string.Empty;

			XmlDocument Document = GetCachedDocument(FilePath);

			try
			{
				XmlNode node = Document.SelectSingleNode(String.Format(xPath, strKey));

				if (node == null)
					Result = "Bilinmiyor";
				else
					Result = node.SelectSingleNode(strValue).InnerText;
			}
			catch (Exception)
			{
				//LOGLAMA
			}

			return Result;
		}

		public static int GetInt32(string strKey, string FilePath, string xPath, string strValue)
		{
			int intResult = 0;
			try
			{
				intResult = Convert.ToInt32(GetString(strKey, FilePath, xPath, strValue));
			}
			catch (Exception ex)
			{
				//LOGLAMA
			}
			return intResult;
		}

		public static Double GetDouble(string strKey, string FilePath, string xPath, string strValue)
		{
			Double intResult = 0;
			try
			{
				intResult = Convert.ToDouble(GetString(strKey, FilePath, xPath, strValue));
			}
			catch (Exception ex)
			{     
				//LOGLAMA																										   
			}
			return intResult;
		}

		public static bool GetBool(string strKey, string FilePath, string xPath, string strValue)
		{
			bool blnResult = false;
			try
			{
				blnResult = GetString(strKey, FilePath, xPath, strValue).ToLower().Equals("true");
			}
			catch (Exception ex)
			{
				//LOGLAMA
			}
			return blnResult;
		}


		/// <summary>
		/// Bu fonksiyon istenen xml dokümanını  performans açsısından değişime bağlı şekilde cachleyerek döner.
		/// </summary>
		public static XmlDocument GetCachedDocument(string FilePath)
		{
			XmlDocument Document = null;
																					   
			if (!string.IsNullOrEmpty(FilePath))
			{
				System.Web.Caching.Cache oCache = (System.Web.HttpContext.Current != null) ? System.Web.HttpContext.Current.Cache : HttpRuntime.Cache;

				if (oCache[FilePath] == null)
				{		   
					Document = new XmlDocument();
					Document.Load(FilePath);
					CacheDependency oDependency = new CacheDependency(FilePath);
					oCache.Insert(FilePath, Document, oDependency);
				}
				else
					Document = (XmlDocument)oCache[FilePath];
			}
			return Document;
		}

	}
}
