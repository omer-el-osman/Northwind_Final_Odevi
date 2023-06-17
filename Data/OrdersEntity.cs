using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class;

namespace Data
{
    public class OrdersEntity : IHelper<Orders>
    {



        List<Orders> MyList = new List<Orders>();


        public void ShowAllData()
        {
            SqlConnection cn = new SqlConnection("Server = OMER\\SQLEXPRESS;DataBase =Northwind ;integrated security =true ;encrypt=false;");
            cn.Open();    //ISNULL(LastName,'bos')as 'LastName'  format(BirthDate ,'yyyy-MM-dd'),'bos')
            SqlCommand cmm = new SqlCommand("select (Orders.OrderID) ," +
                "ISNULL(Orders.CustomerID,'bos') as 'Orders.CustomerID' ," +
                "ISNULL(Customers.CompanyName,'bos') as 'Customers.CompanyName'," +
                "ISNULL(Customers.ContactName,'bos') as 'Customers.ContactName'," +
                "ISNULL(Customers.Country,'bos') as 'Customers.Country'," +
                "ISNULL(Orders.EmployeeID,-1) as 'Orders.EmployeeID'," +

                "ISNULL(Employees.FirstName,'bos') as 'Employees.FirstName'," +
                "ISNULL(Employees.LastName,'bos') as 'Employees.LastName' ," +

                "ISNULL(format(Orders.OrderDate,'yyyy-MM-dd'),'bos') as 'Orders.OrderDate' ," +//a
                "ISNULL(format(Orders.RequiredDate,'yyyy-MM-dd'),'bos') as 'Orders.RequiredDate'," +//a
                "ISNULL(format(Orders.ShippedDate,'yyyy-MM-dd'),'bos') as 'Orders.ShippedDate' ," +//a

                "ISNULL(Orders.ShipVia,-1) as 'Orders.ShipVia'     ," +
                "ISNULL(Orders.Freight,-1) as 'Orders.Freight'     ," +
                "ISNULL(Orders.ShipName,'bos') as 'Orders.ShipName'   , " +

                "ISNULL(Orders.ShipAddress,'bos') as 'Orders.ShipAddress' " +


                ",ISNULL(Orders.ShipCity,'bos') as 'Orders.ShipCity' ," +
                "ISNULL(Orders.ShipRegion,'bos') as 'Orders.ShipRegion' ," +//ShipPostalCode
                "ISNULL(Orders.ShipPostalCode,'bos') as 'Orders.ShipPostalCode' ," +//ShipPostalCode

                "ISNULL(Orders.ShipCountry,'bos') as 'Orders.ShipCountry' " +
                " from Orders,Customers,Employees " +
                "where  Orders.CustomerID=Customers.CustomerID and Orders.EmployeeID=Employees.EmployeeID ", cn);
            SqlDataReader dr = cmm.ExecuteReader();
            while (dr.Read())
            {

                Orders Orders = new Orders()
                {
                    OrderID = (int)dr[0],
                    CustomerID = (string)dr[1],
                    EmployeeID = (int)dr[5],
                    OrderDate = (string)dr[8],
                    RequiredDate = (string)dr[9],
                    ShippedDate = (string)dr[10],

                    ShipVia = (int)dr[11],
                    Freight = (decimal)dr[12],
                    ShipName = (string)dr[13],

                    ShipAddress = (string)dr[14],
                    ShipCity = (string)dr[15],
                    ShipRegion = (string)dr[16],
                    ShipPostalCode = (string)dr[17],
                    ShipCountry = (string)dr[18],



                     CompanyName = (string)dr[2],
                   ContactName = (string)dr[3],
                   Country = (string)dr[4],
                  FirstName = (string)dr[6],
                  LastName = (string)dr[7]
            };
           
                MyList.Add(Orders);

           


            }

            cn.Close();
        }


        public void AddData(Orders orders)
        {
            SqlConnection cn = new SqlConnection("Server = OMER\\SQLEXPRESS;DataBase =Northwind ;integrated security =true ;encrypt=false;");
            SqlCommand CM;//islemler
            SqlDataAdapter DA;//sqlCommand dan geldigi sonuc SqlDataAdapter e depolanacak

            DataTable DT = new DataTable();
         
            CM = new SqlCommand("Orders_Add", cn);
            CM.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameter = new SqlParameter[13];
            parameter[0] = new SqlParameter("@CustomerID", SqlDbType.VarChar, 50);
            parameter[0].Value = orders.CustomerID;
            parameter[1] = new SqlParameter("@EmployeeID", SqlDbType.Int);
            parameter[1].Value =orders.EmployeeID;

            // Not : Create yaparken date icin syntax boyle olmali :1998-05-06 00:00:00.000
            parameter[2] = new SqlParameter("@OrderDate", SqlDbType.VarChar, 50);
            parameter[2].Value =orders.OrderDate;
            parameter[3] = new SqlParameter("@RequiredDate", SqlDbType.VarChar, 50);
            parameter[3].Value = orders.RequiredDate;
            parameter[4] = new SqlParameter("@ShippedDate", SqlDbType.VarChar, 50);
            parameter[4].Value =orders.ShippedDate;

            parameter[5] = new SqlParameter("@ShipVia", SqlDbType.Int);
            parameter[5].Value =orders.ShipVia;

            parameter[6] = new SqlParameter("@ShipName", SqlDbType.VarChar, 50);
            parameter[6].Value = orders.ShipName;

            parameter[7] = new SqlParameter("@ShipAddress", SqlDbType.VarChar, 50);
            parameter[7].Value = orders.ShipAddress;

            parameter[8] = new SqlParameter("@ShipCity", SqlDbType.VarChar, 50);
            parameter[8].Value = orders.ShipCity;

            parameter[9] = new SqlParameter("@ShipRegion", SqlDbType.VarChar, 50);
            parameter[9].Value = orders.ShipRegion;

            parameter[10] = new SqlParameter("@ShipPostalCode", SqlDbType.VarChar, 50);
            parameter[10].Value = orders.ShipPostalCode;

            parameter[11] = new SqlParameter("@ShipCountry", SqlDbType.VarChar, 50);
            parameter[11].Value = orders.ShipCountry;

            parameter[12] = new SqlParameter("@Freight", SqlDbType.Money);
            parameter[12].Value = orders.Freight;



            CM.Parameters.AddRange(parameter);
            cn.Open();
            CM.ExecuteNonQuery();
            cn.Close();
            AllData();

        }
        public void UpdateData(int id, Orders orders)
        {
            SqlConnection cn = new SqlConnection("Server = OMER\\SQLEXPRESS;DataBase =Northwind ;integrated security =true ;encrypt=false;");
            SqlCommand CM;//islemler
            SqlDataAdapter DA;//sqlCommand dan geldigi sonuc SqlDataAdapter e depolanacak

            DataTable DT = new DataTable();

            CM = new SqlCommand("Orders_Update", cn);
            CM.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameter = new SqlParameter[14];

            parameter[0] = new SqlParameter("@OrderID", SqlDbType.Int);
            parameter[0].Value = orders.OrderID;
            parameter[1] = new SqlParameter("@CustomerID", SqlDbType.VarChar, 50);
            parameter[1].Value = orders.CustomerID;
            parameter[2] = new SqlParameter("@EmployeeID", SqlDbType.Int);
            parameter[2].Value = orders.EmployeeID;

            // Not : Create yaparken date icin syntax boyle olmali :1998-05-06 00:00:00.000
            parameter[3] = new SqlParameter("@OrderDate", SqlDbType.VarChar, 50);
            parameter[3].Value = orders.OrderDate;
            parameter[4] = new SqlParameter("@RequiredDate", SqlDbType.VarChar, 50);
            parameter[4].Value = orders.RequiredDate;
            parameter[5] = new SqlParameter("@ShippedDate", SqlDbType.VarChar, 50);
            parameter[5].Value = orders.ShippedDate;

            parameter[6] = new SqlParameter("@ShipVia", SqlDbType.Int);
            parameter[6].Value = orders.ShipVia;

            parameter[7] = new SqlParameter("@ShipName", SqlDbType.VarChar, 50);
            parameter[7].Value = orders.ShipName;

            parameter[8] = new SqlParameter("@ShipAddress", SqlDbType.VarChar, 50);
            parameter[8].Value = orders.ShipAddress;

            parameter[9] = new SqlParameter("@ShipCity", SqlDbType.VarChar, 50);
            parameter[9].Value = orders.ShipCity;

            parameter[10] = new SqlParameter("@ShipRegion", SqlDbType.VarChar, 50);
            parameter[10].Value = orders.ShipRegion;

            parameter[11] = new SqlParameter("@ShipPostalCode", SqlDbType.VarChar, 50);
            parameter[11].Value = orders.ShipPostalCode;

            parameter[12] = new SqlParameter("@ShipCountry", SqlDbType.VarChar, 50);
            parameter[12].Value = orders.ShipCountry;

            parameter[13] = new SqlParameter("@Freight", SqlDbType.Money);
            parameter[13].Value = orders.Freight;



            CM.Parameters.AddRange(parameter);
            cn.Open();
            CM.ExecuteNonQuery();
            cn.Close();
            AllData();

        }
        public void DeleteData(int id)
        {

            SqlConnection cn = new SqlConnection("Server = OMER\\SQLEXPRESS;DataBase =Northwind ;integrated security =true ;encrypt=false;");
            SqlCommand CM;//islemler
            SqlDataAdapter DA;//sqlCommand dan geldigi sonuc SqlDataAdapter e depolanacak

            DataTable DT = new DataTable();

            CM = new SqlCommand("Orders_Delete", cn);
            CM.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter;
            parameter = new SqlParameter("@OrderID", SqlDbType.Int);
            parameter.Value = id;


            CM.Parameters.Add(parameter);
            cn.Open();
            CM.ExecuteNonQuery();
            cn.Close();
            AllData();

        }










        public void Add(Orders table)
        {
            AddData(table);
        }

        public IList<Orders> AllData()
        {
            MyList.Clear();
            ShowAllData();
            return MyList;
        }

        public void Delete(int id)
        {
            DeleteData(id);
        }

        public Orders Find(int id)
        {
            return MyList.Where(x => x.OrderID == id).FirstOrDefault();
        }

        public void Update(int id, Orders table)
        {
            UpdateData(id, table);
        }
    }
}
