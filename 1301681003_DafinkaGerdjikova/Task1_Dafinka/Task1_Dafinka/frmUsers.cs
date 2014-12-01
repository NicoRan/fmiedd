﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task1_Dafinka.Entities;
using Task1_Dafinka.Repositories;
using Task1_Dafinka.Service;

namespace Task1_Dafinka
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        public void RefreshUsers()
        {
            lbUsers.Items.Clear();

            UsersRepository usersRepo = new UsersRepository();
            foreach (User user in usersRepo.GetAll())
            {
                lbUsers.Items.Add(user);
            }
            if (lbUsers.Items.Count > 0)
            {
                lbUsers.SelectedIndex = 0;
            }

            AdjustControlls();

        }

        public void AdjustControlls()
        {
            this.btnNew.Enabled = true;
            this.btnEdit.Enabled = this.lbUsers.SelectedItem != null;
            this.btnDelete.Enabled = this.lbUsers.SelectedItem != null;
        }


        private void frmUsers_Load(object sender, EventArgs e)
        {
            RolesRepository rolesRepo = new RolesRepository();
            Role role = rolesRepo.GetByID(AuthenticationService.LoggedUser.ID);

            if (role.Name != "Administrator")
            {
                btnNew.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
            }
            RefreshUsers();
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            User user = new User();
            frmEditUser frm = new frmEditUser(user);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                RefreshUsers();
            }
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (lbUsers.SelectedIndex >= 0)
            {
                UsersRepository usersRepo = new UsersRepository();

                User user = (User)lbUsers.SelectedItem;

                frmEditUser frm = new frmEditUser(user);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    RefreshUsers();
                }

            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (lbUsers.SelectedIndex >= 0)
            {
                UsersRepository usersRepo = new UsersRepository();

                User user = (User)lbUsers.SelectedItem;
                if (MessageBox.Show("Delete user?", "Delete user", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    usersRepo.Delete(user);
                    RefreshUsers();
                }
            }
        }
    }
}
