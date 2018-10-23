function AddBasket(ID) {


	$.confirm({
		title: 'DİKKAT!',
		content: 'SEPETİ GÜNCELLEMEK istediğinize emin misiniz?',
		buttons: {
			EVET: {
				btnClass: 'btn-green',
				action: function () {


					var _BasketAmount = $("#BasketAmount_" + ID).val().replace(',', '.');


					if (_BasketAmount == "" || parseInt(_BasketAmount) <= 0) {
						alertDikkat("Lütfen Adet Belirtiniz!")
						return;
					}
					$("#postAMOUNT").val(_BasketAmount);
					$("#postID").val(ID);
					$("#postPROCESS").val("1");

					$("#GeneralLoader").show();
					$("#formBasket").submit();

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


function DeleteBasket(ID) {

	$.confirm({
		title: 'DİKKAT!',
		content: 'Ürünü SEPETTEN KALDIRMAK istediğinize emin misiniz?',
		buttons: {
			EVET: {
				btnClass: 'btn-green',
				action: function () {



					$("#postAMOUNT").val("0");
					$("#postID").val(ID);
					$("#postPROCESS").val("2");

					$("#GeneralLoader").show();
					$("#formBasket").submit();


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

function ClearBasket() {

	$.confirm({
		title: 'DİKKAT!',
		content: 'SEPETİ BOŞALTMAK istediğinize emin misiniz?',
		buttons: {
			EVET: {
				btnClass: 'btn-green',
				action: function () {



					$("#postAMOUNT").val("0");
					$("#postID").val("0");
					$("#postPROCESS").val("0");

					$("#GeneralLoader").show();
					$("#formBasket").submit();


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