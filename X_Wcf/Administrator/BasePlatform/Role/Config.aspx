﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Config.aspx.cs" Inherits="X_Wcf.Administrator.BasePlatform.Role.Config" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../../res/Css/Default.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <f:PageManager ID="PageManager1" AutoSizePanelID="FormPanel" runat="server">
            </f:PageManager>
            <f:Panel ID="FormPanel" runat="server" ShowBorder="false" ShowHeader="false" AutoScroll="true">
                <Items>
                    <f:Tree runat="server" ID="tvList" ShowHeader="false" ShowBorder="false" OnNodeCheck="tvList_NodeCheck"></f:Tree>
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