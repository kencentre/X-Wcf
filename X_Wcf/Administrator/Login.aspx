<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="X_Wcf.Administrator.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="res/Css/login.css" rel="stylesheet" />
    <script type="text/javascript" src="res/javascript/jquery.js"></script>
    <script type="text/javascript" src="res/javascript/jquery.cycle.all.js"></script>
    <script type="text/javascript">
        jQuery(function () {
            var sWidth = $(document).width();
            var sHeight = $(document).height();
            var mTop = sHeight / 2 - 110;
            var mLeft = sWidth / 2 - 322;
            $("#nav").css("top", mTop - 50);
            $("#loginpanel").css("top", mTop);
            $(".slideDiv").height(sHeight);
            $(function () {
                var iconImg = "res/images/login/graypoint.png"
                var iconImg_over = "res/images/login/redpoint1.png"
                $('#slideshow').cycle({
                    fx: 'fade',
                    timeout: 3000,
                    speed: 2000,
                    prev: '#crossPrev',
                    next: '#crossNext',
                    pager: '#nav',
                    pagerAnchorBuilder: pagerFactory,
                    before: function (currSlideElement, nextSlideElement, options, forwardFlag) {
                        if ($.browser.version == "6.0") {
                            DD_belatedPNG.fix('a,div,img,background,span');
                        }


                        var curIndex = $(currSlideElement).attr("index");
                        var curSlidnavtitle = $($("#slideDemo .slidnavtitle")[curIndex]);
                        if (curSlidnavtitle != null) {
                            curSlidnavtitle.css("background", "url(" + iconImg + ") center center no-repeat");
                        }

                        var nextIndex = $(nextSlideElement).attr("index");

                        var nextSlidnavtitle = $($("#slideDemo .slidnavtitle")[nextIndex]);
                        if (nextSlidnavtitle != null) {
                            var tesy = "url(" + iconImg_over + ") no-repeat";
                            var tempInt = parseInt(nextIndex) + 1;
                            nextSlidnavtitle.css("background", "url(res/images/login/redpoint" + tempInt + ".png) center center  no-repeat");
                        }
                    }
                });
                function pagerFactory(idx, slide) {
                    var s = idx > 20 ? ' style="display:none"' : '';
                    return ' <span class="m-t-5  slidnavtitle"  style="cursor:pointer;background:url(' + (idx == 0 ? iconImg_over : iconImg) + ') center center no-repeat;height:32px;width:32px;display:inline-block;">&nbsp;</span>';
                };
                //传递并获取多语言
                function changeLan(lan) {
                    $.ajax({
                        type: "POST",
                        data: "lan=" + lan,
                        url: "get_lan.php",
                        success: function (result) {
                            getJsonAndTrans(result)
                            //getXmlAndTrans(result.xml)
                            //getXmlAndTrans(resp.responseXML);
                        }
                    });
                }
                function getJsonAndTrans(result) {
                    var rs = $.parseJSON(result);
                    $('#account').html(rs["account"]);
                    $('#pass').html(rs["pass"]);
                    //$('#login').html(rs["login"]);
                    $('#imgpass').html(rs["imgpass"]);
                }
                //语言选择内容显示位置
                if ($.browser.version >= 8.0) {
                    $("#langDiv").offset({ left: $("#langchoosetable").position().left, top: $("#langchoosetable").position().top + 23 });
                }
                else {
                    $("#langDiv").offset({ left: $("#langchoosetable").offset().left, top: $("#langchoosetable").offset().top + 23 });
                }
                //alert($("#langDiv").position("left",$("#langchoosetable").position().left-20))
                //$("#langDiv").position.top=$("#langchoosetable").position().top;
                //$("#langDiv").position({left:$("#langchoosetable").position().left,top:73});
                $("#langchoosetable").click(function () {
                    $("#langDiv").toggle();
                });
                $(".langitem").hover(function () {
                    $(this).removeClass("langitem").addClass("langitemhover");
                }, function () {
                    $(this).removeClass("langitemhover").addClass("langitem");
                }).click(function () {
                    $("#curlangname").html($(this).html());
                    $("#c_Select").attr("value", $(this).attr("LANG_AB"));
                    $("#USER_LANG").attr("value", $(this).attr("LANG_AB"));
                    changeLan($(this).attr("LANG_AB"))
                });
                $("#login").bind("mouseover", function () {
                    $(this).removeClass("lgsm");
                    $(this).addClass("lgsmMouseOver");
                });
                $("#login").bind("mouseout", function () {
                    $(this).removeClass("lgsmMouseOver");
                    $(this).addClass("lgsm");
                });

                //检测微软雅黑字体在客户端是否安装
                //fontDetection("sfclsid", $("input[name='fontName']").val());
                //检测用户当前浏览器及其版本
                //ieVersionDetection();
                setRandomBg();
            });
            //焦点设置
            if (!$("#USERNAME").attr("value"))
                $("#USERNAME").focus();
            else
                $("#PASSWORD").focus();
            // $("input[name='loginid']").focus();

            //----------------------------------
            // form表单提交时check
            //----------------------------------


        });
        function setRandomBg() {
            var discnt = 5;

            var i = Math.floor(Math.random() * 10 + 1);
            var j = Math.floor(Math.random() * 10 + 1);
            var k = Math.floor(Math.random() * 10 + 1);
            var x = Math.floor(Math.random() * 10 + 1);
            var y = Math.floor(Math.random() * 10 + 1);
            var z = Math.floor(Math.random() * 10 + 1);
            while (i > discnt) {
                i = Math.floor(Math.random() * 10 + 1);
            }
            while (j > discnt || j == i) {
                j = Math.floor(Math.random() * 10 + 1);
            }
            while (k > discnt || k == i || k == j) {
                k = Math.floor(Math.random() * 10 + 1);
            }
            //var i = 1;
            //var j = 2;
            //var k = 3;
            var image_suffix = ".jpg";
            $("#disimg1").css("background", "url(res/images/login/" + i + image_suffix + ") no-repeat");
            $("#disimg2").css("background", "url(res/images/login/" + j + image_suffix + ") no-repeat");
            $("#disimg3").css("background", "url(res/images/login/" + k + image_suffix + ") no-repeat");
        }

    </script>
</head>


<body style="margin: 0px; padding: 0px; background: #ebeeef; width: 100%; height: 100%; z-index: 10;" scroll="auto">
    <form name="form1" id="form1" runat="server">
        <div style="width: 100%; overflow: hidden;" id="slideDemo">
            <div style="margin: 0px; clear: left; top: 0px; width: 100%; height: 100%;" id="slideshow" class="slideDivContinar">
                <div style="cursor: pointer; width: 100%;" id="disimg1" class="slideDiv" index="0"></div>
                <div style="cursor: pointer; width: 100%;" id="disimg2" class="slideDiv" index="1"></div>
                <div style="cursor: pointer; width: 100%;" id="disimg3" class="slideDiv" index="2"></div>
            </div>
            <div id="nav" style="position: absolute; z-index: 100; width: 100%; text-align: center;"></div>
        </div>
        <div id="loginpanel" style="position: absolute; z-index: 100; width: 100%; text-align: center;">
            <table width="100%" border="0">
                <tr>
                    <td>
                        <table width="803" border="0" align="center" style="background: url(Res/Images/login/boxbg.png) no-repeat;">
                            <tr>
                                <td width="493" height="262">
                                    <table>
                                        <tr>
                                            <td align="left">&nbsp;&nbsp;<img src="Res/Images/login/login_logo.png" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <img src="Res/Images/login/login_text .png" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>

                                    <table cellspacing="0" cellpadding="0" width="266" height="100%" valign="top" border="0" align="center">
                                        <tbody>
                                            <tr>
                                                <td style="height: 22px; padding: 0px 0px 8px 0px;" align="left">

                                                    <table  width="123" height="25" style="background:url(images/login/choose_lang_bg.png) no-repeat;display:none" id="langchoosetable" border="0">
                                                        <tr>
                                                            <td>
                                                                <span id="curlangname">简体中文</span>
                                                                <div id="langDiv">
                                                                    <input type="hidden" name="c_Select" id="c_Select" value="cn">
                                                                    <input type="hidden" name="USER_LANG" id="USER_LANG" value="cn">
                                                                    <div class="langitem" lang_ab="cn">简体中文</div>
                                                                </div>
                                                            </td>
                                                            
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="25" width="266" align="left" class="inputtd">
                                                    <div class="labdiv" id="account">帐号：</div>
                                                    <asp:TextBox ID="txtUserName" runat="server" CssClass="baseinput" name="USERNAME"></asp:TextBox><%--<input type="text" class="baseinput" style="width: 124px; font-size: 13px; width:120px" name="USERNAME" id="USERNAME" value="admin" autocomplete="off">--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="25" width="226" align="left" class="inputtd">
                                                    <div class="labdiv" id="pass">密码：</div>
                                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="baseinput" ></asp:TextBox>
                                                    <%--<input class="baseinput" style="width: 124px;  font-size: 12px; height:18px;" id="PASSWORD" name="PASSWORD" type="password" autocomplete="off"  />--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="100%" align="left" style="padding: 10px 0px 2px 0px;">
                                                    <asp:Button CssClass="lgsm" runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" />
                                                    <%--<input id="login" type="submit" class="lgsm" tabIndex="3" name="submit" value="" >--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px 0px;">
                                                    <div id="errorMessage">
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>

                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div style="width: 100%; height: 91px; background: #333; z-index: 100; background: url(Res/Images/login/bg_top.png) repeat-x; position: absolute; top: 0px;">
            <table width="100%">
                <tr>
                    <td width="50%">
                        &nbsp;</td>
                    <td width="50%" align="right">&nbsp;</td>
                </tr>
            </table>
        </div>
        <div style="width: 100%; height: 61px; text-align: center; padding-top: 20px; background: url(Res/Images/login/bg_foot.png); z-index: 100; position: absolute; bottom: 0px;"></div>
    </form>
</body>
</html>
