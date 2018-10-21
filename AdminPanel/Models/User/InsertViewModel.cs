using AdminPanel.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminPanel.Models.User
{
	public class InsertViewModel : IResultState
	{


		public int ID { get; set; }

		[DisplayName("ADI SOYADI"), Required(ErrorMessage = "{0} ALANI BOŞ GEÇİLEMEZ!"), MaxLength(75, ErrorMessage = "{0} ALANI MAXIMUM {1} KARAKTER OLABİLİR!")]
		public string FULLNAME { get; set; }

		[DisplayName("E-POSTA"), Required(ErrorMessage = "{0} ALANI BOŞ GEÇİLEMEZ!"), EmailAddress(ErrorMessage = "GEÇERLİ BİR {0} GİRİNİZ!"), MaxLength(125, ErrorMessage = "{0} ALANI MAXIMUM {1} KARAKTER OLABİLİR!")]
		public string EMAIL { get; set; }

		[DisplayName("ŞİFRE"), Required(ErrorMessage = "{0} ALANI BOŞ GEÇİLEMEZ!"), MaxLength(15, ErrorMessage = "{0} ALANI MAXIMUM {1} KARAKTER OLABİLİR!")]
		public string PASSWORD { get; set; }
												 
		public string PHONE { get; set; }	  
		
		public bool ISEXECUTIVE { get; set; }
													 
		public bool ISACTIVE { get; set; }


		public bool ISINSERT { get; set; }

		public bool ISPROCCESS { get; set; } = false;
		public bool ISSUCCESSFUL { get; set; }
		public string MESSAGE { get; set; }
		public string ERROR_MESSAGE { get; set; }

	}
}