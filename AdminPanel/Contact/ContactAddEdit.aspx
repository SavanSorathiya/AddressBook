<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactAddEdit.aspx.cs" Inherits="AdminPanel_Contact_ContactAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="col-md-12">
        <div class="row">
        
            <div class="col-md-12">
                <h1><asp:Label ID="lblHead" runat="server"></asp:Label></h1>
                
                <p>
                    <asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
                </p>
                <p>&nbsp;</p>
            </div>
        </div>   
        <div class="row">
    <div class="col-md-9">
         
        <div class="form-group row">
            <label for="txtContactName" class="col-md-2 col-form-label">Contact Name:</label>
                <div class="col-md-10">
                    <asp:TextBox ID="txtContactName" runat="server" CssClass="form-control" placeholder="Enter Contact Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvContactName" runat="server" ErrorMessage="Enter Contact Name" ControlToValidate="txtContactName" Display="Dynamic" ForeColor="#CC0000" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>
         </div>
        <br />
        <div class="form-group row">
            <label for="txtAddress" class="col-md-2 col-form-label">Enter Address:</label>
                <div class="col-md-10">
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter Address" Rows="2" TextMode="MultiLine"></asp:TextBox>
                </div>
         </div>
       <br />  

      <div class="form-group row">
             <label for="ddlContactCategory" class="col-md-2 col-form-label">Contact Category:</label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlContactCategory" runat="server" CssClass="form-control"></asp:DropDownList>
                   <%-- <asp:RequiredFieldValidator ID="rfvContactCategory" runat="server" ErrorMessage="Select Contact Category" ControlToValidate="ddlContactCategory" Display="Dynamic" ForeColor="#CC0000" SetFocusOnError="True" InitialValue="-1"></asp:RequiredFieldValidator>
                --%></div>
         </div>

      <br />
         <div class="form-group row">
             <label for="ddlCountry" class="col-md-2 col-form-label">Country:</label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ErrorMessage="Select Country" ControlToValidate="ddlCountry" Display="Dynamic" ForeColor="#CC0000" SetFocusOnError="True" InitialValue="-1"></asp:RequiredFieldValidator>
                </div>
    
              <label for="ddlState" class="col-md-2 col-form-label">State:</label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvState" runat="server" ErrorMessage="Select State" ControlToValidate="ddlState" Display="Dynamic" ForeColor="#CC0000" SetFocusOnError="True" InitialValue="-1"></asp:RequiredFieldValidator>
                </div>
         </div>
         <br />
         <div class="form-group row">
             
              <label for="ddlCity" class="col-md-2 col-form-label">City:</label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvCity" runat="server" ErrorMessage="Select City" ControlToValidate="ddlCity" Display="Dynamic" ForeColor="#CC0000" SetFocusOnError="True" InitialValue="-1"></asp:RequiredFieldValidator>
                </div>
         </div>


    <br />
         <div class="form-group row">
             <label for="txtMobileNumber" class="col-md-2 col-form-label">Mobile Number:</label>
                <div class="col-md-4">
                    <asp:TextBox ID="txtMobileNumber" runat="server" CssClass="form-control" placeholder="Enter Mobile Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvMobileNumber" runat="server" ErrorMessage="Enter Mobile Number" ControlToValidate="txtMobileNumber" Display="Dynamic" ForeColor="#CC0000" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>
    
              <label for="txtEmailAddress" class="col-md-2 col-form-label">Email Address:</label>
                <div class="col-md-4">
                    <asp:TextBox ID="txtEmailAddress" runat="server" CssClass="form-control" placeholder="Enter Email Address"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revEmailAddress" runat="server" ErrorMessage="Enter Valied EmailAddress" Display="Dynamic" ControlToValidate="txtEmailAddress" SetFocusOnError="True" ForeColor="#CC0000" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                     </div>
         </div>
         <br />
         <div class="form-group row">
              <label for="txtPincode" class="col-md-2 col-form-label">PinCode:</label>
                <div class="col-md-4">
                    <asp:TextBox ID="txtPincode" runat="server" CssClass="form-control" placeholder="Enter Pincode"></asp:TextBox>
               </div>
         </div>
         <br />

        <div class="form-group row">
              <label for="txtFacebookID" class="col-md-2 col-form-label">FaceBook ID:</label>
                <div class="col-md-4">
                    <asp:TextBox ID="txtFaceBookID" runat="server" CssClass="form-control" placeholder="Enter FaceBook ID"></asp:TextBox>
               </div>
            <label for="txtLinkedinID" class="col-md-2 col-form-label">Linkedin ID:</label>
                <div class="col-md-4">
                    <asp:TextBox ID="txtLinkedinID" runat="server" CssClass="form-control" placeholder="Enter LinkedinID"></asp:TextBox>
               </div>
         </div>

       </div>
      <div class="col-md-3 newContactCategory_backcolor">
            <div class="text-center">
                <label for="cblContactCategory"><h3>Contact Category:</h3></label>
                <asp:Label ID="lblCheckList" runat="server"></asp:Label>
            </div>
            <hr />
            <div class="row newContactCategory ">
            <asp:CheckBoxList ID="cblContactCategory" runat="server"> </asp:CheckBoxList>
            </div>
        
        </div>
        </div>
        </div>

    <br />
             <asp:Button ID="btnAdd" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnAdd_Click"/>
             <asp:HyperLink ID="hlShowAllContact" runat="server" CssClass="btn btn-danger" NavigateUrl="~/AdminPanel/Contact/ContactList.aspx">Show All Contact</asp:HyperLink>


</asp:Content>

