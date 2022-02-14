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

public partial class AdminPanel_City_CityAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserID"] != null)
            {
                FillDropDownList(Convert.ToInt32(Session["UserID"].ToString()));
            }

            if (Request.QueryString["CityID"] != null)
            {
                LoadControls(Convert.ToInt32(Request.QueryString["CityID"]));
                lblHead.Text = "City Edit";
            }
            else
            {
                lblHead.Text = "City Add";
            }
        }
 
    }
    #endregion Load Event

    #region Load Controls
    private void LoadControls(Int32 CityID)
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
            objCommand.CommandText = "PR_City_SelectByPK";
            objCommand.Parameters.AddWithValue("@CityID", CityID);
            objCommand.Parameters.AddWithValue("@UserID", Session["UserID"]);

            SqlDataReader objSDR = objCommand.ExecuteReader();
            #endregion Set Connection & Command Object


            #region Gather Information
            if (objSDR.HasRows == true)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["CityName"].Equals(DBNull.Value))
                    {
                        txtCityName.Text = objSDR["CityName"].ToString();
                    }
                    if (!objSDR["PinCode"].Equals(DBNull.Value))
                    {
                        txtPincode.Text = objSDR["PinCode"].ToString();
                    }
                    if (!objSDR["STDCode"].Equals(DBNull.Value))
                    {
                        txtSTDCode.Text = objSDR["STDCode"].ToString();
                    }
                    if (objSDR["StateID"] == null)
                    {
                        ddlState.SelectedValue = "-1";
                    }
                    else
                    {
                        ddlState.SelectedValue = objSDR["StateID"].ToString();
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

            objCommand.CommandText = "PR_State_SelectDropDownListByUserID";


            if (Session["UserID"] != null)
            {
                objCommand.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"].ToString()));
            }

            SqlDataReader objSDRState = objCommand.ExecuteReader();
            #endregion Set Connection & Command Object

            #region Gather Information
            if (objSDRState.HasRows == true)
            {
                ddlState.DataSource = objSDRState;
                ddlState.DataTextField = "StateName";
                ddlState.DataValueField = "StateID";
                ddlState.DataBind();
            }

                ddlState.Items.Insert(0, new ListItem("Select State", "-1"));
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
    #endregion Fill DropDownList

    #region Button : Save
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        #region Local Variables
        SqlInt32 strStateID = SqlInt32.Null;
        SqlString strCityName = SqlString.Null;
        SqlString strPincode = SqlString.Null;
        SqlString strSTDCode = SqlString.Null;
        SqlConnection objConnection = new SqlConnection();
        objConnection.ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        #endregion Local Variables


        #region Server Side Validation
        String strErrorMessage = "";

        if (ddlState.SelectedIndex == 0)
        {
            strErrorMessage += "Select State<br/>";
        }
        if (txtCityName.Text.Trim() == "")
        {
            strErrorMessage += "Enter City Name<br/>";
        }
        if (strErrorMessage.Trim() != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Gather Information
        if (ddlState.SelectedIndex > 0)
        {
            strStateID = Convert.ToInt32(ddlState.SelectedValue);
        }
        if (txtCityName.Text.Trim() != "")
        {
            strCityName = txtCityName.Text.Trim();
        }
        if (txtPincode.Text.Trim() != "")
        {
            strPincode = txtPincode.Text.Trim();
        }
        if (txtSTDCode.Text.Trim() != "")
        {
            strSTDCode = txtSTDCode.Text.Trim();
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
            objCommand.Parameters.AddWithValue("@CityName", strCityName);
            objCommand.Parameters.AddWithValue("@pincode", strPincode);
            objCommand.Parameters.AddWithValue("@STDCode", strSTDCode);
            objCommand.Parameters.AddWithValue("@StateID", strStateID);
            #endregion Set Connection & Command Object


            if (Request.QueryString["CityID"] == null)
            {
                #region Insert Record
                objCommand.CommandText = "PR_City_Insert";
                if (Session["UserID"] != null)
                {
                    objCommand.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"].ToString()));
                }
                objCommand.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                objCommand.ExecuteNonQuery();
                lblMessage.Text = "Data Added Successfully...";
                txtCityName.Text = "";
                txtPincode.Text = "";
                txtSTDCode.Text = "";
                ddlState.SelectedIndex = 0;
                #endregion Insert Record
            }
            else
            {

                #region Update Record
                objCommand.CommandText = "PR_City_UpdateByPK";

                if (Session["UserID"] != null)
                {
                    objCommand.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"].ToString()));
                }

                objCommand.Parameters.AddWithValue("@CityID", Request.QueryString["CityID"]);
                objCommand.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/City/CityList.aspx");

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