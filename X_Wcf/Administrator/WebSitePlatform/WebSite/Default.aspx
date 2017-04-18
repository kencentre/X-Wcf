<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="X_Wcf.Administrator.WebSitePlatform.WebSite.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../res/Css/Default.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="FormPanel" runat="server">
        </f:PageManager>

        <f:RegionPanel ID="FormPanel" runat="server">
            <Regions>
                <f:Region ID="LeftPanel" Title="栏目列表" ShowBorder="false" Layout="Fit" Position="Left" runat="server" RegionSplit="true" Width="350px">
                    <Items>
                        <f:Tree ID="tvList" runat="server" ShowBorder="false" ShowHeader="false" OnNodeCommand="tvList_NodeCommand">
                            <Nodes>
                            </Nodes>
                        </f:Tree>
                    </Items>
                    <Toolbars>
                        <f:Toolbar runat="server">
                            <Items>
                                <f:Button ID="btnAdd" runat="server" Text="添加" Icon="Add"></f:Button>
                                <f:Button ID="btnEdit" runat="server" Text="编辑" Icon="Pencil"></f:Button>
                                <f:Button ID="btnDelete" runat="server" Text="删除" Icon="Delete"></f:Button>
                                <f:Button ID="btnConfig" runat="server" Text="生成" Icon="HtmlValid"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                </f:Region>
                <f:Region ID="CenterPanel" runat="server" ShowBorder="false" Title="站点栏目信息" Position="Center">
                    <Items>
                        <f:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="6" ShowBorder="false" ShowHeader="false">
                            <Items>
                                <f:HiddenField ID="txtID" runat="server"></f:HiddenField>
                                <f:TextBox ID="txtChannelName" runat="server" Label="栏目名称" Readonly="true"></f:TextBox>
                                <f:TriggerBox ID="txtParentID" runat="server" Label="上级栏目" ></f:TriggerBox>
                                <f:HiddenField ID="txtParent" runat="server" Readonly="true"></f:HiddenField>
                                <f:TextBox ID="txtTemplate" runat="server" Label="选用模版"></f:TextBox>
                                <f:CheckBox runat="server" ID="cblStatus" Label="启停状态"  Text="启用" Readonly="true"></f:CheckBox>
                                <f:HtmlEditor runat="server" Label="备注" ID="txtDescription" Height="150" ></f:HtmlEditor>
                            </Items>
                        </f:SimpleForm>
                    </Items>
                </f:Region>
            </Regions>
        </f:RegionPanel>
        <f:Window ID="windowSourceCode" Icon="PageWhiteCode" Title="设置" EnableIFrame="true"
            runat="server" IsModal="true" Width="500px" Height="300px" EnableClose="true"
            EnableMaximize="true" EnableResize="true" Target="Parent" Hidden="true">
        </f:Window>
    </form>
</body>
</html>