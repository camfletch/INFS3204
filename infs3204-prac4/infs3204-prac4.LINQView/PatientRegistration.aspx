<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientRegistration.aspx.cs" Inherits="infs3204_prac4.LINQView.PatientRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" Text="Health Insurance No." />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="healthInsuranceNoTxt" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" Text="First Name" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="firstNameTxt" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" Text="LastName" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="lastNameTxt" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" Text="Phone Number" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="phoneNumberTxt" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" Text="Address" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="addressTxt" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" Text="Email" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="emailTxt" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="searchTxt" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button runat="server" Text="Search" ID="searchBtn" OnClick="searchBtn_Click"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button runat="server" Text="Save" ID="saveBtn" OnClick="saveBtn_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Label runat="server" ID="outputLbl" />
</asp:Content>
