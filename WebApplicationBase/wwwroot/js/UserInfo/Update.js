(function ($) {
    
    $(function () {
        $(".btnBack").on("click", function () {
            location.href = `${PageScope.Url.Index}`;
        })

    });
})(jQuery);