using Microsoft.VisualStudio.TestTools.UnitTesting;
using Object_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;	
using Log_Layer.NLOG;
using Log_Layer.Manager;

namespace UnitTestProject
{
	 
	[TestClass]
	public class LogLayer_Test
	{
		[TestMethod]
		public void Insert_Test()
		{
			bool Sonuc = false;
			try
			{
				int a = 2;
				int b = 0;
				int i = a / b;
				Sonuc = false;
			}
			catch (Exception ex)
			{
				LogManager.LogManagerStatic().LogError(ex.Message);
				Sonuc = true;
			}
			
			 		    
			Assert.AreEqual(true, Sonuc);

		}
	}
}
