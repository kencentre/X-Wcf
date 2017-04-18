<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeUserInfo.aspx.cs" Inherits="X_Wcf.Administrator.BasePlatform.Account.ChangeUserInfo" %>

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
                            <f:GroupPanel ID="GroupPanel2" runat="server" Title="用户信息" EnableCollapse="True">
                                <Items>
                                    <f:TextBox ID="txtTrueName" runat="server" Label="真实姓名" Enabled="false"></f:TextBox>
                                    <f:TextBox ID="txtIDCard" runat="server" Label="身份证"></f:TextBox>
                                    <f:TextBox ID="txtPhone" runat="server" Label="联系电话"></f:TextBox>
                                    <f:TextBox ID="txtAdress" runat="server" Label="联系地址"></f:TextBox>
                                    <f:TextBox ID="txtMail" runat="server" Label="电子邮箱"></f:TextBox>
                                    <f:TextArea ID="txtDescription" runat="server" Label="备注"></f:TextArea>
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