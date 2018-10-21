using AdminPanel.Common;
using AdminPanel.Models.General;
using AdminPanel.Models.User;
using Object_Layer;
using System;
using System.Web.Mvc;

namespace AdminPanel.Controllers
{
	public class UserController : Controller
    {
		[FilterAuthorization]
		public ActionResult UserList()
		{
			UserViewModel Model = new UserViewModel();
			Model.List_USERS = TBL_USERS.LIST();

			return View(Model);
		}



		[FilterAuthorization]
		public ActionResult UserDetail(int ID = 0)
		{
			UserViewModel Model = new UserViewModel();
			try
			{
				Model.USERS = TBL_USERS.LIST(ID)[0];
				Model.ISPROCCESS = false;
			}
			catch (Exception ex)
			{	 
				Model.USERS = new TBL_USERS();									 
				Model.ISPROCCESS = true;
				Model.ISSUCCESSFUL = false;
				Model.ERROR_MESSAGE = "İşlem sırasında bir hata oluştu! Lütfen böyle bir kullanıcının varlığından emin olun.";
			}

			return View(Model);
		}

		public JsonResult UserDelete(int ID)
		{
			TransactionStatus I = new TransactionStatus();
			try
			{

				TBL_USERS.DELETE(ID);
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
		public ActionResult UserInsertOrUpdate(int ID = 0)
		{
			InsertViewModel Model = new InsertViewModel();
			Model.ISPROCCESS = false;
			Model.ISINSERT = true;


			if (ID > 0)
			{
				try
				{
					TBL_USERS T = TBL_USERS.LIST(ID)[0];
					Model.EMAIL = T.EMAIL;
					Model.FULLNAME = T.FULLNAME;
					Model.ID = T.ID;
					Model.ISACTIVE = T.ISACTIVE;
					Model.ISEXECUTIVE = T.ISEXECUTIVE;
					Model.PASSWORD = T.PASSWORD;
					Model.PHONE = T.PHONE;

					Model.ISINSERT = false;
				}
				catch (Exception ex)
				{		 
					Model.ISPROCCESS = true;
					Model.ISSUCCESSFUL = false;
					Model.ERROR_MESSAGE = "İşlem sırasında bir hata oluştu! Lütfen böyle bir kullanıcının varlığından emin olun.";
				}
				
			}
			else
			{
				Model.ISACTIVE = true;
				Model.ISEXECUTIVE = false;
				Model.ID = 0;
			}



			return View(Model);
		}



		[HttpPost]
		[FilterAuthorization]
		public ActionResult UserInsertOrUpdate(InsertViewModel Model)
		{


			Model.ISPROCCESS = false;

			 					 

			if (Model.ID > 0)
			{						   
				TBL_USERS T = TBL_USERS.LIST(Model.ID)[0];
				T.EMAIL = Model.EMAIL;
				T.FULLNAME = Model.FULLNAME;
				T.ISACTIVE = Model.ISACTIVE;
				T.ISEXECUTIVE = Model.ISEXECUTIVE;
				T.PASSWORD = Model.PASSWORD;
				T.PHONE = Model.PHONE;		  
				T.LASTCHANGEUSERID = BasePage.LoginUserInf.ID;
				T.LASTCHANGEDATE = DateTime.Now;  
				TBL_USERS.UPDATE(T);

				Model.ISINSERT = false;
				Model.MESSAGE = Model.FULLNAME + " kişisi başarı ile güncellenmiştir. Altta bulunan 'Listeye Dön' linkine tıklayarak Kullanıcı listesine ulaşabilirsiniz.";
			}
			else
			{
				TBL_USERS T = new TBL_USERS();
				T.EMAIL = Model.EMAIL;
				T.FULLNAME = Model.FULLNAME;
				T.ISACTIVE = Model.ISACTIVE;
				T.ISEXECUTIVE = Model.ISEXECUTIVE;
				T.PASSWORD = Model.PASSWORD;
				T.PHONE = Model.PHONE;
				T.ISDELETE = false;
				T.CREATEUSERID = BasePage.LoginUserInf.ID;
				T.CREATEDATE = DateTime.Now;
				TBL_USERS.INSERT(T);


				Model.ISINSERT = true;
				Model.MESSAGE = Model.FULLNAME + " kişisi başarı ile eklenmiştir. Altta bulunan 'Listeye Dön' linkine tıklayarak Kullanıcı listesine ulaşabilirsiniz";


				Model.EMAIL = "";
				Model.FULLNAME = "";
				Model.ISACTIVE = true; 
				Model.ISEXECUTIVE = false;
				Model.PASSWORD = "";   
				Model.PHONE = "";	    

			}


			Model.ISPROCCESS = true;
			Model.ISSUCCESSFUL = true;


			return View(Model);
		}
	}
}