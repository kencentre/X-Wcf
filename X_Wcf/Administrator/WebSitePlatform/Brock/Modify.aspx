<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="X_Wcf.Administrator.WebSitePlatform.Brock.Modify" %>

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
                    <f:HiddenField ID="txtID" runat="server"></f:HiddenField>
                    <f:TextBox ID="txtName" runat="server" Label="模块名称" Required="true" ShowRedStar="true"></f:TextBox>
                    <f:TextBox ID="txtCode" runat="server" Label="模块编码" Required="true" ShowRedStar="true"></f:TextBox>
                    <f:TriggerBox ID="txtTepmlateID" runat="server" Label="所选模版" Required="true" ShowRedStar="true" TriggerIcon="Search"></f:TriggerBox>
                    <f:HiddenField ID="txtTepmlate" runat="server" ></f:HiddenField>
                    <f:NumberBox ID="txtList" runat="server" Label="模块排序" Required="true" ShowRedStar="true" ></f:NumberBox>
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
            <f:Window ID="windowSourceCode" Icon="PageWhiteCode" Title="设置" EnableIFrame="true"
                runat="server" IsModal="true" Width="400px" Height="300px" EnableClose="true"
                EnableMaximize="true" EnableResize="true" Target="Parent" Hidden="true">
            </f:Window>
        </div>
    </form>
</body>
</html>