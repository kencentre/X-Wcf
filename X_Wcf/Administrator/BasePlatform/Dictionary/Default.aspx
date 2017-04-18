<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="X_Wcf.Administrator.BasePlatform.Dictionary.Default" %>

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
                <f:Region ID="LeftPanel" Title="字典列表" ShowBorder="false" Layout="Fit" Position="Left" runat="server" RegionSplit="true" Width="300px">
                    <Items>
                        <f:Tree ID="tvList" runat="server" ShowBorder="false" ShowHeader="false" OnNodeCommand="tvList_NodeCommand" AutoScroll="true">
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
                <f:Region ID="CenterPanel" runat="server" ShowBorder="false" Title="字典信息" Position="Center" Layout="Fit">
                    <Items>
                        <f:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="6" ShowBorder="false" ShowHeader="false">
                            <Items>
                                <f:HiddenField ID="txtID" runat="server"></f:HiddenField>
                                <f:TextBox ID="txtDeptName" runat="server" Label="字典名称"></f:TextBox>
                                <f:TextBox ID="txtDeptCode" runat="server" Label="字典数值"></f:TextBox>
                                <f:TriggerBox ID="txtParentID" runat="server" Label="上级名称" TriggerIcon="Search"></f:TriggerBox>
                                <f:HiddenField ID="txtParent" runat="server"></f:HiddenField>
                                
                                <f:HtmlEditor runat="server" Label="简介" ID="txtDescription" Height="150"></f:HtmlEditor>
                            </Items>
                        </f:SimpleForm>

                    </Items>
                </f:Region>
            </Regions>
        </f:RegionPanel>
        <f:Menu ID="containerMenu" runat="server" ClientIDMode="Static" Hidden="true">
            <f:MenuButton ID="nmAdd" runat="server" Text="添加" Icon="Add"></f:MenuButton>
        </f:Menu>
        <f:Window ID="windowSourceCode" Icon="PageWhiteCode" Title="设置" EnableIFrame="true"
            runat="server" IsModal="true" Width="500px" Height="300px" EnableClose="true"
            EnableMaximize="true" EnableResize="true" Target="Parent" Hidden="true">
        </f:Window>
    </form>
</body>
</html>
