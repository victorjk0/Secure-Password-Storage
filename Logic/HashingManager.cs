using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Secure_Password_Storage.Logic
{
    class HashingManager
    {
        public const int SALT_SIZE = 24;
        public const int HASH_SIZE = 24;
        public const int ITERATIONS = 100000;

        //creates a salted hash with string a string input and a custom salt.
        public byte[] CreateHash(string passwd, byte[] salt)
        {
            //Inits Rfc2898DeriveBytes which takes a string a salt and some iterations to generate a salted hash x ITERATIONS
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(passwd, salt, ITERATIONS);
            
            //Returns the generated key.
            return pbkdf2.GetBytes(HASH_SIZE);
        }

        //Creats a salt
        public byte[] CreateSalt()
        {
            //Inits the RNGCryptoServiceProvider which makes random numbers
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SALT_SIZE];
            //Generates the salt for our hashing Function.
            provider.GetBytes(salt);
            return salt;
        }
    }
}
