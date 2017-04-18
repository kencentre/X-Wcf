// 图片和视频弹出框预览

var preview = {
	show: function (options) {
		var opts = $.extend({
			type: 0,		// 0:图片，1视频
			startindex: 0,	// 初始化选中第几张图片，type=0时有效
			imagesArr: [],
			vedioData: {
				
			}
		}, options || {});
		
		this.render(opts);
	},
	getImageHtml: function (data, startindex) {
		var sHtml = '<div class="img_preview">';
		sHtml += '	<ul>';
		for (var i = 0, l = data.length; i < l; i++) {
			var d = data[i];
			
			sHtml += '<li>';
			sHtml += '	<img src="'+ d.src +'"/>';
			
			if (d.desc) {
				sHtml += '	<p class="desc">'+ d.desc +'</p>';
			}
			
			sHtml += '</li>';
		}
		
		sHtml += '	</ul>';
		
		if (data.length > 0) {
			sHtml += '	<span class="img_btn img_prev"></span>';
			sHtml += '	<span class="img_btn img_next"></span>';
		}
		
		sHtml += '</div>';
		
		return sHtml;
	},
	bindImgEvent: function(data, startindex) {
		var $imglist = $('.img_preview ul'),
			currentPage = startindex + 1,
			totalPage = data.length,
			boxWidth = $('li', $imglist).outerWidth(),
			$prev = $('.img_prev'),
			$next = $('.img_next');
			
		$imglist.width(totalPage * boxWidth);
		
		// 设置翻页箭头样式
		setArrowStyle(currentPage);
		
		$prev.click(function() {
			if (currentPage > 1) {
				currentPage--;
				
				$imglist.stop().animate({
					marginLeft: -1 * (currentPage - 1) * boxWidth
				});
				
				// 设置翻页箭头样式
				setArrowStyle(currentPage);
			}
		});
		
		$next.click(function() {
			if (currentPage < totalPage) {
				currentPage++;
				
				$imglist.stop().animate({
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
				$next.removeClass('current');
			} else {
				$next.addClass('current');
			}
		}
	},
	getVedioHtml: function (data) {
		var vedioSrc = data.src,
			vID = vedioSrc.split('/v_show/id_')[1],
			vID = vID.split('==')[0];
		
		var sHtml = '<div class="vedio_preview">';
		sHtml += '	<img src="images/loading.gif" />';
		sHtml += '	<iframe height="100%" width="100%" src="http://player.youku.com/embed/'+ vID +'" frameborder=0 allowfullscreen></iframe>';
		sHtml += '</div>';
		return sHtml;
	},
	render: function (opts, type) {
		var sHtml = '';
		sHtml += '<div class="window">';
		sHtml += '  <div class="window_title"><i class="window_close"></i></div>';
		sHtml += '	<div class="window_body">';
		
		if (opts.type == 0) {
			sHtml += this.getImageHtml(opts.imagesArr, opts.startindex);
		} else {
			sHtml += this.getVedioHtml(opts.vedioData);
		}
		
		sHtml += '	</div>';
		sHtml += '</div>';
		
		var $mask = $('<div class="window_mask"></div>');
		var $window = $(sHtml);
		
		$mask.appendTo($('body'));
		$window.appendTo($('body'));
		
		// 绑定事件
		// 点击关闭
		$('.window_close', $window).click(function() {
			$mask.remove();
			$window.remove();
		});
		
		if (opts.type == 0) {
			// 初始化显示第几张图片
			var $imglist = $('.img_preview ul'),
				boxWidth = $('li', $imglist).outerWidth(),
				windowHeight = $(window).height();
			
			$imglist.css({
				marginLeft: -1 * opts.startindex * boxWidth
			});
			
			// 设置图片居中显示
			$('img', $imglist).each(function() {
				var imgHeight = $(this).outerHeight();
				
				$(this).css({
					marginTop: (windowHeight - imgHeight) / 2 - 55
				});
			});
			
			// 设置翻页事件
			this.bindImgEvent(opts.imagesArr, opts.startindex);
		} else {
			// 隐藏加载中
			$('.vedio_preview iframe').load(function() {
				$('.vedio_preview img').hide();
			});
		}
	}
};

$.extend({
	preview: preview
});
