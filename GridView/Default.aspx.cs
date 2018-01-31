#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
#endregion Using directives

namespace GridView
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // The Page is accessed for the first time.
            if (!IsPostBack)
            {
                // Initialize the DataTable and store it in ViewState.
                InitializeDataSource();

                // Enable the GridView paging option and specify the page size.
                gvPerson.AllowPaging = true;
                gvPerson.PageSize = 5;

                // Enable the GridView sorting option.
                gvPerson.AllowSorting = true;

                // Initialize the sorting expression.
                ViewState["SortExpression"] = "PersonID ASC";

                // Populate the GridView.
                BindGridView();
            }
        }

        // Initialize the DataTable.
        private void InitializeDataSource()
        {
            // Create a DataTable object named dtPerson.
            DataTable dtPerson = new DataTable();

            // Add four columns to the DataTable.
            dtPerson.Columns.Add("PersonID");
            dtPerson.Columns.Add("LastName");
            dtPerson.Columns.Add("FirstName");

            // Specify PersonID column as an auto increment column
            // and set the starting value and increment.
            dtPerson.Columns["PersonID"].AutoIncrement = true;
            dtPerson.Columns["PersonID"].AutoIncrementSeed = 1;
            dtPerson.Columns["PersonID"].AutoIncrementStep = 1;

            // Set PersonID column as the primary key.
            DataColumn[] dcKeys = new DataColumn[1];
            dcKeys[0] = dtPerson.Columns["PersonID"];
            dtPerson.PrimaryKey = dcKeys;

            // Add new rows into the DataTable.
            dtPerson.Rows.Add(null, "Davolio", "Nancy");
            dtPerson.Rows.Add(null, "Fuller", "Andrew");
            dtPerson.Rows.Add(null, "Leverling", "Janet");
            dtPerson.Rows.Add(null, "Dodsworth", "Anne");
            dtPerson.Rows.Add(null, "Buchanan", "Steven");
            dtPerson.Rows.Add(null, "Suyama", "Michael");
            dtPerson.Rows.Add(null, "Callahan", "Laura");
            dtPerson.Rows.Add(null, "/*_*_//*", "Jo");
            dtPerson.Rows.Add(null, "10941()", "Bob");
            dtPerson.Rows.Add(null, "#@!%$^%", "Kim");
            dtPerson.Rows.Add(null, "Johnson", "[]\\./,'");
            dtPerson.Rows.Add(null, ";--.", "*//:&^");
            dtPerson.Rows.Add(null, "99999", ">+++");
            dtPerson.Rows.Add(null, ">_<;;", "¯\\_(*.*)_/¯");

            // Store the DataTable in ViewState. 
            ViewState["dtPerson"] = dtPerson;
        }

        private void BindGridView()
        {
            if (ViewState["dtPerson"] != null)
            {
                // Get the DataTable from ViewState.
                DataTable dtPerson = (DataTable)ViewState["dtPerson"];

                // Convert the DataTable to DataView.
                DataView dvPerson = new DataView(dtPerson);

                // Set the sort column and sort order.
                dvPerson.Sort = ViewState["SortExpression"].ToString();

                // Bind the GridView control.
                gvPerson.DataSource = dvPerson;
                gvPerson.DataBind();
            }
        }

        // GridView.PageIndexChanging Event
        protected void gvPerson_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the index of the new display page.  
            gvPerson.PageIndex = e.NewPageIndex;

            // Rebind the GridView control to 
            // show data in the new page.
            BindGridView();
        }

        // GridView.RowEditing Event
        protected void gvPerson_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Make the GridView control into edit mode 
            // for the selected row. 
            gvPerson.EditIndex = e.NewEditIndex;

            // Rebind the GridView control to show data in edit mode.
            BindGridView();
        }

        // GridView.RowCancelingEdit Event
        protected void gvPerson_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Exit edit mode.
            gvPerson.EditIndex = -1;

            // Rebind the GridView control to show data in view mode.
            BindGridView();
        }

        // GridView.RowUpdating Event
        protected void gvPerson_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (ViewState["dtPerson"] != null)
            {
                // Get the DataTable from ViewState.
                DataTable dtPerson = (DataTable)ViewState["dtPerson"];

                // Get the PersonID of the selected row.
                object strPersonID = gvPerson.Rows[e.RowIndex].Cells[2].Text;

                // Find the row in DataTable.
                DataRow drPerson = dtPerson.Rows.Find(strPersonID);

                // Retrieve edited values and updating respective items.
                drPerson["LastName"] = ((TextBox)gvPerson.Rows[e.RowIndex].FindControl("TextBox1")).Text;
                drPerson["FirstName"] = ((TextBox)gvPerson.Rows[e.RowIndex].FindControl("TextBox2")).Text;

                // Exit edit mode.
                gvPerson.EditIndex = -1;

                // Rebind the GridView control to show data after updating.
                BindGridView();
            }
        }

        // GridView.RowDeleting Event
        protected void gvPerson_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (ViewState["dtPerson"] != null)
            {
                // Get the DataTable from ViewState.
                DataTable dtPerson = (DataTable)ViewState["dtPerson"];

                // Get the PersonID of the selected row.
                string strPersonID = gvPerson.Rows[e.RowIndex].Cells[2].Text;

                // Find the row in DateTable.
                DataRow drPerson = dtPerson.Rows.Find(strPersonID);

                // Remove the row from the DataTable.
                dtPerson.Rows.Remove(drPerson);

                // Rebind the GridView control to show data after deleting.
                BindGridView();
            }
        }

        // GridView.Sorting Event
        protected void gvPerson_Sorting(object sender, GridViewSortEventArgs e)
        {
            string[] strSortExpression = ViewState["SortExpression"].ToString().Split(' ');

            // If the sorting column is the same as the previous one, 
            // then change the sort order.
            if (strSortExpression[0] == e.SortExpression)
            {
                if (strSortExpression[1] == "ASC")
                {
                    ViewState["SortExpression"] = e.SortExpression + " " + "DESC";
                }
                else
                {
                    ViewState["SortExpression"] = e.SortExpression + " " + "ASC";
                }
            }
            // If sorting column is another column, 
            // then specify the sort order to "Ascending".
            else
            {
                ViewState["SortExpression"] = e.SortExpression + " " + "ASC";
            }

            // Rebind the GridView control to show sorted data.
            BindGridView();
        }
    }
}