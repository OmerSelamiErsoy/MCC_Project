using Dapper;
using Data_Access_Layer.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utility.Methods;

namespace Data_Access_Layer.Dapper_Entity
{
	internal class DapperDBContext  : DBEntity
	{
		//Dependency inversion prensibine uyacak şekilde Dapper ORM'i soyut neseler üzerinden Reflection ve Custom Atrribute kullarak generic şekilde çalışır hale getirdik


		public override bool Insert<T>(T EntityInstance, string ProcedureName, string PrimaryKey)  
		{
			return InsertOrUpdateObject(EntityInstance,   ProcedureName,   PrimaryKey, true);
		}

		public override bool Update<T>(T EntityInstance, string ProcedureName, string PrimaryKey) 
		{
			return InsertOrUpdateObject(EntityInstance, ProcedureName, PrimaryKey, false);
		}	    

		public override List<T> List<T>(string ProcedureName)
		{
			return ListObject<T>(ProcedureName);
		}

		public override List<T> ListParam<T>(string ProcedureName, SqlParameter[] Parameters)
		{
			return ListParamObject<T>(ProcedureName, Parameters);
		}

		public override bool Delete<T>(string ProcedureName, string PrimaryKey, int ID, SqlParameter[] Parameters = null)
		{
			return DeleteObject<T>(ProcedureName, PrimaryKey, ID, Parameters);
		}



		private static bool InsertOrUpdateObject<T>(T EntityInstance, string ProcedureName, string PrimaryKey, bool IsInserting) where T : class
		{
			bool bSuccess = false;

			try
			{
				using (IDbConnection oConnection = new SqlConnection(ConfigManager.ConnectionString))
				{
					Type oCustomType = typeof(T);
					object objPropertyValue = null;
					PropertyInfo[] arrProperties = oCustomType.GetProperties();
					PropertyInfo oPrimaryKeyInfo = null;

					var spPARAM = new DynamicParameters();
					foreach (PropertyInfo oInfo in arrProperties)
					{
						if (Attribute.IsDefined(oInfo, typeof(DBFieldAttribute)))
						{
							DBFieldAttribute oAttribute = (DBFieldAttribute)Attribute.GetCustomAttribute(oInfo, typeof(DBFieldAttribute));
							if (oAttribute.IsDatabaseField)
							{
								if (!(IsInserting && (oAttribute.IsPrimaryKey || oInfo.Name == PrimaryKey)))
								{
									objPropertyValue = oInfo.GetValue(EntityInstance, null);
									if (objPropertyValue == null || DateTime.MinValue.Equals(objPropertyValue))
										spPARAM.Add("@" + oAttribute.ColumnName, DBNull.Value);
									else
										spPARAM.Add("@" + oAttribute.ColumnName, objPropertyValue);
								}
								else
								{
									oPrimaryKeyInfo = oInfo;
								}
							}
						}
					}

					if (oConnection.State == ConnectionState.Closed)
						oConnection.Open();

					var result = oConnection.Execute(ProcedureName, spPARAM, commandType: CommandType.StoredProcedure);


					oConnection.Close();
				}

				bSuccess = true;
			}
			catch (Exception ex)
			{
				//LOGLAMA
			}

			if (bSuccess)
			{
				//string ProcName = IsInserting ? "Insert" : "Update";
				//LOGLAMA
			}
			return bSuccess;
		}


		private static List<T> ListObject<T>(string ProcedureName) where T : class
		{

			List<T> arrResults = new List<T>();
			try
			{
				using (IDbConnection oConnection = new SqlConnection(ConfigManager.ConnectionString))
				{

					if (oConnection.State == ConnectionState.Closed)
						oConnection.Open();

					arrResults = oConnection.Query<T>(ProcedureName, null, commandTimeout: ConfigManager.CommandTimeout, commandType: CommandType.StoredProcedure).ToList();

					oConnection.Close();
				}
			}
			catch (Exception ex)
			{
			  //LOGLAMA
			}
			return arrResults;
		}

		private static List<T> ListParamObject<T>(string ProcedureName, SqlParameter[] Parameters) where T : class
		{

			List<T> arrResults = new List<T>();
			try
			{
				using (IDbConnection oConnection = new SqlConnection(ConfigManager.ConnectionString))
				{

					if (oConnection.State == ConnectionState.Closed)
						oConnection.Open();


					DynamicParameters param = new DynamicParameters();
					if (Parameters != null)
					{
						foreach (SqlParameter oParameter in Parameters)
						{
							param.Add(oParameter.ParameterName, oParameter.Value);
						}

					}

					arrResults = oConnection.Query<T>(ProcedureName, param, commandTimeout: ConfigManager.CommandTimeout, commandType: CommandType.StoredProcedure).ToList();

					oConnection.Close();
				}
			}
			catch (Exception ex)
			{
				//LOGLAMA
			}
			return arrResults;
		}

		private static bool DeleteObject<T>(string ProcedureName, string PrimaryKey, int ID, SqlParameter[] Parameters = null) where T : class
		{
			bool bSuccess = false;
			try
			{


				using (IDbConnection oConnection = new SqlConnection(ConfigManager.ConnectionString))
				{
					var spPARAM = new DynamicParameters();

					Type oCustomType = typeof(T);
					if (Parameters != null)
					{
						foreach (SqlParameter oParameter in Parameters)
						{
							spPARAM.Add("@" + oParameter.ParameterName, oParameter.Value);
						}
					}
					else if (!string.IsNullOrEmpty(PrimaryKey))
						spPARAM.Add("@" + PrimaryKey, ID);
					else
					{
						foreach (PropertyInfo oInfo in oCustomType.GetProperties())
						{
							if (Attribute.IsDefined(oInfo, typeof(DBFieldAttribute)))
							{
								DBFieldAttribute oAttribute = (DBFieldAttribute)Attribute.GetCustomAttribute(oInfo, typeof(DBFieldAttribute));
								if (oAttribute.IsPrimaryKey)
								{
									spPARAM.Add("@" + oInfo.Name, ID);
									break;
								}
							}
						}
					}



					if (oConnection.State == ConnectionState.Closed)
						oConnection.Open();

					var result = oConnection.Execute(ProcedureName, spPARAM, commandType: CommandType.StoredProcedure);

					oConnection.Close();



					bSuccess = true;
				}
			}
			catch (Exception ex)
			{
				//LOGLAMA
			}


			return bSuccess;
		}

		
	}
}
