using System;
using System.Collections.Generic;
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
        if(fuImages.HasFile)
        {
            String fileExt = System.IO.Path.GetExtension(fuImages.FileName);

            if (fileExt.ToLower() == ".jpeg" || fileExt.ToLower() == ".jpg")
            {
                string strFilePath = "~/Content/Images/";
                fuImages.SaveAs(Server.MapPath(strFilePath + fuImages.FileName));
                lblMessage.Text = "File Uploaded Successfully";
            }
            else
            {
                lblMessage.Text = "Only .jpeg or .jpg File Allowed!";
                return;
            }

            HttpPostedFile file = fuImages.PostedFile;
            int fileSize = file.ContentLength;
            if(fileSize > 1048576)
            {
                lblMessage.Text = "File Size Should be less than 1 MB";
                return;
            }
        }
        else
        {
            lblMessage.Text = "Kindly Select a File to Upload";
        }
    }
}