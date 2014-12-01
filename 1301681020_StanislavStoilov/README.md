���������� �� ��������� �� ���������� �� ������ � ���� �����:

1. �� �� ��������� ���� ���� �����, ���������� SQL Management Studio.

2. ���� ���� ���������� ����������, ��������� New Query � ���� ���� ��������� ������ �������.

������:

CREATE DATABASE PROJECT - ������� ������ ���� �����

USE PROJECT

CREATE TABLE USERS - ������� ���������
(

	ID INT PRIMARY KEY,
	USERNAME VARCHAR(50) NOT NULL,
	PASSWORD VARCHAR(30) NOT NULL,
	EMAIL VARCHAR(30) NOT NULL

	)

                 ALTER TABLE USERS
	ADD Role_ID INT


	CREATE TABLE ROLE
	(

                  ID INT FOREIGN KEY REFERENCES USERS NOT NULL,
                  Role VARCHAR(10) NOT NULL

	)

3. ���� ���� ��� ������� ������ �����, ���������� Microsoft Visual Studio 2013.

4. ��������� New Project �> Console Application.

5. �� �� ���� �� �������� � SQL ���� �����, ������ �� ���-������ � ���������� �� �������� using.System.Data.SqlClient.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

6. ���� ����, �� �� ������ �� ����������� ������ � ������ �����, ������ �� ���������� ����� SqlConnection,
   ���� ����� �� ������� ����� �� SQL ������� � ����� �� ������ �����.

������:

SqlConnection sqlcon = new SqlConnection("Server=����� �� �������; Database=����� �� ������; Integrated Security=true; Persist Security Info=false;");
sqlcon.Open();

 ���������: 

 �� �� ���� ���������� �� ������ �� �������� �������, �� ���� ������� ���:

SqlConnection sqlcon = new SqlConnection(@"Data Source=����� �� �������; Initial Catalog=����� �� ������ �����; User ID=MyUserID; Password=MyPassword;");
sqlcon.Open();


7. ����, �� �� ���������� ���������� Insert, Update � Delete, ������ �� ���������� ����� SqlCommand � ���� ���������� �� SQL, �� ��������
    ��� �������� �� �� ���������. ���������� Insert, Update � Delete � ����� �� �� �������� ���� ������ ������ � ���� �� �� �������� 
    � �������� ��������. 

������:

          class Program
       {

          public static void Insert()
        {

            string id;
            Console.Write("\n\n\t\t ID:");
            id = Console.ReadLine();

            string username;
            Console.Write("\n\t\t Username:");
            username = Console.ReadLine();

            if (username == "")
            {
                Console.WriteLine("\n The username cannot be empty!");
            }

            else
                if (username.Length < 5)
                {
                    Console.WriteLine("\n The username is too short!");
                }

                else
                    if (username != "" && username.Length >= 5)
                    {
                        string password;
                        Console.Write("\n\t\t Password:");
                        password = Console.ReadLine();

                        if (password == "")
                        {

                            Console.WriteLine("\n The password cannot be empty!");
                        }

                        else
                            if (password.Length < 5)
                            {
                                Console.WriteLine("\n The password must be betwen 5 and 15 symbols!");
                            }

                            else
                                if (password != "" && password.Length >= 5 || password.Length <= 15)
                                {
                                    string email;
                                    Console.Write("\n\t\t Email:");
                                    email = Console.ReadLine();

                                    if (email == "")
                                    {
                                        Console.WriteLine("\n The email cannot be empty!");
                                    }

                                    else
                                        if (email != "")
                                        {
                                            int role_id;
                                            Console.Write("\n\t\t Role_ID:");
                                            role_id = int.Parse(Console.ReadLine());

                                        if (role_id == 1 || role_id == 2) - ���� ���������� �� ���������, � ��� �� ����� ���� ��������� �� ��������� �������,
				                          ����� ������ �� ����� ������� � ���������.
                                        { 

			SqlConnection sqlcon = new SqlConnection("Server=����� �� �������; Database=����� �� ������; Integrated Security=true; Persist Security Info=false;");
			sqlcon.Open();

                		SqlCommand sqlcom = new SqlCommand("INSERT INTO [PROJECT].[dbo].[USERS] (ID, USERNAME, PASSWORD, EMAIL, Role_ID)" + "VALUES(@ID, @USERNAME, @PASSWORD, @EMAIL, @Role_ID)", sqlcon);

              			 ����� ��������� - ��� ������ �� �������� �����������, ����� �� �� �������� � ��������� ���� ���������,  ����������� ���������(@USERNAME);

			sqlcom.Parameters.Add("@ID", id); - ������ ���������� � ����������, ����� ��� �� ������. � ������ �� ������ �� �� �������� 'ID:' 
			� ��� ������ �� �������� ������� �������� �� ������������ 'id'. ���� ���� �� ���������, �� �� �� ������� �� �������� 'ID' �� ���������.

               		                  sqlcom.Parameters.Add("@USERNAME", username);
              		                  sqlcom.Parameters.Add("@PASSWORD", password);
                		  sqlcom.Parameters.Add("@EMAIL", email);
             			  sqlcom.Parameters.Add("@Role_ID", role_id);

	
������ ������ �� ��������� � ��� Update � Delete.

������:

���������� Update -  SqlCommand ucom = new SqlCommand("UPDATE [PROJECT].[dbo].[USERS]" + "SET PASSWORD='programming'" + "WHERE USERNAME=@USERNAME", sqlcon);
                                   ucom.Parameters.AddWithValue("@USERNAME", usr); - ��� ��������, �� �� �������� ��������, ������ ������� Username

���������� Delete -    SqlCommand dcom = new SqlCommand("DELETE " + "FROM [PROJECT].[dbo].[USERS]" + "WHERE ID=@ID", sqlcon);
                	   dcom.Parameters.Add("@ID", id); - ��� ��������, �� �� ������ ����� ���, �� �������� �������� ID


8. ���� ����, ������ �� ������� ������� � �� �� ���������� �� ������. ���� ����� � ����� SqlDataReader.

������:

        class Program
     {

          public static void Insert()
        {	
            string id;
            Console.Write("\n\n\t\t ID:");
            id = Console.ReadLine();

            string username;
            Console.Write("\n\t\t Username:");
            username = Console.ReadLine();

            if (username == "")
            {
                Console.WriteLine("\n The username cannot be empty!");
            }

            else
                if (username.Length < 5)
                {
                    Console.WriteLine("\n The username is too short!");
                }

                else
                    if (username != "" && username.Length >= 5)
                    {
                        string password;
                        Console.Write("\n\t\t Password:");
                        password = Console.ReadLine();

                        if (password == "")
                        {

                            Console.WriteLine("\n The password cannot be empty!");
                        }

                        else
                            if (password.Length < 5)
                            {
                                Console.WriteLine("\n The password must be betwen 5 and 15 symbols!");
                            }

                            else
                                if (password != "" && password.Length >= 5 || password.Length <= 15)
                                {
                                    string email;
                                    Console.Write("\n\t\t Email:");
                                    email = Console.ReadLine();

                                    if (email == "")
                                    {
                                        Console.WriteLine("\n The email cannot be empty!");
                                    }

                                    else
                                        if (email != "")
                                        {
                                            int role_id;
                                            Console.Write("\n\t\t Role_ID:");
                                            role_id = int.Parse(Console.ReadLine());


                                  if (role_id == 1 || role_id == 2)
                                  {
                                       
                                   SqlConnection sqlcon = new SqlConnection("Server=����� �� �������; Database=����� �� ������; Integrated Security=true; Persist Security Info=false;");
                                   sqlcon.Open();

                                   
                                  SqlCommand sqlcom = new SqlCommand("INSERT INTO [PROJECT].[dbo].[USERS] (ID, USERNAME, PASSWORD, EMAIL, Role_ID)" + "VALUES(@ID, @USERNAME, @PASSWORD, @EMAIL, @Role_ID)", sqlcon);
                                  sqlcom.Parameters.Add("@ID", id);
                                  sqlcom.Parameters.Add("@USERNAME", username);
                                  sqlcom.Parameters.Add("@PASSWORD", password);
                                  sqlcom.Parameters.Add("@EMAIL", email);
                                  sqlcom.Parameters.Add("@Role_ID", role_id);


                                  SqlDataReader sqldr = sqlcom.ExecuteReader();

                                  while (sqldr.Read())
                                  {

                                    Console.WriteLine("ID:{0}\n Username:{1}\n Password:{2}\n Email:{3}\n, Role_ID:{4}", sqldr.GetSqlValue(0), sqldr.GetString(1), sqldr.GetSqlValue(2), sqldr.GetString(3), sqldr.GetSqlValue(4));

                                   }

9. ���� ���� ��������� ������������ ��������, ������ �� ��������� ������, ��������� �� ����� SqlDataReader. ���� ����� ���� ����� �� ������.Close().

������:
 	
        class Program
       {

          public static void Insert()
        {

            string id;
            Console.Write("\n\n\t\t ID:");
            id = Console.ReadLine();

            string username;
            Console.Write("\n\t\t Username:");
            username = Console.ReadLine();

            if (username == "")
            {
                Console.WriteLine("\n The username cannot be empty!");
            }

            else
                if (username.Length < 5)
                {
                    Console.WriteLine("\n The username is too short!");
                }

                else
                    if (username != "" && username.Length >= 5)
                    {
                        string password;
                        Console.Write("\n\t\t Password:");
                        password = Console.ReadLine();

                        if (password == "")
                        {

                            Console.WriteLine("\n The password cannot be empty!");
                        }

                        else
                            if (password.Length < 5)
                            {
                                Console.WriteLine("\n The password must be betwen 5 and 15 symbols!");
                            }

                            else
                                if (password != "" && password.Length >= 5 || password.Length <= 15)
                                {
                                    string email;
                                    Console.Write("\n\t\t Email:");
                                    email = Console.ReadLine();

                                    if (email == "")
                                    {
                                        Console.WriteLine("\n The email cannot be empty!");
                                    }

                                    else
                                        if (email != "")
                                        {
                                            int role_id;
                                            Console.Write("\n\t\t Role_ID:");
                                            role_id = int.Parse(Console.ReadLine());


                                  if (role_id == 1 || role_id == 2)
                                  {
                                     
                                   SqlConnection sqlcon = new SqlConnection("Server=����� �� �������; Database=����� �� ������; Integrated Security=true; Persist Security Info=false;");
                                   sqlcon.Open();

                                   
                                  SqlCommand sqlcom = new SqlCommand("INSERT INTO [PROJECT].[dbo].[USERS] (ID, USERNAME, PASSWORD, EMAIL, Role_ID)" + "VALUES(@ID, @USERNAME, @PASSWORD, @EMAIL, @Role_ID)", sqlcon);
                                  sqlcom.Parameters.Add("@ID", id);
                                  sqlcom.Parameters.Add("@USERNAME", username);
                                  sqlcom.Parameters.Add("@PASSWORD", password);
                                  sqlcom.Parameters.Add("@EMAIL", email);
                                  sqlcom.Parameters.Add("@Role_ID", role_id);


                                  SqlDataReader sqldr = sqlcom.ExecuteReader();

                                  while (sqldr.Read())
                                  {

                                    Console.WriteLine("ID:{0}\n Username:{1}\n Password:{2}\n Email:{3}\n, Role_ID:{4}", sqldr.GetSqlValue(0), sqldr.GetString(1), sqldr.GetSqlValue(2), sqldr.GetString(3), sqldr.GetSqlValue(4));

                                   }
  

                                    sqldr.Close();

                                   }
   			Console.WriteLine("\n\t\t You inserted a new row in the table!");
		}
	     }
	}
         }
       
	���� ����, ���� ������ ����� Insert() ������ �� ������� � ����������. ������ ���� �� ����� � �� Update  �  Delete. ������ ������ �� ����
	� �������� ��������.

10. �� �� ���� ���� �� ������� ����� ������, �� �� ��������� ������ ��������, ���������� ����� ConsoleKeyInfo.

������:

                     ConsoleKeyInfo sqlcki;
                     sqlcki = Console.ReadKey();

11. ���� ���� ���������� ��������� 'switch'.

������:

 switch (sqlcki.Key)
                                {

                                   case ConsoleKey.Tab:
		   Insert();

		   break;

		}

���� ������ ���������, �� ��� �� ������� �������� 'Tab', �� �� ������� ������� Insert(). 

12.  �� �� �������� ���� ����� ���������� ���� �� � ����������� � ������ ����� ��� �� �, ������  �� ���������� ���������� �� ��� string, 
     ���� ����� ������������ �� ����� ���� � ��� ��� ��.

������:

            Console.WriteLine("\t\t\t Welcome to my database!");

            string reg;
            Console.Write("\n Enter 'Registered' or 'Unregistered': ");
            reg = Console.ReadLine();

           ���� ���� ��� ���������� ������������, �������� �������, ���� ����� �� ��������� ����� �� �� ������� ��� ������������ �� � 
           �����������
          

������:

	 if (reg == "Unregistered")
                {

                Console.Write("\n ID:");
                id_reg = Console.ReadLine();

                string username_reg;
                Console.Write("\n Username:");
                username_reg = Console.ReadLine();

                string password_reg;
                Console.Write("\n Password:");
                password_reg = Console.ReadLine();

                string email_reg;
                Console.Write("\n Email:");
                email_reg = Console.ReadLine();

                int role_reg;
                Console.Write("\n Role_ID:");
                role_reg = int.Parse(Console.ReadLine());  - �� ��� ������� �� ����������, �� ��� ������������ � ���, ������ �� �� ������� ������, � �����
	       		                                   ��� �� ������ id, username, password, email � role_id. ���� ������ ������ �� ����������, ����� 
    				                   ���������� �� ����� �����, �����  ������������ 'reg'.
                                                                               

	���� ���� ����� ������� ���:

	 if (id_reg != "" && username_reg != "" && password_reg != "" && email_reg != "" && role_reg == 1 || role_reg == 2)
                    {

                        SqlConnection sqlcon = new SqlConnection("Server=����� �� �������; Database=����� �� ������; Integrated Security=true; Persist Security Info=false;");
                        sqlcon.Open();

                        SqlCommand sqlcom = new SqlCommand("INSERT INTO [PROJECT].[dbo].[USERS] (ID, USERNAME, PASSWORD, EMAIL, Role_ID)" + "VALUES(@ID, @USERNAME, @PASSWORD, @EMAIL, @Role_ID)", sqlcon);
                        sqlcom.Parameters.Add("@ID", id_reg);
                        sqlcom.Parameters.Add("@USERNAME", username_reg);
                        sqlcom.Parameters.Add("@PASSWORD", password_reg);
                        sqlcom.Parameters.Add("@EMAIL", email_reg);
                        sqlcom.Parameters.Add("@Role_ID", role_reg);


                        SqlDataReader sqldr = sqlcom.ExecuteReader();

                        while (sqldr.Read())
                        {
                            Console.WriteLine("ID:{0}\n Username:{1}\n Password:{2}\n Email:{3}\n, Role_ID:{4}", sqldr.GetSqlValue(0), sqldr.GetString(1), sqldr.GetSqlValue(2), sqldr.GetString(3), sqldr.GetSqlValue(4));
                        }

                        sqldr.Close();

                    } - � ���� ��� �������� �� ����������, �� ��� ������������ � �������� ������ ������ �� �����������, ����������� �� ���� ������ ������ ��
        	        �� ����� �������� � ��������� �.�. �� �� ������� ���������� Insert(). 

                  Console.WriteLine("\n Your dates were inserted in the database!");
                  Console.WriteLine("\n Now close the program and start it again!");

                } - ��� ������� �� �����������, �� ������ �� ������� ���������� � �� � �������� ������ ���� ���� � ����� �������� �� �����.
   
13. ���� �� ������ �� ������� ����� �� �� ����� ��� ������������ ���� � ����������� � ������ �����. ���� ����� ��� ������� ���:

              else
                    if (reg == "Registered")
                    {
                        string reg_username;
                        Console.Write("\n Username:");
                        reg_username = Console.ReadLine();

                        if (reg_username == "")
                        {
                            Console.WriteLine("\n The username cannot be empty!");
                        }

                        else
                            if (reg_username.Length < 5)
                            {
                                Console.WriteLine("\n The username is too short!");

                            } - �������� ��� ������, �� ��� ������������ � ���� ����������� � ���������, �� ������ �� �� ����� ���� username, ���� �� username
		�� ����� � ����� ���������. ���� ���� �� ������� ����������� � ������������ � �������� �������� ������ username, �� �� 
		������ ������ �� ��������:

              if (reg_username != "" && reg_username.Length >= 5)
                        {
                            string reg_password;
                            Console.Write("\n Password:");
                            reg_password = Console.ReadLine();

                            if (reg_password == "")
                            {
                                Console.WriteLine("\n The password cannot be empty!");
                            }

                            else
                                if (reg_password.Length < 5 || reg_password.Length > 15)
                                {
                                    Console.WriteLine("\n The password must be between 5 and 15 symbols!");

                                } - ��� ������ �� ����� ��������, ���� ��� �� �������� � ���� ���� ������������ � ����� username � password, ������ �� 
		    �� �� ������ � ������, � ����� �� �����, ���� � admin ��� user �.�. role_id:

                              else
                                    if (reg_password != "" && reg_password.Length >= 5 || reg_password.Length <= 15)
                                    {
                                        Console.WriteLine("\n Now choose admin or user:");
                                        Console.WriteLine("\n 1: user  2: admin");

                                        int reg_role;
                                        Console.Write("\n Role:");
                                        reg_role = int.Parse(Console.ReadLine());

		���� ���� ������ �� ������� ������� ����� �� ������� ���������� ��� ����������� � �������� ������ username, password � role_id:

                             if  (reg_role == 1)
                                        {
                                            Console.WriteLine("\n\n\t\t\t Welcome, {0}!", reg_username);
                                            System.Threading.Thread.Sleep(1000);
                                            Select();

                                        } - � ���� ��� ��������, �� ��� �������� username � password �� ��������� �������� � role_id ������ �������� 1, ���� ��������, 
   		           �� ������������ � ��������� user � �� �� ������� ���� ������� Select() �.�. ��� �� ���� ���� �� ����� ������ �����, ���
		           �� ���� �� � �������


		���� ���� ����� ������� ���:

		  else
                                            if (reg_role == 2)
                                            {

                                                string admin_pass = "manunited";
                                                Console.Write("\n\n Please, enter your admin password:");
                                                admin_pass = Console.ReadLine();

                                                if (admin_pass == "")
                                                {
                                                    Console.WriteLine("\n\n\t\t Your admin password cannot be empty!");
                                                }

                                         else
                                           if (admin_pass != "manunited")
                                             {
                                                 Console.WriteLine("\n\n\t\t Your admin password is incorrect!");

                                             } - ��� ��������, �� ���  �������� username � password �� ��������� �������� � role_id ������ �������� 2, ���� ��������,
			�� ������������ � admin, � ��� �� ���� �� ������� ������ �����. �� �� ������ �����, �� �������� � �����, 
			��� �� ������ �� ������ � ������(admin_pass), ����� � ������ � 'manunited'. ���� ���� ���� ���� �������� ���� ������,
			������������ �� ���� �� ���� ��������� � �� ������� ������������ ��������. ������������ ������ �� ������
			����� �� �� ������� ��� ���� ���������������� ������ � ��������:

	                    else
                                          if (admin_pass == "manunited")
                                       {
                                          Console.WriteLine("\n\n\t\t\t Welcome, {0}!", reg_username);
                                          System.Threading.Thread.Sleep(1000);
                                          Select();

                                         Console.WriteLine("\n\t\t\t\t Menu:");
                                         Console.WriteLine("\n Please choose one of the options: \n");
                                         Console.WriteLine("1. Insert - press 'Insert'! \n");
                                         Console.WriteLine("2. Update - press 'Tab'!\n");
                                         Console.WriteLine("3. Delete - press 'Delete'!");


                                     ConsoleKeyInfo sqlcki;
                                     sqlcki = Console.ReadKey(); - ���� ���� admin_pass � ��������, �� �� ������� ������� �� ������ �� 3�� �������� � ����
					   ����������� �� ���� �� 3�� ������� ������, �� �� ������� ����������� ��������. �� �����
					   �� �������� ����� ConsoleKeyInfo. ���� ���� ������ �� ���������� ���������� 'switch', �� ��
					   ������� ��� �����, ��� �������� �� ���������:



                                  switch (sqlcki.Key)
                                {

                                 case ConsoleKey.Tab:

                                       Console.WriteLine("\n\n Choose the username to update his password!");

                                      Update();

                                      break;


                                case ConsoleKey.Insert:

                                      Console.WriteLine("\n\n\t\t\t Enter your data:");

                                      Insert();

                                       break;


                               case ConsoleKey.Delete:

                                      Console.WriteLine("\n \n Choose which row to delete:");

                                      Delete();

                                     break;
             
                                     }
                              }
                          }
                       }
                    }
                
	


	                    

