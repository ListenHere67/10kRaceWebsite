<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyWebsite._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Letterkenny&#39;s 10k Race Web site.</h1>
        <p class="lead">This website will provide you will user and race information plus all the tools and information required to manage the Letterkenny 10k Race database.</p>
        
        <img alt="" src="./Bike.jpg" /></div>

    <div class="row">
        <div class="col-md-4">
            <h2>Reports</h2>
            <p>
                Click on this button to view race reports</p>
             <p>
                <a class="btn btn-default" href="http://win-vpos7slarr4/Reports/10KRaceReports">View reports &raquo;</a>
            </p>
           
        </div>
        <div class="col-md-4">
            <h2>Update records</h2>
            <p>
                Click here to update records in the database.
            </p>
             <p>
                <a class="btn btn-default" href="/SelectEdit.aspx">Update records &raquo;</a>
            </p>
           
        </div>
        <div class="col-md-4">
            <h2>View records</h2>
            <p>
                Click on this link to search for specific information in the database.
            </p>
            <p>
                <a class="btn btn-default" href="/search.aspx">Search records &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
