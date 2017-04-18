$(function() {
	// 初始化数据
	initData();
	
	// 初始化数据
	function initData () {
		// 初始化选中tab
		var tab = getHashTab(window.location.href);
		$('.jsTab[data-tab="' + tab + '"]').addClass('current').siblings('jsTab').removeClass('current');
	}
	
	// 获取hash
	function getHashTab(url) {
		if(url) {
			return url.substring(url.lastIndexOf('#') + 1, url.length);
		} else {
			return '';
		}
	}
});