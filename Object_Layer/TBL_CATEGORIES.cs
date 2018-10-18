using Data_Access_Layer.AbstractFactory;
using Data_Access_Layer.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Object_Layer
{
	[Serializable]
	public class TBL_CATEGORIES
	{
		#region Constants
		private const string sp_INSERT = "SP_CATEGORIES_INSERT";
		private const string sp_UPDATE = "SP_CATEGORIES_UPDATE";
		private const string sp_LIST = "SP_CATEGORIES_LIST";
		private const string sp_DELETE = "SP_CATEGORIES_DELETE";
		private const string PrimaryKeyName = "ID";
		#endregion

		static DBEntityManager _dbEntityManager = new DBEntityManager();

		public static bool DELETE(int ID)
		{					
			return _dbEntityManager.Delete<TBL_CATEGORIES>(sp_DELETE, PrimaryKeyName, ID);
		}

		public static bool INSERT(TBL_CATEGORIES ObjectList)
		{
			return _dbEntityManager.Insert<TBL_CATEGORIES>(ObjectList, sp_INSERT, PrimaryKeyName);
		}

		public static bool UPDATE(TBL_CATEGORIES ObjectList)
		{
			return _dbEntityManager.Update<TBL_CATEGORIES>(ObjectList, sp_UPDATE, PrimaryKeyName);
		}

		public static List<TBL_CATEGORIES> LIST(int? ID = null, int? CREATEUSERID = null)
		{
			SqlParameter[] Param = {
									new SqlParameter("@ID", ID),
									new SqlParameter("@CREATEUSERID", CREATEUSERID)
			};
			return _dbEntityManager.ListParam<TBL_CATEGORIES>(sp_LIST, Param);
		}


		[DBField("ID", true)]
		public int ID { get; set; }

		[DBField("CATEGORYNAME")]
		public string CATEGORYNAME { get; set; }

		[DBField("CREATEDATE")]
		public DateTime CREATEDATE { get; set; }

		[DBField("CREATEUSERID")]
		public int CREATEUSERID { get; set; }

	}
}
