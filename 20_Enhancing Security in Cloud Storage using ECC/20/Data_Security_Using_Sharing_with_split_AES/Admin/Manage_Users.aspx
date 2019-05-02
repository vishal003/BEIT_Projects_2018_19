<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage_Users.aspx.cs" Inherits="Manage_Users" %>

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
                    <h3><a href="Add_New_User.aspx"> Add New User</a></h3>
                    <br />
                        <asp:GridView Width="100%" ID="GridView1" runat="server" AllowPaging="True" 
                            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                            DataSourceID="SqlDataSource1" ForeColor="Black" BackColor="#CCCCCC" 
                            BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2">
                            <Columns>
                                <asp:BoundField DataField="user_id" HeaderText="user_id" InsertVisible="False" 
                                    ReadOnly="True" SortExpression="user_id" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="full_name" HeaderText="full_name" 
                                    SortExpression="full_name" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="contact_no" HeaderText="contact_no" 
                                    SortExpression="contact_no" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="email_id" HeaderText="email_id" 
                                    SortExpression="email_id" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:HyperLinkField DataNavigateUrlFields="user_id" 
                                    DataNavigateUrlFormatString="Add_New_User.aspx?action=edit&amp;user_id={0}" 
                                    HeaderText="Action" Text="Edit" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:HyperLinkField>
                                <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False"  OnCommand="DeleteButton_OnCommand" CommandArgument='<%#Eval("user_id") %>'
                                        Text="Delete"  OnClientClick="return confirm('Are you certain you want to delete this?');"></asp:LinkButton></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="5%" />
                            </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                            <RowStyle BackColor="White" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView> 
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:dbConnection %>" 
                            SelectCommand="SELECT [user_id], [full_name], [contact_no], [email_id] FROM [User_Master]"></asp:SqlDataSource>   
                    </div>
                    <uc2:footer ID="footer" runat="server" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
