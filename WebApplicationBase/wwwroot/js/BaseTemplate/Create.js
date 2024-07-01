﻿(function ($) {
    $(function () {
        $(".submitBtn").on("click", () => {
            Swal.fire({
                //標頭
                title: `資料送出`,
                showCancelButton: false,
            }).then(function (result) {
                let $form = $("#postform");
                $form.get(0).submit();
            });   
        })
    });
})(jQuery);