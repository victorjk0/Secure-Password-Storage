using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Secure_Password_Storage.DAL
{
    /// <summary>
    /// DAL class
    /// 
    /// This is where all communication to the database exists
    /// </summary>
    class DatabaseHandler
    {

        //Connection obj init (change connection string for other server.
        //TODO Move Connection string to config file.
        private SqlConnection dbConn = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=SPS;Trusted_Connection=True;");

        public DataTable DBSelectUser(string uname)
        {
            //Selects username and password from database where username = param.
            string query = "SELECT user_login, user_password FROM users WHERE user_login = @username";

            dbConn.Open();

            SqlCommand sqlCmd = new SqlCommand(query, dbConn);

            //sets Username parameter for the sql statment. to avoid SQLInjection.
            sqlCmd.Parameters.AddWithValue("username", uname);


            SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);

            //Creates a new DataTable obj with the table name user.
            DataTable dt = new DataTable("user");

            //executes the sqlquery and returns the data to our DataTable.
            sda.Fill(dt);

            //Closes the sql connection
            dbConn.Close();
            //Removes the connection obj when done.
            dbConn.Dispose();

            return dt;
        }


        public void DBInsertUser(string uname, string passwd)
        {

            dbConn.Open();

            //Insert SQL statement with param1 = user and param2 = passwd
            string query = "INSERT INTO users  VALUES (@username, @password)";

            SqlCommand sqlCmd = new SqlCommand(query, dbConn);

            //sets Username parameter and password parameter for the sql statment. to avoid SQLInjection
            sqlCmd.Parameters.AddWithValue("username", uname);
            sqlCmd.Parameters.AddWithValue("password", passwd);

            //executes the sql statement
            sqlCmd.ExecuteNonQuery();

            //Closes the sql connection
            dbConn.Close();
            //Removes the connection obj when done.
            dbConn.Dispose();
        }
    }
}
