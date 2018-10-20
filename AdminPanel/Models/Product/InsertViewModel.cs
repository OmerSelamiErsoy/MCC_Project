using AdminPanel.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility.Methods;

namespace AdminPanel.Models.Product
{
	public class InsertViewModel : IResultState
	{


		[DisplayName("ÜRÜN ADI"), Required(ErrorMessage = "{0} ALANI BOŞ GEÇİLEMEZ!"), MaxLength(75, ErrorMessage = "{0} ALANI MAXIMUM {1} KARAKTER OLABİLİR!")]
		public string PRODUCTNAME { get; set; }

		[DisplayName("ÜRÜN KODU"), Required(ErrorMessage = "{0} ALANI BOŞ GEÇİLEMEZ!"), MaxLength(15, ErrorMessage = "{0} ALANI MAXIMUM {1} KARAKTER OLABİLİR!")]
		public string PRODUCTCODE { get; set; }

		[DisplayName("AÇIKLAMA")]
		public string DESCRIPTION { get; set; }

		[DisplayName("ÜRÜN RESMİ")]
		public string PHOTOADDRESS { get; set; }

		public string PHOTODISPLAY { get { return ConfigManager.ImagesPath + PHOTOADDRESS; } }

		[DisplayName("FİYATI"), Required(ErrorMessage = "{0} ALANI BOŞ GEÇİLEMEZ!")]
		public double PRICE { get; set; }

		[DisplayName("KDV"), Required(ErrorMessage = "{0} ALANI BOŞ GEÇİLEMEZ!")]	  
		public double TAX { get; set; }

		[DisplayName("KATEGORİ"), Range(1, 99999, ErrorMessage = "{0} ALANI BOŞ GEÇİLEMEZ!")]
		public int CATEGORYID { get; set; }	   
		
		public bool ISACTIVE { get; set; }

		public int ID { get; set; }

		public bool ISINSERT { get; set; }

		public List<SelectListItem> CATEGORYLIST { get; set; }

		public bool ISPROCCESS { get; set; } = false;
		public bool ISSUCCESSFUL { get; set; }
		public string MESSAGE { get; set; }
		public string ERROR_MESSAGE { get; set; }
	}
}