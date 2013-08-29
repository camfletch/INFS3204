<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="CountryCodeFinder.aspx.cs" Inherits="infs3204_prac2.CountryCodeFinder" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <h2>
            Country Code Finder 
        </h2>
        <asp:ScriptManager runat="server" ID="scriptmanager1">
            <Services>
                <asp:ServiceReference Path="Services/CountryCodeService.asmx"/>
            </Services>
        </asp:ScriptManager>
        <div>
            <asp:Label runat="server" ID="initialLoadLabel"/>
            <br />

            <asp:Label runat="server" Text="Country:" /> 
            <asp:TextBox runat="server" id="inputTxt"/>
            <input type="button" value="Find country code" onclick="find()" />
            <br />

            <asp:Label runat="server" id="outputLbl" Text="hello"> </asp:Label> 
        </div>

    <script type="text/javascript">
        var find = function () {
            infs3204_prac2.Services.CountryCodeService.HelloWorld(onSuccess, onFailed);
        }

        var onSuccess = function (result) {
            $get("outputLbl").innerHTML = result;
        }

        var onFailed = function (result) {

        }
    </script>
</asp:Content>

