<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Transactions2.aspx.cs" Inherits="MyWebsite.Transactions2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div class="jumbotron">
        <h1>Participant Race details</h1>
    </div>
    <br />
    <br />

    <br />
    <div class="lead">
        <asp:ListView ID="lstAllProducts" runat="server"
            OnItemEditing="lstAllProducts_ItemEditing"
            OnItemUpdating="lstAllProducts_ItemUpdating"
            OnItemCanceling="lstAllProducts_ItemCanceling"
            OnItemDeleting="lstAllProducts_ItemDeleting"
            InsertItemPosition="LastItem"
            OnItemInserting="lstAllProducts_ItemInserting">
            <LayoutTemplate>
                <table id="Table1" runat="server">
                    <tr id="Tr1" runat="server">
                        <td id="Td1" runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="1">
                                <tr id="Tr2" runat="server">
                                    <th id="Th1" runat="server" border="1"></th>
                                    <th id="Th2" runat="server">First Name</th>
                                    <th id="Th3" runat="server">Surname</th>
                                    <th id="Th4" runat="server">Race</th>
                                    <th id="Th5" runat="server">Time Completed</th>
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
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete"
                            Text="Delete" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>
                    <td>
                        <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="SurnameLabel" runat="server" Text='<%# Eval("Surname") %>' />
                    </td>
                    <td>
                        <asp:Label ID="RaceLBL" runat="server" Text='<%# Eval("RaceName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="TimeLBL" runat="server" Text='<%# Eval("TimeCompleted") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <EditItemTemplate>
                <tr>
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update"
                            Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel"
                            Text="Cancel" />
                    </td>
                    <asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("FirstName") %>' />
                    </td> 
                    <td>
                        <asp:TextBox ID="tbxSurname" runat="server" Text='<%# Bind("Surname") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="tbxPPSno" runat="server" Text='<%# Bind("PPSno") %>' />
                    </td>
                </tr>
            </EditItemTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert"
                            Text="Insert" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel"
                            Text="Clear" />
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="tbxFirstName" runat="server" Text='<%# Bind("FirstName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="tbxPPSno" runat="server" Text='<%# Bind("PPSno") %>' />
                    </td>

                </tr>
            </InsertItemTemplate>
        </asp:ListView>
    </div>

</asp:Content>
