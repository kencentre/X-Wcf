<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="X_Wcf.Administrator.BasePlatform.Dept.Add" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../res/Css/Default.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <f:PageManager ID="PageManager1" AutoSizePanelID="FormPanel" runat="server">
            </f:PageManager>
            
        <f:SimpleForm ID="FormPanel" runat="server" BodyPadding="6" ShowBorder="false" ShowHeader="false">
            <Items>
                <f:TextBox ID="txtDeptName" runat="server" Label="部门名称" Required="true" ShowRedStar="true"></f:TextBox>
                <f:TextBox ID="txtDeptCode" runat="server" Label="组织机构码" Required="true" ShowRedStar="true"></f:TextBox>
                <f:TriggerBox ID="txtParentID" runat="server" Label="上级部门" Required="true" ShowRedStar="true" TriggerIcon="Search"></f:TriggerBox>
                <f:HiddenField ID="txtParent" runat="server"></f:HiddenField>
                <f:NumberBox ID="txtDeptList" runat="server" Label="部门排序" Required="true" ShowRedStar="true" ></f:NumberBox>
                <f:HtmlEditor runat="server" Label ="部门简介" ID="txtDescription" Height="150"></f:HtmlEditor>
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
        </f:SimpleForm>
            <f:Window ID="windowSourceCode" Icon="PageWhiteCode" Title="设置" EnableIFrame="true"
                runat="server" IsModal="true" Width="400px" Height="300px" EnableClose="true"
                EnableMaximize="true" EnableResize="true" Target="Parent" Hidden="true">
            </f:Window>
        </div>
    </form>
</body>
</html>