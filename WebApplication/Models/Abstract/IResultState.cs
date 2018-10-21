using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Models.Abstract
{
	interface IResultState
	{
		bool ISPROCCESS { get; set; }
		bool ISSUCCESSFUL { get; set; }
		string MESSAGE { get; set; }
		string ERROR_MESSAGE { get; set; }
	}
}
