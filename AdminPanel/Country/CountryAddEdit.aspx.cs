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

public partial class AdminPanel_Country_CountryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {

        if(!IsPostBack)
            
        {
         
            if (Request.QueryString["CountryID"] != null)
            {
                LoadControls(Convert.ToInt32(Request.QueryString["CountryID"]));
                lblHead.Text = "Country Edit";
            }
            else
            {
                lblHead.Text = "Country Add";
            }
        }
    }
    #endregion Load Event

    #region Load Controls
    private void LoadControls(Int32 CountryID)
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
            objCommand.CommandText = "PR_Country_SelectByPK";
            objCommand.Parameters.AddWithValue("@CountryID", CountryID);
            objCommand.Parameters.AddWithValue("@UserID", Session["UserID"]);
           
            SqlDataReader objSDR = objCommand.ExecuteReader();
            #endregion Set Connection & Command Object


            #region Gather Information
            if (objSDR.HasRows == true)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["CountryName"].Equals(DBNull.Value))
                    {
                        txtCountryName.Text = objSDR["CountryName"].ToString();
                    }
                    if (!objSDR["CountryCode"].Equals(DBNull.Value))
                    {
                        txtCountryCode.Text = objSDR["CountryCode"].ToString();
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
        SqlString strCountryCode = SqlString.Null;
        SqlString strCountryName = SqlString.Null;
      
        SqlConnection objConnection = new SqlConnection();
        objConnection.ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        #endregion Local Variables

        try
        {

            #region Server Side Validation
            String strErrorMessage = "";

            if (txtCountryName.Text.Trim() == "")
            {
                strErrorMessage += "Enter Country Name <br/>";
            }

            if (strErrorMessage != "")
            {
                lblMessage.Text = strErrorMessage;
                return;
            }
            #endregion Server Side Validation


            #region Gather Information
            if (txtCountryName.Text.Trim() != "")
            {
                strCountryName = txtCountryName.Text.Trim();
            }
            if (txtCountryCode.Text.Trim() != "")
            {
                strCountryCode = txtCountryCode.Text.Trim();
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
            objCommand.Parameters.AddWithValue("@CountryName", strCountryName);
            objCommand.Parameters.AddWithValue("@CountryCode", strCountryCode);
            #endregion Set Connection & Command Object


            if (Request.QueryString["CountryID"] == null)
            {
                #region Insert Record
                objCommand.CommandText = "PR_Country_Insert";
                if (Session["UserID"] != null)
                {
                    objCommand.Parameters.AddWithValue("@UserID",Convert.ToInt32(Session["UserID"].ToString()));
                }
                objCommand.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                objCommand.ExecuteNonQuery();
                lblMessage.Text = "Data Added Successfully...";
                txtCountryName.Text = "";
                txtCountryCode.Text = "";
                txtCountryName.Focus();
                #endregion Insert Record
            }
            else
            {
                #region Update Record
                objCommand.CommandText = "PR_Country_UpdateByPK";
                if (Session["UserID"] != null)
                {
                    objCommand.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"].ToString()));
                }
                objCommand.Parameters.AddWithValue("@CountryID", Request.QueryString["CountryID"].ToString());
                objCommand.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
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