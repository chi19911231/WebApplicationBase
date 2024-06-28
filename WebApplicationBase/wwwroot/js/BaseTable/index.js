(function ($) {
    $(function () {

        $(".deleteBtn").on("click", function () {

            //attr:屬性(attr)：這些是更靜態的，表示元素初始加載時的狀態。
            //prop:屬性(prop)：這些是更動態的，並且可以隨著用戶與頁面的交互而改變。例如，複選框的 checked 屬性在用戶選中或取消選中時會改變。   
            let btnValue = $(this).attr("value");

            deleteModel(btnValue);

        })   

    });

    let deleteModel = function (id) {
        
        //alert(`id=${id}`);
        //console.log(`id=${id}`);
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
            data: {id: id }, // 正確地將數據序列化為JSON對象
            success: function (response) {
                console.log("postParameterJson-response: " + JSON.stringify(response));
                alert(JSON.stringify(response));

                location.href = PageScope.Url.Index;

            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);
                alert("Error");
            }
        });
    }


    

})(jQuery);