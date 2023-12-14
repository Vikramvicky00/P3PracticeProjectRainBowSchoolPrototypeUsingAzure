using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolWebApplicationUI
{
    public partial class Teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Bind GridView with sample data
                GridViewTeachers.DataSource = GetSampleTeachers();
                GridViewTeachers.DataBind();
            }
        }

        private DataTable GetSampleTeachers()
        {
            // Implement logic to fetch sample student data from the database
            // For simplicity, we'll use a DataTable here
            DataTable dt = new DataTable();
            dt.Columns.Add("TeacherID", typeof(int));
            dt.Columns.Add("TeacherName", typeof(string));
            dt.Columns.Add("Subject", typeof(string));

            // Add sample data
            dt.Rows.Add(1, "Sunil","Maths ");
            dt.Rows.Add(2, "Lokesh", "Science");
            return dt;
        }

        protected void GridViewTeachers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Handle row editing event
            GridViewTeachers.EditIndex = e.NewEditIndex;
            // Rebind GridView
            GridViewTeachers.DataSource = GetSampleTeachers();
            GridViewTeachers.DataBind();
        }

        protected void GridViewTeachers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Handle row canceling edit event
            GridViewTeachers.EditIndex = -1;
            // Rebind GridView
            GridViewTeachers.DataSource = GetSampleTeachers();
            GridViewTeachers.DataBind();
        }

        protected void GridViewTeachers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Handle row updating event
            int rowIndex = e.RowIndex;
            GridViewRow row = GridViewTeachers.Rows[rowIndex];

            // Retrieve edited values
            int TeacherID = Convert.ToInt32(GridViewTeachers.DataKeys[row.RowIndex].Values[0]);
            string Name = ((TextBox)row.Cells[1].Controls[0]).Text;
            String Subject =((TextBox)row.Cells[2].Controls[0]).Text;

            // Update the DataTable (in a real scenario, you would update the database here)
            DataTable dt = GetSampleTeachers();
            DataRow dr = dt.Select($"TeacherID = {TeacherID}")[0];
            dr["TeacherName"] = Name;
            dr["Subject"] = Subject;

            // Exit edit mode
            GridViewTeachers.EditIndex = -1;
            // Rebind GridView
            GridViewTeachers.DataSource = GetSampleTeachers();
            GridViewTeachers.DataBind();
        }

        protected void GridViewTeachers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Handle row deleting event
            int rowIndex = e.RowIndex;
            int TeacherID = Convert.ToInt32(GridViewTeachers.DataKeys[rowIndex].Values[0]);

            // Update the DataTable (in a real scenario, you would update the database here)
            DataTable dt = GetSampleTeachers();
            DataRow dr = dt.Select($"TeacherID = {TeacherID}")[0];
            dr.Delete();

            // Rebind GridView
            GridViewTeachers.DataSource = GetSampleTeachers();
            GridViewTeachers.DataBind();
        }

     

        protected void btnAddTeacher_Click(object sender, EventArgs e)
        {
            DataTable dt = GetSampleTeachers();
            DataRow newRow = dt.NewRow();
            newRow["TeacherID"] = dt.Rows.Count + 1;
            newRow["TeacherName"] = "New Teacher";
            newRow["Subject"] = "demo";
            dt.Rows.Add(newRow);

            // Rebind GridView
            GridViewTeachers.DataSource = GetSampleTeachers();
            GridViewTeachers.DataBind();
        }
    }
}