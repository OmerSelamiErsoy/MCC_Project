function GetBasket() {

	try {
		$.ajax({
			url: "/Basket/GetBasketProduct", 
			type: 'POST',
			dataType: 'json',
			beforeSend: function () {
				$("#GeneralLoader").show();
			},
			success: function (data) {

				$("#GeneralLoader").hide();
				if (data.TOTALAOMUNT > 0) {
					$("#spnBasketAmount").html(data.TOTALAOMUNT);
					$("#spnBasketAmount").show();
				}
				else {
					$("#spnBasketAmount").html("0");
					$("#spnBasketAmount").hide();
				}
			}
		});
	}
	catch (e) {
		alertDikkat("Beklenmeyen Hata! <br/>" + e.description);
		$("#GeneralLoader").hide();
	}

}

function AddOrUpdateBasket(PRODUCTID, AMOUNT, ISEQUAL) {

	try {
		$.ajax({
			url: "/Basket/AddOrUpdateBasketProduct",
			data: {
				ID: PRODUCTID,
				AMOUNT: AMOUNT,
				ISEQUAL: ISEQUAL
			},
			type: 'POST',
			dataType: 'json',
			beforeSend: function () {
				$("#GeneralLoader").show();
			},
			success: function (data) {

				$("#GeneralLoader").hide();
				if (data.ISSUCCESSFUL) { 
					alertDikkat("Ürün Sepete Eklenmiştir.");
					GetBasket();
				}
				else {
					alertDikkat(data.ERROR_MESSAGE);
				}
			}
		});
	}
	catch (e) {
		alertDikkat("Beklenmeyen Hata! <br/>" + e.description); 
		$("#GeneralLoader").hide();
	}

}

function RemoveBasket(PRODUCTID) {

	try {
		$.ajax({
			url: "/Basket/DeleteBasketProduct",
			data: {
				ID: PRODUCTID 
			},
			type: 'POST',
			dataType: 'json',
			beforeSend: function () {
				$("#GeneralLoader").show();
			},
			success: function (data) {

				$("#GeneralLoader").hide();
				if (!data.ISSUCCESSFUL) {
					alertDikkat("Ürün Sepetten Silinmiştir.");
					GetBasket();
				}
				else {
					alertDikkat(data.ERROR_MESSAGE);
				}
			}
		});
	}
	catch (e) {
		alertDikkat("Beklenmeyen Hata! <br/>" + e.description);
		$("#GeneralLoader").hide();
	}

}