using Data_Access_Layer.Manager;
using Data_Access_Layer.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Object_Layer
{
	[Serializable]
	public class TBL_PAGEOBJECTS
	{
		#region Constants
		private const string sp_INSERT = "SP_PAGEOBJECTS_INSERT";
		private const string sp_UPDATE = "SP_PAGEOBJECTS_UPDATE";
		private const string sp_LIST = "SP_PAGEOBJECTS_LIST";
		private const string sp_DELETE = "SP_PAGEOBJECTS_DELETE";
		private const string PrimaryKeyName = "ID";
		#endregion

		static DBEntityManager _dbEntityManager = new DBEntityManager();

		public static bool DELETE(int ID)
		{
			return _dbEntityManager.Delete<TBL_PAGEOBJECTS>(sp_DELETE, PrimaryKeyName, ID);
		}

		public static bool INSERT(TBL_PAGEOBJECTS ObjectList)
		{
			return _dbEntityManager.Insert<TBL_PAGEOBJECTS>(ObjectList, sp_INSERT, PrimaryKeyName);
		}

		public static bool UPDATE(TBL_PAGEOBJECTS ObjectList)
		{
			return _dbEntityManager.Update<TBL_PAGEOBJECTS>(ObjectList, sp_UPDATE, PrimaryKeyName);
		}

		public static List<TBL_PAGEOBJECTS> LIST(int? ID = null, int? PAGEID = null)
		{
			SqlParameter[] Param = {
									new SqlParameter("@ID", ID)  ,
									new SqlParameter("@PAGEID", PAGEID) 
			};
			return _dbEntityManager.ListParam<TBL_PAGEOBJECTS>(sp_LIST, Param);
		}

		public static TBL_PAGEOBJECTS SINGLE(int? ID = null, int? PAGEID = null)
		{
			var result = LIST(ID: ID, PAGEID: PAGEID);
			if (result == null || result.Count == 0)
				return null;
			else
				return result[0];
		}


		[DBField("ID", true)]
		public int ID { get; set; }


		[DBField("OBJECTNAME")]
		public string OBJECTNAME { get; set; }


		[DBField("PAGEID")]
		public int PAGEID { get; set; }


	}
}
