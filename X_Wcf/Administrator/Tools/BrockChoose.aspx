﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BrockChoose.aspx.cs" Inherits="X_Wcf.Administrator.Tools.BrockChoose" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../res/Css/Default.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
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
                        <f:Grid ID="Grid1" AllowPaging="true" runat="server" DataKeyNames="ID,BROCKNAME" EnableMultiSelect="false" ShowHeader="false" EnableAjax="true" Icon="TableGear" PageSize="10" Width="100%" IsDatabasePaging="true"  OnRowCommand="Grid1_RowCommand" OnPageIndexChange="Grid1_PageIndexChange" OnRowDataBound="Grid1_RowDataBound">
                            <Columns>
                                <f:BoundField  DataField="BROCKNAME" runat="server" Width="200px"  HeaderText="模块名称" />
                                <f:BoundField  DataField="BROCKCODE" runat="server" HeaderText="模块编码"  ExpandUnusedSpace="true"/>
                                <f:BoundField  DataField="TEMPLATENAME" runat="server" HeaderText="所属模版"  ExpandUnusedSpace="true"/>
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
        <f:Window ID="windowSourceCode" Icon="PageWhiteCode"  EnableIFrame="true"
            runat="server" IsModal="true" Width="700px" Height="510px" EnableClose="true"
            EnableMaximize="true" EnableResize="true" Target="Parent" Hidden="true" OnClose="windowSourceCode_Close">
        </f:Window>
    </form>
    
</body>
</html>