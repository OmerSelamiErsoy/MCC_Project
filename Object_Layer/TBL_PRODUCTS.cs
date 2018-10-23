using Data_Access_Layer.Manager;
using Data_Access_Layer.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Utility.Methods;

namespace Object_Layer
{
 

	[Serializable]
	public class TBL_PRODUCTS
	{
		#region Constants
		private const string sp_INSERT = "SP_PRODUCTS_INSERT";
		private const string sp_UPDATE = "SP_PRODUCTS_UPDATE";
		private const string sp_LIST = "SP_PRODUCTS_LIST";
		private const string sp_DELETE = "SP_PRODUCTS_DELETE";
		private const string PrimaryKeyName = "ID";
		#endregion

		static DBEntityManager _dbEntityManager = new DBEntityManager();

		public static bool DELETE(int ID)
		{
			return _dbEntityManager.Delete<TBL_PRODUCTS>(sp_DELETE, PrimaryKeyName, ID);
		}

		public static bool INSERT(TBL_PRODUCTS ObjectList)
		{
			return _dbEntityManager.Insert<TBL_PRODUCTS>(ObjectList, sp_INSERT, PrimaryKeyName);
		}

		public static bool UPDATE(TBL_PRODUCTS ObjectList)
		{
			return _dbEntityManager.Update<TBL_PRODUCTS>(ObjectList, sp_UPDATE, PrimaryKeyName);
		}

		public static List<TBL_PRODUCTS> LIST(int? ID = null, int? CATEGORYID = null, bool? ISACTIVE = null, bool? ISACTIVE_CATEGORY = null, int? TOPNUMBER = null, int? CREATEUSERID = null,string PRODUCTNAME = null)
		{
			SqlParameter[] Param = {
									new SqlParameter("@ID", ID),
									new SqlParameter("@CATEGORYID", CATEGORYID)  ,
									new SqlParameter("@ISACTIVE", ISACTIVE),	   
									new SqlParameter("@ISACTIVE_CATEGORY", ISACTIVE_CATEGORY),
									new SqlParameter("@CREATEUSERID", CREATEUSERID)   ,
									new SqlParameter("@TOPNUMBER", TOPNUMBER)		 ,
									new SqlParameter("@PRODUCTNAME", PRODUCTNAME)
			};
			return _dbEntityManager.ListParam<TBL_PRODUCTS>(sp_LIST, Param);
		}

		public static TBL_PRODUCTS SINGLE(int? ID = null, int? CATEGORYID = null, bool? ISACTIVE = null, bool? ISACTIVE_CATEGORY = null ,int? CREATEUSERID = null)
		{
			var result = LIST(ID: ID, CATEGORYID: CATEGORYID, ISACTIVE: ISACTIVE, ISACTIVE_CATEGORY: ISACTIVE_CATEGORY, TOPNUMBER: null, CREATEUSERID: CREATEUSERID);
			if (result == null || result.Count == 0)
				return null;
			else
				return result[0];
		}

		[DBField("ID", true)]
		public int ID { get; set; }

		[DBField("PRODUCTNAME")]
		public string PRODUCTNAME { get; set; }

		[DBField("PRODUCTCODE")]
		public string PRODUCTCODE { get; set; }

		[DBField("DESCRIPTION")]
		public string DESCRIPTION { get; set; }

		[DBField("PHOTOADDRESS")]
		public string PHOTOADDRESS { get; set; }

		[DBField("PRICE")]
		public double PRICE { get; set; }

		[DBField("TAX")]
		public double TAX { get; set; }

		[DBField("CATEGORYID")]
		public int CATEGORYID { get; set; }	   

		[DBField("CATEGORYNAME",0)]
		public string CATEGORYNAME { get; set; }

		[DBField("ISACTIVE")]
		public bool ISACTIVE { get; set; }

		[DBField("ISDELETE")]
		public bool ISDELETE { get; set; }

		[DBField("CREATEDATE")]
		public DateTime? CREATEDATE { get; set; }

		[DBField("CREATEUSERID")]
		public int CREATEUSERID { get; set; }

		[DBField("CREATEUSERNAME", 0)]
		public string CREATEUSERNAME { get; set; }

		[DBField("LASTCHANGEDATE")]
		public DateTime? LASTCHANGEDATE { get; set; }

		[DBField("LASTCHANGEUSERID")]
		public int? LASTCHANGEUSERID { get; set; }
 
		public double PRICETAXWITHOUT { get { return PRICE / TAX.ToTax(); } }

		// Burada attribute vermedik çünki bu kolon db'de bulunmuyor. Veri tabanından direk şekilde herhangi bir insert update delete list işlemine katılmıyor.
		public string PHOTODISPLAY { get { return ConfigManager.ImagesPath + PHOTOADDRESS; }  }
	}
}
