using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_AddressBookMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["FullName"] != null)
            {
                lblUserName.Text = "Hi"+ " "+ Session["FullName"].ToString();
            }
        }
    }

    protected void lbLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/Default.aspx");
    }
}
