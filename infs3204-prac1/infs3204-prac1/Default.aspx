<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="infs3204_prac1._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Buggy Calculator
    </h2>

    <!-- The input -->
    <asp:TextBox runat="server" id="input1Txt"/>
    <asp:DropDownList runat="server" id="operationDropDown">
        <asp:ListItem>+</asp:ListItem>
        <asp:ListItem>-</asp:ListItem>
        <asp:ListItem>*</asp:ListItem>
        <asp:ListItem>/</asp:ListItem>
    </asp:DropDownList>
    <asp:TextBox runat="server" id="input2Txt"/>

    <!-- The output -->
    <asp:Label runat="server" Text=" = Base10" />
    <asp:TextBox runat="server" ID="outputBase10Txt" />
    <asp:Label runat="server" Text=" = Base2" />
    <asp:TextBox runat="server" ID="outputBase2Txt" />

    <br />

    <!-- The calculate button -->
    <asp:Button runat="server" Text="Calculate" id="calculateBtn" OnClick="calculateBtn_Click" />

</asp:Content>
