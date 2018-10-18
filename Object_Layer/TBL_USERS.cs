using Data_Access_Layer.AbstractFactory;
using Data_Access_Layer.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Object_Layer
{
	[Serializable]
	public class TBL_USERS
	{
		#region Constants
		private const string sp_INSERT = "SP_USERS_INSERT";
		private const string sp_UPDATE = "SP_USERS_UPDATE";
		private const string sp_LIST = "SP_USERS_LIST";
		private const string sp_DELETE = "SP_USERS_DELETE";
		private const string PrimaryKeyName = "ID";
		#endregion

		static DBEntityManager _dbEntityManager = new DBEntityManager();

		public static bool DELETE(int ID)
		{
			return _dbEntityManager.Delete<TBL_USERS>(sp_DELETE, PrimaryKeyName, ID);
		}

		public static bool INSERT(TBL_USERS ObjectList)
		{
			return _dbEntityManager.Insert<TBL_USERS>(ObjectList, sp_INSERT, PrimaryKeyName);
		}

		public static bool UPDATE(TBL_USERS ObjectList)
		{
			return _dbEntityManager.Update<TBL_USERS>(ObjectList, sp_UPDATE, PrimaryKeyName);
		}

		public static List<TBL_USERS> LIST(int? ID = null, int? CREATEUSERID = null)
		{
			SqlParameter[] Param = {
									new SqlParameter("@ID", ID),
									new SqlParameter("@CREATEUSERID", CREATEUSERID)
			};
			return _dbEntityManager.ListParam<TBL_USERS>(sp_LIST, Param);
		}


		[DBField("ID", true)]
		public int ID { get; set; }

		[DBField("FULLNAME")]
		public string FULLNAME { get; set; }

		[DBField("EMAIL")]
		public string EMAIL { get; set; }

		[DBField("PASSWORD")]
		public string PASSWORD { get; set; }

		[DBField("PHONE")]
		public string PHONE { get; set; }

		[DBField("ISEXECUTIVE")]
		public bool ISEXECUTIVE { get; set; }

		[DBField("ISACTIVE")]
		public bool ISACTIVE { get; set; }

		[DBField("ISDELETE")]
		public bool ISDELETE { get; set; }

		[DBField("CREATEDATE")]
		public DateTime CREATEDATE { get; set; }

		[DBField("CREATEUSERID")]
		public int CREATEUSERID { get; set; }

		[DBField("LASTCHANGEDATE")]
		public DateTime LASTCHANGEDATE { get; set; }

		[DBField("LASTCHANGEUSERID")]
		public int LASTCHANGEUSERID { get; set; }

	}
}
