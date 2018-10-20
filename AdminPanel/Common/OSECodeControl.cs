using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanel
{
	//App_Code klasörünün içerisinde "OSEHtmlControl" altında kendi kontrolümüzü bir başka şekilde ekledik 

	public static class OSECodeControl
	{
		public static MvcHtmlString MyDropDownList(this HtmlHelper helper, string id, List<SelectListItem> Content = null, string DefaultText = "", object SelectedValue = null, string css = "")
		{

			string _DefaultText = "", _SelectedValue = "";
			if (DefaultText != "")
				_DefaultText = "<option value='-1'>" + DefaultText + "</option>";

			string ControlHTML = $"<select class='full-width {css}' id='{id}' style='z-index:90' data-init-plugin='select2' >";
			ControlHTML += _DefaultText;
			if (Content != null)
			{
				for (int i = 0; i < Content.Count; i++)
				{
					_SelectedValue = "";
					if (SelectedValue != null)
						if (Content[i].Value == SelectedValue.ToString())
							_SelectedValue = " selected='true' ";

					ControlHTML += "<option value='" + Content[i].Value + "'" + _SelectedValue + ">" + Content[i].Text + "</option>";
				}
			}

			ControlHTML += "</select>";
			//<option value="-1">Lütfen Seçiniz </ option >  

			return MvcHtmlString.Create(ControlHTML);
		}
	}
}