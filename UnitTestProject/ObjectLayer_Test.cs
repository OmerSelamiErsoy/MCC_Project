using Microsoft.VisualStudio.TestTools.UnitTesting;
using Object_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
	[TestClass]
	public class ObjectLayer_Test
	{
		[TestMethod]
		public void Insert_Test()
		{
			bool Sonuc = false;
			TBL_CATEGORIES tbl_Cat = new TBL_CATEGORIES();
			tbl_Cat.CATEGORYNAME = "Test Kategorisi";
			tbl_Cat.CREATEDATE = DateTime.Now;
			tbl_Cat.CREATEUSERID = 2;
			Sonuc = TBL_CATEGORIES.INSERT(tbl_Cat);

			Assert.AreEqual(true, Sonuc);

		}
	}
}
