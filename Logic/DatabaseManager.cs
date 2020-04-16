using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Secure_Password_Storage.DAL;
using Secure_Password_Storage.Models;

namespace Secure_Password_Storage.Logic
{
    class DatabaseManager
    {
        //Inits DAL DatabaseHandler so we can talk with a database.
        DatabaseHandler dbHandler = new DatabaseHandler();

        //Create user function
        public void CreateUser(string uname, string passwd)
        {     
            //Calls the function that inserts users into the db.
            dbHandler.DBInsertUser(uname, passwd);
        }


        //Fetches a single user.
        public User FetchUser(string username)
        {
            //fills dbResults with results from database.
            DataTable dbResults = dbHandler.DBSelectUser(username);
            
            //selects all datarows.
            DataRow[] rows = dbResults.Select();

            //checks that a row is returned
            if(rows.Length > 0)
            {
                //returns a new user object with username and password from database.
                return new User(rows[0]["user_login"].ToString(), rows[0]["user_password"].ToString());
            }
            return null;
        }
    }
}
