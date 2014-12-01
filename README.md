Book Manager: A simple system to manage book records in a database

A project by: Plamena Radneva (rhythmxholic@gmail.com)

#SUMMARY:
* This is a university project for the event-driven programming course
* Should work with Visual Studio 2010 - 2013 (possible breakdowns though)
* A WinForms - based project, implementing simple CRUD using Access DB
* Four forms to operate with
* Five data attributes for a single DB record (book): id, title, author, price and ISBN
	
#DESCRIPTION: 
##Functions/Forms:
* When running the project, the first form you see is called BookManager which has the duty of
a splash screen and can only redirect to the other 3 forms described below;
* <b>View All Books (a.k.a. ViewAll form)</b> - Consits of a lame table (build using labels because VS 2013 didn't provide me with a Line Shape Tool :/ )
where all the present data is going to be displayed by clicking the View button;
* <b>Find/Edit/Delete Book (a.k.a. FindBook form)</b> - User can search only by book title and can change details about the record.
Also, user can input any string for price and ISBN because I was too lazy to make dinput data check. Also, it can
only retrieve one record at a time;
* <b>Add Book (a.k.a. AddBook form)</b> - Speaks for itself, its function is to allow the user to add new records to the DB.
User can add only one record at a time. Has some "amazing" input data check.

##Additional classes:
* <b>BookEntity class</b> - "Storage" class consisting of only properties used in retrieving the data from the DB;
* <b>ViewLabel class</b> - A user-defined class which overrides the hardcoded Label class. This one is used
for displaying the data in the ViewAll form.

>Notes: 
- Please read the comments in the models and controllers folders first in order to understand the whole project;
- The database used for this project is named 'library.mdb' and can be found in the DB\ folder of the project

#INSTRUCTIONS:
* Start the solution (.sln-file) called '1301681023_PlamenaRadneva' in the folder with the same name
* For login:
	- to test the admin role: use 'admin' for username and 'password' for password without the apostrophes
	- to test the member role: use 'user_member' for username and 'password1' for password without the apostrophes
* No matter as who you log in, start breaking the project however you may want ^___^
