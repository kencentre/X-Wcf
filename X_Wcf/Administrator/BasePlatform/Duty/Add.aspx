<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="X_Wcf.Administrator.BasePlatform.Duty.Add" %>

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
                <f:TextBox ID="txtDutyName" runat="server" Label="职务名称" Required="true" ShowRedStar="true" RequiredMessage="职务名称不能为空" OnBlur="txtDutyName_Blur"  EnableBlurEvent="true"></f:TextBox>
                <f:TextBox ID="txtDutyCode" runat="server" Label="职务编码" Required="true" ShowRedStar="true" RequiredMessage="职务编码不能为空"></f:TextBox>
                <f:NumberBox ID="txtDutyList" runat="server" Label="职务排序" Required="true" ShowRedStar="true" RequiredMessage="请对职务进行排序"></f:NumberBox>
                <f:HtmlEditor runat="server" Label ="职务简介" ID="txtDescription" Height="150"></f:HtmlEditor>
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