(function ($) {
    $(function () {
  
        let pageIndex = Number(`${PageScope.Page.PageIndex}`);
        let pagesTotal = Number(`${PageScope.Page.PagesTotal}`);

        let pages = pageTemplate(pageIndex, pagesTotal);

        $("#page").append(pages);
        $(".btnPage").addClass("btn btn-link");

        $(".selectGoToPage").addClass("form-select form-select-sm-3");
        $(".selectGoToPage").on("change", function () {
            goToPage();
        })

        $(".btnPrev").on("click", function () {
            btnPrev(pageIndex);
        })

        $(".btnNext").on("click", function () {
            btnNext(pageIndex);
        })

    });   


    let clearSearch = function () {

    }

    let goToPage = function () {
        let selectGoToPage = $(".selectGoToPage option:selected").val();
        $("#PageNumber").val(Number(selectGoToPage));
        $("#form_search").get(0).submit();
    }

    let btnPrev = function (pageIndex) {

        $("#PageNumber").val(Number(pageIndex) - 1); 
        $("#form_search").get(0).submit();

    }
    
    let btnNext = function (pageIndex) {

        $("#PageNumber").val(Number(pageIndex) + 1);
        $("#form_search").get(0).submit();

    }

    let changePageSize = function ()
    {
        $("#form_search").get(0).submit();
    }

    let pageTemplate = function (pageIndex, pagesTotal) {

        let template = "";

        let pageNumber =
        `
            ${pagesTotal < pageIndex ? `0` : `${pageIndex}/${pagesTotal}`}
        `;

        //上一頁是否顯示
        let prevDisabled =
        `
            ${pageIndex == 1 ? `disabled` : ``}
        `;
        //下一頁是否顯示
        let nextDisabled =
        `
            ${pageIndex == pagesTotal ? `disabled` : ``}
        `;

        template +=
        `
        <input type="hidden" id="PageNumber" name="PageNumber"/>
        <div class="mx-auto">
            第<span> ${pageNumber}</span >頁，
            共<span>${pagesTotal}</span> 頁，
            <a class="btnPage btnPrev ${prevDisabled} "> 上一頁 </a>｜跳至第
            <select class="selectGoToPage">
        `;
        for (var pages = 1; pages <= pagesTotal; pages++) {
            template +=
            `
                <option value="${pages}" ${pageIndex == pages ? `selected="selected"` : ``}>${pages}</option>
            `;
        }
        template +=
        `
            </select>
            頁｜
            <a  class="btnPage btnNext ${nextDisabled} ">下一頁</a>
        </div >
        `;

        return template;

    }

})(jQuery);