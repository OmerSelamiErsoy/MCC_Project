using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility.Methods;
using WebApplication.Common;
using WebApplication.Models.Basket;
using WebApplication.Models.General;

namespace WebApplication.Controllers
{
    public class BasketController : Controller
    {
       
        public ActionResult BasketList()
        {
			BasketViewModel Model = new BasketViewModel();
			Model.BASKET = OrderBasket.myBasket;

			
            return View(Model);
        }

		[HttpPost]
		public ActionResult BasketList(int postPROCESS,int postID,int postAMOUNT)
		{
			switch (postPROCESS)
			{
				case (int)Enumeration.enum_myBasketProcess.DELETE:
					OrderBasket.Delete(postID);
					break;
				case (int)Enumeration.enum_myBasketProcess.ADD_OR_UPDATE:
					OrderBasket.AddOrUpdate(postID, postAMOUNT, 1);
					break;
				case (int)Enumeration.enum_myBasketProcess.CLEAR:
					OrderBasket.Clear();
					break;
			}	  
			 
			BasketViewModel Model = new BasketViewModel();
			Model.BASKET = OrderBasket.myBasket;


			return View(Model);
		}


		public JsonResult GetBasketProduct()
		{  			 
			return Json(OrderBasket.myBasket, JsonRequestBehavior.AllowGet);
		}

		public JsonResult AddOrUpdateBasketProduct(int ID,int AMOUNT,int ISEQUAL)
		{
			TransactionStatus I = new TransactionStatus();
			try
			{
				OrderBasket.AddOrUpdate(ID,AMOUNT, ISEQUAL);
				I.ISSUCCESSFUL = true;

			}
			catch (Exception ex)
			{
				I.ISSUCCESSFUL = false;
				I.ERROR_MESSAGE = "İşlem sırasında beklenmeyen bir hata oluştu!";
			}

			return Json(I, JsonRequestBehavior.AllowGet);
		}

		public JsonResult DeleteBasketProduct(int ID)
		{
			TransactionStatus I = new TransactionStatus();
			try
			{

				OrderBasket.Delete(ID);
				I.ISSUCCESSFUL = true;

			}
			catch (Exception ex)
			{
				I.ISSUCCESSFUL = false;
				I.ERROR_MESSAGE = "İşlem sırasında beklenmeyen bir hata oluştu!";
			}

			return Json(I, JsonRequestBehavior.AllowGet);
		}

	}
}