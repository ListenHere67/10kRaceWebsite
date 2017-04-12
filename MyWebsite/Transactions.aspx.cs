using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebsite
{
    public partial class Transactions : System.Web.UI.Page
    {
        Practical1Entities db = new Practical1Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lstAllProducts.DataSource = GetProducts();
                lstAllProducts.DataBind();
            }
        }

       

        protected void lstAllProducts_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            Product product = new Product();           
            TextBox tbx = (e.Item.FindControl("tbxProductName")) as TextBox;
            if (tbx != null)
                product.ProductName = tbx.Text;          
            tbx = (e.Item.FindControl("tbxProductDescription")) as TextBox;
            if (tbx != null)
              product.ProductDesc = tbx.Text;
            UpdateProductRecord(product, "Add");          
            ResetProductView();
        }

        protected void lstAllProducts_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            lstAllProducts.EditIndex = e.NewEditIndex;
            lstAllProducts.DataSource = GetProducts();
            lstAllProducts.DataBind();         
        }

        protected void lstAllProducts_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            Product product = new Product();
            Label lbl = (lstAllProducts.Items[e.ItemIndex].FindControl("lblProductID")) as Label;
            if (lbl != null)
                product.ProductID = Convert.ToInt16( lbl.Text);             
            TextBox tbx = (lstAllProducts.Items[e.ItemIndex].FindControl("tbxProductName")) as TextBox;
            if (tbx != null)
                product.ProductName = tbx.Text;               
            tbx = (lstAllProducts.Items[e.ItemIndex].FindControl("tbxProductDescription")) as TextBox;
            if (tbx != null)
                product.ProductDesc = tbx.Text;
            UpdateProductRecord(product, "Modify");
            ResetProductView();
        }

        protected void lstAllProducts_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            ResetProductView();
        }

        protected void lstAllProducts_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            Product product = new Product();
            Label lbl = (lstAllProducts.Items[e.ItemIndex].FindControl("lblProductID")) as Label;
            if (lbl != null)
                product.ProductID = Convert.ToInt16(lbl.Text);
            TextBox tbx = (lstAllProducts.Items[e.ItemIndex].FindControl("tbxProductName")) as TextBox;
            if (tbx != null)
                product.ProductName = tbx.Text;
            tbx = (lstAllProducts.Items[e.ItemIndex].FindControl("tbxProductDescription")) as TextBox;
            if (tbx != null)
                product.ProductDesc = tbx.Text;
            UpdateProductRecord(product, "Delete");
            ResetProductView();
            
        }

        private DataTable GetProducts()
        {
            Product p = new Product();
            object[] obj = new object[3];
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductID");
            dt.Columns.Add("ProductName");
            dt.Columns.Add("ProductDescription");
            foreach (var product in db.Products)
            {
                obj[0] = product.ProductID;
                obj[1] = product.ProductName;
                obj[2] = product.ProductDesc;               
                dt.Rows.Add(obj);
            }          
            return dt;
        }

        private void ResetProductView()
        {
            lstAllProducts.EditIndex = -1;
            lstAllProducts.DataSource = GetProducts();
            lstAllProducts.DataBind();
        }

        public void UpdateProductRecord(Product product, string entityState)
        {           
            if (entityState == "Add")
            {
                if (product.ProductDesc == null)
                {
                    product.ProductDesc = " ";
                }

                if (product.ProductName == null)
                {
                    product.ProductName = " ";
                }
                db.Entry(product).State = System.Data.Entity.EntityState.Added;
            }
            if (entityState == "Modify")
            {
                foreach (var productitem in db.Products.Where(t => t.ProductID == product.ProductID))
                {
                    productitem.ProductName = product.ProductName;
                    productitem.ProductDesc = product.ProductDesc;                
                }
                db.Configuration.AutoDetectChangesEnabled = true;
                db.Configuration.ValidateOnSaveEnabled = true;                        
            }
            if (entityState == "Delete")
            {
                db.Products.RemoveRange(
                db.Products.Where(t => t.ProductID == product.ProductID));
            }
            db.SaveChanges();
        }
    }
}