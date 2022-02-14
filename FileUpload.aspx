<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileUpload.aspx.cs" Inherits="FileUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <link href="~/Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Content/css/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="~/Content/js/bootstrap.bundle.min.js"></script>
    <script src="~/Content/js/bootstrap.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
    <div class="row">
        <div class="col-md-12">
            <h1 class="text-center">File Upload</h1>
         
        </div>
    </div>
        <br />

     <div class="row">
        <div class="col-md-12">
            <asp:FileUpload ID="fuImages" runat="server" />
            <br />
            <br />
            <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btn btn-primary" OnClick="btnUpload_Click" />
            <br />
            <asp:Label ID="lblMessage" runat="server" EnableViewState="False" ForeColor="#CC0000"></asp:Label>
        </div>
    </div>


    </div>
    </form>
</body>
</html>
