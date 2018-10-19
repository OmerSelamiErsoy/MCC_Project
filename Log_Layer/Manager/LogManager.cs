using Log_Layer.Abstract;
using Log_Layer.NLOG;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log_Layer.Manager
{
	public class LogManager : Ilogger
	{

		private static LogManager _logmanager;
		private IKernel kernel;
		static object _lockObject = new object();
		private LogManager()
		{												 
			lock (_lockObject)
			{
				if (kernel == null)
				{
					kernel = new StandardKernel();
					kernel.Bind<Ilogger>().To<NLog_Logger>().InSingletonScope();
				}
			}
		}

		public static LogManager LogManagerStatic()
		{
			_logmanager = new LogManager();
			return _logmanager;
		}


		public void LogError(string message)
		{
			kernel.Get<Ilogger>().LogError(message);
		}

		public void LogError(string message, Exception ex)
		{
			kernel.Get<Ilogger>().LogError(message,ex);
		}

		public void LogInfo(string message)
		{
			kernel.Get<Ilogger>().LogInfo(message);

		}

		public void LogInfo(string message, Exception ex)
		{
			kernel.Get<Ilogger>().LogInfo(message,ex);
		}
	}
}
