<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactCategoryAddEdit.aspx.cs" Inherits="AdminPanel_ContactCategory_ContactCategoryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
 <div class="row">
            <div class="col-md-12">
                <h1><asp:Label ID="lblHead" runat="server" ></asp:Label></h1>
                
                <p> 
                    <asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
                </p>
                <p>&nbsp;</p>
            </div>
        </div>
              <div class="mb-3">
                <label for="txtContactCategoryName" class="form-label">Contact Category Name:</label>
                  <asp:TextBox ID="txtContactCategoryName" runat="server" CssClass="form-control" placeholder="Enter Contact Category Name"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="rfvContactCategoryName" runat="server" ErrorMessage="Enter Contact Category Name" ControlToValidate="txtContactCategoryName" Display="Dynamic" ForeColor="#CC0000" SetFocusOnError="True" ></asp:RequiredFieldValidator>
              </div>
            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAdd_Click"/>
            <asp:HyperLink ID="hlShowContactCategory" runat="server" CssClass="btn btn-danger" NavigateUrl="~/AdminPanel/ContactCategory/ContactCategoryList.aspx">Show List</asp:HyperLink>
   
</asp:Content>

