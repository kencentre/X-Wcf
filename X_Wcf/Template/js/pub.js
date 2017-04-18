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
		
		// 分页插件
		setPageList(1);
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
		
		// 图片视频页面-查看大图
		$('.jsImgPreview').click(function() {
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
		$('.jsVedioPreview').click(function() {
			// 预览图片
			$.preview.show({
				type: 1,	// 1：视频
				vedioData: {
					src: 'http://v.youku.com/v_show/id_XMjY4MzkyMDkyNA==.html?f=49396974&spm=a2hww.20023042.m_223465.5~5~5~5~5~5~A&from=y1.3-idx-beta-1519-23042.223465.1-1'
				}
			});
		});
		
		// tab切换
		$('.tab_change span').click(function() {
			$(this).addClass('current').siblings().removeClass('current');
			var index = $(this).index();
			
			$('.jsTabCont').eq(index).show().siblings('.jsTabCont').hide();
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
	function setPageList(currentPage) {
		var totalRecord = 20;
		var currentPage = currentPage;
		var pageSize = 10;
		
		// 分页事件
		if (typeof $.fn.Pager === 'function') {
			$('#qbPager').Pager(totalRecord, {
				currentPageIndex: currentPage,
			    pageSize: pageSize,
			    callback: function (pageIndex, pageSize, $panel) {
				    setPageList(pageIndex, pageSize);
			    }
			});
		}
	}
});