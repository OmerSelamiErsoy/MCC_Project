﻿using AdminPanel.Common;
using AdminPanel.Models.General;
using AdminPanel.Models.Product;
using Object_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Utility.Methods;

namespace AdminPanel.Controllers
{
    public class ProductController : Controller
    {

		[FilterAuthorization]
		public ActionResult ProductList()
		{
			ProductViewModel Model = new ProductViewModel();	   
			Model.List_PRODUCTS = TBL_PRODUCTS.LIST();

			return View(Model);
		}

		public JsonResult ProductDelete(int ID)
		{
			TransactionStatus I = new TransactionStatus();
			try
			{

				TBL_PRODUCTS.DELETE(ID);
				I.ISSUCCESSFUL = true;

			}
			catch (Exception ex)
			{
				I.ISSUCCESSFUL = false;
				I.ERROR_MESSAGE = "İşlem sırasında beklenmeyen bir hata oluştu!";
			}

			return Json(I, JsonRequestBehavior.AllowGet);
		}



		[FilterAuthorization]
		public ActionResult ProductInsertOrUpdate(int ID = 0)
		{
			InsertViewModel Model = new InsertViewModel();
			Model.ISPROCCESS = false;
			Model.CATEGORYLIST = TBL_CATEGORIES.LIST().ConvertAll(t =>
			{
				return new SelectListItem()
				{
					Text = t.CATEGORYNAME.ToString(),
					Value = t.ID.ToString(),
					Selected = false
				};
			});

			if (ID > 0)
			{
				TBL_PRODUCTS T = TBL_PRODUCTS.LIST(ID)[0];
				Model.CATEGORYID = T.CATEGORYID;
				Model.DESCRIPTION = T.DESCRIPTION;
				Model.ISACTIVE = T.ISACTIVE;
				Model.PHOTOADDRESS = T.PHOTOADDRESS;
				Model.PRICE = T.PRICE;
				Model.PRODUCTCODE = T.PRODUCTCODE;
				Model.PRODUCTNAME = T.PRODUCTNAME;
				Model.TAX = T.TAX;
				Model.ID = ID;
				Model.ISINSERT = false;
			}
			else
			{
				Model.ISACTIVE = true;
				Model.CATEGORYID = -1;
				Model.ID = ID;
				Model.ISINSERT = true;
			}
			


			return View(Model);
		}



		[HttpPost]
		[FilterAuthorization]
		public ActionResult ProductInsertOrUpdate(InsertViewModel Model, HttpPostedFileBase inputImage = null)
		{


			Model.ISPROCCESS = false;

			Model.CATEGORYLIST = TBL_CATEGORIES.LIST().ConvertAll(t =>
			{
				return new SelectListItem()
				{
					Text = t.CATEGORYNAME.ToString(),
					Value = t.ID.ToString(),
					Selected = false
				};
			});


			string DOSYAYOLU = "";

			int KULLANICIID = BasePage.LoginUserInf.ID;
			if (inputImage != null)
			{
				if (inputImage.ContentType == "image/jpeg" || inputImage.ContentType == "image/jpg" || inputImage.ContentType == "image/png")
				{
					WebImage img = new WebImage(inputImage.InputStream);
					string UploadDFolder = ConfigManager.UploadDirectoryFolder;
					DOSYAYOLU = BasePage.ImgUpload(img, ConfigManager.UploadDirectory, UploadDFolder);
				}
				else
				{
					ModelState.AddModelError("", "DİKKAT! Upload Edilen Resmin Formatı Hatalı!");   
					return View(Model);
				}
			}
			else
			{
				DOSYAYOLU = ConfigManager.DefaultProductImage;
			}


			if (Model.ID > 0)
			{
				TBL_PRODUCTS T = TBL_PRODUCTS.LIST(Model.ID)[0];
				T.CATEGORYID = Model.CATEGORYID;
				T.DESCRIPTION = Model.DESCRIPTION;
				T.ISACTIVE = Model.ISACTIVE;
				if(inputImage != null)
					T.PHOTOADDRESS = DOSYAYOLU;
				T.PRICE = Model.PRICE;
				T.PRODUCTCODE = Model.PRODUCTCODE;
				T.PRODUCTNAME = Model.PRODUCTNAME;
				T.TAX = Model.TAX;
				T.LASTCHANGEUSERID = BasePage.LoginUserInf.ID;
				T.LASTCHANGEDATE = DateTime.Now;	 
				TBL_PRODUCTS.UPDATE(T);

				Model.ISINSERT = false;
				Model.MESSAGE = Model.PRODUCTNAME + " Ürünü başarı ile güncellenmiştir. Altta bulunan 'Listeye Dön' linkine tıklayarak ürün listesine ulaşabilirsiniz.";
			}
			else
			{
				TBL_PRODUCTS T = new TBL_PRODUCTS();
				T.CATEGORYID = Model.CATEGORYID;
				T.DESCRIPTION = Model.DESCRIPTION;
				T.ISACTIVE = Model.ISACTIVE;
				T.PHOTOADDRESS = DOSYAYOLU;
				T.PRICE = Model.PRICE;
				T.PRODUCTCODE = Model.PRODUCTCODE;
				T.PRODUCTNAME = Model.PRODUCTNAME;
				T.TAX = Model.TAX;
				T.ISDELETE = false;
				T.CREATEUSERID = BasePage.LoginUserInf.ID;
				T.CREATEDATE = DateTime.Now;
				TBL_PRODUCTS.INSERT(T);


				Model.ISINSERT = true;
				Model.MESSAGE = Model.PRODUCTNAME + " Ürünü başarı ile eklenmiştir. Altta bulunan 'Listeye Dön' linkine tıklayarak ürün listesine ulaşabilirsiniz";


				Model.CATEGORYID = -1;
				Model.DESCRIPTION = "";
				Model.ISACTIVE = true;
				Model.PHOTOADDRESS = "";
				Model.PRICE = 0;
				Model.PRODUCTCODE = "";
				Model.PRODUCTNAME = "";
				Model.TAX = 0;
				
			}
						  

			Model.ISPROCCESS = true;
			Model.ISSUCCESSFUL = true;


			return View(Model);
		}




		}
}