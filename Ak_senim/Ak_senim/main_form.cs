using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ak_senim
{
    public partial class main_form : Form
    {
        Database database;
        string login;
        int access;
        
        public main_form(string input_login, int input_access, Database db)
        {
            InitializeComponent();
            login = input_login;
            access = input_access;
            database = db;
        }
        
       

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {

        }
    }
}
