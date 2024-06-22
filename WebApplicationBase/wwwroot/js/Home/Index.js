(function ($) { // $(document).ready(function() { ... });  =   $(function () { .... });

    //寫法1
    $(function () {
        $(".text-center").on("click", () => {
            alert(`Go`);
        })
    });

    ////寫法2
    //$(() => {
    //    $(".text-center").on("click", () => {
    //        alert(`Go`);
    //    })
    //});

    ////舊寫法
    //$(document).ready(() => {
    //    $(".text-center").on("click", () => {
    //        alert(`Go`);
    //    })
    //});

})(jQuery);

