using AdminPanel.Common;
using AdminPanel.Models.AdminAuthority;
using AdminPanel.Models.User;
using Log_Layer.Manager;
using Object_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility.Methods;

namespace AdminPanel.Controllers
{
    public class AdminAuthorityController : Controller
    {
		[FilterAuthorization(Enumeration.enum_PageID.UserBlockPage),LogAction]
		public ActionResult AdminList()
		{
			UserViewModel Model = new UserViewModel();
			Model.List_USERS = TBL_USERS.LIST(ISEXECUTIVE:true);

			return View(Model);
		}


		[FilterAuthorization(Enumeration.enum_PageID.UserBlockPage), LogAction]
		public ActionResult PageObjectList(int ID)
		{
			AdminAuthorityViewModel Model = new AdminAuthorityViewModel();
			Model.LIST_PAGES = TBL_PAGES.LIST();
			Model.LIST_PAGEOBJECTS = TBL_PAGEOBJECTS.LIST();
			Model.USER = TBL_USERS.SINGLE(ID: ID);
			Model.LIST_USERBLOCKLIST = TBL_USERBLOCKLIST.LIST(USERID: ID);
			

			return View(Model);
		}


		[FilterAuthorization, LogAction]
		public ActionResult Unauthorized()
		{	  
			return View();
		}


		[HttpPost]
		public ActionResult PageObjectList(string SelectedBlockList,int USERID)
		{

			AdminAuthorityViewModel Model = new AdminAuthorityViewModel();
			Model.LIST_PAGES = TBL_PAGES.LIST();
			Model.LIST_PAGEOBJECTS = TBL_PAGEOBJECTS.LIST();
			Model.USER = TBL_USERS.SINGLE(ID: USERID);


			TBL_USERBLOCKLIST.DELETE_BYUSERID(USERID);



			if (!String.IsNullOrEmpty(SelectedBlockList))
			{
				TBL_USERBLOCKLIST UBL = new TBL_USERBLOCKLIST();
				UBL.CREATEDATE = DateTime.Now;
				UBL.CREATEUSERID = BasePage.LoginUserInf.ID;
				UBL.USERID = USERID;

				SelectedBlockList = SelectedBlockList.Remove(SelectedBlockList.Length - 1);
				string[] s_row = SelectedBlockList.Split(',');
				for (int i = 0; i < s_row.Length; i++)
				{
					string[] s_column = s_row[i].Split('_');
					string TypeName = s_column[0];
					int _PageOrObjectID = s_column[1].ToInt32();
					bool row_value = (s_column[2] == "true") ? true : false;

					UBL.PAGEID_OR_OBJECTID = _PageOrObjectID;
					UBL.TYPEID = (TypeName.ToUpper() == "P") ? (byte)Enumeration.enum_UserBlockListType.PAGE : (byte)Enumeration.enum_UserBlockListType.PAGEOBJECT;
					TBL_USERBLOCKLIST.INSERT(UBL);
				}
			}
			Model.ISPROCCESS = true;   

			Model.LIST_USERBLOCKLIST = TBL_USERBLOCKLIST.LIST(USERID: USERID);



			LogManager.LogManagerStatic().LogInfo(Model.USER.FULLNAME + "isimli kullanıcının yetkileri " + BasePage.LoginUserInf.FULLNAME + " kullanıcısı tarafından güncellendi.");

			return View(Model);
		}
	}
}