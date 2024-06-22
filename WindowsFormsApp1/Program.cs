using System;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Login());

            if (File.Exists("credentials.txt"))
            {
                // Read the credentials from the file
                using (StreamReader sr = new StreamReader("credentials.txt"))
                {
                    string serverName = sr.ReadLine();
                    string userId = sr.ReadLine();
                    string pass = sr.ReadLine();
                    string db = sr.ReadLine();

                    string SqlConnectionString = $"Data Source={serverName}; Initial Catalog = {db}; User ID = {userId}; Password = {pass}; ";
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(SqlConnectionString))
                        {
                            connection.Open();
                            Application.Run(new WorkOrder(serverName, db, userId, pass));
                        }
                    }
                    catch (Exception ex)
                    {
                        Application.Run(new Login());
                        MessageBox.Show($"Connection failed. Error message: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
            {
                Application.Run(new Login());
            }

        }
    }
}
