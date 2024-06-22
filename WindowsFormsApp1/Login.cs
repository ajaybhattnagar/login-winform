using System;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;


namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public string filePath = Environment.CurrentDirectory + "\\config.ini";

        public Login()
        {
            InitializeComponent();
            password.PasswordChar = '*';
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            login();

            //Save credential to the file
            save_creds();
        }

        private void login()
        {
            try
            {

                if (server_name.Text != null && database.Text != null && database.Text != "" && user_name.Text != null && password.Text != null)
                {
                    string SqlConnectionString = $"Data Source={server_name.Text}; Initial Catalog = {database.Text}; User ID = {user_name.Text}; Password = {password.Text}; ";

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(SqlConnectionString))
                        {
                            connection.Open();
                            WorkOrder wo = new WorkOrder(server_name.Text, database.Text, user_name.Text, password.Text);
                            wo.Show();

                            this.Hide();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Connection failed. Error message: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"Please enter all the fields above.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception EX)
            {
                MessageBox.Show(text: EX.ToString());
            }
        }

        private void serverTextKeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void usernameKeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            if (File.Exists("credentials.txt"))
            {
                // Read the credentials from the file
                using (StreamReader sr = new StreamReader("credentials.txt"))
                {
                    string serverName = sr.ReadLine();
                    string userId = sr.ReadLine();
                    string pass = sr.ReadLine();
                    string db = sr.ReadLine();

                    server_name.Text = serverName;
                    user_name.Text = userId;
                    password.Text = pass;
                    database.Text = db;
                }
            }
        }

        private void save_creds()
        {
            string userId = user_name.Text;
            string pass = password.Text;
            string serverName = server_name.Text;
            string db = database.Text;

            // Save the credentials to a file
            using (StreamWriter sw = new StreamWriter("credentials.txt"))
            {
                sw.WriteLine(serverName);
                sw.WriteLine(userId);
                sw.WriteLine(pass);
                sw.WriteLine(db);
            }
        }

        private void OnClose(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
