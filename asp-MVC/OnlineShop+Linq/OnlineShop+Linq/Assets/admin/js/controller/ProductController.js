var product = {
    init: function () {
        product.registerEventsStatus();
        product.registerEventsVat();
    },
    registerEventsStatus: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault(); //will remove the href='#' in the <a> tag
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/Product/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    if (response.status) {
                        $(btn).text("ACTIVE")
                    } else {
                        $(btn).text("INACTIVE")
                    }
                }
            });
        });
    },
    registerEventsVat: function () {
        $('.btn-active-vat').off('click').on('click', function (e) {
            e.preventDefault(); //will remove the href='#' in the <a> tag
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/Product/ChangeVat",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    if (response.IncludeVAT) {
                        $(btn).text("Yes")
                    } else {
                        $(btn).text("No")
                    }
                }
            });
        });
    }
}

product.init();