<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Share_File.aspx.cs" Inherits="Share_File" %>

<%@ Register TagPrefix="uc1" TagName="header" Src="~/Admin/Includes/Header.ascx" %>
<%@ Register TagPrefix="uc2" TagName="footer" Src="~/Admin/Includes/Footer.ascx" %>
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
                        <table class="style1" cellpadding="5" cellspacing="5">
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
                            <tr>
                                <td class="style2">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select
                                    User:-
                                </td>
                                <td class="style3">
                                    <asp:DropDownList ID="ddlUser" runat="server" Width="200px" AppendDataBoundItems="true"
                                        DataSourceID="SqlDataSource1" DataTextField="email_id" DataValueField="user_id">
                                        <asp:ListItem Selected="True" Value="0" Text="Select User"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbConnection %>"
                                        SelectCommand="SELECT [user_id], [email_id] FROM [User_Master]"></asp:SqlDataSource>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Select
                                    File:-&nbsp;
                                </td>
                                <td class="style3">
                                    <asp:DropDownList ID="ddlfile_name" runat="server" AppendDataBoundItems="true" DataSourceID="SqlDataSource2"
                                        DataTextField="file_name" DataValueField="file_id" Width="200px">
                                        <asp:ListItem Selected="True" Value="0" Text="Select File Name"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:dbConnection %>"
                                        SelectCommand="SELECT [file_id], [file_name] FROM [File_Info]"></asp:SqlDataSource>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td class="style3">
                                    <asp:DropDownList ID="ddlcloud_id" runat="server" Width="200px" Visible="False">
                                        <asp:ListItem Value="0">Cloud</asp:ListItem>
                                        <asp:ListItem Value="1">Cloud</asp:ListItem>
                                      <%--  <asp:ListItem Value="2">Cloud2</asp:ListItem>
                                        <asp:ListItem Value="3">Cloud3</asp:ListItem>--%>
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
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
                                    <asp:Button ID="btnShare" runat="server" Height="25px" Text="Share" Width="70px"
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
    </form>
</body>
</html>
