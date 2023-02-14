<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SteamApplication.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gameGv" runat="server"></asp:GridView>

    <div id="cartView" runat="server">
        Add To Cart
                <br />
         <asp:Label ID="Label3" runat="server" Text="ID Game"></asp:Label>
        <asp:TextBox ID="txGameIdCart" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="addCart" OnClick="addCart_Click" runat="server"  Text="Add To Cart" />
        <br />
    </div>

    <div id="adminView" runat="server">
        Create New Game
        <br />
         <asp:Label ID="lblGame" runat="server" Text="Game Name"></asp:Label>
        <asp:TextBox ID="txName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblPrice" runat="server" Text="Game Price"></asp:Label>
        <asp:TextBox ID="txPrice" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="createBtn" OnClick="createBtn_Click" runat="server"  Text="Create" />
        <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>

        <br />
        Update View
        <br />
        
        <asp:Label ID="Label4" runat="server" Text="Game ID"></asp:Label>
        <asp:TextBox ID="txtUpdateGameId" runat="server"></asp:TextBox>
        <br />
         <asp:Label ID="Label1" runat="server" Text="Game Name"></asp:Label>
        <asp:TextBox ID="txtUpdateGameName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Game Price"></asp:Label>
        <asp:TextBox ID="txtUpdateGamePrice" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="updateBtn" OnClick="updateBtn_Click" runat="server"  Text="Update" />
        <asp:Label ID="errorLblUpdate" runat="server" Text=""></asp:Label>

        <br />
        Delete Game
        <br />
        <asp:Label ID="deleteLbl" runat="server" Text="Game ID"></asp:Label>
        <asp:TextBox ID="txDeleteId" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="deleteBtn" OnClick="deleteBtn_Click" runat="server"  Text="Delete" />
        <asp:Label ID="errorLblDelete" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>
