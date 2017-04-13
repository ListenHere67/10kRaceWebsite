using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using MyWebsite.Models;
using MyWebsite;

namespace MyWebsite.Account
{
    public partial class Register : Page
    {

        Practical1Entities db = new Practical1Entities();
       

        protected void CreateNewUser_Click(object sender, EventArgs e)
        {
            bool updated = false;
            User user = new User();          
            var username = tbxUsername.Text;
            var password = tbxPassword.Text;
            var forename = tbxForename.Text;
            var surname = tbxSurname.Text;
            //Create the surname automatically - optional
            // var forenameFirstLetter = tbxForename.Text.Substring(0, 1).ToLower();
            //var username = forenameFirstLetter + surname;
            updated = UpdateUserRecord(user, "Add");
            if (updated)
            {
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                ((SiteMaster)this.Master).MenuVisibility = true;
                ((SiteMaster)this.Master).TransactionsVisibility = true;
            }
            else
            {
                ErrorMessage.Text = "Problem saving record to database";
            }                              
        }

        public bool UpdateUserRecord(User user, string entityState)
        {
            bool updated = false;
            if (entityState == "Add")
            {
                if (user.Username != null && user.Password != null)
                {
                    db.Entry(User).State = System.Data.Entity.EntityState.Added;
                }                               
            }
            if (entityState == "Modify")
            {
                foreach (var _user in db.Users.Where(t => t.UserID == user.UserID))
                {
                    //your logic
                }
                db.Configuration.AutoDetectChangesEnabled = true;
                db.Configuration.ValidateOnSaveEnabled = true;
            }
            if (entityState == "Delete")
            {
                db.Users.RemoveRange(
                db.Users.Where(t => t.UserID == user.UserID));
            }
            int saved = db.SaveChanges();
            if (saved>0)
            {
                updated = true;
            }
            return updated;
        }
    }
}