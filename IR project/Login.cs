using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IR_project
{
    public partial class LogIn : MaterialForm
    {
        #region Initial
        private SearchForm _searchForm;
        public LogIn(SearchForm parentForm)
        {
            _searchForm = parentForm;
            InitializeComponent();
        }
        #endregion Initial

        #region Public Methods
        #endregion Public Methods


        #region ControlEvents
        private void Login_btn_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void LoginPassword_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Login();
            }
        }

        private void LoginUserName_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Login();
            }
        }

        private void LoginUserName_txt_Enter(object sender, EventArgs e)
        {
            if (LoginUserName_txt.Text == "User Name")
            {
                LoginUserName_txt.Text = string.Empty;
                LoginUserName_txt.TextAlign = HorizontalAlignment.Left;
            }
        }

        private void LoginUserName_txt_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LoginUserName_txt.Text))
            {
                LoginUserName_txt.Text = "User Name";
                LoginUserName_txt.TextAlign = HorizontalAlignment.Center;
            }
        }

        private void LoginPassword_txt_Enter(object sender, EventArgs e)
        {
            if (LoginPassword_txt.Text == "Password")
            {
                LoginPassword_txt.Text = string.Empty;
                LoginPassword_txt.TextAlign = HorizontalAlignment.Left;
                LoginPassword_txt.UseSystemPasswordChar = true;
            }
        }

        private void LoginPassword_txt_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LoginPassword_txt.Text))
            {
                LoginPassword_txt.Text = "Password";
                LoginPassword_txt.TextAlign = HorizontalAlignment.Center;
                LoginPassword_txt.UseSystemPasswordChar = false;
            }
        }
        #endregion ControlEvents

        #region Private Methods

        private void Login()
        {
            lbl_msg.Visible = false;
            if (string.IsNullOrEmpty(LoginUserName_txt.Text) || LoginUserName_txt.Text == "User Name")
            {
                lbl_msg.Text = "Please insert User Name";
                lbl_msg.Visible = true;
                return;
            }
            if (string.IsNullOrEmpty(LoginPassword_txt.Text) || LoginPassword_txt.Text == "Password")
            {
                lbl_msg.Text = "Please insert user Password";
                lbl_msg.Visible = true;
                return;
            }

            if (LoginUserName_txt.Text.ToLower() == "admin" && LoginPassword_txt.Text == "1234")
            {
                _searchForm.AdminLogedIn(true, LoginUserName_txt.Text);
                this.Close();
            }
            else
            {
                lbl_msg.Text = "User Name or Password are Incorrect. Please try again";
                lbl_msg.Visible = true;
            }
        }

        #endregion Private Methods
    }
}
