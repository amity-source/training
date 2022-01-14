var user = {
    init: function () {
        user.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault(); //will remove the href='#' in the <a> tag
            var btn = $(this)
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/User/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    if (response.status == true) {
                        $(btn).text("ACTIVE")
                    } else {
                        $(btn).text("INACTIVE")
                    }
                }
            });
        });
    }   
}

user.init();