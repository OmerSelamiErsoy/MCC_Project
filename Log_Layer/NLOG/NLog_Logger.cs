using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log_Layer.Abstract;
using NLog;
namespace Log_Layer.NLOG
{
	public class NLog_Logger : Ilogger
	{		 
		public void LogInfo(string message)
		{
			Logger logger = LogManager.GetCurrentClassLogger();
			logger.Info(message);

		}
		public void LogInfo(string message, Exception ex)
		{
			Logger logger = LogManager.GetCurrentClassLogger();
			logger.Info(ex, message);
		}

		public void LogError(string message)
		{
			Logger logger = LogManager.GetCurrentClassLogger();
			logger.Error(message);

		}
		public void LogError(string message, Exception ex)
		{
			Logger logger = LogManager.GetCurrentClassLogger();
			logger.Error(ex, message);
		}
	}
}
