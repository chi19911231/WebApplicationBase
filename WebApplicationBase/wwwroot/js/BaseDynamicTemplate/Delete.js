(function ($) {
    $(function () {

        //alert("~/js/BaseDynamicTemplate/Delete.js----btnDetele");
        

        $(".btnDynamicDelete").on("click", () => {
            alert("~/js/BaseDynamicTemplate/Delete.js----btnDetele");
            aa();
        })

        let aa =  function () {
            //alert("刪除");
            $(this).closest(".dynamic").remove();
        }


        let dynamicDetele = function () {
            alert("dynamicDetele");
        }

        function dynamicDetele2(object) {
            alert("dynamicDetele");
            $(object).closest(".dynamic").remove();
        }

    });
})(jQuery);