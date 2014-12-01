﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookManager.Controller;
using System.Collections;
using System.Collections.Specialized;

namespace BookManager
{
    public partial class AddBook : Form
    {
        private User LoggedUser = new User();
        public AddBook(User user)
        {
            LoggedUser = user;
            InitializeComponent();
        }

        public AddBook()
        {
            InitializeComponent();
        }

        OrderedDictionary parameters = new OrderedDictionary();

        private void UpdateParameters()
        {
            parameters.Clear();
            parameters.Add("title", tb_title.Text);
            parameters.Add("author", tb_author.Text);
            parameters.Add("price", tb_price.Text);
            parameters.Add("isbn", tb_isbn.Text);
        }

        private void ClearTextBoxes()
        {
            tb_title.Clear();
            tb_author.Clear();
            tb_price.Clear();
            tb_isbn.Clear();
            tb_title.Focus();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (tb_title.Text == "")
            {
                MessageBox.Show("You have to input at least a title.");
                tb_title.Focus();
            }
            else
            {
                if (parameters.Count!=0 && (parameters["title"].ToString()==tb_title.Text || parameters["isbn"]==tb_isbn))
                {
                    MessageBox.Show("You have already added a record with the same title/ISBN!", "Information");
                    ClearTextBoxes();
                }
                else
                {
                    UpdateParameters();
                    bool success = BookController.Add(parameters);

                    if (success == true)
                    {
                        MessageBox.Show("Record successfully added.", "Information");
                    }
                    else
                    {
                        MessageBox.Show("Adding record failed.", "Information");
                    }
                }       
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            parameters.Clear();
            ClearTextBoxes();
        }

        private void viewAllBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewAll viewAllform = new ViewAll(LoggedUser);
            viewAllform.Show();
            this.Hide();
        }

        private void editBookDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindBook addBookform = new FindBook(LoggedUser);
            addBookform.Show();
            this.Hide();
        }

        private void splashPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookManager bookManagerform = new BookManager(LoggedUser);
            bookManagerform.Show();
            this.Hide();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogIn loginForm = new LogIn();
            loginForm.Show();
            this.Hide();
        }
    }
}
