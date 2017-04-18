<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="X_Wcf.Administrator.BasePlatform.Main.Default" %>

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
                <f:Region ID="LeftPanel" Title="菜单列表" ShowBorder="false" Layout="Fit" Position="Left" runat="server" RegionSplit="true" Width="300px">
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
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                </f:Region>
                <f:Region ID="CenterPanel" runat="server" ShowBorder="false" Title="菜单信息" Position="Center">
                    <Items>
                        <f:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="6" ShowBorder="false" ShowHeader="false">
                            <Items>
                                <f:HiddenField ID="txtID" runat="server"></f:HiddenField>
                                <f:TextBox ID="txtMainName" runat="server" Label="菜单名称" Required="true" ShowRedStar="true"></f:TextBox>
                                <f:TextBox ID="txtMainUrl" runat="server" Label="菜单地址" Required="true" ShowRedStar="true"></f:TextBox>
                                <f:TriggerBox ID="txtIcon" runat="server" Label="菜单图标" Required="true" ShowRedStar="true" TriggerIcon="Search"></f:TriggerBox>
                                <f:HiddenField ID="txtIconValue" runat="server"></f:HiddenField>
                                <f:TriggerBox ID="txtParentID" runat="server" Label="上级菜单" Required="true" ShowRedStar="true" TriggerIcon="Search"></f:TriggerBox>
                                <f:HiddenField ID="txtParent" runat="server"></f:HiddenField>
                                <f:NumberBox ID="txtMainList" runat="server" Label="菜单排序" Required="true" ShowRedStar="true"></f:NumberBox>
                                <f:HtmlEditor runat="server" Label="备注" ID="txtDescription" Height="150"></f:HtmlEditor>
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

