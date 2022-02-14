<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Product" %>

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
    <div class="container-flueid">
        <div class="row">
            <div class="col-md-12">
                <h1 class="text-center">Product</h1>
            </div>
        </div>
    
        <div class="row">
            <asp:Repeater ID="rptProduct" runat="server">
                <ItemTemplate>
                 <div class="col-md-4">
                     <div>
                        <asp:Image ID="imgProduct" runat="server" CssClass="img-fluid" ImageUrl='<%# Eval("PhotoPath") %>' AlternateText='<%#Eval("ProductName") %>' ToolTip='<%#Eval("ProductName") %>' />
                     </div>
                     <div class="text-center fw-bold p-3">
                         <%#Eval("ProductName") %>
                     </div>

                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

    </div>
    </form>
</body>
</html>
