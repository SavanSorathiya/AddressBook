<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="AdminPanel_City_CityAddEdit" %>

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
            <label for="txtCityName" class="col-md-2 col-form-label">City Name:</label>
                <div class="col-md-10">
                    <asp:TextBox ID="txtCityName" runat="server" CssClass="form-control" placeholder="Enter City Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCityName" runat="server" ErrorMessage="Enter City Name" ControlToValidate="txtCityName" Display="Dynamic" ForeColor="#CC0000" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>
         </div>
        <br />
         <div class="form-group row">
              <label for="txtPincode" class="col-md-2 col-form-label">PinCode:</label>
                <div class="col-md-4">
                    <asp:TextBox ID="txtPincode" runat="server" CssClass="form-control" placeholder="Enter Pincode"></asp:TextBox>
                     </div>
    
              <label for="txtSTDCode" class="col-md-2 col-form-label">STDCode:</label>
                <div class="col-md-4">
                    <asp:TextBox ID="txtSTDCode" runat="server" CssClass="form-control" placeholder="Enter STDcode"></asp:TextBox>
                   </div>
         </div>

         <br />
         <div class="form-group row">
            <label for="ddlState" class="col-md-2 col-form-label">State:</label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvState" runat="server" ErrorMessage="Select State" ControlToValidate="ddlState" Display="Dynamic" ForeColor="#CC0000" SetFocusOnError="True" InitialValue="-1"></asp:RequiredFieldValidator>
                </div>
         </div>
        
             <asp:Button ID="btnAdd" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnAdd_Click"/>
             <asp:HyperLink ID="hlShowAllCity" runat="server" CssClass="btn btn-danger" NavigateUrl="~/AdminPanel/City/CityList.aspx">Show All City</asp:HyperLink>

</asp:Content>

