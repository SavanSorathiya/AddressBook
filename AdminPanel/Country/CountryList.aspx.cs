using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Country_CountryList : System.Web.UI.Page
{

    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            FillCountryGridView();
        }
    }
    #endregion Load Event

    #region gvCountry : RowCommand
    protected void gvCountry_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName == "DeleteRecord" && e.CommandArgument!= null)
        {
            DeleteCountry(Convert.ToInt32(e.CommandArgument));
            FillCountryGridView();
        }
    }
    #endregion gvCountry : RowCommand

    #region Fill GridView
    private void FillCountryGridView()
    {
        SqlConnection objConnection = new SqlConnection();
        objConnection.ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;

        try
        {
            if (objConnection.State != ConnectionState.Open)
            {
                objConnection.Open();
            }

            SqlCommand objCommand = new SqlCommand();
            objCommand.Connection = objConnection;
            objCommand.CommandType = CommandType.StoredProcedure;
            if (Session["UserID"] != null)
            {
                objCommand.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"].ToString()));
                objCommand.CommandText = "PR_Country_SelectAllByUserId";
            }

            SqlDataReader objSDR = objCommand.ExecuteReader();

            gvCountry.DataSource = objSDR;
            gvCountry.DataBind();


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
    #endregion Fill GridView

    #region Delete Country Record
    private void DeleteCountry(Int32 CountryID)
    {
        SqlConnection objConnection = new SqlConnection();
        objConnection.ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;

        try
        {

            if (objConnection.State != ConnectionState.Open)
            {
                objConnection.Open();
            }

            SqlCommand objCommand = new SqlCommand();
            objCommand.Connection = objConnection;
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "PR_Country_DeleteByPK";
            objCommand.Parameters.AddWithValue("@CountryID", CountryID);

            objCommand.ExecuteNonQuery();


            if (objConnection.State == ConnectionState.Open)
            {
                objConnection.Close();
            }
        }
        catch(Exception ex)
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
    #endregion Delete Country Record
}