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

public partial class AdminPanel_State_StateAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Session["UserID"] != null)
            {
                FillDropDownList(Convert.ToInt32(Session["UserID"].ToString()));
            }

            if (Request.QueryString["StateID"] != null)
            {
                LoadControls(Convert.ToInt32(Request.QueryString["StateID"]));
                lblHead.Text = "State Edit";
            }
            else
            {
                lblHead.Text = "State Add";
            }
        }

        

    }
    #endregion Load Event


    #region Load Controls
    private void LoadControls(Int32 StateID)
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
            objCommand.CommandText = "PR_State_SelectByPK";
            objCommand.Parameters.AddWithValue("@StateID", StateID);
            objCommand.Parameters.AddWithValue("@UserID", Session["UserID"]);

            SqlDataReader objSDR = objCommand.ExecuteReader();
            #endregion Set Connection & Command Object

            #region Gather Information
            if (objSDR.HasRows == true)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["StateName"].Equals(DBNull.Value))
                    {
                        txtStateName.Text = objSDR["StateName"].ToString();
                    }
                    if (objSDR["CountryID"] == null)
                    {
                        ddlCountry.SelectedValue = "-1";
                    }
                    else
                    {
                        ddlCountry.SelectedValue = objSDR["CountryID"].ToString();
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

    #region Fill DropDownList
    private void FillDropDownList(Int32 UserID)
    {
        SqlConnection objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {

            if (objConnection.State != ConnectionState.Open)
            {
                objConnection.Open();
            }

            SqlCommand objCommand = new SqlCommand();
            objCommand.Connection = objConnection;
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "PR_Country_SelectDropDownListByUserID";

            if (Session["UserID"] != null)
            {
                objCommand.Parameters.AddWithValue("@UserID",Convert.ToInt32(Session["UserID"].ToString()));
            }

            SqlDataReader objSDRCountry = objCommand.ExecuteReader();

            if (objSDRCountry.HasRows == true)
            {
                ddlCountry.DataSource = objSDRCountry;
                ddlCountry.DataTextField = "CountryName";
                ddlCountry.DataValueField = "CountryID";
                ddlCountry.DataBind();
            }

            ddlCountry.Items.Insert(0, new ListItem("Select Country", "-1"));


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
    #endregion Fill DropDownList

    #region Button : Save
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        #region Local Variables
        SqlString strStateName = SqlString.Null;
        SqlInt32 strCountryID = SqlInt32.Null;
        SqlConnection objConnection = new SqlConnection();
        objConnection.ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        #endregion Local Variables


        #region Server Side Validation
        String strErrorMessage = "";

        if (txtStateName.Text.Trim() == "")
        {
            strErrorMessage += "Enter State Name";
        }
        if (ddlCountry.SelectedIndex == 0)
        {
            strErrorMessage += "Select Country";
        }
        if (strErrorMessage.Trim() != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Gather Information
        if (ddlCountry.SelectedIndex > 0)
        {
            strCountryID = Convert.ToInt32(ddlCountry.SelectedValue);
        }
        if (txtStateName.Text.Trim() != "")
        {
            strStateName = txtStateName.Text.Trim();
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
            objCommand.Parameters.AddWithValue("@StateName", strStateName);
            objCommand.Parameters.AddWithValue("@CountryID", strCountryID);
            #endregion Set Connection & Command Object

            if (Request.QueryString["StateID"] == null)
            {
                #region Insert Record
                objCommand.CommandText = "PR_State_Insert";
                if (Session["UserID"] != null)
                {
                    objCommand.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"].ToString()));
                }
                objCommand.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                objCommand.ExecuteNonQuery();
                lblMessage.Text = "Data Insert Successfully.....";
                txtStateName.Text = "";
                ddlCountry.SelectedIndex = 0;
                txtStateName.Focus();
                #endregion Insert Record
            }
            else
            {
                #region Update Record
                objCommand.CommandText = "PR_State_UpdateByPK";

                if (Session["UserID"] != null)
                {
                    objCommand.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"].ToString()));
                }
                objCommand.Parameters.AddWithValue("@StateID", Request.QueryString["StateID"]);
                objCommand.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/State/StateList.aspx");
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