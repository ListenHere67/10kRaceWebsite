<%@ Page Title="Reports" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="MyWebsite.Reports" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    
    <p>Please choose a report below.</p>

     <div class="row">
        <div class="col-md-4">
            <h2>Report details</h2>
            <p>
                Click here for the report details page.
            </p>
            <p>
                <a class="btn btn-default" href="http://win-vpos7slarr4/Reports/report/MyReport/Charts">Report details &raquo;</a>
            </p>

            <h2>Booking details</h2>
            <p>
                Click here for the booking details report screen.
            </p>
            <p>
                <a class="btn btn-default" href="http://win-vpos7slarr4/Reports/report/MyReport/Charts">Report details &raquo;</a>
            </p>

             <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
     
    </div>
</asp:Content>
