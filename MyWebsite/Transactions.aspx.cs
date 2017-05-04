﻿using System;
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
        Practical1Entities1 dbo = new Practical1Entities1();

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
            Participant product = new Participant();           
            TextBox tbx = (e.Item.FindControl("tbxSurname")) as TextBox;
            if (tbx != null)
                product.Surname = tbx.Text;          
            tbx = (e.Item.FindControl("tbxPPSno")) as TextBox;
            if (tbx != null)
              product.PPSno = tbx.Text;
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
            Participant product = new Participant();
            TextBox lbl = (lstAllProducts.Items[e.ItemIndex].FindControl("FirstNameLabel")) as TextBox;
            if (lbl != null)
                product.FirstName = lbl.Text;             
            TextBox tbx = (lstAllProducts.Items[e.ItemIndex].FindControl("tbxSurname")) as TextBox;
            if (tbx != null)
                product.Surname = tbx.Text;               
            tbx = (lstAllProducts.Items[e.ItemIndex].FindControl("tbxPPSno")) as TextBox;
            if (tbx != null)
                product.PPSno = tbx.Text;
            UpdateProductRecord(product, "Modify");
            ResetProductView();
        }

        protected void lstAllProducts_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            ResetProductView();
        }

        protected void lstAllProducts_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            Participant product = new Participant();
            TextBox lbl = (lstAllProducts.Items[e.ItemIndex].FindControl("FirstNameLabel")) as TextBox;
            if (lbl != null)
                product.FirstName = lbl.Text;
            TextBox tbx = (lstAllProducts.Items[e.ItemIndex].FindControl("tbxSurname")) as TextBox;
            if (tbx != null)
                product.Surname = tbx.Text;
            tbx = (lstAllProducts.Items[e.ItemIndex].FindControl("tbxPPSno")) as TextBox;
            if (tbx != null)
                product.PPSno = tbx.Text;
            UpdateProductRecord(product, "Delete");
            ResetProductView();
            
        }

        private DataTable GetProducts()
        {
            Participant p = new Participant();
            object[] obj = new object[3];
            DataTable dt = new DataTable();
            dt.Columns.Add("FirstName");
            dt.Columns.Add("Surname");
            dt.Columns.Add("PPSno");
            foreach (var product in dbo.Participants)
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
            lstAllProducts.DataSource = GetProducts();
            lstAllProducts.DataBind();
        }

        public void UpdateProductRecord(Participant product, string entityState)
        {           
            if (entityState == "Add")
            {
               /* if (product.ProductDesc == null)
                {
                    product.ProductDesc = " ";
                }
                if (product.ProductName == null)
                {
                    product.ProductName = " ";
                }*/
                dbo.Entry(product).State = System.Data.Entity.EntityState.Added;
            }
            if (entityState == "Modify")
            {
                foreach (var productitem in dbo.Participants.Where(t => t.FirstName == product.FirstName))
                {
                    productitem.Surname = product.Surname;
                    productitem.PPSno = product.PPSno;                
                }
                dbo.Configuration.AutoDetectChangesEnabled = true;
                dbo.Configuration.ValidateOnSaveEnabled = true;                        
            }
            if (entityState == "Delete")
            {
                dbo.Participants.RemoveRange(
                dbo.Participants.Where(t => t.FirstName == product.FirstName));
            }
            dbo.SaveChanges();
        }
    }
}