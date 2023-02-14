<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ManageUser.aspx.cs" Inherits="SteamApplication.ManageUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:GridView ID="userGv" runat="server"></asp:GridView>
        Manage User Menu
        <br />
        Update User
        <br />
        <asp:Label ID="Label4" runat="server" Text="User ID"></asp:Label>
        <asp:TextBox ID="txUpdateUserId" runat="server"></asp:TextBox>
        <br />
         <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>
        <asp:TextBox ID="txUpdateUserName" runat="server"></asp:TextBox>
        <br />
         <asp:Label ID="Label2" runat="server" Text="User Password"></asp:Label>
        <asp:TextBox ID="txUpdateUserPassword" runat="server"></asp:TextBox>
            <br />
         <asp:Label ID="Label3" runat="server" Text="User Role"></asp:Label>
        <asp:TextBox ID="txUpdateUserRole" runat="server"></asp:TextBox>
            <br />
         <asp:Label ID="Label5" runat="server" Text="User Email"></asp:Label>
        <asp:TextBox ID="txUpdateUserEmail" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="updateBtn" OnClick="updateBtn_Click" runat="server"  Text="Update" />
        <asp:Label ID="errorLblUpdate" runat="server" Text=""></asp:Label>

        <br />
        Delete User
        <br />
        <asp:Label ID="deleteLbl" runat="server" Text="User ID"></asp:Label>
        <asp:TextBox ID="txDeleteId" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="deleteBtn" OnClick="deleteBtn_Click" runat="server"  Text="Delete" />
        <asp:Label ID="errorLblDelete" runat="server" Text=""></asp:Label>

</asp:Content>
