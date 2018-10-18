using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Common
{

	//Dependency inversion prensibini uygulayabilmek için nesnelerimizi soyutluyoruz
	internal abstract class DBEntity
	{
		public abstract bool Insert<T>(T EntityInstance, string ProcedureName, string PrimaryKey) where T : class;

		public abstract bool Update<T>(T EntityInstance, string ProcedureName, string PrimaryKey) where T : class;

		public abstract List<T> List<T>(string ProcedureName) where T : class;

		public abstract List<T> ListParam<T>(string ProcedureName, SqlParameter[] Parameters) where T : class;

		public abstract bool Delete<T>(string ProcedureName, string PrimaryKey, int ID, SqlParameter[] Parameters = null) where T : class;



	}
}
