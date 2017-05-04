<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="MyWebsite.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-4">
        <h1>Search for a record</h1>
    </div>
    <br />
    <br />
    <p>
        Please select which database you would like to search from the drop down box
    </p>
    <div class="form-group">
        <div class="col-md-10">
            <asp:DropDownList ID="cboDatabaseChoice" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="cboDatabaseChoice_SelectedIndexChanged" runat="server">
                <asp:ListItem>Participants</asp:ListItem>
                <asp:ListItem>Race History</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="tbxSearchText" CssClass="col-md-2 control-label">Search text</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="tbxSearchText" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="tbxSearchText"
                CssClass="text-danger" ErrorMessage="Text is required in the search box." />
        </div>
    </div>
    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <asp:Button runat="server" OnClick="Search_Click" Text="Search" CssClass="btn btn-default" />
        </div>
    </div>

    <p>


        <div class="lead">
            <asp:ListView ID="lstAllProducts" runat="server" Visible="false"
                
                
                >
                <LayoutTemplate>
                    <table id="Table1" runat="server">
                        <tr id="Tr1" runat="server">
                            <td id="Td1" runat="server">
                                <table id="itemPlaceholderContainer" runat="server" border="1">
                                    <tr id="Tr2" runat="server">
                                        <th id="Th1" runat="server" border="1"></th>
                                        <th id="Th2" runat="server">FirstName</th>
                                        <th id="Th3" runat="server">Surname</th>
                                        <th id="Th4" runat="server">PPSno</th>
                                    </tr>
                                    <tr id="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr id="Tr3" runat="server">
                            <td id="Td2" runat="server" style=""></td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                           
                        </td>
                        <td>
                            <asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("FirstName") %>' />
                        </td>
                        <td>
                            <asp:Label ID="tbxSurname" runat="server" Text='<%# Eval("Surname") %>' />
                        </td>
                        <td>
                            <asp:Label ID="tbxPPSno" runat="server" Text='<%# Eval("PPSno") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
               
               
            </asp:ListView>
        </div>
    </p>

</asp:Content>
