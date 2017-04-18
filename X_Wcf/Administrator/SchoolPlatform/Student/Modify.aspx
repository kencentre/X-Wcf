<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="X_Wcf.Administrator.SchoolPlatform.Student.Modify" %>

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
                                            <f:TextBox ID="txtName" runat="server" Label="学员姓名" Required="true" ShowRedStar="true"></f:TextBox>
                            <f:TextBox ID="txtEName" runat="server" Label="英文昵称" Required="true" ShowRedStar="true"></f:TextBox>
                                        </Items>
                                    </f:FormRow>
                                    <f:FormRow runat="server">
                                        <Items>
                                            <f:DropDownList runat="server" ID="ddlSchool" Label="所属校区"></f:DropDownList>
                                            <f:DropDownList runat="server" ID="ddlBrand" Label="学习品牌" EnableMultiSelect="true" MultiSelectSeparator=","></f:DropDownList>
                                        </Items>
                                    </f:FormRow>
                                    <f:FormRow runat="server">
                                        <Items>
                                             <f:TextArea runat="server"  ID="txtInfo" Label="学员简介"></f:TextArea>

                                        </Items>
                                    </f:FormRow>
                                </Rows>
                            </f:Form>
                        </Items>
                    </f:GroupPanel>
                    <f:GroupPanel runat="server" Title="学员照片" EnableCollapse="true">
                        <Items>
                            <f:Toolbar runat="server">
                                <Items>
                                    <f:FileUpload ID="txtPicture" runat="server" ButtonIcon="DiskUpload"  AutoPostBack="true" OnFileSelected="txtPicture_FileSelected" Label="上传照片"></f:FileUpload>
                                    <f:Label runat="server" ID="lblPUrl" Hidden="true"></f:Label>
                                </Items>
                            </f:Toolbar>
                            <f:Image runat="server" ID ="imgPicture" Width="100" Height="40" Hidden="true"></f:Image>
                        </Items>
                    </f:GroupPanel>
                    
                    <f:GroupPanel runat="server" Title="备注">
                        <Items>
                            <f:HtmlEditor ID="txtDescription" runat="server" Label="备注"></f:HtmlEditor>
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
        </div>
    </form>
   
</body>
</html>