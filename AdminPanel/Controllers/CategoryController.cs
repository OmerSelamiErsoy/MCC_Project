using AdminPanel.Common;
using AdminPanel.Models.Category;
using AdminPanel.Models.General;
using Object_Layer;
using System;
using System.Web.Mvc;

namespace AdminPanel.Controllers
{
	public class CategoryController : Controller
    {


		[FilterAuthorization]
		public ActionResult CategoryList()
		{
			CategoryViewModel Model = new CategoryViewModel();
			Model.ISACTIVE = true;
			Model.List_CATEGORIES = TBL_CATEGORIES.LIST(ISPRODUCTCOUNT: true);

			return View(Model);
		}


		[HttpPost]
		[FilterAuthorization]
		public ActionResult CategoryList(string CATEGORYNAME, bool ISACTIVE, int UPDATEID)
		{
			CategoryViewModel Model = new CategoryViewModel();

			if (String.IsNullOrEmpty(CATEGORYNAME))
			{
				Model.ISPROCCESS = true;
				Model.ISSUCCESSFUL = false;
				Model.ERROR_MESSAGE = "Lütfen kategori Adı Belirtiniz!";
			}
			else
			{
				if (UPDATEID == 0)
				{
					TBL_CATEGORIES tbl = new TBL_CATEGORIES();
					tbl.CATEGORYNAME = CATEGORYNAME;
					tbl.CREATEUSERID = BasePage.LoginUserInf.ID;
					tbl.CREATEDATE = DateTime.Now;
					tbl.ISACTIVE = ISACTIVE;
					tbl.ISDELETE = false;
					TBL_CATEGORIES.INSERT(tbl);

					Model.ISPROCCESS = true;
					Model.ISSUCCESSFUL = true;
					Model.MESSAGE = CATEGORYNAME + " isimli kategori başarı ile eklenmiştir!";
				}
				else
				{

					TBL_CATEGORIES tbl = TBL_CATEGORIES.LIST(UPDATEID)[0];
					tbl.CATEGORYNAME = CATEGORYNAME;
					tbl.ISACTIVE = ISACTIVE;
					TBL_CATEGORIES.UPDATE(tbl);

					Model.ISPROCCESS = true;
					Model.ISSUCCESSFUL = true;
					Model.MESSAGE = CATEGORYNAME + " isimli kategori başarı ile Güncellenmiştir!";


				}


			}


			Model.List_CATEGORIES = TBL_CATEGORIES.LIST(ISPRODUCTCOUNT: true);

			return View(Model);
		}

		public JsonResult CategoryDelete(int ID)
		{
			TransactionStatus I = new TransactionStatus();
			try
			{

				TBL_CATEGORIES.DELETE(ID);
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