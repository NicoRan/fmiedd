﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectWinForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
             Login loginForm = new Login();
            DialogResult loginResult = loginForm.ShowDialog();

            if (loginResult == DialogResult.OK)
            {
                Application.Run(new Form1());
            }
        }
    }
}
