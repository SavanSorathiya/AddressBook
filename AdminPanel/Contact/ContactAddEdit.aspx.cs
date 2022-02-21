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

public partial class AdminPanel_Contact_ContactAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            FillContactCategoryCheckBoxList();
            if (Session["UserID"] != null)
            {
                FillCountryDropDownList(Convert.ToInt32(Session["UserID"].ToString()));
                FillContactCategoryDropDownList(Convert.ToInt32(Session["UserID"].ToString()));
                
            }

            if (Request.QueryString["ContactID"] != null)
            {
                LoadControls(Convert.ToInt32(Request.QueryString["ContactID"]));
                lblHead.Text = "Contact Edit";
            }
            else
            {
                lblHead.Text = "Contact Add";
            }
        }
        

    }
    #endregion Load Event

    #region Load Controls
    private void LoadControls(Int32 ContactID)
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
            objCommand.CommandText = "PR_Contact_SelectByPK";
            objCommand.Parameters.AddWithValue("@ContactID", ContactID);
            objCommand.Parameters.AddWithValue("@UserID", Session["UserID"]);

            //ContactCategoryCheckBoxListFillControl(Convert.ToInt32(Request.QueryString["ContactID"]));

            SqlDataReader objSDR = objCommand.ExecuteReader();
            #endregion Set Connection & Command Object

            #region Gather Information
            if (objSDR.HasRows == true)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["ContactName"].Equals(DBNull.Value))
                    {
                        txtContactName.Text = objSDR["ContactName"].ToString();
                    }
                    if (!objSDR["Address"].Equals(DBNull.Value))
                    {
                        txtAddress.Text = objSDR["Address"].ToString();
                    }
                    if (!objSDR["MobileNo"].Equals(DBNull.Value))
                    {
                        txtMobileNumber.Text = objSDR["MobileNo"].ToString();
                    }
                    if (!objSDR["EmailAddress"].Equals(DBNull.Value))
                    {
                        txtEmailAddress.Text = objSDR["EmailAddress"].ToString();
                    }
                    if (!objSDR["FaceBookID"].Equals(DBNull.Value))
                    {
                        txtFaceBookID.Text = objSDR["FaceBookID"].ToString();
                    }
                    if (!objSDR["LinkedinID"].Equals(DBNull.Value))
                    {
                        txtLinkedinID.Text = objSDR["LinkedinID"].ToString();
                    }
                    if (!objSDR["PinCode"].Equals(DBNull.Value))
                    {
                        txtPincode.Text = objSDR["PinCode"].ToString();
                    }
                    if (objSDR["CountryID"] == null)
                    {
                        ddlCountry.SelectedValue = "-1";
                    }
                    else
                    {
                        ddlCountry.SelectedValue = objSDR["CountryID"].ToString();
                    }
                    if (objSDR["StateID"] == null)
                    {
                        ddlState.SelectedValue = "-1";
                    }
                    else
                    {
                        FillStateDropDownList();
                        ddlState.SelectedValue = objSDR["StateID"].ToString();
                    }
                    if (objSDR["CityID"] == null)
                    {
                        ddlCity.SelectedValue = "-1";
                    }
                    else
                    {
                        FillCityDropDownList();
                        ddlCity.SelectedValue = objSDR["CityID"].ToString();
                    }
                    if (objSDR["ContactCategoryID"] == null)
                    {
                        ddlContactCategory.SelectedValue = "-1";
                    }
                    else
                    {
                        ddlContactCategory.SelectedValue = objSDR["ContactCategoryID"].ToString();
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

    #region Fill Country DropDownList
    private void FillCountryDropDownList(Int32 UserID)
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
            objCommand.CommandText = "PR_Country_SelectDropDownListByUserID";

            if (Session["UserID"] != null)
            {
                objCommand.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"].ToString()));
            }

            #endregion Set Connection & Command Object

             #region Country Data Reader
            SqlDataReader objSDRCountry = objCommand.ExecuteReader();
           
            if (objSDRCountry.HasRows == true)
            {
                ddlCountry.DataSource = objSDRCountry;
                ddlCountry.DataTextField = "CountryName";
                ddlCountry.DataValueField = "CountryID";
                ddlCountry.DataBind();
            }

            ddlCountry.Items.Insert(0, new ListItem("Select Country", "-1"));

           
             #endregion Country Data Reader

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

    #region Fill State DropDownList
    private void FillStateDropDownList()
    {
        #region Local Variables
        SqlConnection objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        SqlInt32 strCountryID = SqlInt32.Null;
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

            objCommand.CommandText = "PR_State_SelectDropDownListByCountryID";

            if(ddlCountry.SelectedIndex>0)
            {
                strCountryID = Convert.ToInt32(ddlCountry.SelectedValue);
            }
            //if (Session["UserID"] != null)
            //{
            //    objCommand.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"].ToString()));
            //}
            objCommand.Parameters.AddWithValue("@CountryID", strCountryID);

            SqlDataReader objSDRState = objCommand.ExecuteReader();

            if (objSDRState.HasRows == true)
            {
                ddlState.DataSource = objSDRState;
                ddlState.DataTextField = "StateName";
                ddlState.DataValueField = "StateID";
                ddlState.DataBind();
            }

            ddlState.Items.Insert(0, new ListItem("Select State", "-1"));


            #endregion State Data Reader



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
    #endregion Fill State DropDownList

    #region Fill City DropDownList
    private void FillCityDropDownList()
    {
        #region Local Variables
        SqlConnection objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        SqlInt32 strStateID = SqlInt32.Null;
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

            objCommand.CommandText = "PR_City_SelectDropDownListByStateID";

            if (ddlState.SelectedIndex > 0)
            {
                strStateID = Convert.ToInt32(ddlState.SelectedValue);
            }
            objCommand.Parameters.AddWithValue("@StateID", strStateID);
          //  if (Session["UserID"] != null)
            //{
           //     objCommand.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"].ToString()));
            //}


            SqlDataReader objSDRCity= objCommand.ExecuteReader();

            if (objSDRCity.HasRows == true)
            {
                ddlCity.DataSource = objSDRCity;
                ddlCity.DataTextField = "CityName";
                ddlCity.DataValueField = "CityID";
                ddlCity.DataBind();
            }

          ddlCity.Items.Insert(0, new ListItem("Select City", "-1"));

            


            #endregion State Data Reader



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
    #endregion Fill City DropDownList

    #region Fill Contact Category DropDownList
    private void FillContactCategoryDropDownList(Int32 UserID)
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

            objCommand.CommandText = "PR_ContactCategory_SelectDropDownListByUserID";

            if (Session["UserID"] != null)
            {
                objCommand.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"].ToString()));
            }


            SqlDataReader objSDRContactCategory = objCommand.ExecuteReader();

            if (objSDRContactCategory.HasRows == true)
            {
                ddlContactCategory.DataSource = objSDRContactCategory;
                ddlContactCategory.DataTextField = "ContactCategoryName";
                ddlContactCategory.DataValueField = "ContactCategoryID";
                ddlContactCategory.DataBind();
            }

            ddlContactCategory.Items.Insert(0, new ListItem("Select Contact Category", "-1"));



            #endregion State Data Reader



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
    #endregion Fill Contact Category DropDownList

    #region Button : Save
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        #region Local Variables
        SqlString strContactName = SqlString.Null;
        SqlString strAddress = SqlString.Null;
        SqlInt32 strContactCategoryID = SqlInt32.Null;
        SqlInt32 strCityID = SqlInt32.Null;
        SqlInt32 strStateID = SqlInt32.Null;
        SqlInt32 strCountryID = SqlInt32.Null;
        SqlString strMobileNumber = SqlString.Null;
        SqlString strEmailAddress = SqlString.Null;
        SqlString strPincode = SqlString.Null;
        SqlString strFaceBookID = SqlString.Null;
         SqlString strLinkedinID = SqlString.Null;

         SqlConnection objConnection = new SqlConnection();
         objConnection.ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
         #endregion Local Variables

         #region Server Side Validation
         String strErrorMessage = "";

       
        //if (ddlContactCategory.SelectedIndex == 0)
        //{
        //    strErrorMessage += "Select Contact category<br/>";
        //}
        if (ddlCity.SelectedIndex == 0)
        {
            strErrorMessage += "Select City<br/>";
        }
        if (ddlState.SelectedIndex == 0)
        {
            strErrorMessage += "Select State<br/>";
        }
        if (ddlCountry.SelectedIndex == 0)
        {
            strErrorMessage += "Select Country<br/>";
        }
        if (txtContactName.Text.Trim() == "")
        {
            strErrorMessage += "Enter Contact Name<br/>";
        }
        if (txtMobileNumber.Text.Trim() == "")
        {
            strErrorMessage += "Enter Mobile Number<br/>";
        }
        if (strErrorMessage.Trim() != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Gather Information
        if (ddlContactCategory.SelectedIndex > 0)
        {
            strContactCategoryID = Convert.ToInt32(ddlContactCategory.SelectedValue);
        }
        if (ddlCity.SelectedIndex > 0)
        {
            strCityID = Convert.ToInt32(ddlCity.SelectedValue);
        }
        if (ddlState.SelectedIndex > 0)
        {
            strStateID = Convert.ToInt32(ddlState.SelectedValue);
        }
        if (ddlCountry.SelectedIndex > 0)
        {
            strCountryID = Convert.ToInt32(ddlCountry.SelectedValue);
        }
        if (txtContactName.Text.Trim() != "")
        {
            strContactName = txtContactName.Text.Trim();
        }
        if (txtMobileNumber.Text.Trim() != "")
        {
            strMobileNumber = txtMobileNumber.Text.Trim();
        }
        if (txtAddress.Text.Trim() != "")
        {
            strAddress = txtAddress.Text.Trim();
        }
        if (txtEmailAddress.Text.Trim() != "")
        {
            strEmailAddress = txtEmailAddress.Text.Trim();
        }
        if (txtPincode.Text.Trim() != "")
        {
            strPincode = txtPincode.Text.Trim();
        }
        if (txtFaceBookID.Text.Trim() != "")
        {
            strFaceBookID = txtFaceBookID.Text.Trim();
        }
        if (txtLinkedinID.Text.Trim() != "")
        {
            strLinkedinID = txtLinkedinID.Text.Trim();
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
            objCommand.Parameters.AddWithValue("@ContactCategoryID", strContactCategoryID);
            objCommand.Parameters.AddWithValue("@ContactName", strContactName);
            objCommand.Parameters.AddWithValue("@Address", strAddress);
            objCommand.Parameters.AddWithValue("@Pincode", strPincode);
            objCommand.Parameters.AddWithValue("@CityID", strCityID);
            objCommand.Parameters.AddWithValue("@StateID", strStateID);
            objCommand.Parameters.AddWithValue("@CountryID", strCountryID);
            objCommand.Parameters.AddWithValue("@EmailAddress", strEmailAddress);
            objCommand.Parameters.AddWithValue("@MobileNo", strMobileNumber);
            objCommand.Parameters.AddWithValue("@FacebookID", strFaceBookID);
            objCommand.Parameters.AddWithValue("@LinkedinID", strLinkedinID);
            #endregion Set Connection & Command Object


            if (Request.QueryString["ContactID"] == null)
            {
                #region Insert Record
                objCommand.CommandText = "PR_Contact_Insert";
                if (Session["UserID"] != null)
                {
                    objCommand.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"].ToString()));
                }
                objCommand.Parameters.AddWithValue("@CreationDate", DateTime.Now);

                #region Out Parameter
                objCommand.Parameters.Add("@ContactID", SqlDbType.Int, 20).Direction = ParameterDirection.Output;
              
                #endregion Out Parameter


                objCommand.ExecuteNonQuery();

                #region Get Parameter
                SqlInt32 ContactID = 0;
                ContactID = Convert.ToInt32(objCommand.Parameters["@ContactID"].Value);
                #endregion Get Parameter

             
                foreach(ListItem liContactCategoryID in cblContactCategory.Items)
                {
                    if(liContactCategoryID.Selected)
                    {
                        SqlCommand objCmdContactCategory = new SqlCommand();
                        objCmdContactCategory.Connection = objConnection;
                        objCmdContactCategory.CommandType = CommandType.StoredProcedure;
                        objCmdContactCategory.CommandText = "[PR_ContactWiseContactCategory_Insert]";
                        objCmdContactCategory.Parameters.AddWithValue("@ContactID", ContactID.ToString());
                        objCmdContactCategory.Parameters.AddWithValue("@ContactCategoryID", liContactCategoryID.Value.ToString());
                        objCmdContactCategory.ExecuteNonQuery();
                    }
                }


                lblMessage.Text = "Data Added Successfully...";
                txtContactName.Text = "";
                txtAddress.Text = "";
                txtMobileNumber.Text = "";
                txtEmailAddress.Text = "";
                txtPincode.Text = "";
                txtFaceBookID.Text = "";
                txtLinkedinID.Text = "";
                ddlState.SelectedIndex = 0;
                ddlCountry.SelectedIndex = 0;
                ddlCity.SelectedIndex = 0;
                ddlContactCategory.SelectedIndex = 0;
                txtContactName.Focus();
                #endregion Insert Record


            }
            else
            {
                #region Update Record
                objCommand.CommandText = "PR_Contact_UpdateByPK";

                if (Session["UserID"] != null)
                {
                    objCommand.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"].ToString()));
                }

                objCommand.Parameters.AddWithValue("@ContactID", Request.QueryString["ContactID"]);
                objCommand.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/Contact/ContactList.aspx");
                ContactCategoryCheckBoxListFillControl(Convert.ToInt32(Request.QueryString["ContactID"]));

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


    #region State Select By Country
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillStateDropDownList();
    }
    #endregion State Select By Country

    #region City Select By State
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillCityDropDownList();
    }
    #endregion City Select By State


    #region Contact Category Checklist
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




            SqlDataReader objSDRCotactCategory = objCommand.ExecuteReader();

            if (objSDRCotactCategory.HasRows == true)
            {
                cblContactCategory.DataSource = objSDRCotactCategory;
                cblContactCategory.DataTextField = "ContactCategoryName";
                cblContactCategory.DataValueField = "ContactCategoryID";
                cblContactCategory.DataBind();
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
    #endregion Contact Category Checklist


    //#region Contact Category Checklist Fill Control
    //private void ContactCategoryCheckBoxListFillControl(SqlInt32 ContactID)
    //{

    //    SqlConnection objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);


    //    try
    //    {

    //        if (objConnection.State != ConnectionState.Open)
    //        {
    //            objConnection.Open();
    //        }

    //        SqlCommand objCommand = objConnection.CreateCommand();
    //        objCommand.CommandType = CommandType.StoredProcedure;
    //        objCommand.CommandText = "PR_ContactCategory_SelectDropDownList";




    //        SqlDataReader objSDRCotactCategory = objCommand.ExecuteReader();




    //        while (objSDRCotactCategory.Read())
    //        {
    //            foreach (ListItem Cbl in cblContactCategory.Items)
    //            {
    //                if (objSDRCotactCategory["ContactCategoryID"].ToString() == Request.QueryString["ContactID"])
    //                {
    //                    Cbl.Selected = true;
    //                }
    //            }
    //            break;
    //        }


    //        if (objConnection.State == ConnectionState.Open)
    //        {
    //            objConnection.Close();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMessage.Text = ex.Message;
    //    }
    //    finally
    //    {
    //        if (objConnection.State == ConnectionState.Open)
    //        {
    //            objConnection.Close();
    //        }
    //    }

    //}
    //#endregion Contact Category Checklist Fill Control

}