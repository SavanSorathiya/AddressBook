<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="AdminPanel_Contact_ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
     <div class="row">
            <div class="col-md-12">
                <h1>Contact List</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                Display List Of Contact<br />
                 <asp:HyperLink ID="hlAdd" runat="server" CssClass="btn btn-success" NavigateUrl="~/AdminPanel/Contact/ContactAddEdit.aspx">Add</asp:HyperLink>
                    <br />
                <asp:Label ID="lblMessage" runat="server" EnableViewState="false"></asp:Label>
                <asp:GridView ID="gvContact" runat="server" OnRowCommand="gvContact_RowCommand">
               <Columns>
                   <asp:TemplateField HeaderText="Edit">
                       <ItemTemplate>
                           <asp:HyperLink ID="hlEdit" runat="server" NavigateUrl='<%# "~/AdminPanel/Contact/ContactAddEdit.aspx?ContactID=" + Eval("ContactID") %>'><i class="fa fa-edit"></i></asp:HyperLink>
                       </ItemTemplate>
                   </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete"  CssClass="btn btn-sm btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactID") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ContactID" HeaderText="Contact ID"/>
                        <asp:BoundField DataField="ContactCategoryID" HeaderText="Contact Category ID"/>
                        <asp:BoundField DataField="CityID" HeaderText="City ID"/>
                        <asp:BoundField DataField="StateID" HeaderText="State ID"/>
                        <asp:BoundField DataField="CountryID" HeaderText="Country ID"/>
                        <asp:BoundField DataField="ContactName" HeaderText="Contact Name"/>    
                        <asp:BoundField DataField="ContactCategoryName" HeaderText="Contact Category Name"/>
                        <asp:BoundField DataField="Address" HeaderText="Address"/>
                        <asp:BoundField DataField="Pincode" HeaderText="Pincode"/>
                        <asp:BoundField DataField="CityName" HeaderText="City Name"/>
                        <asp:BoundField DataField="StateName" HeaderText="State Name"/>
                        <asp:BoundField DataField="CountryName" HeaderText="Country Name"/>    
                        <asp:BoundField DataField="EmailAddress" HeaderText="Email Address"/>
                        <asp:BoundField DataField="MobileNo" HeaderText="Mobile No"/>
                        <asp:BoundField DataField="FacebookID" HeaderText="Facebook ID"/>
                        <asp:BoundField DataField="LinkedinID" HeaderText="Linkedin ID"/>    
                        
                        
               </Columns>
                </asp:GridView>
            </div>
        </div>
   </asp:Content>

