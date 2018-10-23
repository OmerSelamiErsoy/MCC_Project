using AdminPanel.Models.Abstract;

namespace AdminPanel.Models.General
{
	public  class TransactionStatus	: IResultState
	{
		public bool ISPROCCESS { get; set; } = false;
		public bool ISSUCCESSFUL { get; set; }
		public string MESSAGE { get; set; }
		public string ERROR_MESSAGE { get; set; }
	}
}