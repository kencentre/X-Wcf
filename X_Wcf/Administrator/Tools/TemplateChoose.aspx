<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TemplateChoose.aspx.cs" Inherits="X_Wcf.Administrator.Tools.TemplateChoose" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server">
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
                                        <f:TextBox ID="txtSearch" runat="server" Label="模版名称"></f:TextBox>
                                        <f:DatePicker ID="txtStartDate" runat="server" Label="创建时间" LabelWidth="80"></f:DatePicker>
                                        <f:DatePicker ID="txtEndDate" runat="server" Label="至" LabelWidth="20"></f:DatePicker>
                                        <f:Button runat="server" Text="搜索" ID="btnSearch" Icon="Find" OnClick="btnSearch_Click"></f:Button>
                                        <f:Button runat="server" Text="选择" ID="btnAdd" Icon="Add" OnClick="btnAdd_Click"></f:Button>
                                    </Items>
                                </f:FormRow>
                            </Rows>
                        </f:Form>
                    </Items>
                </f:Region>
                <f:Region ID="Region2" runat="server" Position="Center" ShowHeader="true" Title="详细信息"
                    Layout="Fit">
                    <Items>
                        <f:Grid ID="Grid1" AllowPaging="true" runat="server" DataKeyNames="ID,STATUS,TEMPLATENAME"  ShowHeader="false" EnableAjax="true" Icon="TableGear" PageSize="10" Width="100%" IsDatabasePaging="true"  OnPageIndexChange="Grid1_PageIndexChange" OnRowDataBound="Grid1_RowDataBound" EnableMultiSelect="false">
                            <Columns>
                                <f:BoundField  DataField="TEMPLATENAME" runat="server" Width="200px"  HeaderText="模版名称" />
                                <f:BoundField  DataField="TEMPLATEURL" runat="server" HeaderText="模版地址"  ExpandUnusedSpace="true"/>
                                 <f:BoundField  DataField="STATUS" runat="server" HeaderText="状态" />
                            </Columns>
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
    </div>
    </form>
</body>
</html>
