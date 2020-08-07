using Newtonsoft.Json;
using System;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace afw_project.Model
{
    /// <summary>
    /// JSON object to read
    /// </summary>
    class Credentials
    {
        public string connection;
        public string admin_ID;
        public string admin_password;
    }

    static class ContextCredentials
    {
        /// <summary>
        /// path to file with credential information
        /// </summary>
        private static readonly string connection_file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)) + @"\connection.json";

        /// <summary>
        /// Gets or sets the connection string information
        /// </summary>
        public static string Connection { get; private set; }

        /// <summary>
        /// Gets or sets the username for  the administrator
        /// </summary>
        private static string Admin_ID { get; set; }

        /// <summary>
        /// Gets or sets the password for the administrator
        /// </summary>
        private static string Admin_Password { get; set; }

        /// <summary>
        /// SHA for passwords.
        /// </summary>
        /// <param name="source">Plain password of the customer.</param>
        /// <returns>Password value in SHA256.</returns>
        public static string GetHash(string source)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
                byte[] hashBytes = sha256Hash.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
                return hash;
            }
        }

        /// <summary>
        /// Gets the credentials saved in the file
        /// </summary>
        /// <returns>Whether the data connection to the database was succesful.</returns>
        public static bool GetSavedCredentials()
        {
            try
            {
                string text = File.ReadAllText(connection_file);
                Credentials credentials = JsonConvert.DeserializeObject<Credentials>(text);
                Connection = credentials.connection;

                Context db = new Context();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Saves the information in the file.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="admin_ID"></param>
        /// <param name="admin_password"></param>
        public static void SetCredentials(string connectionString, string admin_ID, string admin_password)
        {
            Connection = connectionString;
            Admin_ID = admin_ID;
            Admin_Password = admin_password;
            try
            {
                Credentials credentials = new Credentials { admin_ID = Admin_ID, connection = Connection, admin_password = Admin_Password };
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    string text = JsonConvert.SerializeObject(credentials);
                    File.WriteAllText(connection_file, text);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
