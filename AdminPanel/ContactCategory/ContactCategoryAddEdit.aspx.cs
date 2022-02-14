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

public partial class AdminPanel_ContactCategory_ContactCategoryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if(Request.QueryString["ContactCategoryID"]!=null)
            {
                LoadControls(Convert.ToInt32(Request.QueryString["ContactCategoryID"]));
                lblHead.Text = "Contact Category Edit";
            }
            else
            {
                lblHead.Text = "Contact Category Add";
            }
        }


    }
    #endregion Load Event

    #region Load Controls
    private void LoadControls(Int32 ContactCategoryID)
    {
        #region Local Variables
        SqlConnection objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Local Variables

        try
        {
            #region Set Connection & Command Object
            if (objConnection.State != ConnectionState.Open)
            {
                objConnection.Open();
            }

            SqlCommand objCommand = objConnection.CreateCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "PR_ContactCategory_SelectByPK";
            objCommand.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID);
            objCommand.Parameters.AddWithValue("@UserID", Session["UserID"]);

            SqlDataReader objSDR = objCommand.ExecuteReader();
            #endregion Set Connection & Command Object

            #region Gather Information
            if (objSDR.HasRows == true)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["ContactCategoryName"].Equals(DBNull.Value))
                    {
                        txtContactCategoryName.Text = objSDR["ContactCategoryName"].ToString();
                    }
                }
            }
            #endregion Gather Information

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
    #endregion Load Controls

    #region Button : Save
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        #region Local Variables
        SqlString strContactCategoryName = SqlString.Null;
        SqlConnection objConnection = new SqlConnection();
        objConnection.ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        #endregion Local Variables

        #region Server Side Validation
        String strErrorMessage="";

        if(txtContactCategoryName.Text.Trim()=="")
        {
            strErrorMessage += "Enter Contact Category<br/>";
        }
        if(strErrorMessage!="")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Gather Information
        if (txtContactCategoryName.Text.Trim() != "")
        {
            strContactCategoryName = txtContactCategoryName.Text.Trim();
        }
        #endregion Gather Information

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
            objCommand.Parameters.AddWithValue("@ContactCategoryName", strContactCategoryName);
            #endregion Set Connection & Command Object

            if (Request.QueryString["ContactCategoryID"] == null)
            {
                #region Insert Record
                objCommand.CommandText = "PR_ContactCategory_Insert";
                if (Session["UserID"] != null)
                {
                    objCommand.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"].ToString()));
                }
                objCommand.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                objCommand.ExecuteNonQuery();
                lblMessage.Text = "Data Insert Successfully.....";
                txtContactCategoryName.Text = "";
                txtContactCategoryName.Focus();
                #endregion Insert Record
            }
            else
            {
                #region Update Record
                objCommand.CommandText = "PR_ContactCategory_UpdateByPK";

                if (Session["UserID"] != null)
                {
                    objCommand.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"].ToString()));
                }

                objCommand.Parameters.AddWithValue("@ContactCategoryID", Request.QueryString["ContactCategoryID"]);
                objCommand.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/ContactCategory/ContactCategoryList.aspx");
                #endregion Update Record

            }
            
           
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
    #endregion Button : Save
}