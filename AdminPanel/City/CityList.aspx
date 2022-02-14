<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="AdminPanel_City_CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row">
            <div class="col-md-12">
                <h1>City List</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                Display List Of City><br/>
                <asp:HyperLink ID="hlAdd" runat="server" CssClass="btn btn-success" NavigateUrl="~/AdminPanel/City/CityAddEdit.aspx">Add</asp:HyperLink>
<br />
                <asp:Label ID="lblMessage" runat="server" EnableViewState="false"></asp:Label>
                <asp:GridView ID="gvCity" runat="server"  OnRowCommand="gvCity_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlEdit" runat="server" NavigateUrl='<%#"/AdminPanel/City/CityAddEdit.aspx?CityID=" + Eval("CityID")%>'><i class="fa fa-edit"></i></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete"  CssClass="btn btn-sm btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("CityID") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CityID" HeaderText="City ID"/>
                        <asp:BoundField DataField="StateID" HeaderText="State ID"/>
                        <asp:BoundField DataField="CityName" HeaderText="CIty Name"/>
                        <asp:BoundField DataField="StateName" HeaderText="State Name"/>
                        <asp:BoundField DataField="Pincode" HeaderText="PinCode"/>
                        <asp:BoundField DataField="STDCode" HeaderText="STDCode"/>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
         </asp:Content>

