<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmMatchHash.aspx.cs" Inherits="Users_frmMatchHash" %>

<%@ Register TagPrefix="uc1" TagName="header" Src="~/Users/Includes/Header.ascx" %>
<%@ Register TagPrefix="uc2" TagName="footer" Src="~/Users/Includes/Footer.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>hash match</title>
    <meta name="description" content="" />
    <meta name="keywords" content="" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 136px;
        }
        .style2
        {
            width: 212px;
        }
        .style3
        {
            width: 198px;
        }
        .style4
        {
            height: 35px;
        }
        .style5
        {
            height: 32px;
        }
        .style6
        {
            width: 212px;
            height: 33px;
        }
        .style7
        {
            width: 198px;
            height: 33px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="page-out">
        <div class="page-in">
            <div class="page">
                <div class="main">
                    <div class="header">
                        <uc1:header ID="header" runat="server" />
                        <div class="content">
                            <h1 class="title">
                                <span>Perform Hash Matching</span></h1>
                            <table class="style1">
                                <tr>
                                    <td class="style4">
                                        <asp:Label ID="lblViewFN" runat="server" Text="File Name:" Font-Bold="False" 
                                            Font-Size="Medium"></asp:Label>
                                    </td>
                                    <td class="style4">
                                        <asp:Label ID="lblFileName" runat="server" Text="txtFileName" Font-Size="Small"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style5">
                                        <asp:Label ID="lblViewHV" runat="server" Text="Hash Value:" Font-Bold="False" 
                                            Font-Size="Medium"></asp:Label>
                                    </td>
                                    <td class="style5">
                                        <asp:Label ID="lblHashValue" runat="server" Text="txtHashValue" 
                                            Font-Size="Small"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        <asp:Label ID="Label1" runat="server" Text="Upload Source File :" 
                                            Font-Bold="False" Font-Size="Medium"></asp:Label>
                                    </td>
                                    <td class="style3">
                                        &nbsp;
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style6">
                                        <asp:Label ID="lblViewGHash" runat="server" Text="Generated Hash Value" 
                                            Font-Bold="False" Font-Size="Medium"></asp:Label>
                                    </td>
                                    <td class="style7">
                                        <asp:Label ID="lblGeneratedHash" runat="server" Text="txtHAsh" 
                                            Font-Size="Small"></asp:Label>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td class="style2">
                                        &nbsp;
                                    </td>
                                    <td class="style3">
                                        &nbsp;
                                        <asp:Button ID="btnGenerateHash" runat="server" Height="33px" Text="Generate Hash"
                                            Width="150px" onclick="btnGenerateHash_Click" />
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="footer">
                            <!--DO NOT Remove The Footer Links-->
                            <!--Designed by-->
                            <a href="#">
                                <img src="images/footer.gif" alt="html templates" border="0" height="1" width="1"></a>
                            <p>
                                &copy; Copyright 2016. Designed by <a target="_blank" href="#">htmltemplates.net</a><br>
                                <!--DO NOT Remove The Footer Links-->
                            </p>
                            <ul>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
