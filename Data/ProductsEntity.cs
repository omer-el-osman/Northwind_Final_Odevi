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
    public class ProductsEntity : IHelper<Products>
    {


        List<Products> MyList = new List<Products>();


        public void ShowAllData()
        {
            SqlConnection cn = new SqlConnection("Server = OMER\\SQLEXPRESS;DataBase =Northwind ;integrated security =true ;encrypt=false;");
            cn.Open();    //ISNULL(LastName,'bos')as 'LastName'  format(BirthDate ,'yyyy-MM-dd'),'bos')
            SqlCommand cmm = new SqlCommand("select ISNULL(ProductID,-1) as 'ProductID'," +
                "ISNULL(ProductName,'bos') as 'ProductName'," +
                "ISNULL(Suppliers.CompanyName,'bos') as 'Suppliers'," +
                "ISNULL(Suppliers.ContactName,'bos') as 'Suppliers'," +
                "ISNULL(Categories.CategoryName,'bos') as 'Categories'," +
                "ISNULL(QuantityPerUnit,'bos') as 'QuantityPerUnit'," +
                "ISNULL(UnitPrice,-1) as 'UnitPrice'," +
                "ISNULL(UnitsInStock,-1) as 'UnitsInStock'," +
                "ISNULL(UnitsOnOrder,-1) as 'UnitsOnOrder'," +
                "ISNULL(ReorderLevel,-1) as 'ReorderLevel'," +
                "ISNULL(Discontinued,'bos') as 'Discontinued' " +
                "from Products ,Categories ,Suppliers " +
                "where Categories.CategoryID=Products.CategoryID and Products.SupplierID=Suppliers.SupplierID ", cn);
            SqlDataReader dr = cmm.ExecuteReader();
            while (dr.Read())
            {

                Products products = new Products()
                {
                    ProductID = (int)dr[0],
                    ProductName = (string)dr[1],
                    CompanyName = (string)dr[2],
                    ContactName = (string)dr[3],
                    CategoryName = (string)dr[4],
                    QuantityPerUnit = (string)dr[5],
                    UnitPrice = (decimal)dr[6],
                    UnitsInStock = (short)dr[7],
                    UnitsOnOrder = (short)dr[8],
                    ReorderLevel = (short)dr[9],
                    Discontinued = (bool)dr[10]

                };

                MyList.Add(products);




            }

            cn.Close();
        }


        public void AddData(Products products)
        {
            SqlConnection cn = new SqlConnection("Server = OMER\\SQLEXPRESS;DataBase =Northwind ;integrated security =true ;encrypt=false;");
            SqlCommand CM;//islemler
            SqlDataAdapter DA;//sqlCommand dan geldigi sonuc SqlDataAdapter e depolanacak

            DataTable DT = new DataTable();

            CM = new SqlCommand("Products_Add", cn);
            CM.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameter = new SqlParameter[9];

            parameter[0] = new SqlParameter("@ProductName", SqlDbType.VarChar, 50);
            parameter[0].Value = products.ProductName;
            parameter[1] = new SqlParameter("@SupplierID", SqlDbType.Int);
            parameter[1].Value = products.SupplierID;

            // Not : Create yaparken date icin syntax boyle olmali :1998-05-06 00:00:00.000
            parameter[2] = new SqlParameter("@CategoryID", SqlDbType.Int);
            parameter[2].Value = products.CategoryID;
            parameter[3] = new SqlParameter("@QuantityPerUnit", SqlDbType.VarChar, 50);
            parameter[3].Value = products.QuantityPerUnit;
            parameter[4] = new SqlParameter("@UnitPrice", SqlDbType.Money);
            parameter[4].Value = products.UnitPrice;

            parameter[5] = new SqlParameter("@UnitsInStock", SqlDbType.SmallInt);
            parameter[5].Value = products.UnitsInStock;

            parameter[6] = new SqlParameter("@UnitsOnOrder", SqlDbType.SmallInt);
            parameter[6].Value = products.UnitsOnOrder;

            parameter[7] = new SqlParameter("@ReorderLevel", SqlDbType.SmallInt);
            parameter[7].Value = products.ReorderLevel;

            parameter[8] = new SqlParameter("@Discontinued", SqlDbType.Bit);
            parameter[8].Value = products.Discontinued;




            CM.Parameters.AddRange(parameter);
            cn.Open();
            CM.ExecuteNonQuery();
            cn.Close();
            AllData();

        }
        public void UpdateData(int id, Products products)
        {
            SqlConnection cn = new SqlConnection("Server = OMER\\SQLEXPRESS;DataBase =Northwind ;integrated security =true ;encrypt=false;");
            SqlCommand CM;//islemler
            SqlDataAdapter DA;//sqlCommand dan geldigi sonuc SqlDataAdapter e depolanacak

            DataTable DT = new DataTable();

            CM = new SqlCommand("Products_Update", cn);
            CM.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameter = new SqlParameter[10];
            parameter[0] = new SqlParameter("@ProductID", SqlDbType.Int);
            parameter[0].Value = products.ProductID;
            parameter[1] = new SqlParameter("@ProductName", SqlDbType.VarChar, 50);
            parameter[1].Value = products.ProductName;
            parameter[2] = new SqlParameter("@SupplierID", SqlDbType.Int);
            parameter[2].Value = products.SupplierID;

            // Not : Create yaparken date icin syntax boyle olmali :1998-05-06 00:00:00.000
            parameter[3] = new SqlParameter("@CategoryID", SqlDbType.Int);
            parameter[3].Value = products.CategoryID;
            parameter[4] = new SqlParameter("@QuantityPerUnit", SqlDbType.VarChar, 50);
            parameter[4].Value = products.QuantityPerUnit;
            parameter[5] = new SqlParameter("@UnitPrice", SqlDbType.Money);
            parameter[5].Value = products.UnitPrice;

            parameter[6] = new SqlParameter("@UnitsInStock", SqlDbType.SmallInt);
            parameter[6].Value = products.UnitsInStock;

            parameter[7] = new SqlParameter("@UnitsOnOrder", SqlDbType.SmallInt);
            parameter[7].Value = products.UnitsOnOrder;

            parameter[8] = new SqlParameter("@ReorderLevel", SqlDbType.SmallInt);
            parameter[8].Value = products.ReorderLevel;

            parameter[9] = new SqlParameter("@Discontinued", SqlDbType.Bit);
            parameter[9].Value = products.Discontinued;



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

            CM = new SqlCommand("Product_Delete", cn);
            CM.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter;
            parameter = new SqlParameter("@ProductID", SqlDbType.Int);
            parameter.Value = id;


            CM.Parameters.Add(parameter);
            cn.Open();
            CM.ExecuteNonQuery();
            cn.Close();
            AllData();

        }













        public void Add(Products table)
        {
            AddData(table);
        }

        public IList<Products> AllData()
        {
            MyList.Clear();
            ShowAllData();
            return MyList;
        }

        public void Delete(int id)
        {
            DeleteData(id);
        }

        public Products Find(int id)
        {
            return MyList.Where(x => x.ProductID == id).FirstOrDefault();
        }

        public void Update(int id, Products table)
        {
            UpdateData(id, table);
        }
    }
}
