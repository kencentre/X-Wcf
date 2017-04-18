<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Notice.aspx.cs" Inherits="X_Wcf.Administrator.UserDesk.Notice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../res/Css/Default.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server">
        </f:PageManager>
        <f:RegionPanel ID="RegionPanel1" runat="server" ShowBorder="false">
            <Regions>
                <f:Region ID="Region2" runat="server" Position="Center" ShowHeader="false" Title="详细信息"
                    Layout="Fit">
                    <Items>
                        <f:Grid ID="Grid1"  runat="server" DataKeyNames="ID,STATUS,TITLE" ShowHeader="false" EnableAjax="true" Icon="TableGear" Width="100%" ShowGridHeader="false" >
                            <Columns>
                                <f:TemplateField runat="server" Width="40px" >
                                    <ItemTemplate>
                                        <f:Image runat="server" Icon="PageLink" Width="40px" Label=""></f:Image>
                                    </ItemTemplate>
                                </f:TemplateField>
                                <f:WindowField  WindowID="windowSourceCode"  DataTextFormatString="{0}" DataIFrameUrlFields="ID"
                DataIFrameUrlFormatString="../BasePlatform/notice/Show.aspx?id={0}" DataWindowTitleField="TITLE"
                DataWindowTitleFormatString="{0}"  DataTextField ="TITLE" ExpandUnusedSpace="true" />
                                <f:BoundField  DataField="CREATEDATE" DataFormatString="{0:yyyy-MM-dd}" runat="server"  />
                                
                            </Columns>
                            <Toolbars>
                                <f:Toolbar runat="server" Position="Bottom" >
                                    <Items>
                                        <f:ToolbarFill runat="server"></f:ToolbarFill>
                                        <f:Button ID="btnAdd" Text="更多" runat="server" Icon="Add" EnablePostBack="false" OnClientClick="openHelloFineUI();"></f:Button>
                                    </Items>
                                </f:Toolbar>
                            </Toolbars>
                            
                        </f:Grid>
                    </Items>
                </f:Region>
            </Regions>
        </f:RegionPanel>
        <f:Window ID="windowSourceCode" Icon="PageWhiteCode"  EnableIFrame="true"
            runat="server" IsModal="true" Width="700px" Height="500px" EnableClose="true"
            EnableMaximize="true" EnableResize="true" Target="Top" Hidden="true" >
        </f:Window>
        <script type="text/javascript">

            var basePath = '<%= ResolveUrl("~/") %>';

            function openHelloFineUI() {
                
                parent.parent.addExampleTab.apply(null, ['notice_all_tab', basePath + 'administrator/BasePlatform/notice/SearchList.aspx', '通知公告查阅', basePath + 'res/icon/page.png', true]);
            }


            function closeActiveTab() {
                parent.removeActiveTab();
            }
    </script>
    </form>
    
</body>
</html>
