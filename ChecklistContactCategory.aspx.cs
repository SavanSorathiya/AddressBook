using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Checklist_Contact_Category : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            FillContactCategoryCheckBoxList();

            if (Request.QueryString["NCCID"] != null)
            {
                LoadControls(Convert.ToInt32(Request.QueryString["NCCID"]));
              
            }
            
        }
        FillCountryGridView();
    }


    private void FillContactCategoryCheckBoxList()
    {
       
        SqlConnection objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
     

        try
        {
            
            if (objConnection.State != ConnectionState.Open)
            {
                objConnection.Open();
            }

            SqlCommand objCommand = objConnection.CreateCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "PR_ContactCategory_SelectDropDownList";

          

          
            SqlDataReader objSDRCntactCategory = objCommand.ExecuteReader();

            if (objSDRCntactCategory.HasRows == true)
            {
                cblContact.DataSource = objSDRCntactCategory;
                cblContact.DataTextField = "ContactCategoryName";
                cblContact.DataValueField = "ContactCategoryID";
                cblContact.DataBind();
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


    protected void btnSave_Click(object sender, EventArgs e)
    {
        //foreach (ListItem li in cblContact.Items)
        //{
        //    if(li.Selected==true)
        //    {
        //        lblMessage.Text += li + "<br/>";
        //    }
        //}
        string CblSelect = "";
        for (int i=0;i<cblContact.Items.Count;i++)
        {
            if(cblContact.Items[i].Selected)
            {
                if(CblSelect=="")
                {
                    CblSelect = cblContact.Items[i].Text;
                }
                else
                {
                    CblSelect += "," + cblContact.Items[i].Text;
                }
            }
            
        }



        SqlConnection objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);


        try
        {

            if (objConnection.State != ConnectionState.Open)
            {
                objConnection.Open();
            }

            SqlCommand objCommand = objConnection.CreateCommand();
            objCommand.CommandType = CommandType.Text;
            objCommand.CommandText = "insert into [dbo].[NewContactCategory] (NCCName) values ('" + CblSelect + "')";




           objCommand.ExecuteNonQuery();



           lblMessage.Text = "Selected value " + CblSelect ;




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
            objCommand.CommandType = CommandType.Text;
           
            objCommand.CommandText = "select * from [dbo].[NewContactCategory]";
            SqlDataReader objSDR = objCommand.ExecuteReader();

            gvNewContact.DataSource = objSDR;
            gvNewContact.DataBind();


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


    #region Load Controls
    private void LoadControls(Int32 NCCID)
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
            objCommand.CommandText = "[PR_NCC_SelectByPK]";
            objCommand.Parameters.AddWithValue("@NCCID", NCCID);
          

            SqlDataReader objSDR = objCommand.ExecuteReader();
            #endregion Set Connection & Command Object

            #region Gather Information
            if (objSDR.HasRows == true)
            {
                while (objSDR.Read())
                {
                  
                   
                    if (objSDR["NCCID"] != null)
                    {
                        cblContact.SelectedValue = objSDR["NCCID"].ToString();
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
}