<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="X_Wcf.Administrator.BasePlatform.Notice.Show" %>

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
            
        <f:Panel ID="FormPanel" runat="server" BodyPadding="6" ShowBorder="false" ShowHeader="false" AutoScroll="true">
            <Items>
                
                
                
                <f:ContentPanel ID ="cp" runat="server" ShowBorder="false" ShowHeader="false">
                    <table width="100%" border="0">
                        <tr>
                            <td style="text-align:center;color:red;font-size:16px"><h3><f:Label ID="txtTitle" runat="server"></f:Label></h3></td>
                        </tr>
                        <tr>
                            <td><hr /></td>
                        </tr>
                        <tr>
                            <td style="text-align:center;font-size:12px"><f:Label ID="txtCode" runat="server"></f:Label></td>
                        </tr>
                        <tr>
                            <td><asp:Literal runat="server" ID="txtDescription" ></asp:Literal></td>
                        </tr>
                    </table>
                </f:ContentPanel>
            </Items>
            <Toolbars>
                <f:Toolbar runat="server" Position="Bottom">
                    <Items>
                        <f:ToolbarFill runat="server"></f:ToolbarFill>
                        <f:Button runat="server" Text="打印" ID="btnAdd" Icon="Printer" OnClientClick="window.print();" ></f:Button>
                        <f:Button runat="server" Text="关闭" ID="btnCancle" Icon="Delete"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Panel>
        </div>
    </form>
</body>
</html>