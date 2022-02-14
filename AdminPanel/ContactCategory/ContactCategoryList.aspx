<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactCategoryList.aspx.cs" Inherits="AdminPanel_ContactCategory_ContactCategoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row">
            <div class="col-md-12">
                <h1>Contact Category List</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                Display List Of Contact Category<br />
                 <asp:HyperLink ID="hlAdd" runat="server" CssClass="btn btn-success" NavigateUrl="~/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx">Add Contact Category</asp:HyperLink>
                    <br />
                <asp:Label ID="lblMessage" runat="server" EnableViewState="false"></asp:Label>
                <asp:GridView ID="gvContactCategory" runat="server" OnRowCommand="gvContactCategory_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlEdit" runat="server" NavigateUrl='<%# "~/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx?ContactCategoryID=" + Eval("ContactCategoryID") %>'><i class="fa fa-edit"></i></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete"  CssClass="btn btn-sm btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactCategoryID") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ContactCategoryID" HeaderText="Contact Category ID" />
                        <asp:BoundField DataField="ContactCategoryName" HeaderText="Contact Category Name" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </asp:Content>

