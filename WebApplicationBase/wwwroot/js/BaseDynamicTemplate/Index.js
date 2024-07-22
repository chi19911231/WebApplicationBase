(function ($) {
    //註冊事件
    $(function () {

        //新增按鈕
        $(".btnCreate").on("click", () => {
            location.href = `${PageScope.Url.Create}`;
        })      


        //編輯按鈕
        $(".btnEdit").on("click", function (){ 
            let btnValue = $(this).attr("value");
            location.href = `${PageScope.Url.Update}?id=${btnValue}`;
        })

        //刪除按鈕
        $(".btnDelete").on("click", function(){
            let btnValue = $(this).attr("value");    
  
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
                    deleteInfo(btnValue);
                }
                else {
                    //Swal.fire("您選擇了Cancel");
                }
            });



        })


    });

    //宣告方法
    let deleteInfo = (btnValue) => {
        $.ajax({
            url: PageScope.Url.Delete,
            type: "POST",
            contentType: "application/x-www-form-urlencoded",
            dataType: "json",
            data: { id: btnValue },
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

    //
    let confirmHref = (title, text) => {
        Swal.fire({
            //標頭
            title: title,
            //內容
            text: text,
            showCancelButton: false,
        }).then(function (result) {
            location.href = PageScope.Url.Index;
            //if (result.value) {
            //    location.href = PageScope.Url.Index;
            //}
        });
    }

})(jQuery);