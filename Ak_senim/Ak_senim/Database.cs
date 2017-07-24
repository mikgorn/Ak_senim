using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;

namespace Ak_senim
{
    public class Database
    {
        string data_source = "";
        SQLiteConnection connection;
        string create_fileloc = "";
        public Database(string source)
        {

            data_source = source;

            if (source == "new")
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "db files (*.db)|*.db|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    create_fileloc = saveFileDialog1.FileName;
                }
                data_source = create_fileloc;
                Properties.Settings.Default.database = create_fileloc;
                Properties.Settings.Default.Save();
                
                MessageBox.Show("База данных успешно создана");
            }
            this.connection_open();
        }

        public void connection_open()
        {
            try
            {
                connection = new SQLiteConnection(String.Format("Data Source={0};", data_source));
                connection.Open();
            }
            catch  (Exception ex){ MessageBox.Show(ex.Message); }
        }

        public void connection_close()
        {
            try
            {
                connection.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public DataTable request(string request_message)
        {
            DataTable dt = new DataTable();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(request_message, connection);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                cmd.CommandType = CommandType.Text;
                da.Fill(dt);
                
            }catch(Exception ex) { MessageBox.Show(ex.Message); }

            return dt;
        }

        public void exec(string request_message)
        {
            SQLiteCommand cmd = new SQLiteCommand(request_message, connection);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }
        public void fill_empty()
        {
            this.exec("create table if not exists users(id rowid, login text, password text, access int, name text, memo text);");
            this.exec("create table if not exists types(id rowid, name text);");
            this.exec("create table if not exists services(id rowid, code int, type text, name text, price int, doctorcode text, share int);");
            this.exec("create table if not exists doctors(id rowid,name text,doctorcode text);");
            this.exec("create table if not exists logs(date datetime default CURRENT_TIMESTAMP, name text, service_code int, price int, discount int, final int, doctorcode text, share int, white int, login text);");
            this.exec("create table if not exists book(date text,time text, doctor text, name text, phone text, doctorcode int, memo text);");
        }
        public void merge(string db)
        {
            this.exec(String.Format("attach '{0}' as toMerge;" +
                "BEGIN;" +
                "insert into users select *from toMerge.users;" +
                "insert into types select *from toMerge.types;" +
                "insert into services select *from toMerge.services;" +
                "insert into doctors select *from toMerge.doctors;" +
                "insert into logs select *from toMerge.logs;" +
                "insert into book select *from toMerge.book;" +
                "COMMIT;detach toMerge; ",db));
        }
    }
}
