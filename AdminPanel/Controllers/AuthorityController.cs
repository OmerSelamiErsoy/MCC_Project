using AdminPanel.Common;
using AdminPanel.Models.Login;
using Log_Layer.Manager;
using Object_Layer;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace AdminPanel.Controllers
{
	public class AuthorityController : Controller
    {
        // GET: Authority
        public ActionResult Login()
        {
			LoginViewModel Model = new LoginViewModel();
			string CookiResult = BasePage.ReadCookies(cookieKeyRememberMe);
			if (CookiResult != "")
			{
				Model.BENIHATIRLA = true;
				Model.EPOSTA = CookiResult;
			}
			else
				Model.BENIHATIRLA = false;

			return View(Model);
        }



		string cookieKeyRememberMe = "cookREMEMBERME";

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(LoginViewModel UG)
		{
			if (UG == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			if (ModelState.IsValid)
			{
				TBL_USERS _USER = TBL_USERS.SINGLE(EMAIL: UG.EPOSTA, PASSWORD: UG.SIFRE, ISEXECUTIVE: true);
				if (_USER == null)
				{
					ModelState.AddModelError("", "Hatalı Eposta veya Şifre girdiniz!");
					return View(UG);
				}
				else
				{
					if (UG.BENIHATIRLA)
					{
						BasePage.AddCookies(cookieKeyRememberMe, UG.EPOSTA);
					}
					else
					{
						if (BasePage.ReadCookies(cookieKeyRememberMe) != "")
							BasePage.DeleteCookies(cookieKeyRememberMe);

					}

					List<TBL_USERBLOCKLIST> _BLOCKLIST = TBL_USERBLOCKLIST.LIST(USERID: _USER.ID);
					BasePage.LoginSessionAddUserAuthority(_USER, _BLOCKLIST);
																										 

					LogManager.LogManagerStatic().LogInfo(_USER.FULLNAME + " Kullanıcısı Sisteme Giriş Yaptı");

					 
					return RedirectToAction("Index", "Home");

				}
			}

			return View(UG);
		}


		public ActionResult Logout()
		{

			BasePage.LoginSessionDelUserAuthority();

			return RedirectToAction("Login", "Authority");
		}
	}
}