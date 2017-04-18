<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="X_Wcf.Administrator.SchoolPlatform.Signup.Add" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../../res/Css/Default.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../../ueditor/themes/default/css/ueditor.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <f:PageManager ID="PageManager1" AutoSizePanelID="FormPanel" runat="server">
            </f:PageManager>
            <f:Form ID="FormPanel" runat="server" ShowBorder="false" ShowHeader="false" AutoScroll="true">
                <Items>
                    <f:TextBox ID="txtName" runat="server" Label="学员姓名" Required="true" ShowRedStar="true"></f:TextBox>
                    <f:TextBox ID="txtPhone" runat="server" Label="联系电话" Required="true" ShowRedStar="true"></f:TextBox>
                    <f:TextBox ID="txtQQ" runat="server" Label="QQ" Required="true" ShowRedStar="true"></f:TextBox>
                    <f:TextBox ID="txtEMail" runat="server" Label="电子邮箱" Required="true" ShowRedStar="true"></f:TextBox>
                    <f:TextBox ID="txtAdress" runat="server" Label="联系地址" Required="true" ShowRedStar="true"></f:TextBox>
                    <f:DropDownList runat="server" ID="ddlSchool" Label="所属校区"></f:DropDownList>
                    <f:DropDownList runat="server" ID="ddlBrand" Label="学习品牌" EnableMultiSelect="true" MultiSelectSeparator=","></f:DropDownList>
                    <f:HtmlEditor runat="server" ID ="txtDescription" Label="备注"></f:HtmlEditor>
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
            </f:Form>
        </div>
    </form>
   
</body>
</html>