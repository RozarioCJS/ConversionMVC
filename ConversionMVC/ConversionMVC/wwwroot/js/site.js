$(document).ready(function () {
    var currentPageUrl = new URL(window.location.href);
    $(".nav-pills li a").each(function () {
        var linkUrl = new URL($(this).attr("href"), window.location.href);

        if (currentPageUrl.pathname === linkUrl.pathname) {
            $(this).addClass("active");
        } else {
            $(this).removeClass("active");
        }
    });
})