using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class WorkOrder : Form
    {
        public string dbname = "";
        public string usname = "";
        public string pass = "";
        public string serverName = "";

        public DataTable dataTable;
        public WorkOrder(string servername, string database, string username, string password)
        {
            serverName = servername;
            dbname = database;
            usname = username;
            pass = password;
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.Manual;
            Rectangle screen = Screen.FromPoint(Cursor.Position).WorkingArea;
            int w = Width >= screen.Width ? screen.Width : (screen.Width + Width) / 2;
            int h = Height >= screen.Height ? screen.Height : (screen.Height + Height) / 2;
            Location = new Point(screen.Left + (screen.Width - w) / 2, screen.Top + (screen.Height - h) / 2);
            Size = new Size(w, h);
        }
    }
}
