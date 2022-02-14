using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_ContactCategory_ContactCategoryList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            FillContactCategoryGridView();
        }
    }
    #endregion Load Event

    #region gvContactCategory : RowCommand
    protected void gvContactCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
        {
            DeleteContactCategory(Convert.ToInt32(e.CommandArgument));
            FillContactCategoryGridView();
        }
    }
    #endregion gvContactCategory : RowCommand


    #region Fill GridView
    private void FillContactCategoryGridView()
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
                objCommand.CommandText = "PR_ContactCategory_SelectAllByUserId";
            }

            SqlDataReader objSDR = objCommand.ExecuteReader();

            gvContactCategory.DataSource = objSDR;
            gvContactCategory.DataBind();

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

    #region Delete ContactCategory Record
    private void DeleteContactCategory(Int32 ContactCategoryID)
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
            objCommand.CommandText = "PR_ContactCategory_DeleteByPK";
            objCommand.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID);

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
    #endregion Delete ContactCategory Record
}