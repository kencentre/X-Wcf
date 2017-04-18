<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="X_Wcf.Administrator.WebSitePlatform.Property.Add" %>

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
                    <f:TextBox ID="txtName" runat="server" Label="属性名称" Required="true" ShowRedStar="true"></f:TextBox>
                    <f:RadioButtonList ID="ddlType" runat="server" Label="展现类型">
                        <f:RadioItem Text="文本框" Value="0" Selected="true" />
                        <f:RadioItem Text="上传控件" Value="1" />
                        <f:RadioItem Text="文本域" Value="2" />
                    </f:RadioButtonList>
                    <f:HtmlEditor runat="server" Label="备注" ID="txtDescription" Height="150"></f:HtmlEditor>
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