﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
namespace CRUD
{
    class Program
    {
        static bool user_kind = false;
        static bool flag = false;
        static int id = 0;
        static OleDbDataReader dr = null;
        static OleDbCommand cmd = new OleDbCommand();
        static OleDbConnection cn = new OleDbConnection();
        public static void Reader(OleDbConnection cn, OleDbCommand cmd, OleDbDataReader dr)
        {
            try
            {
                string q = "select * from info";
                cmd.CommandText = q;
                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Console.WriteLine("ID: " + dr[0].ToString() + "; " + "Username: " + dr[1].ToString() + "; " + "Password: " + dr[2].ToString() + "; " + "email: " + dr[3].ToString());
                        id = Convert.ToInt32(dr[0]);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message.ToString());
            }
        }
        public static void LogIn(OleDbConnection cn, OleDbCommand cmd, OleDbDataReader dr)
        {
            Console.WriteLine("username= ");
            string log_name = Console.ReadLine();
            Console.WriteLine("pass= ");
            string log_pass = Console.ReadLine();
            string name = "";
            string pass = "";
            try
            {
                string q = "select * from roles";
                cmd.CommandText = q;
                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                         name = dr[1].ToString();
                         pass = dr[2].ToString();
                         if (log_name == name && log_pass == pass)
                         {
                             flag = true;
                         }
                         else
                         {
                             name = "";
                             pass = "";
                         }
                        }
                        if (flag == true)
                        {
                            Console.WriteLine("You are logged as "+ log_pass);
                        }
                        else
                        {
                            Console.WriteLine("Wrong username or password, please try again.");
                            Console.WriteLine();
                        }
                    }
                if (log_pass == "admin")
                {
                    user_kind = true;
                }
                else
                { user_kind = false; }
                dr.Close();
                cn.Close();
                }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message.ToString());
            }
        }
        public static void Cud(String u, OleDbConnection cn, OleDbCommand cmd)
        {
            try
            {
                cn.Open();
                cmd.CommandText = u;
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message.ToString());
            }
        }
        public static void Create(OleDbConnection cn, OleDbCommand cmd)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Create a record in database: ");
            Reader(cn, cmd, dr);
            Console.WriteLine();
            Console.WriteLine("Username: ");
            string username = (Console.ReadLine());
            Console.WriteLine("Password: ");
            string password2 = (Console.ReadLine());
            Console.WriteLine("E-mail: ");
            string email = (Console.ReadLine());
            id += 1;
            string s = @"INSERT INTO info ([id], [username], [password2], [email]) VALUES('" + id + "','" + username + "','" + password2 + "','" + email + "')";
            Cud(s, cn, cmd);
            Console.WriteLine();
            Reader(cn, cmd, dr);
        }
        public static void Update(OleDbConnection cn, OleDbCommand cmd)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Update a record in database: ");
            Reader(cn, cmd, dr);
            Console.WriteLine();
            Console.WriteLine("ID= ");
            string id = (Console.ReadLine());
            Console.WriteLine("Username: ");
            string username = (Console.ReadLine());
            Console.WriteLine("Password: ");
            string password2 = (Console.ReadLine());
            Console.WriteLine("E-mail: ");
            string email = (Console.ReadLine());
            string u = "update info set username ='" + username + "',password2 ='" + password2 + "',email ='" + email + "'where id=" + id;
            Cud(u, cn, cmd);
            Console.WriteLine();
            Reader(cn, cmd, dr);
        }
        public static void Delete(OleDbConnection cn, OleDbCommand cmd)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Delete a record in database: ");
            Reader(cn, cmd, dr);
            Console.WriteLine();
            Console.WriteLine("ID= ");
            string id_del = (Console.ReadLine());
            string p = "delete * from info where id=" + id_del;
            Cud(p, cn, cmd);
            Reader(cn, cmd, dr);
        }
        static void Main(string[] args)
        {
            cn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\fmi\Source\Repos\fmiedd\1301681031_Pavel_Bogdanov\CRUD\CRUD\Database1.accdb;Persist Security Info=True";
            cmd.Connection = cn;
            while (flag == false)
            { LogIn(cn, cmd, dr); }
            if (user_kind == true)
            {
                Create(cn, cmd);
                Update(cn, cmd);
                Delete(cn, cmd);
            }
            else
            {
                Reader(cn, cmd, dr);
            }
            Console.ReadKey();
        }
    }
}