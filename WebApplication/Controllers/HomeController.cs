using Object_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.Home;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
			IndexViewModel Model = new IndexViewModel();

			Model.LIST_PRODUCTS_NEW = TBL_PRODUCTS.LIST(ISACTIVE: true, ISACTIVE_CATEGORY: true, TOPNUMBER: 8);

			return View(Model);
        }
    }
}