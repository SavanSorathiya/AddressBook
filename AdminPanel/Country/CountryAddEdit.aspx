<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CountryAddEdit.aspx.cs" Inherits="AdminPanel_Country_CountryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
     <div class="row">
            <div class="col-md-12">
                <h1><asp:Label ID="lblHead" runat="server"></asp:Label></h1>
                
                <p>
                    <asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
                </p>
                <p>&nbsp;</p>
            </div>
        </div>
              <div class="mb-3">
                <label for="txtCountryName" class="form-label">Country Name:</label>
                  <asp:TextBox ID="txtCountryName" runat="server" CssClass="form-control" placeholder="Enter Country Name"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="rfvCountryName" runat="server" ErrorMessage="Enter Country Name" ControlToValidate="txtCountryName" Display="Dynamic" ForeColor="#CC0000" SetFocusOnError="True" ValidationGroup="CountryList"></asp:RequiredFieldValidator>
              </div>
              <div class="mb-3">
                <label for="txtCountryCode" class="form-label">Country Code:</label>
                  <asp:TextBox ID="txtCountryCode" runat="server" CssClass="form-control" placeholder="Enter Country Code"></asp:TextBox>
                  </div>
            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary" ValidationGroup="CountryList" OnClick="btnAdd_Click"/>
            <asp:HyperLink ID="hlShowList" runat="server" CssClass="btn btn-danger" NavigateUrl="~/AdminPanel/Country/CountryList.aspx">Show List</asp:HyperLink>
   
</asp:Content>

