<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="X_Wcf.Administrator.BasePlatform.Desk.Modify" %>

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
                <f:TextBox ID="txtName" runat="server" Label="模块名称" Required="true" ShowRedStar="true" RequiredMessage="模块名称不能为空" OnBlur="txtDutyName_Blur"  EnableBlurEvent="true"></f:TextBox>
                <f:TextBox ID="txtCode" runat="server" Label="模块编码" Required="true" ShowRedStar="true" RequiredMessage="模块编码不能为空"></f:TextBox>
                <f:TextBox ID="txtURL" runat="server" Label="模块地址" Required="true" ShowRedStar="true" RequiredMessage="请输入模块地址"></f:TextBox>
                <f:NumberBox ID="txtList" runat="server" Label="模块排序" Required="true" ShowRedStar="true" RequiredMessage="请输入排序字段"></f:NumberBox>
                <f:NumberBox ID="txtWidth" runat="server" Label="模块长度" Required="true" ShowRedStar="true" RequiredMessage="请输入模块长度"></f:NumberBox>
                <f:NumberBox ID="txtHeight" runat="server" Label="模块高度" Required="true" ShowRedStar="true" RequiredMessage="请输入模块高度"></f:NumberBox>
                <f:RadioButtonList runat="server" ID="rblEnableClose" Label="是否关闭"
                     Hidden ="true">
                    <f:RadioItem Selected="true" Text="是" Value="1" />
                    <f:RadioItem Text="否" Value="0" />
                </f:RadioButtonList>
                <f:RadioButtonList runat="server" ID="rblEnableMax" Label="最大化"
                     Hidden ="true">
                    <f:RadioItem Selected="true" Text="是" Value="1" />
                    <f:RadioItem Text="否" Value="0" />
                </f:RadioButtonList>
                <f:RadioButtonList runat="server" ID="rblEnableMin" Label="最小化"
                     Hidden ="true">
                    <f:RadioItem Selected="true" Text="是" Value="1" />
                    <f:RadioItem Text="否" Value="0" />
                </f:RadioButtonList>
                <f:RadioButtonList runat="server" ID="rblEnableCol" Label="可折叠"
                    Required="true" ShowRedStar="true">
                    <f:RadioItem Selected="true" Text="是" Value="1" />
                    <f:RadioItem Text="否" Value="0" />
                </f:RadioButtonList>
                <f:HtmlEditor runat="server" Label ="模块简介" ID="txtDescription" Height="150"></f:HtmlEditor>
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