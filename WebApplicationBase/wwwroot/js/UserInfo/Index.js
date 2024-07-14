(function ($) {
    
    $(function () {

        $(".Welcome").on("click", () => {
            alert(`Welcome`);         
        })

        $(".btnCreate").on("click", function () {
            location.href = `${PageScope.Url.Create}`;
        })

        $(".btnEdit").on("click", function (){
            let id = $(this).attr("value");
            location.href = `${PageScope.Url.Update}?id=${id}`;
        })

        $(".btnDelete").on("click", function () {
            let id = $(this).attr("value");
            Swal.fire({
                //標頭
                title: `是否刪除？`,
                //內容
                text: `刪除此筆資料`,
                //圖示
                icon: "warning",
                //是否啟用取消按鈕
                showCancelButton: true,
                //確認按鈕顏色
                confirmButtonColor: "#3085d6",
                //確認按鈕文字
                confirmButtonText: "刪除",
                //取消按鈕顏色
                cancelButtonColor: "#d33",
                //取消按鈕文字
                cancelButtonText: "取消",
            }).then(function (result) {   

                console.log(JSON.stringify(result));
                if (result.value) { 
                    deleteUserInfo(id);
                }
                else {
                    //Swal.fire("您選擇了Cancel");
                }
            });
        })      

        $(".GetListData").on("click", () => {
            alert(`GetListData`); 
            location.href = `${PageScope.Url.GetList}`;
        })

        $(".GetData").on("click", () => {
            alert(`GetData`);
            location.href = `${PageScope.Url.GetAsync}?id=1`;
        })

        $(".AjaxTemplate").on("click", () => {
            alert(`AjaxTemplate`);
            location.href = `${PageScope.Url.AjaxTemplateIndex}`;
        })

        $(".BaseTemplate").on("click", () => {
            location.href = `${PageScope.Url.BaseTableIndex}`;
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
                    confirmHref("刪除成功",null);
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