(function ($) {

    $(function () {
        
        $(".btnModalClose").on("click", function () {         
            closeProductInfo();
        })

        $(".btnModalSend").on("click", function () {
            sendProductInfo();

            //if ($('#modalForm').valid()) {
            //    send();
            //}

        })

        //Delete: "@Url.Action("Delete", "ProductInfo")",
        $(".btnModalDelete").on("click", function () {
            let id = $("#Id").val();
            deleteSweetAlert(id);
        })

    });

    let closeProductInfo = function () { 
        $("#modalScope").empty();
    }

    let sendProductInfo = function () {

        let formData = $('#modalForm').serializeArray(); //表單序列化
        let model = {};

        //表單序列化轉成Json格式
        $.each(formData, function (index, item) {
            model[item.name] = item.value;
        });    

        console.log(JSON.stringify(model));


        $.ajax({
            url: PageScope.Url.Update,
            //發送格式:GET,POST
            type: "POST",
            //Clinet端傳送Server端的資料格式
            //傳送格式
            //application/x-www-form-urlencoded：上傳html表單
            //application/json:上傳Json格式
            //multipart/form-data:上傳檔案、圖片
            contentType: "application/json;",
            //Server端傳送Clinet端的資料格式
            //接收格式
            //html:接收html格式
            //json:接收json格式
            dataType: "json",
            data: JSON.stringify(model),
            success: function (response) {
                if (response.status == PageScope.StatusType.Success) {
                    confirmHref("新增成功", null);
                }
                else if (response.status == PageScope.StatusType.Fail) {
                 

                    Swal.fire({
                        //標頭
                        title: "新增失敗",
                        //內容
                        text: "X",
                        showCancelButton: false,
                    }).then(function (result) {
                        //if (result.value) {
                        //    location.href = PageScope.Url.Index;
                        //}
                    });
                }
                else {

                }
            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);
            }
        });
    }   

    let deleteSweetAlert = function (id) {
        
        //SweetAlert2
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
            if (result.value) {
                //Swal.fire("您按了OK");
                deleteProductInfo(id);
            }
            else {
                //Swal.fire("您選擇了Cancel");
            }
        });
    }


    let deleteProductInfo = (id) => {
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
            location.href = PageScope.Url.Index;
            //if (result.value) {
            //    location.href = PageScope.Url.Index;
            //}
        });
    }

})(jQuery);