<%@ Page Language="C#" MasterPageFile="~/admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="manageAttendance.aspx.cs" Inherits="manageAttendance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        body {font-family: Arial, Helvetica, sans-serif;}
        form {border: 3px solid #f1f1f1;}

        .textbox{
          width: 50%;
          padding: 12px 20px;
          margin: 8px 0;
          display: inline-block;
          border: 1px solid #ccc;
          box-sizing: border-box;
          margin-left:275px;
        }

        .btn {
          background-color: #4CAF50;
          color: white;
          padding: 14px 20px;
          margin: 8px 0;
          border: none;
          cursor: pointer;
          width: 50%;
          margin-left:275px;
        }

        button:hover {
          opacity: 0.8;
        }

        .cancelbtn {
          width: auto;
          padding: 10px 18px;
          background-color: #f44336;
        }

        .imgcontainer {
          text-align: center;
          margin: 24px 0 12px 0;
        }

        img.avatar {
          width: 10%;
          border-radius: 50%;
        }

        .container {
          padding: 16px;
        }

        span.psw {
          float: right;
          padding-top: 16px;
        }

        /* Change styles for span and cancel button on extra small screens */
        @media screen and (max-width: 300px) {
          span.psw {
             display: block;
             float: none;
          }
          .cancelbtn {
             width: 100%;
          }
        }
        .lbl{
            margin-left:400px;
            font-size:large;
            font-weight:bold;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="inside-banner">
      <div class="container"> 
        <span class="pull-right">Home / ManageAttendance</span>
        <h2><u>Manage Attendance</u></h2>
    </div>
    </div>
    <div class="container">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:TextBox ID="txtDate" runat="server" CssClass="textbox"></asp:TextBox>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"></cc1:CalendarExtender>
        <br />
        <asp:DropDownList ID="ddlBranch" runat="server" CssClass="textbox"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlBranch"></asp:RequiredFieldValidator>
        <br />
        <asp:DropDownList ID="ddlSem" runat="server" CssClass="textbox"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlSem"></asp:RequiredFieldValidator>
        <br />
        <asp:DropDownList ID="ddlSub" runat="server" CssClass="textbox"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlSem"></asp:RequiredFieldValidator>
        <br />
        <asp:DropDownList ID="ddlId" runat="server" CssClass="textbox"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlSem"></asp:RequiredFieldValidator>
        <br />
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="textbox">
            <asp:ListItem Text="Present" Value="present"></asp:ListItem>
            <asp:ListItem Text="Absent" Value="absent"></asp:ListItem>
        </asp:RadioButtonList>
        <asp:Button ID="btnAdd" runat="server" Text="Add" class="btn btn-success"/>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
    </div>
</asp:Content>
