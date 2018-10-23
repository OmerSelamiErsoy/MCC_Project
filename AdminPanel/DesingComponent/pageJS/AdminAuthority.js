function cboxstatePage(PAGEID) {
	$("#tr_O_" + PAGEID + " input[type=checkbox]").prop('checked', $("#ISPERMISSION_P_" + PAGEID).is(':checked'));

}
function cboxstatePageObject(PAGEID, OBJECTID) {
	if ($("#ISPERMISSION_O_" + OBJECTID).is(':checked')) {
		$("#ISPERMISSION_P_" + PAGEID).prop('checked', true);
	}

}

function cboxAllState(state) {
	$("#cboxGeneral-Div input[type=checkbox]").prop('checked', state);
}




$("#btnSave").click(function () {


	var Values = '';
	$("#cboxGeneral-Div input[type=checkbox]").each(function (i) {
		if (!$(this).is(':checked')) {
			Values += this.id.replace("ISPERMISSION_", "") + '_' + String($(this).is(':checked')) + ',';
		}
	});




	$.confirm({
		title: 'DİKKAT!',
		content: 'İşlemi Yapmak İstediğinize Emin Misiniz?',
		buttons: {
			EVET: {
				btnClass: 'btn-green',
				action: function () {


					$("#SelectedBlockList").val(Values);
					$("#formBlockList").submit();


				}
			},
			HAYIR: {
				btnClass: 'btn-red',
				action: function () {
					//$.alert('Canceled!');
				}
			}
		}
	});



});