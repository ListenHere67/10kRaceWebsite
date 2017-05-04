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

        Practical1Entities1 dbo = new Practical1Entities1();
       

        protected void CreateNewUser_Click(object sender, EventArgs e)
        {
            
            User user = new User();          
            var username = tbxUsername.Text;
            var password = tbxPassword.Text;
            var forename = tbxForename.Text;
            var surname = tbxSurname.Text;

            user.Username = username;
            user.Password = password;
            user.Forename = forename;
            user.Surname = surname;

            //Create the surname automatically - optional
            // var forenameFirstLetter = tbxForename.Text.Substring(0, 1).ToLower();
            //var username = forenameFirstLetter + surname;
            bool exists = CheckIfExists(user);
            if (!exists)
            {
                bool updated = UpdateUserRecord(user, "Add");
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
            else
            {
                ErrorMessage.Text = "The user already exists.";
            }                                
        }

        private bool CheckIfExists(User user)
        {
            bool exists = false;
            try
            {
                foreach (var _user in dbo.Users.Where(t => t.Username == user.Username))
                {
                    exists = true;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = "Problem checking if the user exists " + ex.InnerException;
            }
            return exists;
        }

        public bool UpdateUserRecord(User user, string entityState)
        {
            bool updated = false;
            try
            {               
                if (entityState == "Add")
                {
                    if (user.Username != null && user.Password != null)
                    {
                        //Remove this line if using auto-increment in the database
                        //user.UserID = Guid.NewGuid().ToString();
                        dbo.Entry(user).State = System.Data.Entity.EntityState.Added;
                    }
                }
                if (entityState == "Modify")
                {
                    foreach (var _user in dbo.Users.Where(t => t.UserID == user.UserID))
                    {
                        _user.Username = user.Username;
                        _user.Password = user.Password;
                        _user.Forename = user.Forename;
                        _user.Surname = user.Surname;
                    }
                    dbo.Configuration.AutoDetectChangesEnabled = true;
                    dbo.Configuration.ValidateOnSaveEnabled = true;
                }
                if (entityState == "Delete")
                {
                    dbo.Users.RemoveRange(
                    dbo.Users.Where(t => t.UserID == user.UserID));
                }
                int saved = dbo.SaveChanges();
                if (saved > 0)
                {
                    updated = true;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = "Problem saving record to database" + ex.InnerException;
            }         
            return updated;
        }
    }
}