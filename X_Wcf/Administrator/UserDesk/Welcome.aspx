<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="X_Wcf.Administrator.UserDesk.Welcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="../css/jalendar.css" type="text/css" />
    <script type="text/javascript" src="../../res/js/jquery-1.10.2.min.js"></script>
    <!--jQuery-->
    <script type="text/javascript" src="../../res/js/jalendar.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#myId').jalendar({
                customDay: '2017/12/01',  // Format: Year/Month/Day
                color: '#ed145a', // Unlimited Colors
                lang: 'EN' // Format: English — 'EN', Türkçe — 'TR'
            });
            $('#myId2').jalendar({
                customDay: '2016/02/29',
                color: '#023447',
                lang: 'ES'
            });
            $('#myId3').jalendar({
                lang: 'CHN'
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table>
                <tr>
                    <td>

                        <div id="myId3" class="jalendar">
                        </div>
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
