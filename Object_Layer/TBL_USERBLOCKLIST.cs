using Data_Access_Layer.Manager;
using Data_Access_Layer.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Object_Layer
{
	[Serializable]
	public class TBL_USERBLOCKLIST
	{
		#region Constants
		private const string sp_INSERT = "SP_USERBLOCKLIST_INSERT";
		private const string sp_UPDATE = "SP_USERBLOCKLIST_UPDATE";
		private const string sp_LIST = "SP_USERBLOCKLIST_LIST";
		private const string sp_DELETE = "SP_USERBLOCKLIST_DELETE";	 
		private const string sp_DELETE_BYUSERID = "SP_USERBLOCKLIST_DELETE_BYUSERID";
		private const string PrimaryKeyName = "ID";
		#endregion

		static DBEntityManager _dbEntityManager = new DBEntityManager();

		public static bool DELETE(int ID)
		{
			return _dbEntityManager.Delete<TBL_USERBLOCKLIST>(sp_DELETE, PrimaryKeyName, ID);
		}  
		public static bool DELETE_BYUSERID(int USERID)
		{
			return _dbEntityManager.Delete<TBL_USERBLOCKLIST>(sp_DELETE_BYUSERID, PrimaryKeyName, USERID);
		}

		public static bool INSERT(TBL_USERBLOCKLIST ObjectList)
		{
			return _dbEntityManager.Insert<TBL_USERBLOCKLIST>(ObjectList, sp_INSERT, PrimaryKeyName);
		}

		public static bool UPDATE(TBL_USERBLOCKLIST ObjectList)
		{
			return _dbEntityManager.Update<TBL_USERBLOCKLIST>(ObjectList, sp_UPDATE, PrimaryKeyName);
		}

		public static List<TBL_USERBLOCKLIST> LIST(int? ID = null, int? PAGEID_OR_OBJECTID = null, int? USERID = null, int? TYPEID = null)
		{
			SqlParameter[] Param = {
									new SqlParameter("@ID", ID)  ,
									new SqlParameter("@PAGEID_OR_OBJECTID", PAGEID_OR_OBJECTID)         ,
									new SqlParameter("@USERID", USERID) ,
									new SqlParameter("@TYPEID", TYPEID)  
			};
			return _dbEntityManager.ListParam<TBL_USERBLOCKLIST>(sp_LIST, Param);
		}

		public static TBL_USERBLOCKLIST SINGLE(int? ID = null, int? PAGEID_OR_OBJECTID = null, int? USERID = null, int? TYPEID = null)
		{
			var result = LIST(ID: ID, PAGEID_OR_OBJECTID: PAGEID_OR_OBJECTID, USERID: USERID, TYPEID: TYPEID);
			if (result == null || result.Count == 0)
				return null;
			else
				return result[0];
		}


		[DBField("ID", true)]
		public int ID { get; set; }	   

		[DBField("USERID")]
		public int USERID { get; set; }

		[DBField("PAGEID_OR_OBJECTID")]
		public int PAGEID_OR_OBJECTID { get; set; }

		[DBField("TYPEID")]
		public byte TYPEID { get; set; }

		[DBField("CREATEDATE")]
		public DateTime CREATEDATE { get; set; }

		[DBField("CREATEUSERID")]
		public int CREATEUSERID { get; set; }



	}
}
