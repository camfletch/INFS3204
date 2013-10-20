<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ASCIIFilter.aspx.cs" Inherits="Prac5Client.ASCIIFilter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" Text="filter" />
                <asp:TextBox runat="server" ID="inputFilter"/>
                <asp:Label runat="server" Text="input words" />
                <asp:TextBox runat="server" ID="inputWords"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button runat="server" OnClick="filter_Click" Text="Filter" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="output" Height="200" Width="700"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="errors" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
