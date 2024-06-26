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
        alert(`PageScope.Url.GetHttpGet = ${PageScope.Url.GetHttpGet}`);
        $.ajax({
            url: PageScope.Url.GetHttpGet,
            //發送格式:GET,POST
            type: "GET",
            success: function (response) {
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
        alert(`PageScope.Url.GetHttpPost = ${PageScope.Url.GetHttpPost}`);
        $.ajax({
            url: PageScope.Url.GetHttpPost,
            //發送格式:GET,POST
            type: "POST",
            success: function (response) {           
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
        alert(`PageScope.Url.GetHttpGetParameter = ${PageScope.Url.GetHttpGetParameter}?id=${id=1}`);
        $.ajax({
            url: `${PageScope.Url.GetHttpGetParameter}?id=${id = 1}`,
            //發送格式:GET,POST
            type: "GET",
            //Clinet端傳送Server端的資料格式
            //傳送格式
            //application/json:上傳Json格式
            //application/x-www-form-urlencoded：上傳html表單
            //multipart/form-data:上傳檔案、圖片
            contentType: "application/json", 
            //Server端傳送Clinet端的資料格式
            //接收格式
            //Html:接收html格式
            //Json:接收Json格式
            dataType: "Html",
          
            success: function (response) {
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
        alert(`PageScope.Url.GetHttpPostParameter = ${PageScope.Url.GetHttpPostParameter}`);
        $.ajax({
            url: PageScope.Url.GetHttpPostParameter,
            //發送格式:GET,POST
            type: "POST",
            contentType: "application/json", //Clinet端傳送Server端的資料格式
            //傳送格式
            //application/json:上傳Json格式
            //application/x-www-form-urlencoded：上傳html表單
            //multipart/form-data:上傳檔案、圖片
            dataType: "Html",//Server端傳送Clinet端的資料格式
            //接收格式
            //Html:接收html格式
            //Json:接收Json格式
            data: { id: 1 },
            success: function (response) {
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

        //JavaScript物件
        let model = {
            Id: 1,
            Message: "Message1",
        }

        //寫法1
        //let model = {
        //    Id: 1,
        //    Message:"Message1" ,
        //    Data:"Data"
        //    getDataFunction: function () {
        //        console.log(`getDataFunction : ${this.Data}`);
        //    }
        //}

        //寫法2
        //let model = {};
        //data.Id= 1,
        //data.Message= "Message1",
        //data.Data= "Data"
        //data.getDataFunction= function () {
        //    console.log(`getDataFunction : ${this.Data}`);
        //}

        alert(`PageScope.Url.GetHttpGetObjectJson = ${PageScope.Url.GetHttpGetObject}?id=${model.Id}&Message=${model.Message}`);
        $.ajax({
            url: PageScope.Url.GetHttpGetObject,
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
            //Html:接收html格式
            //Json:接收Json格式
            dataType: "Html",    
            success: function (response) {
                console.log("response: " + JSON.stringify(response));
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
        alert(`PageScope.Url.GetHttpPostObjectJson = ${PageScope.Url.GetHttpPostObject}`);

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
            url: PageScope.Url.GetHttpPostObject,
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
            //Html:接收html格式
            //Json:接收Json格式
            dataType: "Html",
            
            data: JSON.stringify(model),
            success: function (response) {
                console.log("response: " + JSON.stringify(response));
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

        alert(`PageScope.Url.GetHttpGetJson = ${PageScope.Url.GetHttpGetJson}`);
        $.ajax({
            url: PageScope.Url.GetHttpGetJson,
            type: "GET",//GET,POST
            //Server端傳送Clinet端的資料格式
            //接收格式
            //Html:接收html格式
            //Json:接收Json格式
            dataType: "Json",       
            success: function (response) {
                console.log("response: " + JSON.stringify(response));
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
        alert(`PageScope.Url.GetHttpGetJson = ${PageScope.Url.GetHttpPostJson}`);
        $.ajax({
            url: PageScope.Url.GetHttpPostJson,
            type: "POST",//GET,POST
            dataType: "Json",//Server端傳送Clinet端的資料格式
            //接收格式
            //Html:接收html格式
            //Json:接收Json格式
            success: function (response) {
                console.log("response: " + JSON.stringify(response));           
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
        alert(`PageScope.Url.GetHttpGetParameterJson = ${PageScope.Url.GetHttpGetParameterJson}?id=${1}`);
        $.ajax({
            url: PageScope.Url.GetHttpGetParameterJson,
            //發送格式:GET,POST
            type: "GET",
            //Clinet端傳送Server端的資料格式
            //傳送格式
            //application/json:上傳Json格式
            //application/x-www-form-urlencoded：上傳html表單
            //multipart/form-data:上傳檔案、圖片
            contentType: "application/json", 
            //Server端傳送Clinet端的資料格式
            //接收格式
            //Html:接收html格式
            //Json:接收Json格式  
            dataType: "Json",               
            success: function (response) {
                console.log("response: " + JSON.stringify(response));
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
        alert(`PageScope.Url.GetHttpPostParameterJson = ${PageScope.Url.GetHttpPostParameterJson}`);
        $.ajax({
            url: PageScope.Url.GetHttpPostParameterJson,
            //發送格式:GET,POST
            type: "POST",
            //Clinet端傳送Server端的資料格式
            //傳送格式
            //application/json:上傳Json格式
            //application/x-www-form-urlencoded：上傳html表單
            //multipart/form-data:上傳檔案、圖片
            contentType: "application/json",
            //Server端傳送Clinet端的資料格式
            //接收格式
            //Html:接收html格式
            //Json:接收Json格式  
            dataType: "Json",               
            data: { id: "1" }, // 將 JavaScript 對象轉換為 JSON 字符串
            success: function (response) {
                console.log("response: " + JSON.stringify(response));
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

        alert(`PageScope.Url.GetHttpGetObjectJson = ${PageScope.Url.GetHttpGetObjectJson}?id=${model.Id}&Message=${model.Message}`);
        $.ajax({
            url: PageScope.Url.GetHttpGetObjectJson,
            //發送格式:GET,POST
            type: "GET",
            contentType: "application/json", //Clinet端傳送Server端的資料格式
            //傳送格式
            //application/json:上傳Json格式
            //application/x-www-form-urlencoded：上傳html表單
            //multipart/form-data:上傳檔案、圖片
            dataType: "json",//Server端傳送Clinet端的資料格式
            //接收格式
            //Html:接收html格式
            //Json:接收Json格式
            data: model,
            success: function (response) {
                console.log("response: " + JSON.stringify(response));
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
        alert(`PageScope.Url.GetHttpPostObjectJson = ${PageScope.Url.GetHttpPostObjectJson}`);

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
            url: PageScope.Url.GetHttpPostObjectJson,
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
            //Html:接收html格式
            //Json:接收Json格式
            dataType: "Json",      
            data: JSON.stringify(model),
            success: function (response) {
                console.log("response: " + JSON.stringify(response));

                alert("Success");
            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);
            }
        });
    }
   
    //Html載入完成後執行JavaScript
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





