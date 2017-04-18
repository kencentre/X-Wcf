<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="X_Wcf.Administrator.BasePlatform.Role.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../res/Css/Default.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server" EnableFStateValidation="false">
        </f:PageManager>
        <f:RegionPanel ID="RegionPanel1" runat="server" ShowBorder="false">
            <Regions>
                <f:Region ID="Region1" runat="server" Position="Top" ShowHeader="true" Split="true"
                    Title="搜索条件"  EnableCollapse="true">
                    <Items>
                        <f:Form runat="server" ShowBorder="false" BodyPadding="6" ShowHeader="false">
                            <Rows>
                                <f:FormRow runat="server">
                                    <Items>
                                        
                                        <f:TextBox ID="txtSearch" runat="server" Label="角色名称"></f:TextBox>
                                        <f:Button runat="server" Text="搜索" ID="btnSearch" Icon="Find" OnClick="btnSearch_Click"></f:Button>
                                    </Items>
                                </f:FormRow>
                            </Rows>
                        </f:Form>
                    </Items>
                </f:Region>
                <f:Region ID="Region2" runat="server" Position="Center" ShowHeader="true" Title="详细信息"
                    Layout="Fit">
                    <Items>
                        <f:Grid ID="Grid1" AllowPaging="true" runat="server" DataKeyNames="ID,Status,ROLENAME,ROLECODE" EnableCheckBoxSelect="True" ShowHeader="false" EnableAjax="true" Icon="TableGear" PageSize="10" Width="100%" IsDatabasePaging="true" CheckBoxSelectOnly="true" OnRowCommand="Grid1_RowCommand" OnPageIndexChange="Grid1_PageIndexChange" OnRowDataBound="Grid1_RowDataBound">
                            <Columns>
                                <f:BoundField  DataField="ROLETYPE" runat="server" Width="200px"  HeaderText="角色类型" />
                                <f:BoundField ID="BoundField1" DataField="ROLENAME" runat="server" Width="200px"  HeaderText="角色名称" />
                                <f:BoundField ID="BoundField2" DataField="DESCRIPTION" runat="server" HeaderText="角色备注"  ExpandUnusedSpace="true"/>
                                <f:BoundField ID="BoundField4" DataField="STATUS" runat="server" HeaderText="状态" />
                                <f:WindowField Width="60px" WindowID="windowSourceCode" HeaderText="编辑"
                Icon="PageEdit" ToolTip="编辑" DataTextFormatString="{0}" DataIFrameUrlFields="ID"
                DataIFrameUrlFormatString="Modify.aspx?id={0}" DataWindowTitleField="Name"
                DataWindowTitleFormatString="编辑 - {0}"  TextAlign="Center"  />
                                <f:LinkButtonField Icon="PageFind" runat="server" CommandName="Approval" HeaderText="审核" ToolTip="审核" ID="lbfApproval" Width="60px" ConfirmText="审核选中行？" ConfirmTarget="Top" 
  TextAlign="Center" />
                                <f:WindowField Width="80px" WindowID="windowSourceCode" HeaderText="配置菜单"
                Icon="PageForward" ToolTip="配置菜单" DataTextFormatString="{0}" DataIFrameUrlFields="ID"
                DataIFrameUrlFormatString="Config.aspx?id={0}" DataWindowTitleField="Name"
                DataWindowTitleFormatString="配置菜单 - {0}" TextAlign="Center" />
                                <f:WindowField Width="80px" WindowID="windowSourceCode" HeaderText="应用授权"
                Icon="PageKey" ToolTip="应用授权" DataTextFormatString="{0}" DataIFrameUrlFields="ID"
                DataIFrameUrlFormatString="ConfigApp.aspx?id={0}" DataWindowTitleField="Name"
                DataWindowTitleFormatString="应用授权 - {0}"  TextAlign="Center"  Hidden="true" />
                                <f:LinkButtonField Icon="PageDelete" runat="server" CommandName="Delete" HeaderText="删除" ToolTip="删除" ID="lbfDelete" Width="60px"  ConfirmText="删除选中行？" ConfirmTarget="Top" TextAlign="Center" 
/>
                            </Columns>
                            <Toolbars>
                                <f:Toolbar runat="server">
                                    <Items>
                                        <f:Button ID="btnAdd" Text="添加" runat="server" Icon="Add"></f:Button>
                                        <f:Button ID="btnApproval" Text="审核" runat="server" Icon="PageFind" OnClick="btnApproval_Click"></f:Button>
                                        <f:Button ID="btnDelete" Text="删除" runat="server" Icon="Delete" OnClick="btnDelete_Click"></f:Button>
                                    </Items>
                                </f:Toolbar>
                            </Toolbars>
                            <PageItems>
                                <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                                </f:ToolbarSeparator>
                                <f:ToolbarText ID="ToolbarText1" runat="server" Text="每页记录数：">
                                </f:ToolbarText>
                                <f:DropDownList runat="server" ID="ddlPageSize" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                    <f:ListItem Text="10" Value="10" />
                                    <f:ListItem Text="15" Value="15" />
                                    <f:ListItem Text="20" Value="20" />
                                </f:DropDownList>
                            </PageItems>
                        </f:Grid>
                    </Items>
                </f:Region>
            </Regions>
        </f:RegionPanel>
        <f:Window ID="windowSourceCode" Icon="PageWhiteCode" Title="设置" EnableIFrame="true"
            runat="server" IsModal="true" Width="500px" Height="310px" EnableClose="true"
            EnableMaximize="true" EnableResize="true" Target="Parent" Hidden="true" OnClose="windowSourceCode_Close">
        </f:Window>
    </form>
</body>
</html>