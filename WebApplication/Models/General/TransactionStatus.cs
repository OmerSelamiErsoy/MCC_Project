using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.Abstract;

namespace WebApplication.Models.General
{
	public class TransactionStatus : IResultState
	{
		public bool ISPROCCESS { get; set; } = false;
		public bool ISSUCCESSFUL { get; set; }
		public string MESSAGE { get; set; }
		public string ERROR_MESSAGE { get; set; }
	}
}