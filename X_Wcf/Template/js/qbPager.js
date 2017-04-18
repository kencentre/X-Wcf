
jQuery.fn.Pager = function (totalPage, opts) {
    opts = jQuery.extend({
        pageSize: 10,
        length: 6,
        currentPageIndex: 1,
        StartAndEndLength: 1,
        link: "javascript:void(0);",
        prev_text: "<",
        next_text: ">",
        goToPage: false,
        ellipse_text: "...",
        prev_show_always: true,
        next_show_always: true,
        callback: function () { return false; }
    }, opts || {});

    return this.each(function () {
        function numPages() {
            //return Math.ceil(totalPage/opts.items_per_page);
            return (!totalPage || totalPage < 0) ? 1 : totalPage;
        }
        function getInterval() {
            var ne_half = Math.ceil(opts.length / 2);
            var np = numPages();
            var upper_limit = np - opts.length;
            var start = currentPageIndex > ne_half ? Math.max(Math.min(parseInt(currentPageIndex) - parseInt(ne_half), upper_limit), 0) : 0;
            var end = currentPageIndex > ne_half ? Math.min(parseInt(currentPageIndex) + parseInt(ne_half), np) : Math.min(opts.length, np);
            return [start, end];
        }
        function pageSelected(page_id, evt) {
            currentPageIndex = page_id;
            drawLinks();
            var continuePropagation = opts.callback(page_id,opts.pageSize, panel);
            if (!continuePropagation) {
                if (evt.stopPropagation) {
                    evt.stopPropagation();
                }
                else {
                    evt.cancelBubble = true;
                }
            }
            return continuePropagation;
        }

        /**
        * This function inserts the pagination links into the container element
        */
        function drawLinks() {
            panel.empty();
            var interval = getInterval();
            var np = numPages();
            var getClickHandler = function (page_id) {
                return function (evt) { return pageSelected(page_id, evt); }
            }
            var appendItem = function (page_id, appendopts) {
                page_id = page_id < 1 ? 1 : (page_id < np ? page_id : np); // Normalize page id to sane value
                appendopts = jQuery.extend({ text: page_id, classes: "" }, appendopts || {});
                if (page_id == currentPageIndex) {
                    var lnk = jQuery("<span class='current'>" + (appendopts.text) + "</span>");
                }
                else {
                    var lnk = jQuery("<a>" + (appendopts.text) + "</a>")
						.bind("click", getClickHandler(page_id))
						.attr('href', opts.link.replace(/_id_/, page_id));


                }
                if (appendopts.classes) { lnk.addClass(appendopts.classes); }
                panel.append(lnk);
            }

            if (opts.prev_text && (currentPageIndex > 1 || opts.prev_show_always)) {
                appendItem(currentPageIndex - 1, { text: opts.prev_text, classes: "prev" });
            }

            if (interval[0] > 0 && opts.StartAndEndLength > 0) {
                var end = Math.min(opts.StartAndEndLength, interval[0]);
                for (var i = 0; i < end; i++) {
                    appendItem(i + 1);
                }
                if (opts.StartAndEndLength < interval[0] && opts.ellipse_text) {
                    jQuery("<span>" + opts.ellipse_text + "</span>").appendTo(panel);
                }
            }

            for (var i = interval[0]; i < interval[1]; i++) {
                appendItem(i + 1);
            }

            if (interval[1] < np && opts.StartAndEndLength > 0) {
                if (np - opts.StartAndEndLength > interval[1] && opts.ellipse_text) {
                    jQuery("<span>" + opts.ellipse_text + "</span>").appendTo(panel);
                }
                var begin = Math.max(np - opts.StartAndEndLength, interval[1]);
                for (var i = begin; i < np; i++) {
                    appendItem(i + 1);
                }

            }

            if (opts.next_text && (currentPageIndex < np || opts.next_show_always)) {

                appendItem(currentPageIndex + 1, { text: opts.next_text, classes: "next" });
            }

            if (opts.goToPage) {
                var np = numPages();
                var goToPage = jQuery("<input type='text' class='text' class='pager_gotoNum' />");
                panel.append(goToPage);
                var gotoPageButton = jQuery("<input type='button' class='gotoBtn' value='GO'>").attr("class","pager_button").bind("click", function (event) {
                    event.preventDefault();
//                    var value = $("#pager_gotoNum").val().match(/^[1-9]\d*$/);
//                    var value = $("#pager_gotoNum").val();
//                    var value = Number($(this).prev().val());
                    var value = $(this).prev().val().match(/^\d*$/);
                    if (value == null || value == "undefined"  || value == "") {
                    	$(this).prev().val("");
                        return;
                    }
                    
                    if(value > np){
                    	value = np;
                    }else if(value < 1){
                    	value = 1;
                    }

                    pageSelected(value, event);
                });

                panel.append(gotoPageButton);
            }
        }

        var currentPageIndex = opts.currentPageIndex;
        opts.pageSize = (!opts.pageSize || opts.pageSize < 0) ? 1 : opts.pageSize;
        var panel = jQuery(this);
        drawLinks();
        // call callback function
        // opts.callback(currentPageIndex, this);
    });
}


