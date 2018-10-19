using AdminPanel.Common;
using AdminPanel.Models.Product;
using Object_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanel.Controllers
{
    public class ProductController : Controller
    {
		[FilterAuthorization]
		public ActionResult CategoryList()
        {
			CategoryViewModel Model = new CategoryViewModel();

			Model.List_CATEGORIES = TBL_CATEGORIES.LIST(ISPRODUCTCOUNT: true);

			return View(Model);
        }
    }
}