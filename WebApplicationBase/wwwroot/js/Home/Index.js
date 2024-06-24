(function ($) { // $(document).ready(function() { ... });  =   $(function () { .... });
    
    $(function () {

        $(".text-center").on("click", () => {
            //alert(`Go`);         
        })

        $(".get").on("click", function () {       
            get();       
        })
        $(".post").on("click", function () {        
            post();     
        })

        $(".getParameter").on("click", function () {
            getParameter();
        })
        $(".postParameter").on("click", function () {
            postParameter();
        })
    });



    //Ajax-Get
    let get = function () {
        alert(`PageScope.Url.GetAsyncUrl = ${PageScope.Url.GetHttpGet}`);
        $.ajax({
            url: PageScope.Url.GetHttpGet,
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
        alert(`PageScope.Url.GetAsyncUrl = ${PageScope.Url.GetHttpPost}`);
        $.ajax({
            url: PageScope.Url.GetHttpPost,
            type: "Post",//Get,Post
            dataType: "Json",
            success: function (response) {           
                alert("success");
            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);
            }
        });
    }


    //Ajax-GetParameter
    let getParameter = function () {
        alert(`PageScope.Url.GetHttpGetParameter = ${PageScope.Url.GetHttpGetParameter}`);
        $.ajax({
            url: PageScope.Url.GetHttpGetParameter,
            type: "Get",//Get,Post
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

    //Ajax-PostParameter
    let postParameter = function () {
        alert(`PageScope.Url.GetHttpPostParameter = ${PageScope.Url.GetHttpPostParameter}`);
        $.ajax({
            url: PageScope.Url.GetHttpPostParameter,
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

