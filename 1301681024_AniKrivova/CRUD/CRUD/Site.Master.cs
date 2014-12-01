﻿using ConsoleLibrary.Entity;
using ConsoleLibrary.Repository;
using ConsolePhonebook.Entity;
using ConsolePhonebook.Repository;
using ConsolePhonebook.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD
{
    public partial class SiteMaster : MasterPage
    {
        public static int rolleId;
        public static string rollename;
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["authService"] != null)
            {
                Response.Redirect("~/Default.aspx");
                return;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
           
            AuthenticationService authService = new AuthenticationService();
           authService.AuthenticateUser(tbUsername.Text, tbPassword.Text);

           User us = new User();
            us.Username=tbUsername.Text;
            us.Password=tbPassword.Text;
           UsersRepository usr = new UsersRepository();
           us=usr.GetByUsernameAndPassword(us.Username, us.Password);
           Rolles rolle = new Rolles();
           rolle.UserId = us.Id;
           RollesRepository rollerepo = new RollesRepository();
           rolle.RolleName=rollerepo.GetRolleByUserId(rolle.UserId);
           

           rolleId=rolle.UserId;
           rollename = rolle.RolleName;
            
            

           if (us.FirstName != null && us.LastName!=null)
            {
                Session["authService"] = authService;
                Response.Redirect("~/Member.aspx");
            }
            else
            {
                tbUsername.Text = null;
                tbPassword.Text = null;
                this.lblError.Text = "Invalid user!";
            }
        }
    }
}