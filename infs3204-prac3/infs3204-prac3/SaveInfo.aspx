<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SaveInfo.aspx.cs" Inherits="infs3204_prac3.SaveInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="personForm">
        <h3>Person </h3> 
        <asp:Label ID="Label1" runat="server" Text="First Name: "/> <asp:TextBox ID="firstName" runat="server"/>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required field" ControlToValidate="firstName"/>
        <br />

        <asp:Label ID="Label2" runat="server" Text="Last Name: "/><asp:TextBox ID="lastName" runat="server"/>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required field" ControlToValidate="lastName" />
        <br />

        <asp:Label ID="Label3" runat="server" Text="Date of Birth: "/><asp:TextBox ID="dateBirth" runat="server"/>
        <br />

        <asp:Label ID="Label4" runat="server" Text="Email: "/><asp:TextBox ID="email" runat="server"/>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid email" 
                                        ControlToValidate="email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
        <br />

        <asp:Label ID="Label5" runat="server" Text="Street: "/><asp:TextBox ID="street" runat="server"/>
        <br />

        <asp:Label ID="Label6" runat="server" Text="Suburb: "/><asp:TextBox ID="suburb" runat="server"/>
        <br />

        <asp:Label ID="Label7" runat="server" Text="State: "/><asp:TextBox ID="state" runat="server"/>
        <br />

        <asp:Label ID="Label8" runat="server" Text="Post Code: "/><asp:TextBox ID="postcode" runat="server"/>
        <asp:Label runat="server" ID="postCodeError" />
        <br />
    </div>

    <div id="jobForm">
        <h3>Job</h3>
        <asp:Label ID="Label9" runat="server" Text="Position Number: "/> <asp:TextBox ID="jobPos" runat="server"/>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required field" ControlToValidate="jobPos" />
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="jobPos" ErrorMessage="Must be a number" Operator="DataTypeCheck" Type="Integer" />
        <br />

        <asp:Label ID="Label10" runat="server" Text="Position Title: "/><asp:TextBox ID="jobTitle" runat="server" />
        <br />

        <asp:Label ID="Label11" runat="server" Text="Position Description: "/><asp:TextBox ID="jobDesc" runat="server" />
        <br />

        <asp:Label ID="Label12" runat="server" Text="Company Name: "/><asp:TextBox ID="companyName" runat="server"/>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required field" ControlToValidate="companyName"/>
        <br />
    </div>
    <hr />
    <asp:Button ID="save" runat="server" Text="Save" OnClick="save_Click" />
    <asp:Label ID="generalErrorLbl" runat="server" />
</asp:Content>
