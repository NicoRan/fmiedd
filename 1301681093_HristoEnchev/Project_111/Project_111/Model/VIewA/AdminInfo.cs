﻿using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_111.Model
{
    class AdminInfo : Connection
    {
        public void FullInfo()
        {
           // OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\usersDB.accdb;Persist Security Info=False;");
            //OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Ico-PC\Source\Repos\fmiedd\1301681093_HristoEnchev\Project_111\Project_111\Data\usersDB.accdb;Persist Security Info=False;");

            OleDbCommand command = new OleDbCommand("select * from users", connection);
            try
            {
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                User user = new User();
                while (reader.Read())
                {

                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("ID: {0} || UserName: {1} || Email: {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(3));
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("-------------------------------------------------------------------------------", Console.ForegroundColor = ConsoleColor.DarkGray);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                connection.Close();
                reader.Close();
            }
            catch (OleDbException e)
            {
                Console.WriteLine("Error: {0}", e.Errors[0].Message);
            }
        }
    }
}
