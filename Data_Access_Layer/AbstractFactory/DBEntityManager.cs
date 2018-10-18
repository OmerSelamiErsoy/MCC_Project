using Data_Access_Layer.Common;
using Ninject;
using Data_Access_Layer.Dapper_Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.AbstractFactory
{
	public class DBEntityManager
	{
		//Ninject IOC container kullanarak dependency injection ile üst sınıf olan object_layer katmanını alt sınıf olan Dapper Context bağımlılığından kurtulacak hale getiriyoruz
		IKernel kernel = new StandardKernel();
		public DBEntityManager()
		{

			kernel.Bind<DBEntity>().To<DapperDBContext>().InSingletonScope();

		}

		public bool Delete<T>(string ProcedureName, string PrimaryKey, int ID, SqlParameter[] Parameters = null) where T : class
		{
			return kernel.Get<DBEntity>().Delete<T>(ProcedureName, PrimaryKey, ID, Parameters);
		}

		public bool Insert<T>(T EntityInstance, string ProcedureName, string PrimaryKey) where T : class
		{
			return kernel.Get<DBEntity>().Insert<T>(EntityInstance, ProcedureName, PrimaryKey);
		}

		public List<T> List<T>(string ProcedureName) where T : class
		{
			return kernel.Get<DBEntity>().List<T>(ProcedureName);
		}

		public List<T> ListParam<T>(string ProcedureName, SqlParameter[] Parameters) where T : class
		{
			return kernel.Get<DBEntity>().ListParam<T>(ProcedureName, Parameters);
		}

		public bool Update<T>(T EntityInstance, string ProcedureName, string PrimaryKey) where T : class
		{
			return kernel.Get<DBEntity>().Update<T>(EntityInstance, ProcedureName, PrimaryKey);
		}
	}
}
