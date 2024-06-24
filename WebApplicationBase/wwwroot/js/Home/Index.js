(function ($) { // $(document).ready(function() { ... });  =   $(function () { .... });
    
    $(function () {
        $(".text-center").on("click", () => {
            alert(`Go`);
            alert(`PageScope.Url.GetAsyncUrl = ${PageScope.Url.GetAsyncUrl}`);
        })

        $(".get").on("click", function () {       
            get();
        })

        $(".post").on("click", function () {
        
            post();
        })

    });

    //Ajax-Get
    let get = function () {
        $.ajax({
            url: PageScope.Url.GetListUrl,
            type: "Get",//Get,Post
            dataType: "Json",
            success: function (response) {
                alert("success");
            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);
            }
        });
    }

    //Ajax-Post
    let post = function () {
        $.ajax({
            url: PageScope.Url.GetAsyncUrl,
            type: "Post",//Get,Post
            dataType: "Json",
            data: { id: 1 },
            success: function (response) {           
                alert("success");
            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);
            }
        });
    }


    //寫法1
    //$(function () {
    //    $(".text-center").on("click", () => {
    //        alert(`Go`);
    //    })
    //});

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

