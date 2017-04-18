<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="X_Wcf.Administrator.BasePlatform.Role.Modify" %>

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
            
        <f:SimpleForm ID="FormPanel" runat="server" BodyPadding="6" ShowBorder="false" ShowHeader="false" AutoScroll="true">
            <Items>
                <f:DropDownList ID="ddlRoleNameType" runat="server" Label="角色类型" AutoPostBack="true" >
                    <f:ListItem Text="平台角色" Value="0" />
                    <f:ListItem Text="应用角色" Value="1" />
                </f:DropDownList>
                <f:TextBox ID="txtRoleName" runat="server" Label="角色名称" Required="true" ShowRedStar="true" RequiredMessage="角色名称不能为空" OnBlur="txtRoleName_Blur" EnableBlurEvent="true"></f:TextBox>
                <f:TextBox ID="txtRoleCode" runat="server" Label="角色代码" Required="true" ShowRedStar="true" RequiredMessage="角色代码不能为空"></f:TextBox>
                <f:NumberBox ID="txtRoleList" runat="server" Label="角色排序" Required="true" ShowRedStar="true" RequiredMessage="请对角色进行排序"></f:NumberBox>
                <f:HtmlEditor runat="server" Label ="角色简介" ID="txtDescription" Height="150"></f:HtmlEditor>
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
        </div>
    </form>
</body>
</html>