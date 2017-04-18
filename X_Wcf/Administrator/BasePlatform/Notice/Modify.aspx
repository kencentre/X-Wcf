<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="X_Wcf.Administrator.BasePlatform.Notice.Modify" %>

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
                <f:TextBox ID="txtName" runat="server" Label="公告标题" Required="true" ShowRedStar="true" RequiredMessage="公告标题不能为空"  EnableBlurEvent="true"></f:TextBox>
                <f:TextBox ID="txtCode" runat="server" Label="关键字" Required="true" ShowRedStar="true" RequiredMessage="关键字不能为空"></f:TextBox>
                <f:HtmlEditor runat="server" Label ="公告正文" ID="txtDescription" Height="150"></f:HtmlEditor>
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