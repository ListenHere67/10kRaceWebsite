<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="MyWebsite.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Sean Murphy.</h3>
    <address>
        LYIT<br />
        Letterkenny, County Donegal, Ireland.<br />
        <abbr title="Phone">P:</abbr>
        074 727 727</address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@10k.</a>ie<br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@10k.ie</a></address>
</asp:Content>
