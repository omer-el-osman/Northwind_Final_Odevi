using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class;

namespace Data
{
    public class Order_Details_Entity : IHelper<Order_Details>
    {


        List<Order_Details> MyList = new List<Order_Details>();


        public void ShowAllData()
        {
            SqlConnection cn = new SqlConnection("Server = OMER\\SQLEXPRESS;DataBase =Northwind ;integrated security =true ;encrypt=false;");
            cn.Open();
            SqlCommand cmm = new SqlCommand("select * from [dbo].[Order Details]", cn);
            SqlDataReader dr = cmm.ExecuteReader();
            while (dr.Read())
            {

                Order_Details order_details = new Order_Details()
                {
                    OrderID = (int)dr[0],
                    ProductID = (int)dr[1],
                    UnitPrice = (decimal)dr[2],
                    Quantity = (Int16)dr[3],
                    Discount = (Single)dr[4],
                };
                MyList.Add(order_details);


            }

            cn.Close();
        }


        public void Add(Order_Details table)
        {
            throw new NotImplementedException();
        }

        public IList<Order_Details> AllData()
        {
            MyList.Clear();
            ShowAllData();
            return MyList;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Order_Details Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Order_Details table)
        {
            throw new NotImplementedException();
        }
    }
}
