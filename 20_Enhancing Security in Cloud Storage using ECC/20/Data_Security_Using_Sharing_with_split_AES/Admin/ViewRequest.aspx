<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewRequest.aspx.cs" Inherits="Admin_ViewRequest" %>

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
                            <a href="ViewRequest.aspx">File Requests</a></h3>
                        <br />
                        <asp:GridView Width="100%" ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="3" BackColor="White" DataSourceID="SqlDataSource1"
                            BorderColor="#CCCCCC" BorderStyle="None" OnRowCommand="gridRowCommand"
                            BorderWidth="1px">
                            <Columns>
                             <asp:BoundField DataField="id" HeaderText="Request ID" 
                                    InsertVisible="False" ReadOnly="True"
                                    SortExpression="id">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="file_id" HeaderText="File ID" 
                                    InsertVisible="False" ReadOnly="True"
                                    SortExpression="share_id">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="file_name" HeaderText="file_name" SortExpression="file_name">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="email_id" HeaderText="username" 
                                    SortExpression="username" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                 <asp:ButtonField Text="Share" CommandName="share_"/>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbConnection %>"
                            SelectCommand="SELECT a.id,file_id,file_name,email_id FROM (select id,fm.file_id,file_name,status from requestMaster as rm left join fileMaster as fm on rm.file_id=fm.file_id) as a left join (select id,email_id from requestMaster as rm left join User_master as um on rm.user_id=um.user_id) as b on a.id=b.id where status=0"></asp:SqlDataSource>
                    </div>
                    <uc2:footer ID="footer" runat="server" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
