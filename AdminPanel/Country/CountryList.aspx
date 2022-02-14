<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CountryList.aspx.cs" Inherits="AdminPanel_Country_CountryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row">
            <div class="col-md-12">
                <h1>Country List</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                Display List Of Country<br />
                <asp:HyperLink ID="hlAdd" runat="server" CssClass="btn btn-success" NavigateUrl="~/AdminPanel/Country/CountryAddEdit.aspx">Add Country</asp:HyperLink>
               <br />
                <asp:Label ID="lblMessage" runat="server" EnableViewState="false"></asp:Label>

                 <asp:GridView ID="gvCountry" runat="server" OnRowCommand="gvCountry_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink ID="hyEdit" runat="server" NavigateUrl='<%# "~/AdminPanel/Country/CountryAddEdit.aspx?CountryID=" + Eval("CountryID").ToString().Trim() %>'><i class="fa fa-edit"></i></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete"  CssClass="btn btn-sm btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("CountryID") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CountryID" HeaderText="ID"/>
                        <asp:BoundField DataField="CountryCode" HeaderText="Country Code"/>
                        <asp:BoundField DataField="CountryName" HeaderText="Country Name"/>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
     
</asp:Content>

