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
        string data_source = "ak_senim.db";
        SQLiteConnection connection;
        public void connection_open()
        {

            connection = new SQLiteConnection(String.Format("Data Source={0};", data_source));
            connection.Open();
        }

        public void connection_close()
        {
            connection.Close();
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
    }
}
