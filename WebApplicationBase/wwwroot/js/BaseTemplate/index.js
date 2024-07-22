(function ($) {
    $(function () {

        $(".btnCreate").on("click", () => {
            location.href = PageScope.Url.Create;
        })

        $(".btnUpdate").on("click", function () {
            let btnValue = $(this).attr("value");
            location.href = `${PageScope.Url.Update}?id=${btnValue}`;
        })

        $(".btnDelete").on("click", function () {
            //attr:網頁初始載入時的狀態
            //prop:網頁初始後改變的狀態
            let btnValue = $(this).attr("value");
            deleteModel(btnValue);
        })   

    });

    let deleteModel = function (id) {

        //SweetAlert2
        //Swal.fire({
        //    //標頭
        //    title: "是否刪除",
        //    //內容
        //    text: "是否刪除?",
        //    //圖示
        //    icon: "success",
        //});

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
                deleteBaseTable(id);
            }
            else {
                //Swal.fire("您選擇了Cancel");
            }
        });
    }

    let deleteBaseTable = (id) => {
        $.ajax({
            url: PageScope.Url.Delete,
            //發送格式:GET,POST
            type: "POST",
            //Clinet端傳送Server端的資料格式
            //傳送格式
            //application/json:上傳Json格式
            //application/x-www-form-urlencoded：上傳html表單
            //multipart/form-data:上傳檔案、圖片
            contentType: "application/x-www-form-urlencoded",
            //Server端傳送Clinet端的資料格式
            //接收格式
            //html:接收html格式
            //json:接收json格式  
            dataType: "json",
            data: { id: id },
            success: function (response) {

                console.log("postParameterJson-response: " + JSON.stringify(response));
                
                confirmHref();

            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);
                alert("Error");
            }
        });
    }

    let confirmHref = () => {
        Swal.fire({
            //標頭
            title: `刪除成功`,
            showCancelButton: false,
        }).then(function (result) {
            if (result.value) {
                location.href = PageScope.Url.Index;
            }
        });
    }
    
})(jQuery);