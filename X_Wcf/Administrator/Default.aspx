<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="X_Wcf.Administrator.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>清波CMS管理系统</title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" />
    <link type="text/css" rel="stylesheet" href="~/res/css/default.css" />
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server"></f:PageManager>
        <f:RegionPanel ID="RegionPanel1" ShowBorder="false" runat="server">
            <Regions>
                <f:Region ID="Region1" ShowBorder="false" ShowHeader="false"
                    Position="Top" Layout="Fit" runat="server">
                    <Items>
                        <f:ContentPanel ID="topPanel" CssClass="topregion" RegionPosition="Top" ShowBorder="false" ShowHeader="false" EnableCollapse="true" runat="server">
                            <div id="header">
                            <table>
                                <tr>
                                    <td>
                                        <a class="homepage" href="#" >
                                            <img src="../res/icon/house.png" alt="Home" />
                                        </a>
                                        <a class="logo" href="#">清波CMS管理系统
                                        </a>
                                    </td>
                                    <td style="text-align: right;">
                                        <f:Button Hidden="true" runat="server" CssClass="x-btn-icon-top" Text="在线帮助" IconAlign="Top" IconUrl="~/res/images/HELP.PNG" ID="btnResource">
                                        </f:Button>
                                        <f:Button Hidden="true" runat="server" CssClass="x-btn-icon-top" Text="意见反馈" IconAlign="Top" IconUrl="~/res/images/CHART.PNG" ID="btnHelp">
                                        </f:Button>
                                        <f:Button runat="server" CssClass="userpicaction" Text="USERNAME" IconUrl="~/res/images/ADMIN.PNG" IconAlign="Left"
                                            EnablePostBack="false" ID="btnUserName">
                                            <Menu runat="server">
                                                <f:MenuButton Text="修改个人信息" EnablePostBack="false" Icon="User" runat="server" ID="btnModifyInfo">
                                                </f:MenuButton>
                                                <f:MenuSeparator runat="server"></f:MenuSeparator>
                                                <f:MenuButton Text="修改密码" ID="btnModifyPwd" runat="server" Icon="Key">
                                                </f:MenuButton>
                                                <f:MenuSeparator runat="server"></f:MenuSeparator>
                                                <f:MenuButton Text="安全退出" Icon="ZoomOut" runat="server" ID="btnQuite" OnClientClick="window.location.href='login.aspx';">
                                                </f:MenuButton>
                                            </Menu>
                                        </f:Button>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        </f:ContentPanel>
                    </Items>
                </f:Region>
                <f:Region ID="leftPanel" RegionSplit="true" Width="220px" ShowHeader="true" ShowBorder="true" Title="菜单"
                    EnableCollapse="true" Layout="Fit" Collapsed="false" RegionPosition="Left" runat="server">
                </f:Region>
                <f:Region ID="mainRegion" ShowHeader="false" Layout="Fit" ShowBorder="true" Position="Center"
                    runat="server">
                    <Items>
                        <f:TabStrip ID="mainTabStrip" EnableTabCloseMenu="true" ShowBorder="false" runat="server">
                            <Tabs>
                                <f:Tab Title="首页" Layout="Fit" Icon="House" CssClass="maincontent" runat="server">
                                    <Items>
                                        <f:Panel runat="server" ID="framePanel" Layout="Fit" ShowBorder="false" ShowHeader="false"></f:Panel>
                                    </Items>
                                </f:Tab>
                            </Tabs>
                        </f:TabStrip>
                    </Items>
                </f:Region>
                <f:Region ID="bottomPanel" RegionPosition="Bottom" ShowBorder="false" ShowHeader="false" EnableCollapse="false" runat="server" Layout="Fit">
                    <Items>
                        <f:ContentPanel runat="server" ShowBorder="false" ShowHeader="false">
                            <table class="bottomtable">
                                <tr>
                                    <td style="text-align: center;">Copyright &copy; </td>
                                    <td style="width: 300px; text-align: right;">在线人数：<asp:Literal runat="server" ID="litOnlineUserCount"></asp:Literal>&nbsp;</td>
                                </tr>
                            </table>
                        </f:ContentPanel>
                    </Items>
                </f:Region>
            </Regions>
        </f:RegionPanel>
        <f:Window ID="windowSourceCode" Icon="PageWhiteCode" Title="" Hidden="true" EnableIFrame="true"
            runat="server" IsModal="true" Width="950px" Height="550px" EnableClose="true"
            EnableMaximize="true" EnableResize="true">
        </f:Window>
        <f:Window ID="windowLoadingSelector" Title="加载动画" Hidden="true" EnableIFrame="true" IFrameUrl="tools/loading.aspx"
            runat="server" IsModal="true" Width="1000px" Height="625px" EnableClose="true"
            EnableMaximize="true" EnableResize="true">
        </f:Window>
        <f:Menu ID="menuSettings" runat="server">
            <f:MenuButton ID="btnExpandAll" IconUrl="~/res/images/expand-all.gif" Text="展开菜单" EnablePostBack="false"
                runat="server">
            </f:MenuButton>
            <f:MenuButton ID="btnCollapseAll" IconUrl="~/res/images/collapse-all.gif" Text="折叠菜单"
                EnablePostBack="false" runat="server">
            </f:MenuButton>
            <f:MenuSeparator ID="MenuSeparator1" runat="server">
            </f:MenuSeparator>
            <f:MenuButton ID="MenuTheme" EnablePostBack="false" Text="主题" runat="server">
                <Menu ID="Menu4" runat="server">
                    <f:MenuCheckBox Text="海卫一（Triton）" ID="MenuThemeTriton" Checked="true" GroupName="MenuTheme" runat="server">
                    </f:MenuCheckBox>
                    <f:MenuCheckBox Text="小清新（Crisp）" ID="MenuThemeCrisp" GroupName="MenuTheme" runat="server">
                    </f:MenuCheckBox>
                    <f:MenuCheckBox Text="海王星（Neptune）" ID="MenuThemeNeptune" GroupName="MenuTheme" runat="server">
                    </f:MenuCheckBox>
                    <f:MenuCheckBox Text="蓝色（Blue）" ID="MenuThemeBlue" GroupName="MenuTheme" runat="server">
                    </f:MenuCheckBox>
                    <f:MenuCheckBox Text="灰色（Gray）" ID="MenuThemeGray" GroupName="MenuTheme" runat="server">
                    </f:MenuCheckBox>
                </Menu>
            </f:MenuButton>
            <f:MenuSeparator ID="MenuSeparator2" runat="server">
            </f:MenuSeparator>
            <f:MenuButton ID="MenuButton1" IconUrl="~/res/images/collapse-all.gif" Text="加载动画"
                EnablePostBack="false" runat="server">
                <Listeners>
                    <f:Listener Event="click" Handler="onLoadingSelectClick" />
                </Listeners>
            </f:MenuButton>
        </f:Menu>
    </form>
    <script src="../res/js/jquery.min.js"></script>
    <script>
        var btnExpandAllClientID = '<%= btnExpandAll.ClientID %>';
        var btnCollapseAllClientID = '<%= btnCollapseAll.ClientID %>';
        var leftPanelClientID = '<%= leftPanel.ClientID %>';
        var mainTabStripClientID = '<%= mainTabStrip.ClientID %>';
        var windowSourceCodeClientID = '<%= windowSourceCode.ClientID %>';
        var menuSettingsClientID = '<%= menuSettings.ClientID %>';
        var windowLoadingSelectorClientID = '<%= windowLoadingSelector.ClientID %>';
        var MenuThemeClientID = '<%= MenuTheme.ClientID %>';

        // 点击加载动画
        function onLoadingSelectClick(event) {
            var windowLoadingSelector = F(windowLoadingSelectorClientID);
            windowLoadingSelector.f_show();
        }

        F.ready(function () {
            var btnExpandAll = F(btnExpandAllClientID);
            var btnCollapseAll = F(btnCollapseAllClientID);
            var leftPanel = F(leftPanelClientID);
            var mainTabStrip = F(mainTabStripClientID);
            var windowSourceCode = F(windowSourceCodeClientID);
            var menuSettings = F(menuSettingsClientID);

            var MenuTheme = F(MenuThemeClientID);

            var treeMenu = leftPanel.items.getAt(0);
            var menuType = 'accordion';

            // 点击展开菜单
            btnExpandAll.on('click', function () {
                treeMenu.expandAll();
            });

            // 点击折叠菜单
            btnCollapseAll.on('click', function () {
                treeMenu.collapseAll();
            });



            // 切换主题
            function MenuThemeItemCheckChange(cmp, checked) {
                if (checked) {
                    var lang = 'neptune';
                    if (cmp.id.indexOf('MenuThemeBlue') >= 0) {
                        lang = 'blue';
                    } else if (cmp.id.indexOf('MenuThemeGray') >= 0) {
                        lang = 'gray';
                    } else if (cmp.id.indexOf('MenuThemeCrisp') >= 0) {
                        lang = 'crisp';
                    } else if (cmp.id.indexOf('MenuThemeTriton') >= 0) {
                        lang = 'triton';
                    }

                    F.cookie('Theme_v6', lang, {
                        expires: 100 // 单位：天
                    });
                    top.window.location.reload();
                }
            }
            MenuTheme.menu.items.each(function (item, index) {
                item.on('checkchange', MenuThemeItemCheckChange);
            });


            // 添加示例标签页
            window.addExampleTab = function (id, iframeUrl, title, icon, refreshWhenExist) {
                // 动态添加一个标签页
                // mainTabStrip： 选项卡实例
                // id： 选项卡ID
                // iframeUrl: 选项卡IFrame地址 
                // title: 选项卡标题
                // icon： 选项卡图标
                // createToolbar： 创建选项卡前的回调函数（接受tabConfig参数）
                // refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame
                F.addMainTab(mainTabStrip, {
                    id: id,
                    iframeUrl: iframeUrl,
                    title: title,
                    icon: icon,
                    refreshWhenExist: refreshWhenExist
                });
            };

            // 移除选中标签页
            window.removeActiveTab = function () {
                var activeTab = mainTabStrip.getActiveTab();
                mainTabStrip.removeTab(activeTab.id);
            };



            // 添加工具图标，并在点击时显示上下文菜单
            // 专业版提醒：请将 type:'gear' 改为 iconFont:'gear'
            leftPanel.addTool({
                type: 'gear',
                //tooltip: '系统设置',
                handler: function (event) {
                    menuSettings.showBy(this);
                }
            });

        });
    </script>
</body>
</html>
