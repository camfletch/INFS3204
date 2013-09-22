<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AppointmentBooking.aspx.cs" Inherits="infs3204_prac4.LINQView.AppointmentBooking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" Text="Patient Name" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="patientFirstNameTxt" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="patientLastNameTxt" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" Text="Doctor Name" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="doctorFirstNameTxt" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="doctorLastNameTxt" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" Text="Appointment Time" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="dateTxt" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="timeTxt" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" Text="Clinic Name" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="clinicNameTxt" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button runat="server" Text="Save" ID="saveBtn" OnClick="saveBtn_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Label runat="server" ID="outputLbl" />
</asp:Content>
