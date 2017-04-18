$(function() {
	// 初始化数据
	initData();

	// 初始化绑定事件
	bindEvent();

	// 初始化数据
	function initData() {
		// 加载头部
		$('#header').load('./layout/header.html');

		// 加载底部
		$('#footer').load('./layout/footer.html');
	}

	// 初始化绑定事件
	function bindEvent() {
		// 返回顶部
		$('#gotoTop').click(function() {
			$('html, body').animate({
				scrollTop: 0
			}, 200);
		});
		
		// 切换明星导师
		$('.mentor_menu span').click(function() {
			$(this).addClass('current').siblings().removeClass('current');
			var index = $(this).index();
			
			$('.mentor_list').eq(index).show().siblings('.mentor_list').hide();
		});
		
		// 初始化切换明星学员绑定事件
		initStarStuEvent();
		
		// 了解清波，教学环境查看大图
		$('.jsPreview').click(function() {
			var index = $('.jsPreview').index($(this));
			
			// 界面上显示的图片路径
			var imagesArr = getImagesArr($('.jsPreview'));

			// 预览图片
			$.preview.show({
				type: 0,
				startindex: index,
				imagesArr: imagesArr
			});
		});
		
		
		
		// tab切换
		$('.tab_change span').click(function() {
			$(this).addClass('current').siblings().removeClass('current');
			var index = $(this).index();
			//$('.jsTabCont').eq(index).show().siblings('.jsTabCont').hide();

			var type = $(this).attr("data-type");
			//alert(type);
		    // 分页插件
			setPageList(1, type);
		});
	}
	
	// 获取对象内图片路径
	function getImagesArr($obj, type) {
		var resultArr = [];
		
		$obj.each(function () {
			if (type == 1) {
				resultArr.push({
					src: $(this).attr('src'),
					desc: $(this).parents('li').find('p a').text()
				});
			} else {
				resultArr.push({
					src: $(this).attr('src')
				});
			}
			
		});
		
		return resultArr;
	}
	
	// 初始化切换明星学员绑定事件
	function initStarStuEvent() {
		// 明星学员列表展开简介
		$('#starStuList li').mouseenter(function() {
			$(this).addClass('current').siblings().removeClass('current');
			$(this).find('p.font').stop().show(100).parent().siblings().find('p.font').hide();
		});
		
		// 切换明星学员
		var $stuboxlist = $('.stu_boxlist'),
			currentPage = 1,
			totalPage = $('.stu_boxdetail', $stuboxlist).length,
			boxWidth = $('.stu_boxdetail', $stuboxlist).outerWidth(),
			$prev = $('.jsPrev'),
			$next = $('.jsNext');
			
		$stuboxlist.width(totalPage * boxWidth);
		
		// 设置翻页箭头样式
		setArrowStyle(currentPage);
		
		$prev.click(function() {
			if (currentPage > 1) {
				currentPage--;
				
				$stuboxlist.stop().animate({
					marginLeft: -1 * (currentPage - 1) * boxWidth
				});
				
				// 设置翻页箭头样式
				setArrowStyle(currentPage);
			}
		});
		
		$next.click(function() {
			if (currentPage < totalPage) {
				currentPage++;
				
				$stuboxlist.stop().animate({
					marginLeft: -1 * (currentPage - 1) * boxWidth
				});
				
				// 设置翻页箭头样式
				setArrowStyle(currentPage);
			}
		});
		
		// 设置翻页箭头样式
		function setArrowStyle(currentPage) {
			if (currentPage == 1) {
				$prev.removeClass('current');
			} else {
				$prev.addClass('current');
			}
			
			if (currentPage == totalPage) {
				$next.removeClass('current1');
			} else {
				$next.addClass('current1');
			}
		}

	    // 切换明星导师
		var $mentor = $(".mentor_list");
		$mentor.each(function () {
		    var $mentorlist = $('ul', $(this)),
			currentPage = 1,
            totalRecord = $('li', $mentorlist).length,
			totalPage = Math.ceil(totalRecord / 4),
			boxWidth = 1200,
			$mprev = $('.jsMentorPrev'),
			$mnext = $('.jsMentorNext');

		    // 设置翻页箭头样式
		    setMentorArrowStyle(currentPage);

		    $mprev.click(function () {
		        if (currentPage > 1) {
		            currentPage--;

		            $mentorlist.stop().animate({
		                marginLeft: -1 * (currentPage - 1) * boxWidth - 80
		            });

		            // 设置翻页箭头样式
		            setMentorArrowStyle(currentPage);
		        }
		    });

		    $mnext.click(function () {
		        if (currentPage < totalPage) {
		            currentPage++;

		            $mentorlist.stop().animate({
		                marginLeft: -1 * (currentPage - 1) * boxWidth - 80
		            });

		            // 设置翻页箭头样式
		            setMentorArrowStyle(currentPage);
		        }
		    });

		    // 设置翻页箭头样式
		    function setMentorArrowStyle(currentPage) {
		        if (currentPage == 1) {
		            $mprev.removeClass('current');
		        } else {
		            $mprev.addClass('current');
		        }

		        if (currentPage == totalPage) {
		            $mnext.removeClass('current1');
		        } else {
		            $mnext.addClass('current1');
		        }
		    }
		});

	    
	}
	
	// 获取地址栏参数
	function getArguments(url) {
		if(arguments.length === 0) {
			url = window.location.href;
		}

		url = decodeURI(url);

		var argObj = {};
		var urlSplit = url.split('?');

		if(urlSplit.length > 1) {
			var args = urlSplit[1].replace('#', '&').split('&');

			for(var i = 0; i < args.length; i++) {
				var arg = args[i].split('=');
				argObj[arg[0]] = arg[1];
			}
		}

		return argObj;
	}
	
	// 分页插件
	function setPageList(currentPage, type) {
	    $.ajax({
	        type: "post",
	        url: "ajax.ashx",
	        data: "ac=GetNews&pindex=" + currentPage + "&type=" + type,
	        //{
	        //    currentPage: currentPage,
	        //    pageSize: 10,
	        //    type: type
	        //},
	        success: function (data) {
	            var totalRecord = data.total;
	            debugger;
	            var obj = jQuery.parseJSON(data);
	            var json = obj.data;
	            var applist = "";
	            for (var i = 0, l = json.length; i < l; i++) {
	                var previewClass = "";
	                if (type == 2) {
	                    previewClass = "jsImgPreview";
	                }
	                if (type == 3) {
	                    previewClass = "jsVedioPreview";
	                }
	                if (type == 0 || type == 1)
	                {
	                    
	                        applist += "<li>";
	                   
	                    applist += "<img class=\"" + previewClass + "\" src=\"../" + json[i].IMAGESHOW + "\" width=\"380\" height=\"380\" />";
	                    applist += "<p><a href=\"../" + json[i].NEWSURL + "\">" + json[i].TITLE + "</a><span>" + json[i].NEWSTEXT + "</span><span>" + json[i].CREATEDATE + "</span></p>";
	                    applist += "</li>";
	                    $(".photo_list").html(applist);
	                }
	                if (type == 2 || type == 3)
                    {
	                    applist += "<li>";
	                    applist += "<a href=\"javascript:;\"><img class=\"" + previewClass + "\" data-videoUrl='../" + json[i].VIDEOSHOW + "' src=\"../" + json[i].IMAGESHOW + "\" width=\"380\" height=\"380\" /></a>";
	                    applist += "<p><a href=\"../" + json[i].NEWSURL + "\">" + json[i].TITLE + "</a></p>";
	                    applist += "</li>";

	                    $(".photo_list").html(applist);
	                }
	            }
	            
	            //$('#qbPager').Pager(totalRecord, {
	            //    currentPageIndex: currentPage,
	            //    pageSize: 15,
	            //    callback: function (pageIndex, pageSize, $panel) {
	            //        setPageList(pageIndex);
	            //    }
	            //});

	            // 图片视频页面-查看大图
	            $('.jsImgPreview').click(function () {
	                var index = $('.jsImgPreview').index($(this));

	                // 界面上显示的图片路径和介绍
	                var imagesArr = getImagesArr($('.jsImgPreview'), 1);

	                // 预览图片
	                $.preview.show({
	                    type: 0,	// 0：图片
	                    startindex: index,
	                    imagesArr: imagesArr
	                });
	            });

	            // 图片视频页面-查看视频
	            $('.jsVedioPreview').click(function () {
	                var src = $(this).attr("data-videoUrl");
	                // 预览图片
	                $.preview.show({
	                    type: 1,	// 1：视频
	                    vedioData: {
	                        src: src
	                    }
	                });
	            });
	        }

	    });
	}
});