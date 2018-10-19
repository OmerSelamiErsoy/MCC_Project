using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log_Layer.Abstract
{
	interface Ilogger
	{
		void LogInfo(string message);

		void LogInfo(string message, Exception ex);


		void LogError(string message);

		void LogError(string message, Exception ex);

	}
}
