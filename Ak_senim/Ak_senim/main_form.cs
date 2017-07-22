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
        DataTable types;
        DataTable services;
        Database database;
        Order orders = new Order();
        BindingSource binding_source;
        string login;

        string open_fileloc;
        string create_fileloc;
        string merge_fileloc;
        int access;
        public int convert(string input)
        {
            int n = 0;
            if (input != "")
            {
                n = Convert.ToInt32(input);
            }
            return n;
        }
        public main_form(string input_login, int input_access, Database db)
        {
            InitializeComponent();
            login = input_login;
            access = input_access;
            database = db;

            refresh_combobox();
            service_datagrid.DataSource = orders.orders;
        }

        private void s_create_change_button_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "db files (*.db)|*.db|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                create_fileloc = saveFileDialog1.FileName;
                s_create_path_textbox.Text = create_fileloc;
            }
        }

        private void s_create_button_Click(object sender, EventArgs e)
        {
            database.connection_close();
            database = new Database(create_fileloc);

            database.fill_empty();

            Properties.Settings.Default.database = create_fileloc;
            Properties.Settings.Default.Save();

            MessageBox.Show("База данных успешно создана");
        }

        private void s_open_button_Click(object sender, EventArgs e)
        {
            database.connection_close();
            database = new Database(open_fileloc);

            MessageBox.Show("База данных открыта");
        }

        private void s_open_change_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_file_dialog = new OpenFileDialog();
            open_file_dialog.Filter = "db files (*.db)|*.db|All files (*.*)|*.*";
            open_file_dialog.FilterIndex = 1;
            open_file_dialog.RestoreDirectory = true;

            if (open_file_dialog.ShowDialog() == DialogResult.OK)
            {
                open_fileloc = open_file_dialog.FileName;
                s_open_path_textbox.Text = open_fileloc;
            }
        }

        private void s_merge_change_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_file_dialog = new OpenFileDialog();
            open_file_dialog.Filter = "db files (*.db)|*.db|All files (*.*)|*.*";
            open_file_dialog.FilterIndex = 1;
            open_file_dialog.RestoreDirectory = true;

            if (open_file_dialog.ShowDialog() == DialogResult.OK)
            {
                merge_fileloc = open_file_dialog.FileName;
                s_merge_path_textbox.Text = merge_fileloc;
            }
        }

        private void s_merge_button_Click(object sender, EventArgs e)
        {
            database.merge(merge_fileloc);

            MessageBox.Show("База данных успешно добавлена");
        }

        private void s_service_add_button_Click(object sender, EventArgs e)
        {
            int code = Convert.ToInt32(s_service_code_textbox.Text);
            string type = s_service_type_combobox.Text;
            string name = s_service_name_textbox.Text;
            int price = Convert.ToInt32(s_service_price_textbox.Text);
            string doctorcode = s_service_doctorcode_textbox.Text;
            int share = Convert.ToInt32(s_service_share_textbox.Text);
            database.exec(String.Format("insert into services(code, type, name, price, doctorcode, share) values({0},'{1}','{2}',{3},'{4}',{5});", code, type, name, price, doctorcode, share));
            MessageBox.Show("Услуга успешно добавлена");
        }

        private void s_type_add_button_Click(object sender, EventArgs e)
        {
            string type = s_type_name_textbox.Text;
            database.exec(String.Format("insert into types(name) values('{0}');", type));
            refresh_combobox();
            MessageBox.Show("Новый раздел успешно добавлен");
        }

        private void s_user_add_button_Click(object sender, EventArgs e)
        {
            string new_login = s_user_login_textbox.Text;
            string new_password = s_user_password_textbox.Text;
            int new_access = Convert.ToInt32(s_user_access_combobox.Text);
            string name = s_user_name_textbox.Text;
            string memo = s_user_memo_textbox.Text;
            database.exec(String.Format("insert into users(login, password, access, name, memo) values('{0}','{1}',{2},'{3}','{4}');", new_login, new_password, new_access, name, memo));

            MessageBox.Show("Новый пользователь успешно добавлен");
        }

        private void s_doctor_add_button_Click(object sender, EventArgs e)
        {
            string name = s_doctor_name_textbox.Text;
            string code = s_doctor_code_textbox.Text;
            database.exec(String.Format("insert into doctors(name,doctorcode) values('{0}','{1}');", name, code));

            MessageBox.Show("Новый врач успешно добавлен");
        }

        private void refresh_combobox()
        {
            services = database.request("select * from services;");
            types = database.request("select * from types;");

            service_type_combobox.Items.Clear();
            s_service_type_combobox.Items.Clear();

            foreach (DataRow dr in types.Rows)
            {
                service_type_combobox.Items.Add(dr["name"]);
                s_service_type_combobox.Items.Add(dr["name"]);
            }
        }
        private void refresh_service_combobox()
        {
            service_name_combobox.Items.Clear();

            foreach (DataRow dr in services.Rows)
            {
                if (dr["type"].ToString() == service_type_combobox.Text)
                {
                    service_name_combobox.Items.Add(dr["name"]);
                }

            }
        }

        private void service_check_button_Click(object sender, EventArgs e)
        {
            refresh_combobox();
        }

        private void service_type_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            refresh_service_combobox();
        }
        private void refresh_sum()
        {
            int sum = orders.count_sum();
            service_total_sum_label.Text = "Сумма: "+ sum;
        }
        private void service_add_button_Click(object sender, EventArgs e)
        {
            orders.add_order(convert(service_code_textbox.Text), service_name_combobox.Text, convert(service_price_textbox.Text), convert(service_discount_textbox.Text), service_doctorcode_textbox.Text, Convert.ToInt32(service_share_textbox.Text));
            refresh_sum();
            service_datagrid.Refresh();
        }

        private void service_delete_button_Click(object sender, EventArgs e)
        {
            while (service_datagrid.SelectedRows.Count > 0)
            {
                orders.orders.Rows[service_datagrid.SelectedRows[0].Index].Delete();
            }
            refresh_sum();
            service_datagrid.Refresh();
        }

        private void service_save_button_Click(object sender, EventArgs e)
        {
            orders.send_order(login, service_client_name_textbox.Text, database);
            MessageBox.Show("Запись добавлена");
        }
        private void service_price_textbox_TextChanged(object sender, EventArgs e)
        {
            refresh_price();
        }
        private void refresh_price()
        {
            int price = 0;
            int discount = 0;
            if (service_price_textbox.Text != "")
            {
                price = Convert.ToInt32(service_price_textbox.Text);
            }
            if (service_discount_textbox.Text != "")
            {
                discount = Convert.ToInt32(service_discount_textbox.Text);
            }
            service_total_price_label.Text = (price * (100 - discount) / 100).ToString();
        }

        private void service_discount_textbox_TextChanged(object sender, EventArgs e)
        {
            refresh_price();
        }
        public void clear_service_form()
        {
            service_client_name_textbox.Text = "";
            service_name_combobox.Text = "";
            service_type_combobox.Text = "";
            service_code_textbox.Text = "";
            service_price_textbox.Text = "";
            service_discount_textbox.Text = "";
            service_doctorcode_textbox.Text = "";
            service_share_textbox.Text = "";
            service_white_checkbox.Checked = false;
            orders.clear();
            service_datagrid.Refresh();
            refresh_sum();
        }
        private void service_refresh_button_Click(object sender, EventArgs e)
        {
            clear_service_form();
        }

        private void service_type_combobox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            refresh_service_combobox();
        }

        private void service_name_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in services.Rows)
            {
                if (dr["name"].ToString() == service_name_combobox.Text)
                {
                    service_code_textbox.Text = dr["code"].ToString();
                    service_price_textbox.Text = dr["price"].ToString();
                    service_doctorcode_textbox.Text = dr["doctorcode"].ToString();
                    service_share_textbox.Text = dr["share"].ToString();
                }
            }
        }

        private void service_code_textbox_TextChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in services.Rows)
            {
                if (dr["code"].ToString() == service_code_textbox.Text)
                {
                    service_name_combobox.Text = dr["name"].ToString();
                    service_price_textbox.Text = dr["price"].ToString();
                    service_doctorcode_textbox.Text = dr["doctorcode"].ToString();
                    service_share_textbox.Text = dr["share"].ToString();
                    service_type_combobox.Text = dr["type"].ToString();
                }
            }
        }
    }
}