(function ($) {
    $(function () {


        //動態新增
        $(".btnDynamicAdd").on("click", () => {
            dynamicView();
        })

        //資料送出 動態欄位重新定義容器中物件的name
        $(".btnCeate").on("click", () => {
            //dynamicResetObjectAttributes("#DynamicView .DynamicID", "name", "DynamicID");
            //dynamicResetObjectAttributes("#DynamicView .DynamicAddress", "name", "Address");
        })



        //$(".btnCeate").on("click", () => {

            //dynamicResetObjectAttributes("#DynamicView .DynamicAddress", "name", "Address");
            //寫法1(方法)
            //let $dynamicView = $("#DynamicView");
            //dynamicResetName($dynamicView.find(".DynamicAddress"), "Address");
            //dynamicResetName("#DynamicView .DynamicAddress", "Address");

            //寫法2
            //let $dynamicView = $("#DynamicView");
            //$dynamicView.find(".DynamicAddress").each(function (index) {
            //    $(this).attr("name", `ListDynamicData[${index}].Address`);
            //});

            //寫法3(抓種別)
            //$("#DynamicView .DynamicAddress").each(function (index) {
            //    $(this).attr("name", `ListDynamicData[${index}].Address`);
            //});

            //寫法4(抓種類)
            //$("#DynamicView input").each(function (index) {
            //    $(this).attr("name", `ListDynamicData[${index}].Address`);
            //});
        //})

        $(".btnUpdate").on("click", function () {
            Swal.fire({
                //標頭
                title: `資料送出`,
                showCancelButton: false,
            }).then(function (result) {
                let $form = $("#postform");
                $form.get(0).submit();
            });
        })
        
        //動態新增
        let dynamicView = function () {
            var result = null; // 初始化回傳值
            $.ajax({
                url: PageScope.Url.Dynamic,
                //發送格式:GET,POST
                type: "GET",
                dataType: "html",
                success: function (response) {
                    //console.log("get-response: " + JSON.stringify(response));
                    //alert("Success");

                    $("#DynamicView").append(response);
                    //result = response;
                },
                error: function (xhr, status, error) {
                    console.log("Error: " + error);
                    alert("Error");
                }
            });

            return result;

        }

        //dynamicView:容器
        //objectName:容器中要改name的物件名稱
        let dynamicResetName = function (dynamicView, objectName) {
            $(dynamicView).each(function (index, value) {
                $(this).attr("name", `ListDynamicData[${index}].${objectName}`);
            });
        }

        //dynamicView:容器
        //modifyAttributes:修改屬性
        //objectName:重新定義容器中物件的name
        let dynamicResetObjectAttributes = function (dynamicView, modifyAttributes, objectName) {
            $(dynamicView).each(function (index, value) {
                $(this).attr(modifyAttributes, `ListDynamicData[${index}].${objectName}`);
            });
        }

    });    
})(jQuery);