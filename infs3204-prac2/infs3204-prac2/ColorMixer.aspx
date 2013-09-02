<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ColorMixer.aspx.cs" Inherits="infs3204_prac2.ColorMixer" %>

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
    <asp:Label runat="server" text="=" />
    <asp:TextBox runat="server" ID="outputTxt" />
    <br />

    <!-- The calculate button -->
    <asp:Button runat="server" Text="Mix" id="calculateBtn" OnClick="calculateBtn_Click" />

</asp:Content>

