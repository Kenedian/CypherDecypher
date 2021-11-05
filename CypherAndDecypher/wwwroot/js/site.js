$(function () {

    $(".dropdown-menuFrom a").click(function () {
        $(".btnDropFrom:first-child").val($(this).text());
    });

});

$(function () {

    $(".dropdown-menuTo a").click(function () {
        $(".btnDropTo:first-child").val($(this).text());
    });

});
