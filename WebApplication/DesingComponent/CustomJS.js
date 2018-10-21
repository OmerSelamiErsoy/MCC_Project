function inputEnterBtn(e, buttonID) {

	var asciiValue = e.keyCode || e.charCode; 

	
	if (asciiValue == 13 && typeof buttonID != 'undefined') {
		e.preventDefault(); 
		document.getElementById(buttonID).click();
	} 
}

function alertDikkat(text) {
	$.alert({
		title: 'DİKKAT',
		icon: 'fa fa-warning',
		type: 'orange',
		content: '<h4>' + text + '</h4>',
		animationBounce: 1.5,
		animation: 'zoom',
		closeAnimation: 'scale',
	});
}



function ddlSelectedValueWriteHidden(ddlFieldName, hiddenFieldName) {
	$('#' + ddlFieldName).on('change', function () {
		var selectedValue = $("#" + ddlFieldName + " > option:selected").attr("value");
		$("#" + hiddenFieldName).val(selectedValue)
	});

}



$(document).ready(function () {
	$(".numberinput").forceNumeric();
});


jQuery.fn.forceNumeric = function () {
	return this.each(function () {
		$(this).keydown(function (e) {
			var key = e.which || e.keyCode;

			if (!e.shiftKey && !e.altKey && !e.ctrlKey &&
				// numbers
				key >= 48 && key <= 57 ||
				// Numeric keypad
				key >= 96 && key <= 105 ||
				// comma, period and minus, . on keypad
				key == 190 || key == 188 || key == 109 || key == 110 ||
				// Backspace and Tab and Enter
				key == 8 || key == 9 || key == 13 ||
				// Home and End
				key == 35 || key == 36 ||
				// left and right arrows
				key == 37 || key == 39 ||
				// Del and Ins
				key == 46 || key == 45)
				return true;

			return false;
		});
	});
}