﻿(function ($) {
    
    $(function () {

        $(".Welcome").on("click", () => {
            alert(`Welcome`);         
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
            location.href = `${PageScope.Url.BaseTemplateIndex}`;
        })
    

    });        
   
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
    
})(jQuery);