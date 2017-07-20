using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ak_senim
{
    public class Order
    {
        public DataTable orders;
        private string client_name = "";
        public Order()
        {
            set_new_order();
        }
        public void set_client_name(string name)
        {
            client_name = name;
        }

        public void set_new_order()
        {
            orders = new DataTable();
            orders.Columns.Add("service_code");
            orders.Columns.Add("service_name");
            orders.Columns.Add("price");
            orders.Columns.Add("discount");
            orders.Columns.Add("final_price");
            orders.Columns.Add("share");
            orders.Columns.Add("doctor");
        }

        public int sum()
        {
            int s = 0;
            foreach(DataRow dr in orders.Rows)
            {
                s += Convert.ToInt32(dr["final_price"]);

            }
            return s;
        }
        public void add_order( int service_code, string service_name, int price, int discount, string doctorcode ,int share)
        {
            DataRow dr = orders.NewRow();
            dr["service_code"] = service_code;
            dr["service_name"] = service_name;
            dr["price"] = price;
            dr["discount"] = discount;
            dr["final_price"] = price * (100 - discount) / 100;
            dr["doctor"] = doctorcode;
            dr["share"] = share;

            orders.Rows.Add(dr);
        }
        

    }
}
