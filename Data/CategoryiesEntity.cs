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
    public class CategoryiesEntity : IHelper<Categories>
    {

     
        List<Categories> MyList = new List<Categories>();


        public void ShowAllData()
        {
            SqlConnection cn = new SqlConnection("Server = OMER\\SQLEXPRESS;DataBase =Northwind ;integrated security =true ;encrypt=false;");
            cn.Open();
            SqlCommand cmm = new SqlCommand("select  ISNULL(CategoryID,'bos')as 'CategoryID'," +
                " ISNULL(CategoryName,'bos')as 'CategoryName', " +
                "ISNULL(Description,'bos')as 'Description' from Categories", cn);
            SqlDataReader dr = cmm.ExecuteReader();
            while (dr.Read())
            {
              
                    Categories categories = new Categories()
                    {
                        CategoryID = (int)dr[0],
                        CategoryName = (string)dr[1],
                        Description = dr[2].ToString()
                    };
                    MyList.Add(categories);

               
            }

            cn.Close();
        }


        public void AddData(Categories categories)
        {
            SqlConnection cn = new SqlConnection("Server = OMER\\SQLEXPRESS;DataBase =Northwind ;integrated security =true ;encrypt=false;");
            SqlCommand CM;//islemler
            SqlDataAdapter DA;//sqlCommand dan geldigi sonuc SqlDataAdapter e depolanacak

            DataTable DT = new DataTable();

            CM = new SqlCommand("Categories_Add", cn);
            CM.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameter = new SqlParameter[2];
            parameter[0] = new SqlParameter("@CategryName", SqlDbType.VarChar, 50);
            parameter[0].Value = categories.CategoryName;

            parameter[1] = new SqlParameter("@Desc", SqlDbType.VarChar, 50);
            parameter[1].Value = categories.Description;



            CM.Parameters.AddRange(parameter);
            cn.Open();
            CM.ExecuteNonQuery();
            cn.Close();
            AllData();

        }
        public void UpdateData(int id, Categories categories)
        {
            SqlConnection cn = new SqlConnection("Server = OMER\\SQLEXPRESS;DataBase =Northwind ;integrated security =true ;encrypt=false;");
            SqlCommand CM;//islemler
            SqlDataAdapter DA;//sqlCommand dan geldigi sonuc SqlDataAdapter e depolanacak

            DataTable DT = new DataTable();

            CM = new SqlCommand("Categories_Update", cn);
            CM.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameter = new SqlParameter[3];
            parameter[0] = new SqlParameter("@CategoryID", SqlDbType.Int);
            parameter[0].Value = categories.CategoryID;

            parameter[1] = new SqlParameter("@CategryName", SqlDbType.VarChar, 50);
            parameter[1].Value = categories.CategoryName;

            parameter[2] = new SqlParameter("@Desc", SqlDbType.VarChar, 50);
            parameter[2].Value = categories.Description;



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

            CM = new SqlCommand("Categories_Delete", cn);
            CM.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter;
            parameter = new SqlParameter("@CategoryID", SqlDbType.Int);
            parameter.Value =id;


            CM.Parameters.Add(parameter);
            cn.Open();
            CM.ExecuteNonQuery();
            cn.Close();
            AllData();

        }






        public void Add(Categories table)
        {
            AddData(table);
        }

        public IList<Categories> AllData()
        {
            MyList.Clear();
            ShowAllData();
            return MyList;
        }

        public void Delete(int id)
        {
            DeleteData(id);
        }

        public Categories Find(int id)
        {
            return MyList.Where(x => x.CategoryID == id).First();
        }

        public void Update(int id, Categories table)
        {
            UpdateData(id, table);
        }
    }
}
