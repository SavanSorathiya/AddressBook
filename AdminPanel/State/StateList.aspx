<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="StateList.aspx.cs" Inherits="AdminPanel_State_StateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row">
            <div class="col-md-12">
                <h1>State List</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                Display List Of State<br />
                <asp:HyperLink ID="hlAdd" runat="server" CssClass="btn btn-success" NavigateUrl="~/AdminPanel/State/StateAddEdit.aspx">Add</asp:HyperLink>
                <br />
                 <asp:Label ID="lblMessage" runat="server" EnableViewState="false"></asp:Label>
                <asp:GridView ID="gvState" runat="server"  OnRowCommand="gvState_RowCommand">
                  <Columns>
                      <asp:TemplateField HeaderText="Edit">
                          <ItemTemplate>
                              <asp:HyperLink ID="hlEdit" runat="server" NavigateUrl='<%#"~/AdminPanel/State/StateAddEdit.aspx?StateID=" + Eval("StateID") %>'><i class="fa fa-edit"></i></asp:HyperLink>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete"  CssClass="btn btn-sm btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("StateID") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                      <asp:BoundField DataField="StateID" HeaderText="State ID"/>
                      <asp:BoundField DataField="CountryID" HeaderText="Country ID"/>
                      <asp:BoundField DataField="StateName" HeaderText="State Name"/>
                      <asp:BoundField DataField="CountryName" HeaderText="Country Name"/>
                  </Columns>
                </asp:GridView>
            </div>
        </div>
     </asp:Content>

