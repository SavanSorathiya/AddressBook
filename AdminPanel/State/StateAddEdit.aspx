<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="StateAddEdit.aspx.cs" Inherits="AdminPanel_State_StateAddEdit" %>

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
      <div class="form-group row">
            <label for="txtStateName" class="col-md-2 col-form-label">State Name:</label>
                <div class="col-md-10">
                    <asp:TextBox ID="txtStateName" runat="server" CssClass="form-control" placeholder="Enter State Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvStateName" runat="server" ErrorMessage="Enter State Name" ControlToValidate="txtStateName" Display="Dynamic" ForeColor="#CC0000" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>
         </div>
    <br />

    <div class="form-group row">
              <label for="ddlCountry" class="col-md-2 col-form-label">Country:</label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ErrorMessage="Select Country" ControlToValidate="ddlCountry" Display="Dynamic" ForeColor="#CC0000" SetFocusOnError="True" InitialValue="-1"></asp:RequiredFieldValidator>
                </div>
    </div>
    <br />

      <asp:Button ID="btnAdd" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnAdd_Click"/>
      <asp:HyperLink ID="hlShowAllState" runat="server" CssClass="btn btn-danger" NavigateUrl="~/AdminPanel/State/StateList.aspx">Show All State</asp:HyperLink>

</asp:Content>

