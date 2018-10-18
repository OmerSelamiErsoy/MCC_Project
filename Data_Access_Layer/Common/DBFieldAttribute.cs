using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Common
{

	//Object_Layer içerisindeki tabloya eşitlediğimiz property'leri dbden soyutlayabilmek, farklı isimle çağırabilmek, primary key belirtebilmek ve bunu modularity^yi arttırarak yapmak için Attribute modelimizi tanımlıyoruz
	// Bu model context sınıfların içerisinde db ye gönderilip gönderilmeme ve nasıl gönderileceği şeklinde yardımcı olacak
	[AttributeUsage(AttributeTargets.Property)]
	public class DBFieldAttribute : Attribute
	{
		private string _ColumnName;
		private bool _IsPrimaryKey = false;
		private bool _IsDatabaseField = true;

		 
		public DBFieldAttribute(string ColumnName)
			: this(ColumnName, false)
		{

		}

		public DBFieldAttribute(string ColumnName, bool IsPrimaryKey)
		{
			this._ColumnName = ColumnName;
			this._IsPrimaryKey = IsPrimaryKey;
		}

		public DBFieldAttribute(string ColumnName, short IsDatabaseField)
		{
			this._ColumnName = ColumnName;
			this._IsDatabaseField = Convert.ToBoolean(IsDatabaseField);
		}

		public string ColumnName
		{
			get { return _ColumnName; }
		}
		public bool IsPrimaryKey
		{
			get { return _IsPrimaryKey; }
		}
		public bool IsDatabaseField
		{
			get { return _IsDatabaseField; }
		}
	}
}
