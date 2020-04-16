using System;
using System.Collections.Generic;
using System.Text;
using Secure_Password_Storage.Logic;
using Secure_Password_Storage.Models;

namespace Secure_Password_Storage
{
    class ManagerController
    {
        DatabaseManager dbManager;
        HashingManager hashManager;
        LoginManager loginManager;
        User user;

        public bool VerifyLogin(string uname, string passwd)
        {
            //inits DatabaseManger
            dbManager = new DatabaseManager();
            //inits LoginManager
            loginManager = new LoginManager();
            //calls the function to fetch a user object from the database
            user = dbManager.FetchUser(uname);
            
            //Checks that user exists
            if (user == null)
            {
                //if not return false
                return false;
            }
            else
            {
                //else Verify that salted hashes matches (returns true if match and false if not)
                return loginManager.PasswordVerifier(user, passwd);
            }

        }

        //Function to create Test Accounts
        public void CreateTestAccounts()
        {
            //inits the HashManager
            hashManager = new HashingManager();
            
            //inits the DatabaseManager
            dbManager = new DatabaseManager();



            //ints a userList to create multiple accounts 
            List<User> uL = new List<User>();

            uL.Add(new User("Adam", "1234"));
            uL.Add(new User("Leif", "4321"));
            uL.Add(new User("Lars", "asd123"));
            uL.Add(new User("Jens", "321dsa"));
            uL.Add(new User("Frank", "qwerty12"));
            uL.Add(new User("Ole", "21ytrewq"));
            uL.Add(new User("Andy", "5x03Meu7J38"));

            
            foreach (User u in uL)
            {
                //creates custom salt for each user
                byte[] bsalt = hashManager.CreateSalt();

                //creates salted hash for each user
                byte[] hpassword = hashManager.CreateHash(u.Password, bsalt);

                //Inserts user into database, with the username in plaintext and salted hash with the salt, format salt:saltedHash which is base64 encoded.
                dbManager.CreateUser(u.Username, Convert.ToBase64String(bsalt)+":"+Convert.ToBase64String(hpassword));
            }
        }



    }
}
