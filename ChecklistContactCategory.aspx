<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChecklistContactCategory.aspx.cs" Inherits="Checklist_Contact_Category" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div >

      
        <asp:CheckBoxList ID="cblContact" runat="server"></asp:CheckBoxList>
    </div>
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Button" OnClick="btnSave_Click" />
        <br />
        <br />
        <asp:Label ID="lblMessage" runat="server" EnableViewState="False" ></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
  

        <div>
            <asp:GridView ID="gvNewContact" runat="server" >
                    <Columns>
                        <asp:templatefield headertext="edit">
                            <itemtemplate>
                               <asp:HyperLink ID="hyEdit" runat="server" NavigateUrl='<%# "~/ChecklistContactCategory.aspx?NCCID=" + Eval("NCCID").ToString().Trim() %>'>edit</asp:HyperLink>
                            </itemtemplate>
                        </asp:templatefield>
                        <asp:BoundField DataField="NCCID" HeaderText="ID"/>
                        <asp:BoundField DataField="NCCName" HeaderText="Country Name"/>
                    </Columns>
                </asp:GridView>
        </div>

    </form>
</body>
</html>
