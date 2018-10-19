using AdminPanel.Common;
using AdminPanel.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanel.Controllers
{
	public class HomeController : Controller
	{
		[FilterAuthorization]
		public ActionResult Index()
		{
			IndexViewModel Model = new IndexViewModel();

			return View(Model);
		}
	}
}