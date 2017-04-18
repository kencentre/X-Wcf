<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchList.aspx.cs" Inherits="X_Wcf.Administrator.BasePlatform.Notice.SearchList" %>

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
                    Title="搜索条件" EnableCollapse="true">
                    <Items>
                        <f:Form runat="server" ShowBorder="false" BodyPadding="6" ShowHeader="false">
                            <Rows>
                                <f:FormRow runat="server">
                                    <Items>
                                        <f:TextBox ID="txtSearch" runat="server" Label="公告名称"></f:TextBox>
                                        <f:DatePicker ID="txtStartDate" runat="server" Label="创建时间" LabelWidth="80"></f:DatePicker>
                                        <f:DatePicker ID="txtEndDate" runat="server" Label="至" LabelWidth="20"></f:DatePicker>
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
                        <f:Grid ID="Grid1" AllowPaging="true" runat="server" DataKeyNames="ID,STATUS,TITLE" ShowHeader="false" EnableAjax="true" Icon="TableGear" PageSize="10" Width="100%" IsDatabasePaging="true" OnPageIndexChange="Grid1_PageIndexChange" ShowGridHeader="false">
                            <Columns>
                                <f:TemplateField runat="server" Width="40px">
                                    <ItemTemplate>
                                        <f:Image runat="server" Icon="PageLink" Width="40px" Label=""></f:Image>
                                    </ItemTemplate>
                                </f:TemplateField>
                                <f:WindowField WindowID="windowSourceCode" DataTextFormatString="{0}" DataIFrameUrlFields="ID"
                                    DataIFrameUrlFormatString="Show.aspx?id={0}" DataWindowTitleField="TITLE"
                                    DataWindowTitleFormatString="{0}" DataTextField="TITLE" ExpandUnusedSpace="true" />
                                <f:BoundField DataField="CREATEDATE" DataFormatString="{0:yyyy-MM-dd}" runat="server" />


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

        

        <f:Window ID="windowSourceCode" Icon="PageWhiteCode" EnableIFrame="true"
            runat="server" IsModal="true" Width="700px" Height="500px" EnableClose="true"
            EnableMaximize="true" EnableResize="true" Target="Parent" Hidden="true">
        </f:Window>

        
    </form>

</body>
</html>