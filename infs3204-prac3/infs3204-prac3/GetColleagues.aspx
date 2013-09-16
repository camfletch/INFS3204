<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GetColleagues.aspx.cs" Inherits="infs3204_prac3.GetColleagues" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" Text="First Name: " /><asp:TextBox runat="server" ID="firstName" />
    <asp:Label runat="server" Text="Last Name: " /><asp:TextBox runat="server" ID="lastName" />
    <br />
    <asp:Button ID="search" runat="server" Text="Search" OnClick="search_Click" />
    <br />

    <asp:TextBox ID="result" runat="server" TextMode="MultiLine" Width="500" Height="300"/>
</asp:Content>
