using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Product : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            FillProduct();
        }
    }

    private void FillProduct()
    {

        SqlConnection objConnection = new SqlConnection();
        objConnection.ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        objConnection.Open();

        SqlCommand objCommand = new SqlCommand();
        objCommand.Connection = objConnection;
        objCommand.CommandType = CommandType.StoredProcedure;
        objCommand.CommandText = "PR_Product_SelectAll";

        SqlDataReader objSDR =objCommand.ExecuteReader();

        DataTable dtProduct = new DataTable();
        dtProduct.Load(objSDR);

        rptProduct.DataSource = dtProduct;
        rptProduct.DataBind();

        objConnection.Close();
    }
}