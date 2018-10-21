function DELETE(ID) {

	var _ProductName = $("#PRODUCTNAME_" + ID).text();
	$.confirm({
		title: 'DİKKAT!',
		content: _ProductName + ' Ürününü SİLMEK istediğinize emin misiniz?',
		buttons: {
			EVET: {
				btnClass: 'btn-green',
				action: function () {
					$("#Divresult").hide();


					try {
						$.ajax({
							url: "/Product/ProductDelete",
							data: {
								ID: ID
							},
							type: 'POST',
							dataType: 'json',
							success: function (data) {
								if (data.ISSUCCESSFUL) {
									$('#tr_' + ID).remove();
									alertDikkat(_ProductName + " Ürünü Silinmiştir.");
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






$("#btnProduct").click(function () {

	var _PRODUCTNAME = $("#PRODUCTNAME").val();
	var _PRODUCTCODE = $("#PRODUCTCODE").val();
	var _CATEGORYID = $("#CATEGORYID").val();
	var _TAX = $("#TAX").val().replace(',', '.');
	var _PRICE = $("#PRICE").val().replace(',', '.');

	if (_PRODUCTNAME == '') {
		alertDikkat("Lütfen Ürün İsmi Belirtiniz!")
		return;
	}
	if (_PRODUCTCODE == '') {
		alertDikkat("Lütfen Ürün Kodu Belirtiniz!")
		return;
	}
	if (_CATEGORYID == '') {
		alertDikkat("Lütfen Kategori Belirtiniz!")
		return;
	}
	else if (parseInt(_CATEGORYID) <= 0) {
		alertDikkat("Lütfen Kategori Belirtiniz!")
		return;
	}

	if (_TAX == '') {
		alertDikkat("Lütfen KDV Belirtiniz!")
		return;
	}

	if (_PRICE == '') {
		alertDikkat("Lütfen Fiyat Belirtiniz!")
		return;
	}
	else if (parseFloat(_PRICE) <= 0) {
		alertDikkat("Lütfen Fiyat Belirtiniz!")
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