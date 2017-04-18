<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="X_Wcf.Administrator.BasePlatform.Dept.Delete" %>

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
        <f:Form ID="FormPanel" runat="server" Layout="Fit" Title="部门信息" ShowHeader="false" ShowBorder="false">
            <Rows>
                <f:FormRow runat="server">
                    <Items>
                        <f:Tree runat="server" ID ="tvList" ShowHeader="false" ShowBorder="false" AutoScroll="true" OnNodeCheck="MainList_NodeCheck">
                        </f:Tree>
                    </Items>
                </f:FormRow>
            </Rows>
            <Toolbars>
                <f:Toolbar runat="server" Position="Bottom">
                    <Items>
                        <f:ToolbarFill runat="server"></f:ToolbarFill>
                        <f:Button ID="btnAdd" runat="server" Text="提交" Icon="Accept" OnClick="btnAdd_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Form>
    </form>
</body>
</html>