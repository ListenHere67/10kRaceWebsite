<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SelectEdit.aspx.cs" Inherits="MyWebsite.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2> Modify Database</h2>
    
    <p>Please to modifiy either Participant Details or the Race Details below.</p>

     <div class="row">
        <div class="col-md-4">
            <h2>Race Participants</h2>
            <p>
                Click here to modify the Participant Details.
            </p>
            <p>
                <a class="btn btn-default" href="./Transactions.aspx">Participant Details &raquo;</a>
            </p>

            <p>
                &nbsp;</p>

            <p>
                &nbsp;</p>
        </div>

           <div class="row">
        <div class="col-md-4">
            <h2>Race Details</h2>
            <p>
                Click here to modify the Race Details.
            </p>
            <p>
                <a class="btn btn-default" href="./Transactions2.aspx">Race Details &raquo;</a>
            </p>

            <p>
                &nbsp;</p>

            <p>
                &nbsp;</p>
        </div>
     
    </div>








</asp:Content>
