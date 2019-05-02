<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage Files.aspx.cs" Inherits="Manage_Files" %>

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
                        <h3>
                            <a href="Upload_File.aspx">Upload File</a></h3>
                        <br />
                        <asp:GridView Width="100%" ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" 
                            ForeColor="Black" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" 
                            BorderWidth="3px" CellSpacing="2">
                            <Columns>
                                <asp:BoundField DataField="file_id" HeaderText="file_id" InsertVisible="False" ReadOnly="True"
                                    SortExpression="file_id">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="file_name" HeaderText="file_name" 
                                    SortExpression="file_name">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:HyperLinkField DataNavigateUrlFields="file_id" DataNavigateUrlFormatString="frmHashMatch.aspx?fid={0}"
                                    HeaderText="Action" Text="Match hash">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:HyperLinkField>

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
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbConnection %>"
                            SelectCommand="SELECT [file_id], [file_name] FROM [File_Info]">
                        </asp:SqlDataSource>
                    </div>
                    <uc2:footer ID="footer" runat="server" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
