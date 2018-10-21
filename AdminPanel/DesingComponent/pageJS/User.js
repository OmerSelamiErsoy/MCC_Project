function DELETE(ID) {

	var _UserName = $("#FULLNAME_" + ID).text();
	$.confirm({
		title: 'DİKKAT!',
		content: _UserName + ' kullanıcısını SİLMEK istediğinize emin misiniz?',
		buttons: {
			EVET: {
				btnClass: 'btn-green',
				action: function () {
					$("#Divresult").hide();


					try {
						$.ajax({
							url: "/User/UserDelete",
							data: {
								ID: ID
							},
							type: 'POST',
							dataType: 'json',
							success: function (data) {
								if (data.ISSUCCESSFUL) {
									$('#tr_' + ID).remove();
									alertDikkat(_UserName + " kullanıcısı Silinmiştir.");
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





 