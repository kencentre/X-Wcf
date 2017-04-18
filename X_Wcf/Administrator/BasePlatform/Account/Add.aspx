<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="X_Wcf.Administrator.BasePlatform.Account.Add" %>

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
                            <f:GroupPanel ID="GroupPanel1" runat="server" Title="用户基本设置" EnableCollapse="True" BoxConfigAlign="Stretch" Layout="Anchor">
                                <Items>
                                    <f:TextBox ID="txtUserName" runat="server" Label="用户帐号" Required="true" ShowRedStar="true" ></f:TextBox>
                                    <f:TriggerBox ID="txtUserCode" runat="server" Label="用户工号" Required="true" ShowRedStar="true" TriggerIcon="Search" OnTriggerClick="txtUserCode_TriggerClick"></f:TriggerBox>
                                    <f:DropDownList ID="ddlDuty" runat="server" Label="用户职务" EnableMultiSelect="true" MultiSelectSeparator=",">
                                    </f:DropDownList>
                                    <f:TriggerBox ID="txtDept" runat="server" Label="用户部门" Required="true" ShowRedStar="true" TriggerIcon="Search"></f:TriggerBox>
                                    <f:HiddenField ID="txtDeptCode" runat="server"></f:HiddenField>
                                     <f:DropDownList ID="ddlRole" runat="server" Label="用户角色" EnableMultiSelect="true" MultiSelectSeparator=",">
                                    </f:DropDownList>
                                </Items>
                            </f:GroupPanel>
                        </Items>
                    </f:FormRow>
                    <f:FormRow runat="server">
                        <Items>
                            <f:GroupPanel ID="GroupPanel2" runat="server" Title="其他设置" EnableCollapse="True">
                                <Items>
                                    <f:TextBox ID="txtTrueName" runat="server" Label="真实姓名"></f:TextBox>
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
             <f:Window ID="windowSourceCode" Icon="PageWhiteCode" Title="设置" EnableIFrame="true"
            runat="server" IsModal="true" Width="300px" Height="350px" EnableClose="true"
            EnableMaximize="true" EnableResize="true" Target="Parent" Hidden="true"  >
        </f:Window>
        </div>
    </form>
</body>
</html>
