using Log_Layer.Manager;
using Object_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.Product;

namespace WebApplication.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ProductList(int? ID = null)
        {
			ProductViewModel Model = new ProductViewModel();
			Model.LIST_PRODUCTS = TBL_PRODUCTS.LIST(CATEGORYID: ID,ISACTIVE: true,ISACTIVE_CATEGORY:true);
			Model.LIST_CATEGORIES = TBL_CATEGORIES.LIST(ISACTIVE: true,ISPRODUCTCOUNT:true).OrderByDescending(x => x.PRODUCTCOUNT).ToList();
			if (ID > 0)
			{
				Model.SELECTEDCATEGORY = Model.LIST_CATEGORIES.Where(x => x.ID == ID).ToList()?[0].CATEGORYNAME ?? "";
			}
			return View(Model);
        }

		public ActionResult ProductDetail(int? ID = null)
		{
			if (ID == null)
			{
				return RedirectToAction("ProductList");
			}

			ProductViewModel Model = new ProductViewModel();
			try
			{
				Model.PRODUCTS = TBL_PRODUCTS.LIST(ID: ID, ISACTIVE: true, ISACTIVE_CATEGORY: true)[0];
			}
			catch (Exception ex)
			{
				LogManager.LogManagerStatic().LogError(ex.Message);

				return RedirectToAction("ProductList");
			}

			return View(Model);
		}

	}
}