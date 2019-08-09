// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function ($) {
    if (window.location.pathname !== "/") {
        return;
    }

    $.get("Home/Locations", function (res) {
        $(".search-input-from").autocomplete({
            lookup: res,
            onSelect: function (suggestion) {
                var id = suggestion.data;
                var text = suggestion.value;

                $("#FromId").val(id);
            }
        });

        $(".search-input-to").autocomplete({
            lookup: res,
            onSelect: function (suggestion) {
                var id = suggestion.data;
                var text = suggestion.value;

                $("#ToId").val(id);
            }
        });
    });

    $(".btn-change").click(function () {
        var fromId = $("#FromId");
        var fromText = $("#FromText");
        var toId = $("#ToId");
        var toText = $("#ToText");

        var fromIdValue = fromId.val();
        var fromTextValue = fromText.val();
        var toIdValue = toId.val();
        var toTextValue = toText.val();

        toId.val(fromIdValue);
        toText.val(fromTextValue);

        fromId.val(toIdValue);
        fromText.val(toTextValue);
    });

    $(".btn-today").click(function () {
        var now = new Date();

        var day = ("0" + now.getDate()).slice(-2);
        var month = ("0" + (now.getMonth() + 1)).slice(-2);

        var today = now.getFullYear() + "-" + (month) + "-" + (day);

        $("#Date").val(today);
    })

    $(".btn-tomorrow").click(function () {
        var now = new Date();

        var day = ("0" + (now.getDate() + 1)).slice(-2);
        var month = ("0" + (now.getMonth() + 1)).slice(-2);

        var tomorrow = now.getFullYear() + "-" + (month) + "-" + (day);

        $("#Date").val(tomorrow);
    })
}); 