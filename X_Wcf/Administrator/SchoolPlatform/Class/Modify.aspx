<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="X_Wcf.Administrator.SchoolPlatform.Class.Modify" %>

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
                                            <f:TextBox ID="txtName" runat="server" Label="课程名称" Required="true" ShowRedStar="true"></f:TextBox>
                                        </Items>
                                    </f:FormRow>
                                    <f:FormRow runat="server">
                                        <Items>
                                            <f:DropDownList runat="server" ID="ddlBrand" Label="所属品牌"></f:DropDownList>
                                        </Items>
                                    </f:FormRow>
                                </Rows>
                            </f:Form>
                        </Items>
                    </f:GroupPanel>
                    <f:GroupPanel runat="server" Title="标题图片" EnableCollapse="true">
                        <Items>
                            <f:Toolbar runat="server">
                                <Items>
                                    <f:FileUpload ID="txtPicture" runat="server" ButtonIcon="DiskUpload"  AutoPostBack="true" OnFileSelected="txtPicture_FileSelected" Label="上传图片"></f:FileUpload>
                                    
                                    <f:Label runat="server" ID="lblPUrl" Hidden="true"></f:Label>
                                </Items>
                            </f:Toolbar>
                            <f:Image runat="server" ID ="imgPicture" Width="100" Height="40" Hidden="true"></f:Image>
                        </Items>
                    </f:GroupPanel>
                    
                    <f:GroupPanel runat="server" Title="课程简介">
                        <Items>
                            <f:ContentPanel runat="server" EnableCollapse="true" ShowBorder="false" ShowHeader="false" ID="ContentPanel1">
                                <script type="text/plain" name="Editor1" id="Editor1">
                                    <%=htmlMessage %>
                                </script>
                            </f:ContentPanel>
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
    <script type="text/javascript">
        window.UEDITOR_HOME_URL = '<%= ResolveUrl("../../../ueditor/") %>';
    </script>
    <script type="text/javascript" src="../../../res/js/jquery.min.js"></script>
    <script type="text/javascript" src="../../../ueditor/ueditor.config.js"></script>
    <script type="text/javascript" src="../../../ueditor/ueditor.all.min.js"></script>
    <script type="text/javascript">

        var containerClientID = '<%= ContentPanel1.ClientID %>';

        var editor;
        F.ready(function () {
            // 初始化
            editor = UE.getEditor('Editor1', {
                initialFrameWidth: '100%',
                initialFrameHeight: 90,
                autoHeightEnabled: false,
                autoFloatEnabled: false,
                focus: true,
                onready: function () {
                    // 重新布局外部容器
                    F(containerClientID).updateLayout();
                }
            });

        });

        // 更新编辑器内容
        function updateEditor(content) {
            if (editor && editor.isReady) {
                editor.setContent(content);
            }
        }
    </script>
</body>
</html>