﻿using System;
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
            orders.Columns.Add("final");
            orders.Columns.Add("share");
            orders.Columns.Add("doctorcode");
        }
        public void clear()
        {
            orders.Clear();
        }
        public int count_sum()
        {
            int sum = 0;
            foreach (DataRow dr in orders.Rows)
            {
                sum += Convert.ToInt32(dr["final"]);
            }
            return sum;
        }
        public string reason_line()
        {
            string s = "";
            if (orders.Rows.Count > 0)
            {
                s = orders.Rows[0]["service_name"].ToString();
            }
            if (orders.Rows.Count > 1)
            {
                s += " +" + (orders.Rows.Count - 1) + " услуг(и)";
            }
            return s;
        }
        public void add_order(int service_code, string service_name, int price, int discount, string doctorcode, int share)
        {
            DataRow dr = orders.NewRow();
            dr["service_code"] = service_code;
            dr["service_name"] = service_name;
            dr["price"] = price;
            dr["discount"] = discount;
            dr["final"] = price * (100 - discount) / 100;
            dr["doctorcode"] = doctorcode;
            dr["share"] = share;

            orders.Rows.Add(dr);
        }

        public void send_order(string login, string name, int white,Database database)
        {
            foreach (DataRow dr in orders.Rows)
            {
                string request = String.Format("insert into logs(name, service_code , price , discount , final , doctorcode , share,white , login) values('{0}',{1},{2},{3},{4},'{5}',{6},{7},'{8}');",
                    name,
                    dr["service_code"],
                    dr["price"],
                    dr["discount"],
                    dr["final"],
                    dr["doctorcode"],
                    dr["share"],
                    white,
                    login);
                database.exec(request);
            }
        }

    }
}