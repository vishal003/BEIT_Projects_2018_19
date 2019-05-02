<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Upload_File.aspx.cs" Inherits="Upload_File" %>

<%@ Register TagPrefix="uc1" TagName="header" Src="~/Admin/Includes/Header.ascx" %>
<%@ Register TagPrefix="uc2" TagName="footer" Src="~/Admin/Includes/Footer.ascx" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Home</title>
    <meta name="description" content="" />
    <meta name="keywords" content="" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 310px;
        }
        .style2
        {
            width: 135px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="page-out">
        <div class="page-in">
            <div class="page">
                <div class="main">
                    <uc1:header ID="header" runat="server" />
                    <div class="content">
                        <table class="style1" style="width:100%" cellpadding="5" cellspacing="5">
                            <tr>
                                <td class="style2">
                                    Select File:-
                                </td>
                                <td class="style3">
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <%-- <tr>
                                <td class="style2">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select
                                    Key1:-
                                </td>
                                <td class="style3">
                                    <asp:DropDownList ID="ddlKey1" runat="server" Width="200px" DataSourceID="SqlDataSource1"
                                        DataTextField="key_value" DataValueField="key_id" AppendDataBoundItems="true">
                                        <asp:ListItem Selected="True" Value="0" Text="Select First Key"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbConnection %>"
                                        SelectCommand="SELECT * FROM [auto_keys]"></asp:SqlDataSource>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>--%>                            <%--        <tr>
                                <td class="style2">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select
                                    Key2:-
                                </td>
                                <td class="style3">
                                    <asp:DropDownList ID="ddlKey2" runat="server" Width="200px" DataSourceID="SqlDataSource1"
                                        DataTextField="key_value" DataValueField="key_id" AppendDataBoundItems="true">
                                        <asp:ListItem Selected="True" Value="0" Text="Select Second Key"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select
                                    Key3:-
                                </td>
                                <td class="style3">
                                    <asp:DropDownList ID="ddlKey3" runat="server" Width="200px" DataSourceID="SqlDataSource1"
                                        DataTextField="key_value" DataValueField="key_id" AppendDataBoundItems="true">
                                        <asp:ListItem Selected="True" Value="0" Text="Select Third Key"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>--%>
                            <tr>
                                <td class="style2">
                                    &nbsp;
                                </td>
                                <td class="style3">
                                    <asp:Button ID="btnSave" runat="server" Height="25px" Text="generate keys" Width="119px"
                                        OnClick="btnSave_Click" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnCancel" runat="server" Height="25px" Text="Cancel" 
                                        Width="70px" onclick="btnCancel_Click" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr><td class="style2"></td></tr>
                            <tr>
                            <td colspan="3">
                            
                                <asp:Label ID="Label1" runat="server" Text="ECC Algo." Font-Bold="True"></asp:Label>
                            
                            </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    <asp:Label ID="lblPublic" runat="server" Text="ECC alice Key"></asp:Label>
                                </td>
                                <td class="style3">
                                    <asp:Label ID="lblViewPublic" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    <asp:Label ID="lblPrivate" runat="server" Text="ECC bob Key"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblViewPrivate" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td class="style2"><asp:Label ID="lblECCTime" runat="server" Text="ECC Encryption Time"></asp:Label></td>
                            <td><asp:Label ID="lblViewTime" runat="server" Text="lblViewTime"></asp:Label> </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                </td>
                                <td>
                                    <asp:Button ID="btnEncryptData" runat="server" Height="25px" Text="Encrypt" 
                                        Width="70px" onclick="btnEncryptData_Click"/>
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
