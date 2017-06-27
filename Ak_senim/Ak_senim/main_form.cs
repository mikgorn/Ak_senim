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
        
        private void create_database(object sender, EventArgs e)
        {
            database.exec("create table if not exists log(_id integer primaty key," +
                "time datetime default current_timestamp," +
                "client_name text," +
                "client_code integer," +
                "service_id integer," +
                "price integer not null," +
                "discount integer," +
                "price_final integer," +
                "doctor_code integer);");

            database.exec("create table if not exists users(_id integer primary key, " +
                "name text unique not null, " +
                "password text not null," +
                "access integer not null);");
            database.exec("insert into users(name,password,access) values('kirill','ann',1);");

            database.exec("create table if not exists service(_id integer primary key," +
                "name text unique not null," +
                "type text," +
                "price integer not null," +
                "doctor text," +
                "share integer);");

            database.exec("create table if not exists type(_id integer primary key," +
                "name text unique not null);");

            

            MessageBox.Show("Database created");
        }
    }
}
