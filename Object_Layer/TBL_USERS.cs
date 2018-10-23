using Data_Access_Layer.Manager;
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

		public static List<TBL_USERS> LIST(int? ID = null, string EMAIL = null, string PASSWORD = null, bool? ISEXECUTIVE = null, bool? ISACTIVE = null, int? TOPNUMBER = null)
		{
			SqlParameter[] Param = {
									new SqlParameter("@ID", ID),
									new SqlParameter("@EMAIL", EMAIL) ,
									new SqlParameter("@PASSWORD", PASSWORD)   ,
									new SqlParameter("@ISEXECUTIVE", ISEXECUTIVE)   ,
									new SqlParameter("@ISACTIVE", ISACTIVE)    ,
									new SqlParameter("@TOPNUMBER", TOPNUMBER)
			};
			return _dbEntityManager.ListParam<TBL_USERS>(sp_LIST, Param);
		}

		public static TBL_USERS SINGLE(int? ID = null, string EMAIL = null, string PASSWORD = null, bool? ISEXECUTIVE = null)
		{
			var result = LIST(ID: ID,EMAIL: EMAIL, PASSWORD: PASSWORD, ISEXECUTIVE: ISEXECUTIVE,ISACTIVE:true, TOPNUMBER: null);
			if (result == null || result.Count == 0)
				return null;
			else
				return result[0];
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

		[DBField("CREATEUSERNAME",0)]
		public string CREATEUSERNAME { get; set; }

		[DBField("LASTCHANGEDATE")]
		public DateTime LASTCHANGEDATE { get; set; }

		[DBField("LASTCHANGEUSERID")]
		public int LASTCHANGEUSERID { get; set; }

	}
}
