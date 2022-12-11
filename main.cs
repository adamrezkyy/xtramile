using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using System.Web.UI;

using System.Web.UI.WebControls;

using System.Data;

using System.Data.SqlClient;



public partial class _Default : System.Web.UI.Page

{

    protected void Page_Load(object sender, EventArgs e)

    {

        if (!IsPostBack)

        {

            BindGrid();

        }

    }



    private void BindGrid()

    {

        string constr = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Owner\Documents\Visual Studio 2010\WebSites\WebSite1\App_Data\Database1.mdf;Integrated Security=True;User Instance=True";

        using (SqlConnection con = new SqlConnection(constr))

        {

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Student"))

            {

                using (SqlDataAdapter sda = new SqlDataAdapter())

                {

                    cmd.Connection = con;

                    sda.SelectCommand = cmd;

                    using (DataTable dt = new DataTable())

                    {

                        sda.Fill(dt);

                        GridView1.DataSource = dt;

                        GridView1.DataBind();

                    }

                }

            }

        }

    }



    protected void Insert(object sender, EventArgs e)

    {

        string constr = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Owner\Documents\Visual Studio 2010\WebSites\WebSite1\App_Data\Database1.mdf;Integrated Security=True;User Instance=True";

        using (SqlConnection con = new SqlConnection(constr))

        {

            using (SqlCommand cmd = new SqlCommand("INSERT INTO Student (FirstName, LastName, StudentID, BirthDate) VALUES (@FirstName, @LastName, @StudentID, @BirthDate)"))

            {

                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);

                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);

                cmd.Parameters.AddWithValue("@StudentID", txtStudentID.Text);

                cmd.Parameters.AddWithValue("@BirthDate", txtBirthDate.Text);

                cmd.Connection = con;

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

            }

        }

        this.BindGrid();

    }



    protected void OnRowEditing(object sender, GridViewEditEventArgs e)

    {

        GridView1.EditIndex = e.NewEditIndex;

        this.BindGrid();

    }



    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)

    {

        GridViewRow row = GridView1.Rows[e.RowIndex];

        int StudentID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

        string FirstName = (row.FindControl("txtFirstName") as TextBox).Text;

        string LastName = (row.FindControl("txtLastName") as TextBox).Text;

        string StudentID = (row.FindControl("txtStudentID") as TextBox).Text;

        string BirthDate = (row.FindControl("txtBirthDate") as TextBox).Text;

        string constr = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Owner\Documents\Visual Studio 2010\WebSites\WebSite1\App_Data\Database1.mdf;Integrated Security=True;User Instance=True";

        using (SqlConnection con = new SqlConnection(constr))

        {

            using (SqlCommand cmd = new SqlCommand("UPDATE Student SET FirstName = @FirstName, LastName = @LastName, StudentID = @StudentID, BirthDate = @BirthDate WHERE StudentID = @StudentID"))

            {

                cmd.Parameters.AddWithValue("@FirstName", FirstName);

                cmd.Parameters.AddWithValue("@LastName", LastName);

                cmd.Parameters.AddWithValue("@StudentID", StudentID);

                cmd.Parameters.AddWithValue("@BirthDate", BirthDate);

                cmd.Connection = con;

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

            }

        }

        GridView1.EditIndex = -1;

        this.BindGrid();

    }



    protected void OnRowCancelingEdit(object sender, EventArgs e)

    {

        GridView1.EditIndex = -1;

        this.BindGrid();

    }



    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)

    {

        int StudentID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

        string constr = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Owner\Documents\Visual Studio 2010\WebSites\WebSite1\App_Data\Database1.mdf;Integrated Security=True;User Instance=True";

        using (SqlConnection con = new SqlConnection(constra))

        {

            using (SqlCommand cmd = new SqlCommand("DELETE FROM Student WHERE StudentID = @StudentID"))

            {

                cmd.Parameters.AddWithValue("@StudentID", StudentID);

                cmd.Connection = con;

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

            }

        }

        this.BindGrid();

    }

}
