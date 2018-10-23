using Log_Layer.Manager;
using System;
using System.Web.Mvc;
using Utility;

namespace AdminPanel.Common
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
	public class LogAction : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			 string	CurrentActionName = filterContext.ActionDescriptor.ActionName;

			 string	CurrentControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

			LogManager.LogManagerStatic().LogInfo(BasePage.LoginUserInf.FULLNAME + " "  + CurrentControllerName + " > " + CurrentActionName + " sayfasına girdi.");

		}
	}
}