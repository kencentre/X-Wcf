<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePassword.aspx.cs" Inherits="X_Wcf.Administrator.BasePlatform.Account.UpdatePassword" %>

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

            <f:Form ID="FormPanel" runat="server" ShowHeader="false" ShowBorder="false" AutoScroll="true">
                <Rows>
                    <f:FormRow runat="server">
                        <Items>
                            <f:GroupPanel ID="GroupPanel1" runat="server" Title="修改密码" EnableCollapse="True" BoxConfigAlign="Stretch" Layout="Anchor">
                                <Items>
                                    <f:TextBox ID="txtPwd" runat="server" Label="登录密码" Required="true" ShowRedStar="true" TextMode="Password"></f:TextBox>
                                    <f:TextBox ID="txtNewPwd" runat="server" Label="新  密  码" Required="true" ShowRedStar="true" TextMode="Password"></f:TextBox>
                                    <f:TextBox ID="txtRePwd" runat="server" Label="重复密码" Required="true" ShowRedStar="true" TextMode="Password"></f:TextBox>
                                </Items>
                            </f:GroupPanel>
                        </Items>
                    </f:FormRow>
                </Rows>
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
