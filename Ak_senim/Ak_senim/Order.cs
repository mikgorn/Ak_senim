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
        private DataTable orders;
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
            orders.Columns.Add("service_name");
            orders.Columns.Add("service_code");
            orders.Columns.Add("service_type");
            orders.Columns.Add("price");
            orders.Columns.Add("doctor");
        }

        public void add_order(string service_name, int service_code, string service_type, int price, string doctor ="")
        {

        }

    }
}
