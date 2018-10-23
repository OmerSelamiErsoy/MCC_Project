using Data_Access_Layer.Manager;
using Data_Access_Layer.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Object_Layer
{
	[Serializable]
	public class TBL_PAGES
	{
		#region Constants
		private const string sp_INSERT = "SP_PAGES_INSERT";
		private const string sp_UPDATE = "SP_PAGES_UPDATE";
		private const string sp_LIST = "SP_PAGES_LIST";
		private const string sp_DELETE = "SP_PAGES_DELETE";
		private const string PrimaryKeyName = "ID";
		#endregion

		static DBEntityManager _dbEntityManager = new DBEntityManager();

		public static bool DELETE(int ID)
		{
			return _dbEntityManager.Delete<TBL_PAGES>(sp_DELETE, PrimaryKeyName, ID);
		}

		public static bool INSERT(TBL_PAGES ObjectList)
		{
			return _dbEntityManager.Insert<TBL_PAGES>(ObjectList, sp_INSERT, PrimaryKeyName);
		}

		public static bool UPDATE(TBL_PAGES ObjectList)
		{
			return _dbEntityManager.Update<TBL_PAGES>(ObjectList, sp_UPDATE, PrimaryKeyName);
		}

		public static List<TBL_PAGES> LIST(int? ID = null)
		{
			SqlParameter[] Param = {
									new SqlParameter("@ID", ID) 
			};
			return _dbEntityManager.ListParam<TBL_PAGES>(sp_LIST, Param);
		}

		public static TBL_PAGES SINGLE(int? ID = null)
		{
			var result = LIST(ID: ID);
			if (result == null || result.Count == 0)
				return null;
			else
				return result[0];
		}


		[DBField("ID", true)]
		public int ID { get; set; }


		[DBField("PAGENAME")]
		public string PAGENAME { get; set; }

	}
}
