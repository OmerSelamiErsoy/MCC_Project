using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Methods
{
	/// <summary>
	/// Setting.xml dosyamızı okuduğumuz ortak alan
	/// </summary>
	public sealed class ConfigManager
	{

		public static string WEBDirectory
		{
			get
			{
				if (IsDirectorylocal)
					return GetString("WEBDirectoryLocal");
				else
					return GetString("WEBDirectory");
			}
		}

		public static string AdminDirectory
		{
			get
			{
				if (IsDirectorylocal)
					return GetString("AdminDirectoryLocal");
				else
					return GetString("AdminDirectory");
			}
		}

		public static string ConnectionString
		{
			get
			{
				return GetString("Connnection_DB");
			}
		}


		public static bool IsDirectorylocal
		{
			get
			{
				return GetBool("IsDirectorylocal");
			}
		}


		public static bool IsLOG
		{
			get
			{
				return GetBool("IsLOG");
			}
		}

		public static bool IsImgPathlocal
		{
			get
			{
				return GetBool("IsImgPathlocal");
			}
		}
		public static string DefaultProductImage
		{
			get
			{
				return GetString("DefaultProductImage");
			}
		}

		public static string UploadDirectory
		{
			get
			{
				return GetString("UploadDirectory");
			}
		}


		public static string UploadDirectoryFolder
		{
			get
			{
				return GetString("UploadDirectoryFolder");
			}
		}


		public static string ImagesPath
		{
			get
			{
				if (IsImgPathlocal)
					return GetString("ImagesPathlocal");
				else
					return GetString("ImagesPath");
			}
		}


		public static int ProductImgMaxWidth
		{
			get
			{
				return GetInt32("ProductImgMaxWidth");
			}
		}


		public static int ProductImgMaxHeight
		{
			get
			{
				return GetInt32("ProductImgMaxHeight");
			}
		}


		public static string DefaultProfileImage
		{
			get
			{
				return GetString("DefaultProfileImage");
			}
		}


		public static int CommandTimeout
		{
			get
			{
				return GetInt32("CommandTimeout");
			}
		}







		#region Functions

		/// <summary>
		/// Aşağıdaki fonksiyonlar çalışma anında projelerin configlerinde adresi bulunan xml dosyasında verilen key lere göre istenen tipte value  döner
		/// </summary> 

		public static string GetString(string strKey)
		{
			return MethodBase.GetString(strKey, ConfigManager.ConfigurationFilePath, "Lists/List/Item[@Name='{0}']", "@Value");
		}

		private static string GetString(string list, string itemkey, string strKey)
		{
			string xPath = string.Format("Lists/List[@Key='{0}']/Items[@Key='{1}']/Item[@Name='[NAME]']", list, itemkey);
			xPath = xPath.Replace("[NAME]", "{0}");

			return MethodBase.GetString(strKey, ConfigManager.ConfigurationFilePath, xPath, "@Value");
		}

		private static bool GetBool(string strKey)
		{
			return MethodBase.GetBool(strKey, ConfigManager.ConfigurationFilePath, "Lists/List/Item[@Name='{0}']", "@Value");
		}

		private static int GetInt32(string strKey)
		{
			return MethodBase.GetInt32(strKey, ConfigManager.ConfigurationFilePath, "Lists/List/Item[@Name='{0}']", "@Value");
		}

		private static double GetDouble(string strKey)
		{
			return MethodBase.GetDouble(strKey, ConfigManager.ConfigurationFilePath, "Lists/List/Item[@Name='{0}']", "@Value");
		}


		public static string ConfigurationFilePath
		{
			get
			{
				return ConfigurationSettings.AppSettings["ConfigFilePath"];
			}
		}

		#endregion
	}


}
