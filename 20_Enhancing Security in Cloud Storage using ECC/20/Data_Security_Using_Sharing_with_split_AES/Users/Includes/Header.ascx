<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="Includes_Header" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <meta name="description" content=""/>
    <meta name="keywords" content=""/>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1"/>
    <link href="../css/style.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <div class="header">
       <%-- <div class="header-top">
            <h1>
                Company <span>Name</span></h1>
        </div>--%>
        <div class="header-bottom">
            <h2>
              
                </h2>
        </div>
        <div class="topmenu">
            <ul>
                <li style="background: transparent none repeat scroll 0% 50%; -moz-background-clip: initial;
                    -moz-background-origin: initial; -moz-background-inline-policy: initial; padding-left: 0px;">
                    <a href="Home.aspx"><span>Home</span></a></li>
                <li><a href="View_Share_Files.aspx"><span>View Share Files</span></a></li>
                <li><a href="Change_Password.aspx"><span>Change Password</span></a></li>
                <%--<li><a href="Manage Files.aspx"><span>Manage Files</span></a></li>
                <li><a href="Share_Log.aspx"><span>Share File</span></a></li>
                --%><%--<li><a href="Manage_keyword.aspx"><span>Manage&nbsp;Keyword</span></a></li>
                <li><a href="File_upload.aspx"><span>File &nbsp;Upload </span></a></li>
                --%><%--<li><a href="#"><span>Contact</span></a></li>
                <li><a href="#"><span>Resources</span></a></li>--%>
                <li><a href="Login.aspx?msg=logout"><span>Logout</span></a></li>
            </ul>
        </div>
    </div>
</body>
</html>
