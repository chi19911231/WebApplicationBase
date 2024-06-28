(function ($) {     
    $(function () {
        
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

        $(".getObject").on("click", function () {
            getObject();
        })
        $(".postObject").on("click", function () {
            postObject();
        })     


        $(".getJson").on("click", function () {            
            getJson();
        })
        $(".postJson").on("click", function () {      
            postJson();
        })

        $(".getParameterJson").on("click", function () {
            getParameterJson();
        })

        $(".postParameterJson").on("click", function () {
            postParameterJson();
        })

        $(".getObjectJson").on("click", function () {
            getObjectJson();
        })
        $(".postObjectJson").on("click", function () {
            postObjectJson();
        })

    });
        

    //Ajax-Get
    //傳送格式:無
    //接收格式:PartialView
    let get = function () {

        alert(`get-PageScope.Url.GetHttpGet = ${PageScope.Url.HttpGet}`);

        $.ajax({
            url: PageScope.Url.HttpGet,
            //發送格式:GET,POST
            type: "GET",
            success: function (response) {
                console.log("get-response: " + JSON.stringify(response));
                alert("Success");
            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);
                alert("Error");
            }
        });
    }

    //Ajax-Post
    //傳送格式:無
    //接收格式:PartialView
    let post = function () {

        alert(`post-PageScope.Url.HttpPost = ${PageScope.Url.HttpPost}`);

        $.ajax({
            url: PageScope.Url.HttpPost,
            //發送格式:GET,POST
            type: "POST",
            success: function (response) {      
                console.log("post-response: " + JSON.stringify(response));
                alert("Success");
            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);
                alert("Error");
            }
        });
    }        

    //Ajax-GetParameter
    //傳送格式:簡單繫節
    //接收格式:PartialView
    let getParameter = function () {

        alert(`getParameter-PageScope.Url.HttpGetParameter = ${PageScope.Url.HttpGetParameter}?id=${id = 1}`);

        $.ajax({
            url: `${PageScope.Url.HttpGetParameter}?id=${id = 1}`,
            //發送格式:GET,POST
            type: "GET",          
            //Server端傳送Clinet端的資料格式
            //接收格式
            //html:接收html格式
            //json:接收json格式
            dataType: "html",    
            success: function (response) {
                console.log("getParameter-response: " + JSON.stringify(response));
                alert("Success");
            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);
                alert("Error");
            }
        });
    }

    //Ajax-PostParameter
    //傳送格式:簡單繫節
    //接收格式:PartialView
    let postParameter = function () {

        alert(`postParameter-PageScope.Url.HttpPostParameter = ${PageScope.Url.HttpPostParameter}`);

        $.ajax({
            url: PageScope.Url.HttpPostParameter,
            //發送格式:GET,POST
            type: "POST",
            //Clinet端傳送Server端的資料格式    
            //傳送格式
            //application/x-www-form-urlencoded：上傳html表單
            //application/json:上傳Json格式     
            //multipart/form-data:上傳檔案、圖片
            //dataType: "html",//Server端傳送Clinet端的資料格式
            contentType: "application/x-www-form-urlencoded",     
            //接收格式
            //html:接收html格式
            //json:接收json格式
            data: {id : 1 },
            success: function (response) {
                console.log("postParameter-response: " + JSON.stringify(response));
                alert("Success");
            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);
                alert("Error");
            }
        });
    }
    
    //Ajax-GetParameter
    //傳送格式:複雜繫節
    //接收格式:PartialView
    let getObject = function () {
    
        let model = {
            Id: 1,
            Message: "Message1",
        }       

        alert(`PageScope.Url.HttpGetObject = ${PageScope.Url.HttpGetObject}?Id=${model.Id}&Message=${model.Message}`);

        $.ajax({
            url: `${PageScope.Url.HttpGetObject}?Id=${model.Id}&Message=${model.Message}`,
            //發送格式:GET,POST
            type: "GET",
            //Clinet端傳送Server端的資料格式
            //傳送格式:
            //application/x-www-form-urlencoded：上傳html表單
            //application/json(上傳Json格式)           
            //multipart/form-data:上傳檔案、圖片
            contentType: "application/json", 
            //Server端傳送Clinet端的資料格式
            //接收格式
            //html:接收html格式
            //json:接收json格式
            dataType: "html",    
            success: function (response) {
                console.log("getObject-response: " + JSON.stringify(response));
                alert("Success");
            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);
            }
        });
    }

    //Ajax-PostParameter
    //傳送格式:複雜繫節
    //接收格式:PartialView
    let postObject = function () {

        alert(`PageScope.Url.HttpPostObjectJson = ${PageScope.Url.HttpPostObject}`);

        let obj = new Object();
        obj.data1 = "資料1";
        obj.data2 = "資料2";

        //JavaScript物件
        let model = {
            Id: 1,
            Message: "Message1",
            Data: obj,
        }    

        $.ajax({
            url: PageScope.Url.HttpPostObject,
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
            dataType: "html",
            
            data: JSON.stringify(model),
            success: function (response) {
                console.log("postObject-response: " + JSON.stringify(response));
                alert("Success");
            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);
            }
        });
    }


    //Ajax-GetJson
    //傳送格式:無
    //接收格式:Json
    let getJson = function () {

        alert(`getJson-PageScope.Url.HttpGetJson = ${PageScope.Url.HttpGetJson}`);

        $.ajax({
            url: PageScope.Url.HttpGetJson,
            type: "GET",//GET,POST
            //Server端傳送Clinet端的資料格式
            //接收格式
            //html:接收html格式
            //json:接收json格式
            dataType: "Json",       
            success: function (response) {
                console.log("getJson-response: " + JSON.stringify(response));
                alert("Success");
            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);
                alert("Error");
            }
        });
    }

    //Ajax-PostJson
    //傳送格式:無
    //接收格式:Json
    let postJson = function () {

        alert(`postJson-PageScope.Url.HttpGetJson = ${PageScope.Url.HttpPostJson}`);

        $.ajax({
            url: PageScope.Url.HttpPostJson,
            type: "POST",//GET,POST
            dataType: "Json",//Server端傳送Clinet端的資料格式
            //接收格式
            //html:接收html格式
            //json:接收json格式
            success: function (response) {
                console.log("postJson-response: " + JSON.stringify(response));           
                alert("Success");
            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);
                alert("Error");
            }
        });
    }

    //Ajax-GetParameterJson
    //傳送格式:簡單繫節
    //接收格式:Json
    let getParameterJson = function () {

        alert(`getParameterJson-PageScope.Url.HttpGetParameterJson = ${PageScope.Url.HttpGetParameterJson}?id=${1}`);

        $.ajax({
            url: PageScope.Url.HttpGetParameterJson,
            //發送格式:GET,POST
            type: "GET",
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
            dataType: "Json",               
            success: function (response) {
                console.log("getParameterJson-response: " + JSON.stringify(response));
                alert("Success");
            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);
                alert("Error");
            }
        });
    }
 
    //Ajax-PostParameterJson
    //傳送格式:簡單繫節
    //接收格式:Json
    let postParameterJson = function () {

        alert(`postParameterJson-PageScope.Url.HttpPostParameterJson = ${PageScope.Url.HttpPostParameterJson}`);

        $.ajax({
            url: PageScope.Url.HttpPostParameterJson,
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
            data: JSON.stringify({ id: "1" }), // 將 JavaScript 對象轉換為 JSON 字符串
            success: function (response) {
                console.log("postParameterJson-response: " + JSON.stringify(response));
                alert("Success");
            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);
                alert("Error");
            }
        });
    }

    //Ajax-GetObjectJson
    //傳送格式:複雜繫節
    //接收格式:Json
    let getObjectJson = function () {        

        //JavaScript物件
        let model = {
            Id: 1,
            Message: "Message1",            
        }       

        alert(`getObjectJson-PageScope.Url.HttpGetObjectJson = ${PageScope.Url.HttpGetObjectJson}?id=${model.Id}&Message=${model.Message}`);

        $.ajax({
            url: PageScope.Url.HttpGetObjectJson,
            //發送格式:GET,POST
            type: "GET",
            contentType: "application/json", //Clinet端傳送Server端的資料格式
            //傳送格式
            //application/json:上傳Json格式
            //application/x-www-form-urlencoded：上傳html表單
            //multipart/form-data:上傳檔案、圖片
            dataType: "json",//Server端傳送Clinet端的資料格式
            //接收格式
            //html:接收html格式
            //json:接收json格式
            data: model,
            success: function (response) {
                console.log("getObjectJson-response: " + JSON.stringify(response));
                alert("Success");
            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);
            }
        });
    }

    //Ajax-PostObjectJson
    //傳送格式:複雜繫節
    //接收格式:Json
    let postObjectJson = function () {

        alert(`postObjectJson-PageScope.Url.HttpPostObjectJson = ${PageScope.Url.HttpPostObjectJson}`);

        let obj = new Object();
        obj.data1 = "資料1";
        obj.data2 = "資料2";

        //JavaScript物件
        let model = {
            Id: 1,
            Message: "Message1",
            Data: obj,           
        }

        $.ajax({
            url: PageScope.Url.HttpPostObjectJson,
            //發送格式:GET,POST
            type: "POST",
            //Clinet端傳送Server端的資料格式
            //傳送格式
            //application/json:上傳Json格式
            //application/x-www-form-urlencoded：上傳html表單
            //multipart/form-data:上傳檔案、圖片
            contentType: "application/json;",            
            //Server端傳送Clinet端的資料格式
            //接收格式
            //html:接收html格式
            //json:接收json格式
            dataType: "Json",      
            data: JSON.stringify(model),
            success: function (response) {
                console.log("postObjectJson-response: " + JSON.stringify(response));

                alert("Success");
            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);
            }
        });
    }
   
    //html載入完成後執行JavaScript
    ////寫法1
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

    ////舊寫法
    //$(document).ready(function () {
    //    ...
    //});

    //JavaScript物件相關
    //let obj = new Object();
    //obj.data1 = "資料1";
    //obj.data2 = "資料2";
    //寫法1
    //let model = {
    //    Id: 1,
    //    Message:"Message1" ,
    //    Data: obj,
    //    getDataFunction: function () {
    //        console.log(`getDataFunction : ${this.Data}`);
    //    }
    //}

    //寫法2
    //let model = {};
    //    data.Id= 1,
    //    data.Message= "Message1",
    //    data.Data= obj
    //    data.getDataFunction= function () {
    //    console.log(`getDataFunction : ${this.Data}`);
    //}


})(jQuery);