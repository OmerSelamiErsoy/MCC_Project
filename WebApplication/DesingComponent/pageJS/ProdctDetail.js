
$("#btnAddBasket").click(function () {


	var _BasketAmount = $("#BasketAmount").val().replace(',', '.');
	var _productID = $("#ID").val();


	if (_BasketAmount == "" || parseInt(_BasketAmount) <= 0) {
		alertDikkat("Lütfen Adet Belirtiniz!")
		return;
	}


	AddOrUpdateBasket(_productID, _BasketAmount, 1);

});
