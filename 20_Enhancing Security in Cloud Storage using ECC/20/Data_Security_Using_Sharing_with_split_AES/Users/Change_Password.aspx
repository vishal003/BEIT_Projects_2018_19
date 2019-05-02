<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Change_Password.aspx.cs"
    Inherits="Users_Change_Password" %>

<%@ Register TagPrefix="uc1" TagName="header" Src="~/Users/Includes/Header.ascx" %>
<%@ Register TagPrefix="uc2" TagName="footer" Src="~/Users/Includes/Footer.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Home</title>
    <meta name="description" content="" />
    <meta name="keywords" content="" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="page-out">
        <div class="page-in">
            <div class="page">
                <div class="main">
                    <uc1:header ID="header" runat="server" />
                    <div class="content">
                        <table class="style1" cellpadding="5" cellspacing="5" width="100%">
                            <tr>
                                <td class="style2">
                                    &nbsp;
                                </td>
                                <td class="style3">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                    Current Password:-
                                </td>
                                <td class="style3">
                                    <asp:TextBox ID="txtexisting_pwd" runat="server" Height="24px" Width="200px" 
                                        TextMode="Password"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtexisting_pwd"
                                        ErrorMessage="Current Password Mendatory"></asp:RequiredFieldValidator>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                    New Password:- 
                                </td>
                                <td class="style3">
                                    <asp:TextBox ID="txtnew_password" runat="server" Height="24px" Width="200px" 
                                        TextMode="Password"></asp:TextBox>
                                </td>
                                <td>
                                   &nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtnew_password"
                                        ErrorMessage="New Password Mendatory"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            
                            <tr>
                                <td class="style2">
                                    &nbsp;
                                </td>
                                <td class="style3">
                                    <asp:Button ID="btnsubmit" runat="server" Height="25px" Text="Submit" Width="70px"
                                        OnClick="btnSave_Click" />
                                    &nbsp;&nbsp;&nbsp;
                                    </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    &nbsp;
                                </td>
                                <td class="style3">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                    <uc2:footer ID="footer" runat="server" />
                </div>
            </div>
        </div>
    </div>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
