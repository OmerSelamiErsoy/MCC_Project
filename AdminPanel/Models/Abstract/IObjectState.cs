using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.Models.Abstract
{
	interface IObjectState
	{
		 bool ISINSERT_BLOCK { get; set; } 
		 bool ISUPDATE_BLOCK { get; set; }  
		 bool ISDELETE_BLOCK { get; set; }  
	}
}
