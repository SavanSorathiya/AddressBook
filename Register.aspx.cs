using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
         #region Local Variables
        SqlString strFullName = SqlString.Null;
        SqlString strUserName = SqlString.Null;
        SqlString strPassword = SqlString.Null;
        SqlString strMobileNo = SqlString.Null;
        SqlString strEmail = SqlString.Null;
        SqlString strAddress = SqlString.Null;
        SqlString strFacebookID = SqlString.Null;
        SqlString strBirthDate = SqlString.Null;
      
        SqlConnection objConnection = new SqlConnection();
        objConnection.ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        #endregion Local Variables

        try
        {

            #region Server Side Validation
            String strErrorMessage = "";

            if (txtUserName.Text.Trim() == "")
            {
                strErrorMessage += "Enter User Name <br/>";
            }
            if (txtFullName.Text.Trim() == "")
            {
                strErrorMessage += "Enter Full Name <br/>";
            }

            if (txtPassword.Text.Trim() == "")
            {
                strErrorMessage += "Enter Password <br/>";
            }

            if (strErrorMessage != "")
            {
                lblMessage.Text = strErrorMessage;
                return;
            }
            #endregion Server Side Validation


            #region Gather Information
            if (txtFullName.Text.Trim() != "")
            {
                strFullName = txtFullName.Text.Trim();
            }
            if (txtUserName.Text.Trim() != "")
            {
                strUserName = txtUserName.Text.Trim();
            }
              if (txtPassword.Text.Trim() != "")
            {
                strPassword = txtPassword.Text.Trim();
            }
              if (txtMobileNo.Text.Trim() != "")
            {
                strMobileNo = txtMobileNo.Text.Trim();
            }
              if (txtEmail.Text.Trim() != "")
            {
                strEmail = txtEmail.Text.Trim();
            }
              if (txtAddress.Text.Trim() != "")
            {
                strAddress = txtAddress.Text.Trim();
            }
              if (txtBirthDate.Text.Trim() != "")
            {
                strBirthDate = txtBirthDate.Text.Trim();
            }
              if (txtFacebookID.Text.Trim() != "")
            {
                strFacebookID = txtFacebookID.Text.Trim();
            }
             
            #endregion Gather Information


            #region Set Connection & Command Object
            if (objConnection.State != ConnectionState.Open)
            {
                objConnection.Open();
            }

            SqlCommand objCommand = new SqlCommand();
            objCommand.Connection = objConnection;
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@UserName", strUserName);
            objCommand.Parameters.AddWithValue("@Password", strPassword);
            objCommand.Parameters.AddWithValue("@FullName", strFullName);
            objCommand.Parameters.AddWithValue("@Address", strAddress);
            objCommand.Parameters.AddWithValue("@MobileNo", strMobileNo);
            objCommand.Parameters.AddWithValue("@EmailID", strEmail);
            objCommand.Parameters.AddWithValue("@FacebookID", strFacebookID);
            objCommand.Parameters.AddWithValue("@BirthDate", strBirthDate);
            objCommand.Parameters.AddWithValue("@CreationDate", DateTime.Now);
            #endregion Set Connection & Command Object


           
                #region Insert Record
                objCommand.CommandText = "PR_UserMaster_Insert";
                if (Session["UserID"] != null)
                {
                    objCommand.Parameters.AddWithValue("@UserID",Convert.ToInt32(Session["UserID"].ToString()));
                }
               
                objCommand.ExecuteNonQuery();
                lblMessage.Text = "Registration Successfully...";
               txtUserName.Text="";
               txtFullName.Text="";
               txtPassword.Text="";
               txtMobileNo.Text="";
               txtEmail.Text="";
               txtAddress.Text="";
               txtBirthDate.Text="";
               txtFacebookID.Text="";
               txtUserName.Focus();
                #endregion Insert Record
          
          
           
            if (objConnection.State == ConnectionState.Open)
            {
                objConnection.Close();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
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
