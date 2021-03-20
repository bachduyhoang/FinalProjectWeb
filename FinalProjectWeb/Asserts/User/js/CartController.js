var cart = {
    init: function () {
        cart.regEvents();
    },

    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = '/';
        });

        $('#btnUpdate').off('click').on('click', function () {
            var listProduct = $('.quantity');
            var cart = [];
            $.each(listProduct, function (i, item) {
                cart.push({
                    Quantity: $(item).val(),
                    Product: {
                        productID: $(item).data('id')
                    }
                });
            });

            $.ajax({
                url: '/cart/update',
                data: { cart: JSON.stringify(cart) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = '/cart';
                    }
                }
            })
        });

        $('#btnDeleteCart').off('click').on('click', function () {
            $.ajax({
                url: '/cart/deleteall',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/cart";
                    }
                }
            })
        });

        $('.btnDelete').off('click').on('click', function (e) {
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/cart/delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/cart";
                    }
                }
            })
        });

    }
}
cart.init();