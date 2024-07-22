(function ($) {
    
    $(function () {

        //$(".btnModalClose").on("click", function () {
        //    alert("btnModalClose");
        //    close();
        //})

        $(".btnCreate").on("click", function () {
            create();
        })        

        $(".btnEdit").on("click", function (){
            let btnValue = $(this).attr("value");
            //location.href = `${PageScope.Url.Update}?id=${id}`;
            update(btnValue);
        })

        $(".btnDelete").on("click", function () {
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
                
                if (result.value) {
                    deleteUserInfo(btnValue);
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

    

    //btnModalClose
    let close = function () {       
        //$("#productInfoModal").html("");
        $("#productInfoModal").remove();
    }


    let create = function () {
        $.ajax({
            url: PageScope.Url.Create,
            //發送格式:GET,POST
            type: "GET",
            dataType: "html",
            success: function (response) {
                $("#modalScope").html(response);
                $('#modalTemplate').modal("show");             
            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);
                alert("Error");
            }
        });

    }

    let update = function (id) {
    
        $.ajax({
            url: `${PageScope.Url.Update}?id=${id}`,
            //發送格式:GET,POST
            type: "GET",
            dataType: "html",
            success: function (response) {
                $("#modalScope").html(response);
                $('#modalTemplate').modal("show");
            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);
                alert("Error");
            }
        });
    }
    //data: JSON.stringify({ id: "1" }),

    let deleteUserInfo = (btnValue) => {
        $.ajax({
            url: PageScope.Url.Delete,
            type: "POST",
            contentType: "application/x-www-form-urlencoded",
            dataType: "json",
            data: { id: btnValue },
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