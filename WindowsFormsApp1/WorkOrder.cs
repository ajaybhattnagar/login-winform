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
    }
}
