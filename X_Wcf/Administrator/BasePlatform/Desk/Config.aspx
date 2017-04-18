<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Config.aspx.cs" Inherits="X_Wcf.Administrator.BasePlatform.Desk.Config" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../res/Css/Default.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="FormPanel" runat="server">
        </f:PageManager>

        <f:RegionPanel ID="FormPanel" runat="server">
            <Regions>
                <f:Region ID="LeftPanel" Title="菜单列表" ShowBorder="false" Layout="Fit" Position="Left" runat="server" RegionSplit="true" Width="300px">
                    <Items>
                        
                    </Items>
                </f:Region>
                <f:Region ID="CenterPanel" runat="server" ShowBorder="false" Title="菜单信息" Position="Center">
                    <Items>
                        
                    </Items>
                </f:Region>
            </Regions>
        </f:RegionPanel>
        <f:Window ID="windowSourceCode" Icon="PageWhiteCode" Title="设置" EnableIFrame="true"
            runat="server" IsModal="true" Width="500px" Height="300px" EnableClose="true"
            EnableMaximize="true" EnableResize="true" Target="Parent" Hidden="true">
        </f:Window>
    </form>
</body>
</html>
