���� ��������� ������������:

1 - ����������� Microsoft Visual Studio

2 - �������� �� File -> Open -> Project/Solution � �������� ����� CRUDAccessConsole.sln, ������ �� �������� �������� �� ����, � ���� ���� �������� �� Open

3 - �������� ��������� � ������ ����� Users:
- �������� �� Tools -> Connect to Database
- ��� �� ������ �������� Add Connection �������� �� Change ������ ���� Data source
- �� �� ������ �������� Change Data Source, ��� � ������� Data source �������� �� Microsoft Access Database File � ���� ���� �������� OK
- ������ �� �� ������ ��������� Add Connection, �� ���� ��� �������� �� Browse, ������ ���� Database file name � �������� ����� Users.accdb, ������ �� �������� �������� �� ����, � ���� ���� �������� �� Open
- ���� ���� ������ � ��������� Add Connection �������� �� Test Connection � ��� �� ������ ��� �������� � �����: Test 
connection succeeded. �������� �� OK
- ����� ��� � ��������� Add Connection �������� �� OK
- �������� �� View -> Server Explorer, �� �� �� ������ ��������� Server Explorer, ��� �� � ���� ��������
- �������� �� View -> Properties Window, �� �� �� ������ ��������� Properties, ��� �� � ���� ��������
- �� ��������� Server Explorer �������� �� Users.accdb � ���� ���� � ��������� Properties ��������� ������ �� Connection String-�:

�������� �����: Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\user\Desktop\1301681022_Janeta_Stanilova\Users.accdb

- ���������� ���� ����� �� Connection String-� ��������� � ������� ���, ������� �� ��� � �������� �� ���������� ���:
aConnection =
    new OleDbConnection(@"�������� ��� ����������");

������: aConnection =
            new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\user\Desktop\1301681022_Janeta_Stanilova\Users.accdb");

���� ��������� � �������� ��� ������ ����� Users!

4 - ����������� ��������� ���� �������� �� Debug -> Start Without Debugging

5- ��� ���� ������������ ������� �� ������:
- ����, ����� �� �� ���� ���� ��� ������������ ��� ��
- ��� �� ��� �����������, �� �� ����������
- ��� ��� �����������, �� �� ������ �� �� �������
- ��� ��� ����������� ���� Member, �� �� ������ ������ �����
- ��� ��� ����������� ���� Admin, �� �� ���� �� �������� �� ������, ����� �: adminpassword, ���� ���� � �������� �� �� ������ ����� ����, �� ����� �� ������ �� ������ ������ �����, �� �������� ���� �����������, �� ���������� �����, ��������, ������ ��� ������(Member/Admin) �� ����� ����������, �� ������ �����������, ��� �� �������� �� �����������

6 - ������ ���������� ��������� Microsoft Visual Studio