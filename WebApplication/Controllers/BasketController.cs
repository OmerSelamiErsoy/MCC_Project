using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Common;
using WebApplication.Models.General;

namespace WebApplication.Controllers
{
    public class BasketController : Controller
    {
        // GET: Basket
        public ActionResult BasketList()
        {
            return View();
        }

		public JsonResult GetBasketProduct()
		{  			 
			return Json(OrderBasket.myBasket, JsonRequestBehavior.AllowGet);
		}

		public JsonResult AddOrUpdateBasketProduct(int ID,int AMOUNT)
		{
			TransactionStatus I = new TransactionStatus();
			try
			{
				OrderBasket.AddOrUpdate(ID,AMOUNT);
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