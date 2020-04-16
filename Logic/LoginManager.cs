using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Secure_Password_Storage.Models;

namespace Secure_Password_Storage.Logic
{
    class LoginManager
    {
        public bool PasswordVerifier(User user, string userInput)
        {
            //inits the Hashing Manager
            HashingManager hManager = new HashingManager();

            //Takes the user objecs password which is fetched from the database
            //and splits it so we can extract our salt.
            string salt = user.Password.Split(":")[0];
            
            //Takes the same password as above and splits it so we can get our
            //salted hash.
            string dbHash = user.Password.Split(":")[1];

            //converts the salt from base64 to a byte array to verify
            byte[] bsalt = Convert.FromBase64String(salt);

            //converts the hash from base64 to a byte array to verify
            byte[] bHash = Convert.FromBase64String(dbHash);

            //Hashes the user input with the salt from the database to
            //verify that they match
            byte[] userInputHashed = hManager.CreateHash(userInput, bsalt);

            //Matches the user inputs salted hash to the salted hash fetched from the database.
            bool isEqual = bHash.SequenceEqual(userInputHashed) ?  true : false;

            //returns true false for login form
            return isEqual;
        }



    }
}
