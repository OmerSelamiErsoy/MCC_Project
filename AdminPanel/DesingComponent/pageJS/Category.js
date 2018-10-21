

$("#btnAddCategory").click(function () {

	var _CategoryName = $("#CATEGORYNAME").val();

	if (_CategoryName == '') {
		alertDikkat("Lütfen Kategori Adı Belirtiniz!")
		return;
	}


	$.confirm({
		title: 'DİKKAT!',
		content: 'İşlemi Yapmak İstediğinize Emin Misiniz?',
		buttons: {
			EVET: {
				btnClass: 'btn-green',
				action: function () {


					$("#formAdd").submit();



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

$("#close").click(function () {
	$("#divNewCategory").slideUp("slow", function () { });
	$("#Divresult").hide();
});

$("#btnnew").click(function () {
	$("#divNewCategory").slideDown("slow", function () { });
	$("#Divresult").hide();
	$('#UPDATEID').val('0')
	$('#CATEGORYNAME').val('')
	$('#ISACTIVE').prop('checked', true);
	$('#divProccessTitle').text("Ekle")
});

function UPDATE(ID) {
	$("#Divresult").hide();
	var _CategoryName = $("#CATEGORYNAME_" + ID).text();
	var _IsActive = $("#ISACTIVE_" + ID).val();
	if (_IsActive) {
		$('#ISACTIVE').prop('checked', true);
	}
	else {
		$('#ISACTIVE').prop('checked', false);
	}
	$("#divNewCategory").slideDown("slow", function () { });
	$('#CATEGORYNAME').val(_CategoryName)
	$('#UPDATEID').val(ID)
	$('#divProccessTitle').text("Güncelle")
}


function DELETE(ID) {

	var _CategoryName = $("#CATEGORYNAME_" + ID).text();
	$.confirm({
		title: 'DİKKAT!',
		content: _CategoryName + ' Kategorisini SİLMEK istediğinize emin misiniz?',
		buttons: {
			EVET: {
				btnClass: 'btn-green',
				action: function () {
					$("#Divresult").hide();


					try {
						$.ajax({
							url: "/Category/CategoryDelete",
							data: {
								ID: ID
							},
							type: 'POST',
							dataType: 'json',
							success: function (data) {
								if (data.ISSUCCESSFUL) {
									$('#tr_' + ID).remove();
									alertDikkat(_CategoryName + " Kategorisi Silinmiştir.");
								}
								else {
									alertDikkat(data.ERROR_MESSAGE);
								}
							}
						});
					}
					catch (e) {
						alertDikkat("Beklenmeyen Hata! <br/>" + e.description);
					}


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

}
