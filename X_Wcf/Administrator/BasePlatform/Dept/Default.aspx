<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="X_Wcf.Administrator.BasePlatform.Dept.Default" %>

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
                <f:Region ID="LeftPanel" Title="部门列表" ShowBorder="false" Layout="Fit" Position="Left" runat="server" RegionSplit="true" Width="300px">
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
                <f:Region ID="CenterPanel" runat="server" ShowBorder="false" Title="部门信息" Position="Center" Layout="Fit">
                    <Items>
                        <f:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="6" ShowBorder="false" ShowHeader="false">
                                            <Items>
                                                <f:HiddenField ID="txtID" runat="server"></f:HiddenField>
                                                <f:TextBox ID="txtDeptName" runat="server" Label="部门名称" Required="true" ShowRedStar="true"></f:TextBox>
                                                <f:TextBox ID="txtDeptCode" runat="server" Label="组织机构码" Required="true" ShowRedStar="true"></f:TextBox>
                                                <f:TriggerBox ID="txtParentID" runat="server" Label="上级部门" Required="true" ShowRedStar="true" TriggerIcon="Search"></f:TriggerBox>
                                                <f:HiddenField ID="txtParent" runat="server"></f:HiddenField>
                                                <f:NumberBox ID="txtDeptList" runat="server" Label="部门排序" Required="true" ShowRedStar="true"></f:NumberBox>
                                                <f:HtmlEditor runat="server" Label="部门简介" ID="txtDescription" Height="100"></f:HtmlEditor>
                                            </Items>
                                        </f:SimpleForm>
                        <f:RegionPanel runat="server" ShowBorder="false" Hidden="true">
                            <Regions>
                                <f:Region runat="server" ShowBorder="false" ShowHeader="false" Position="Top" Height="250">
                                    <Items>
                                        
                                    </Items>
                                </f:Region>
                                <f:Region Hidden="true" runat="server" ShowBorder="false" ShowHeader="false" Position="Center" Layout="Fit">
                                    <Items>
                                        <f:Panel ID="userPanel" runat="server" Title="部门人员" ShowBorder="false" Layout="Fit">
                                            <Items>
                                                <f:Grid ID="Grid1" runat="server" ShowBorder="false" ShowHeader="false" AllowPaging="true" PageSize="5" OnPageIndexChange="Grid1_PageIndexChange" CheckBoxSelectOnly="true" EnableCheckBoxSelect="True">
                                                    <Columns>
                                                        <f:BoundField ID="colUserName" runat="server" DataField="TrueName" HeaderText="用户姓名" ExpandUnusedSpace="true"></f:BoundField>
                                                        <f:BoundField ID="colUserCode" runat="server" DataField="UserCode" HeaderText="用户工号"></f:BoundField>
                                                        <f:BoundField ID="colUserPhone" runat="server" DataField="Phone" HeaderText="用户电话"></f:BoundField>
                                                        <f:BoundField ID="colUserMail" runat="server" DataField="EMail" HeaderText="用户邮箱"></f:BoundField>
                                                    </Columns>
                                                    <Toolbars>
                                                        <f:Toolbar runat="server">
                                                            <Items>
                                                                <f:Button ID="btnCallIn" runat="server" Text="人员调入" Icon="UserAdd"></f:Button>
                                                                <f:Button ID="btnCallOut" runat="server" Text="人员调出" Icon="UserDelete"></f:Button>
                                                            </Items>
                                                        </f:Toolbar>
                                                    </Toolbars>
                                                </f:Grid>
                                            </Items>
                                        </f:Panel>
                                    </Items>
                                </f:Region>
                            </Regions>
                        </f:RegionPanel>
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