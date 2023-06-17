using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class;

namespace Data
{
    public class CustomersEntity : IHelperCustomers<Customers>
    {
        List<Customers> MyList = new List<Customers>();


        public void ShowAllData()
        {
            SqlConnection cn = new SqlConnection("Server = OMER\\SQLEXPRESS;DataBase =Northwind ;integrated security =true ;encrypt=false;");
            cn.Open();
            SqlCommand cmm = new SqlCommand("select ISNULL(CustomerID,'bos')as 'CustomerID' ," +
                "ISNULL(CompanyName,'bos')as 'CompanyName' ," +
                "ISNULL(ContactName,'bos')as 'ContactName' ," +
                "ISNULL(ContactTitle,'bos')as 'ContactTitle' ," +
                "ISNULL(Address,'bos')as 'Address' ," +
                "ISNULL(City,'bos')as 'City' ," +
                "ISNULL(Region,'bos')as 'Region' ," +
                "ISNULL(PostalCode,'bos')as 'PostalCode' ," +
                "ISNULL(Country,'bos')as 'Country' ," +
                "ISNULL(Phone,'bos')as 'Phone' ," +
                "ISNULL(Fax,'bos')as 'Fax'  from Customers", cn);
            SqlDataReader dr = cmm.ExecuteReader();
            while (dr.Read())
            {
              
               
                
                    Customers customers = new Customers()
                    {
                        CustomerID = (string)dr[0],
                        CompanyName = (string)dr[1],
                        ContactName = (string)dr[2],
                        ContactTitle =(string) dr[3],
                        Address = (string)dr[4],
                        City = (string)dr[5],
                        Region = (string)dr[6],
                        PostalCode = (string)dr[7],
                        Country = (string)dr[8],
                        Phone = (string)dr[9],
                        Fax = (string)dr[10]                        
                        
                    };
                    MyList.Add(customers);
       

            }

            cn.Close();
        }


        public void AddData(Customers customers)
        {
            SqlConnection cn = new SqlConnection("Server = OMER\\SQLEXPRESS;DataBase =Northwind ;integrated security =true ;encrypt=false;");
            SqlCommand CM;//islemler
            SqlDataAdapter DA;//sqlCommand dan geldigi sonuc SqlDataAdapter e depolanacak

            DataTable DT = new DataTable();

            CM = new SqlCommand("Customers_Add", cn);
            CM.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameter = new SqlParameter[11];
            parameter[0] = new SqlParameter("@CID", SqlDbType.VarChar,50);
            parameter[0].Value = customers.CustomerID;

            parameter[1] = new SqlParameter("@CName", SqlDbType.VarChar, 50);
            parameter[1].Value = customers.CompanyName;

            parameter[2] = new SqlParameter("@ContactName", SqlDbType.VarChar, 50);
            parameter[2].Value = customers.ContactName;

            parameter[3] = new SqlParameter("@ContactTitle", SqlDbType.VarChar, 50);
            parameter[3].Value = customers.ContactTitle;

            parameter[4] = new SqlParameter("@Address", SqlDbType.VarChar, 50);
            parameter[4].Value = customers.Address;

            parameter[5] = new SqlParameter("@City", SqlDbType.VarChar, 50);
            parameter[5].Value = customers.City;

            parameter[6] = new SqlParameter("@Region", SqlDbType.VarChar, 50);
            parameter[6].Value = customers.Region;

            parameter[7] = new SqlParameter("@PostalCode", SqlDbType.VarChar, 50);
            parameter[7].Value = customers.PostalCode;

            parameter[8] = new SqlParameter("@Country", SqlDbType.VarChar, 50);
            parameter[8].Value = customers.Country;

            parameter[9] = new SqlParameter("@Phone", SqlDbType.VarChar, 50);
            parameter[9].Value = customers.Phone;

            parameter[10] = new SqlParameter("@Fax", SqlDbType.VarChar, 50);
            parameter[10].Value = customers.Fax;



            CM.Parameters.AddRange(parameter);
            cn.Open();
            CM.ExecuteNonQuery();
            cn.Close();
            AllData();

        }
        public void UpdateData(string id, Customers customers)
        {
            SqlConnection cn = new SqlConnection("Server = OMER\\SQLEXPRESS;DataBase =Northwind ;integrated security =true ;encrypt=false;");
            SqlCommand CM;//islemler
            SqlDataAdapter DA;//sqlCommand dan geldigi sonuc SqlDataAdapter e depolanacak

            DataTable DT = new DataTable();

            CM = new SqlCommand("Customers_Update", cn);
            CM.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameter = new SqlParameter[11];
            parameter[0] = new SqlParameter("@CID", SqlDbType.VarChar,50);
            parameter[0].Value = id;

            parameter[1] = new SqlParameter("@CName", SqlDbType.VarChar, 50);
            parameter[1].Value = customers.CompanyName;

            parameter[2] = new SqlParameter("@ContactName", SqlDbType.VarChar, 50);
            parameter[2].Value = customers.ContactName;

            parameter[3] = new SqlParameter("@ContactTitle", SqlDbType.VarChar, 50);
            parameter[3].Value = customers.ContactTitle;

            parameter[4] = new SqlParameter("@Address", SqlDbType.VarChar, 50);
            parameter[4].Value = customers.Address;

            parameter[5] = new SqlParameter("@City", SqlDbType.VarChar, 50);
            parameter[5].Value = customers.City;

            parameter[6] = new SqlParameter("@Region", SqlDbType.VarChar, 50);
            parameter[6].Value = customers.Region;

            parameter[7] = new SqlParameter("@PostalCode", SqlDbType.VarChar, 50);
            parameter[7].Value = customers.PostalCode;

            parameter[8] = new SqlParameter("@Country", SqlDbType.VarChar, 50);
            parameter[8].Value = customers.Country;

            parameter[9] = new SqlParameter("@Phone", SqlDbType.VarChar, 50);
            parameter[9].Value = customers.Phone;

            parameter[10] = new SqlParameter("@Fax", SqlDbType.VarChar, 50);
            parameter[10].Value = customers.Fax;


            CM.Parameters.AddRange(parameter);
            cn.Open();
            CM.ExecuteNonQuery();
            cn.Close();
            AllData();

        }
        public void DeleteData(string id)
        {

            SqlConnection cn = new SqlConnection("Server = OMER\\SQLEXPRESS;DataBase =Northwind ;integrated security =true ;encrypt=false;");
            SqlCommand CM;//islemler
            SqlDataAdapter DA;//sqlCommand dan geldigi sonuc SqlDataAdapter e depolanacak

            DataTable DT = new DataTable();

            CM = new SqlCommand("Customers_Delete", cn);
            CM.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter;
            parameter = new SqlParameter("@CId", SqlDbType.VarChar,50);
            parameter.Value = id;


            CM.Parameters.Add(parameter);
            cn.Open();
            CM.ExecuteNonQuery();
            cn.Close();
            AllData();

        }

        public IList<Customers> AllData()
        {
            MyList.Clear();
            ShowAllData();
            return MyList;
        }

        public Customers Find(string id)
        {
             return MyList.Where(x => x.CustomerID == id).FirstOrDefault();
        }

        public void Add(Customers table)
        {
            AddData(table);
        }

        public void Update(string id, Customers table)
        {
            UpdateData(id, table);
        }

        public void Delete(string id)
        {
            DeleteData(id);
        }









        //public void Add(Customers table)
        //{
        //    AddData(table);
        //}

        //public IList<Customers> AllData()
        //{
        //    MyList.Clear();
        //    ShowAllData();
        //    return MyList;
        //}

        //public void Delete(string id)
        //{
        //    DeleteData(id);
        //}

        //public Customers Find(string id)
        //{
        //    return MyList.Where(x => x.CustomerID == id).FirstOrDefault();
        //}

        //public void Update(string id, Customers table)
        //{
        //    UpdateData(id, table);
        //}
    }
}
