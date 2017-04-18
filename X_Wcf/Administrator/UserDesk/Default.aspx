<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="X_Wcf.Administrator.UserDesk.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="FormPanel" runat="server">
        </f:PageManager>


        <f:Panel ID="FormPanel" runat="server" ShowBorder="false" ShowHeader="false" Layout="Fit">
            <Items>
                <f:Panel runat="server" ID="p1" ShowBorder="false" ShowHeader="false" Layout="Column" AutoScroll="true"></f:Panel>
            </Items>
            <Toolbars>
                <f:Toolbar runat="server">
                    <Items>
                        <f:ToolbarFill runat="server">
                        </f:ToolbarFill>
                        <f:Button ID="btnFrush" runat="server" Text="刷新" Icon="ArrowRefresh" OnClientClick="javascript:history.go(0)">
                        </f:Button>
                        <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                        </f:ToolbarSeparator>
                        <f:Button ID="btnConfig" runat="server" Text="设置" Icon="Cog">
                        </f:Button>
                        <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                        </f:ToolbarSeparator>

                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Panel>
        <f:Window ID="windowSourceCode" Icon="PageWhiteCode" Title="设置" EnableIFrame="true"
            runat="server" IsModal="true" Width="500px" Height="300px" EnableClose="true"
            EnableMaximize="true" EnableResize="true" Target="Parent" Hidden="true" OnClose="windowSourceCode_Close">
        </f:Window>
    </form>
</body>
</html>
