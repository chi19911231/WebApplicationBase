(function ($) {
    
    $(function () {

        $(".btnBack").on("click", function () {
            location.href = `${PageScope.Url.Index}`;
        })

        $(".btnDelete").on("click", function () {
            let id = $("#ID").val();
            deleteUserInfo(id);
        })

    });

    let deleteUserInfo = (id) => {
        $.ajax({
            url: PageScope.Url.Delete,
            type: "POST",
            contentType: "application/x-www-form-urlencoded",
            dataType: "json",
            data: { id: id },
            success: function (response) {
                console.log("postParameterJson-response: " + JSON.stringify(response));
                if (response.status == PageScope.StatusType.Success) {
                    confirmHref("刪除成功", null);
                }
                else {
                    console.log("postParameterJson-response: " + JSON.stringify(response));
                    confirmHref("刪除失敗", response.message);
                }

            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);
                alert("Error");
            }
        });
    }

    let confirmHref = (title, text) => {
        Swal.fire({
            //標頭
            title: title,
            //內容
            text: text,
            showCancelButton: false,
        }).then(function (result) {
            if (result.value) {
                location.href = PageScope.Url.Index;
            }
        });
    }

})(jQuery);