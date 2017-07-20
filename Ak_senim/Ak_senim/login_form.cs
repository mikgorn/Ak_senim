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
    public partial class login_form : Form
    {
        static string db_loc = Properties.Settings.Default.database;
        Database database = new Database(db_loc);
        public login_form()
        {
            InitializeComponent();
        }

        private void log_in(object sender, EventArgs e)
        {
            string login = login_textbox.Text;
            string password = password_textbox.Text;

            DataTable dt = database.request(String.Format("select * from users where login='{0}';",login));
            if ((login == "") && (password == ""))
            {
                access_main(login, 1);
            }
            if (dt.Rows.Count > 0)
            {
                string correct_pass = dt.Rows[0]["password"].ToString();
                if (password == correct_pass)
                {
                    access_main(login, 1);
                }
                else { MessageBox.Show("Incorrect password"); }
            }
            else { MessageBox.Show("Login has not found"); }
            
        }
        private void access_main(string login, int access)
        {
            this.Hide();
            var form = new main_form(login, access,database);
            form.ShowDialog();
            this.Close();
        }
    }
}
