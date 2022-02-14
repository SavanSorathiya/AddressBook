using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_City_CityList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
     if(!IsPostBack)
     {
         FillCityGridView();
     }
    }
    #endregion Load Event

    #region gvCity : RowCommand
    protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
        {
            DeleteCity(Convert.ToInt32(e.CommandArgument));
            FillCityGridView();
        }
    }
    #endregion gvCity : RowCommand

    #region Fill GridView
    private void FillCityGridView()
    {
        SqlConnection objConnection = new SqlConnection();
        objConnection.ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString; ;

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
                objCommand.CommandText = "PR_City_SelectAllByUserId";
            }

            SqlDataReader objSDR = objCommand.ExecuteReader();

            gvCity.DataSource = objSDR;
            gvCity.DataBind();

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

    #region Delete City Record
    private void DeleteCity(Int32 CityID)
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
            objCommand.CommandText = "PR_City_DeleteByPK";
            objCommand.Parameters.AddWithValue("@CityID", CityID);

            objCommand.ExecuteNonQuery();

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
    #endregion Delete City Record

}