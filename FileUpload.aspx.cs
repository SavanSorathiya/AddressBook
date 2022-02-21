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

public partial class FileUpload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
            String strFilePath = "";
        #region File Validation
        if (fuImages.HasFile)
        {
            String fileExt = System.IO.Path.GetExtension(fuImages.FileName);

            HttpPostedFile file = fuImages.PostedFile;
            int fileSize = file.ContentLength;
            if (fileSize > 1048576)
            {
                lblMessage.Text = "File Size Should be less than 1 MB";
                return;
            }

            if (fileExt.ToLower() == ".jpeg" || fileExt.ToLower() == ".jpg")
            {
                strFilePath = "~/Content/Images/";
                fuImages.SaveAs(Server.MapPath(strFilePath + fuImages.FileName));
                lblMessage.Text = "File Uploaded Successfully";
            }
            else
            {
                lblMessage.Text = "Only .jpeg or .jpg File Allowed!";
                return;
            }

           
        }
        else
        {
            lblMessage.Text = "Kindly Select a File to Upload";
        }
        #endregion File Validation



        #region PhotoPath insert

        SqlString strPhotoName = SqlString.Null;
        SqlString strPhotoPath = SqlString.Null;

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
            
  
                objCommand.CommandText = "PR_Product_Insert";
              
                objCommand.Parameters.AddWithValue("@ProductName", fuImages.FileName);
                objCommand.Parameters.AddWithValue("@PhotoPath", strFilePath + fuImages.FileName);
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

        #endregion PhotoPath insert

}