using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminPanel.Models.Login
{
	public class LoginViewModel
	{
		[DisplayName("E-POSTA"), Required(ErrorMessage = "{0} ALANI BOŞ GEÇİLEMEZ!"), EmailAddress(ErrorMessage = "GEÇERLİ BİR {0} GİRİNİZ!"), MaxLength(125, ErrorMessage = "{0} ALANI MAXIMUM {1} KARAKTER OLABİLİR!")]
		public string EPOSTA { get; set; }

		[DisplayName("ŞİFRE"), Required(ErrorMessage = "{0} ALANI BOŞ GEÇİLEMEZ!"), DataType(DataType.Password), MaxLength(15)]
		public string SIFRE { get; set; }


		public bool BENIHATIRLA { get; set; }
	}
}