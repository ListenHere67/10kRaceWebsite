using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebsite
{
   
    public partial class Search : System.Web.UI.Page
    {
        test t = new test();

        public string databaseToSearch
        {
            get
            {
                return (string)ViewState["databaseToSearch"] ?? "";
            }
            set
            {
                ViewState["databaseToSearch"] = value;
            }
        }

        public partial class test
        {
            public string a;
        }
        Practical1Entities1 dbo = new Practical1Entities1();
        
        string searchText { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void cboDatabaseChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            var choice = "";
            var _dropdownlist = (DropDownList)sender;
            if (_dropdownlist.SelectedIndex>-1)
            {
                ListItem item = _dropdownlist.SelectedItem;
                databaseToSearch = item.Value;
                t.a = item.Value;
            }          
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            searchText = tbxSearchText.Text;
            PerformSearch(databaseToSearch, searchText);
        }

        private void PerformSearch(string databaseToSearch, string searchText)
        {
            if (databaseToSearch == "Participants")
            {
                lstAllProducts.DataSource = GetParticipants(searchText);
                if (lstAllProducts.Items.Count>0)
                {
                    lstAllProducts.Visible = true;
                }
                lstAllProducts.DataBind();
            }
        }

        private DataTable GetParticipants(string searchText)
        {
            Product p = new Product();
            object[] obj = new object[3];
            DataTable dt = new DataTable();
            dt.Columns.Add("FirstName");
            dt.Columns.Add("Surname");
            dt.Columns.Add("PPSno");
            foreach (var product in dbo.Participants.Where(t => t.Surname == searchText || t.Surname == searchText))
            {
                obj[0] = product.FirstName;
                obj[1] = product.Surname;
                obj[2] = product.PPSno;
                dt.Rows.Add(obj);
            }
            return dt;
        }

        private void ResetProductView()
        {
            lstAllProducts.EditIndex = -1;
            lstAllProducts.DataSource = GetParticipants("");
            lstAllProducts.DataBind();
        }
    }
}