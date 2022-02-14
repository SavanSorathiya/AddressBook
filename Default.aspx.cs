using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {

        #region Server  Side Validation
        String strErrorMessage = "";
        if(txtUserName.Text.Trim()=="")
        {
            strErrorMessage += "Enter User Name <br/>";
        }
        if (txtPassword.Text.Trim() == "")
        {
            strErrorMessage += "Enter Password <br/>";
        }
        if(strErrorMessage!= "")
        {
            lblErrorMessage.Text = strErrorMessage;
            return;
        }

         
        
        #endregion Server  Side Validation


        #region Local Variables
        SqlConnection objConnection = new SqlConnection();
        objConnection.ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        #endregion Local Variables



        try
        {

            #region Set Connection & Command Object
            if (objConnection.State != ConnectionState.Open)
            {
                objConnection.Open();
            }

            SqlCommand objCommand = new SqlCommand();
            objCommand.Connection = objConnection;
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "PR_UserMaster_SelectByUserNamePassword";
            objCommand.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
            objCommand.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());

            SqlDataReader objSDR = objCommand.ExecuteReader();
            #endregion Set Connection & Command Object


            DataTable dtUser = new DataTable();
            dtUser.Load(objSDR);


            if (objConnection.State == ConnectionState.Open)
            {
                objConnection.Close();
            }


            if(dtUser!=null && dtUser.Rows.Count>0)
            {
                foreach(DataRow drUser in dtUser.Rows)
                {
                    if (!drUser["UserID"].Equals(DBNull.Value))
                    {
                        Session["UserID"] = drUser["UserID"].ToString();
                    }
                    if (!drUser["FullName"].Equals(DBNull.Value))
                    {
                        Session["FullName"] = drUser["FullName"].ToString();
                    }
                    break;
                }
                Response.Redirect("~/AdminPanel/Default.aspx");
            }
            else
            {
                
                lblErrorMessage.Text = "Either Your UserName or Password is not Valid, Please Try Again.";
                txtUserName.Text = "";
                txtPassword.Text = "";
                txtUserName.Focus();
            }



        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.Message;
        }
        finally
        {

            if (objConnection.State == ConnectionState.Open)
            {
                objConnection.Close();
            }
        }
    }
  
}