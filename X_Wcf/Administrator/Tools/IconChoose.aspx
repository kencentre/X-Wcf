<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IconChoose.aspx.cs" Inherits="X_Wcf.Administrator.Administrator.Tools.IconChoose" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <f:PageManager ID="PageManager1" AutoSizePanelID="FormPanel" runat="server">
            </f:PageManager>
            <f:Panel ID="FormPanel" runat="server" ShowBorder="false" ShowHeader="false"  AutoScroll="true">
                <Items>
                    <f:RadioButtonList ID="rblIcon" runat="server" ColumnNumber="8">
                        <f:RadioItem Value="Application" Text="<img src='../../res/icon/application.png'>" />
                        <f:RadioItem Value="ApplicationForm" Text="<img src='../../res/icon/application_form.png'>" />
                        <f:RadioItem Value="ApplicationOsx" Text="<img src='../../res/icon/application_osx.png'>" />
                        <f:RadioItem Value="Book" Text="<img src='../../res/icon/book.png'>" />
                        <f:RadioItem Value="BookOpen" Text="<img src='../../res/icon/book_open.png'>" />
                        <f:RadioItem Value="BulletDisk" Text="<img src='../../res/icon/bullet_disk.png'>" />
                        <f:RadioItem Value="ChartBar" Text="<img src='../../res/icon/chart_bar.png'>" />
                        <f:RadioItem Value="Comment" Text="<img src='../../res/icon/comment.png'>" />
                        <f:RadioItem Value="DataBaseYellow" Text="<img src='../../res/icon/database_yellow.png'>" />
                        <f:RadioItem Value="Folder" Text="<img src='../../res/icon/folder.png'>" />
                        <f:RadioItem Value="House" Text="<img src='../../res/icon/house.png'>" />
                        <f:RadioItem Value="Mail" Text="<img src='../../res/icon/mail.png'>" />
                        <f:RadioItem Value="Map" Text="<img src='../../res/icon/map.png'>" />
                        <f:RadioItem Value="Page" Text="<img src='../../res/icon/page.png'>" />
                        <f:RadioItem Value="Report" Text="<img src='../../res/icon/report.png'>" />
                        <f:RadioItem Value="Table" Text="<img src='../../res/icon/table.png'>" />
                        <f:RadioItem Value="User" Text="<img src='../../res/icon/user.png'>" />
                        <f:RadioItem Value="Vcard" Text="<img src='../../res/icon/vcard.png'>" />
                        <f:RadioItem Value="Zoom" Text="<img src='../../res/icon/zoom.png'>" />
                        <f:RadioItem Value="Pencil" Text="<img src='../../res/icon/pencil.png'>" />
                        <f:RadioItem Value="Printer" Text="<img src='../../res/icon/printer.png'>" />
                        <f:RadioItem Value="Smartphone" Text="<img src='../../res/icon/smartphone.png'>" />
                        <f:RadioItem Value="Star" Text="<img src='../../res/icon/star.png'>" />
                        <f:RadioItem Value="World" Text="<img src='../../res/icon/world.png'>" />
                    </f:RadioButtonList>
                </Items>
                <Toolbars>
                    <f:Toolbar runat="server" Position="Bottom">
                        <Items>
                            <f:ToolbarFill runat="server"></f:ToolbarFill>
                            <f:Button runat="server" Text="提交" ID="btnAdd" Icon="Add" OnClick="btnAdd_Click"></f:Button>
                            <f:Button runat="server" Text="关闭" ID="btnCancle" Icon="Delete"></f:Button>
                        </Items>
                    </f:Toolbar>
                </Toolbars>
            </f:Panel>
        </div>
    </form>
</body>
</html>
