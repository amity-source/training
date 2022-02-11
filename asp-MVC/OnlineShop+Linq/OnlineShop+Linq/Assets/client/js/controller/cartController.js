var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/";   //redirect back to home
        });
        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/checkout";
        });
        $('#btnUpdate').off('click').on('click', function () {
            var listProduct = $('.txtQuantity');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                var quantity = $(this).val();
                if (quantity > 0) {
                    cartList.push({
                        Quantity: quantity,
                        Product: {
                            ID: $(item).data('id')
                        }
                    });
                }
            });
            $.ajax({
                url: '/Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart";
                    }
                }
            })
        });
        $('#btnDeleteAll').off('click').on('click', function () {
            $.ajax({
                url: '/Cart/DeleteAll',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart";
                    }
                }
            })
        });
        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Cart/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart";
                    }
                }
            })
        });
        $('.minus-button').off('click').on('click', function (e) {
            e.preventDefault();
            var quantity = $('.txtQuantity');
            quantity.val(parseInt(quantity.val()) - 1);
            if (quantity.val() == 0) {
                quantity.val(1);
                $(this).toggleClass('')
            }
        });
        $('.plus-button').off('click').on('click', function (e) {
            e.preventDefault();
            $('.txtQuantity').val(parseInt($('.txtQuantity').val()) + 1);
        });
    }
}

cart.init();