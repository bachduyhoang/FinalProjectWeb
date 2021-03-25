var search = {
    init: function () {
        search.registerEvent();
    },

    registerEvent: function () {
        $("#name").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/Home/ListName",
                    dataType: "json",
                    data: {
                        q: request.term
                    },
                    success: function (res) {
                        response(res.data);
                    }
                });
            },
            focus: function (event, ui) {
                $("#name").val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                $("#name").val(ui.item.label);
                return false;
            }
        })
            .autocomplete("instance")._renderItem = function (ul, item) {
                return $("<li>")
                    .append("<a>" + item.label + "</a>")
                    .appendTo(ul);
            };
    }
}

search.init();
