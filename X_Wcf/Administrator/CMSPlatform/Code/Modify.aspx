<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="Modify.aspx.cs" Inherits="X_Wcf.Administrator.CMSPlatform.Code.Modify" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../../res/Css/Default.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../../ueditor/themes/default/css/ueditor.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <f:PageManager ID="PageManager1" AutoSizePanelID="FormPanel" runat="server">
            </f:PageManager>
            
            <f:SimpleForm ID="FormPanel" runat="server" ShowBorder="false" ShowHeader="false" AutoScroll="true">
                <Items>
                    <f:GroupPanel runat="server" Title="基本信息设置">
                        <Items>
                            <f:Form runat="server" ShowBorder="false" ShowHeader="false" >
                                <Rows>
                                    <f:FormRow runat="server">
                                        <Items>
                                            <f:TextBox ID="txtName" runat="server" Label="标题" Required="true" ShowRedStar="true"></f:TextBox>
                                        </Items>
                                    </f:FormRow>
                                    
                                </Rows>
                            </f:Form>
                        </Items>
                    </f:GroupPanel>
                    <f:GroupPanel runat="server" Title="图片" EnableCollapse="true">
                        <Items>
                            <f:Toolbar runat="server">
                                <Items>
                                    <f:FileUpload ID="txtPicture" runat="server" ButtonIcon="DiskUpload"  AutoPostBack="true" OnFileSelected="txtPicture_FileSelected"></f:FileUpload>
                                    
                                    <f:HiddenField runat="server" ID="lblPUrl" ></f:HiddenField>
                                </Items>
                            </f:Toolbar>
                            <f:Image runat="server" ID ="imgPicture" Width="100" Height="40" Hidden="true"></f:Image>
                        </Items>
                    </f:GroupPanel>
                    
                    <f:GroupPanel runat="server" Title="正文">
                        <Items>
                            <f:HtmlEditor runat="server" ID="txtDescription"></f:HtmlEditor>
                        </Items>
                    </f:GroupPanel>
                </Items>
                <Toolbars>
                    <f:Toolbar runat="server" Position="Bottom">
                        <Items>
                            <f:ToolbarFill runat="server"></f:ToolbarFill>
                             
                            <f:Button runat="server" Text="提交" ID="btnAdd" Icon="Add" OnClick="btnAdd_Click"></f:Button>
                            <f:Button runat="server" Text="关闭" ID="btnCancle" Icon="Delete"></f:Button>
                        </Items>
                    </f:Toolbar>
                </Toolbars>
            </f:SimpleForm>
             <f:Window ID="windowSourceCode" Icon="PageWhiteCode" Title="设置" EnableIFrame="true"
                runat="server" IsModal="true" Width="400px" Height="300px" EnableClose="true"
                EnableMaximize="true" EnableResize="true" Target="Parent" Hidden="true">
            </f:Window>
        </div>
    </form>
    
</body>
</html>