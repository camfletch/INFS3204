<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="infs3204_prac2._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Color Mixer
    </h2>

    <!-- The input -->
    <asp:TextBox runat="server" id="input1Txt"/>
    <asp:Label runat="server" text="+" />
    <asp:TextBox runat="server" id="input2Txt"/>

    <!-- The output -->
    <asp:TextBox runat="server" ID="outputTxt" />
    <br />

    <!-- The calculate button -->
    <asp:Button runat="server" Text="Mix" id="calculateBtn" OnClick="calculateBtn_Click" />

</asp:Content>

