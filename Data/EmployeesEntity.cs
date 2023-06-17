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
    public class EmployeesEntity : IHelper<Employees>
    {

        List<Employees> MyList = new List<Employees>();


        public void ShowAllData()
        {
            SqlConnection cn = new SqlConnection("Server = OMER\\SQLEXPRESS;DataBase =Northwind ;integrated security =true ;encrypt=false;");
            cn.Open();
            SqlCommand cmm = new SqlCommand("select ISNULL(EmployeeID,'bos')as 'EmployeeID'," +
                " ISNULL(LastName,'bos')as 'LastName', " +
                "ISNULL(FirstName,'bos')as 'FirstName'," +
                " ISNULL(Title,'bos')as 'Title', " +
                "ISNULL(TitleOfCourtesy,'bos')as 'TitleOfCourtesy'," +
                " isnull(format(BirthDate ,'yyyy-MM-dd'),'bos') as 'BirthDate', " +
                "isnull(format(HireDate ,'yyyy-MM-dd'),'bos') as  'HireDate', " +
                "ISNULL(Address,'bos')as 'Address'," +
                " ISNULL(City,'bos')as 'City', " +
                "ISNULL(Region,'bos')as 'Region'," +
                " ISNULL(PostalCode,'bos')as 'PostalCode', " +
                "ISNULL(Country,'bos')as 'Country', " +
                "ISNULL(HomePhone,'bos')as 'HomePhone', " +
                "ISNULL(Extension,'bos')as 'Extension'," +
                " ISNULL(Notes,'bos')as 'Notes' ," +
                " ISNULL(ReportsTo,-1)as 'ReportsTo' " +
                " from Employees", cn);
            SqlDataReader dr = cmm.ExecuteReader();
            while (dr.Read())
            {
                Employees employees = new Employees()
                {
                    EmployeeID = (int)dr[0],
                    LastName = (string)dr[1],
                    FirstName = (string)dr[2],
                    Title = (string)dr[3],
                    TitleOfCourtesy = (string)dr[4],
                    BirthDate =((string)dr[5]),
                    HireDate=((string)dr[6]),
                    Address = (string)dr[7],
                    City = (string)dr[8],
                    Region = (string)dr[9],
                    PostalCode = (string)dr[10],
                    Country = (string)dr[11],
                    HomePhone = (string)dr[12],
                    Extension = (string)dr[13],
                    Notes = (string)dr[14],
                    ReportsTo = (int)dr[15]

                };
                MyList.Add(employees);


            }

            cn.Close();
        }


        public void AddData(Employees employees)
        {
            SqlConnection cn = new SqlConnection("Server = OMER\\SQLEXPRESS;DataBase =Northwind ;integrated security =true ;encrypt=false;");
            SqlCommand CM;//islemler
            SqlDataAdapter DA;//sqlCommand dan geldigi sonuc SqlDataAdapter e depolanacak

            DataTable DT = new DataTable();

            CM = new SqlCommand("Employees_Add", cn);
            CM.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameter = new SqlParameter[15];
            //parameter[0] = new SqlParameter("@CID", SqlDbType.Int);
            //parameter[0].Value = employees.EmployeeID;

            parameter[0] = new SqlParameter("@LastName", SqlDbType.VarChar, 50);
            parameter[0].Value =employees.LastName;

            parameter[1] = new SqlParameter("@FirstName", SqlDbType.VarChar, 50);
            parameter[1].Value = employees.FirstName;

            parameter[2] = new SqlParameter("@Title", SqlDbType.VarChar, 50);
            parameter[2].Value = employees.Title;

            parameter[3] = new SqlParameter("@TitleOfCourtesy", SqlDbType.VarChar, 50);
            parameter[3].Value = employees.TitleOfCourtesy;

            parameter[4] = new SqlParameter("@BirthDate", SqlDbType.VarChar,50);
            parameter[4].Value = employees.BirthDate;

            parameter[5] = new SqlParameter("@HireDate", SqlDbType.VarChar, 50);
            parameter[5].Value = employees.HireDate;

            parameter[6] = new SqlParameter("@Address", SqlDbType.VarChar, 50);
            parameter[6].Value = employees.Address;

            parameter[7] = new SqlParameter("@City", SqlDbType.VarChar, 50);
            parameter[7].Value = employees.City;

            parameter[8] = new SqlParameter("@Region", SqlDbType.VarChar, 50);
            parameter[8].Value = employees.Region;

            parameter[9] = new SqlParameter("@PostalCode", SqlDbType.VarChar, 50);
            parameter[9].Value = employees.PostalCode;

            parameter[10] = new SqlParameter("@Country", SqlDbType.VarChar, 50);
            parameter[10].Value = employees.Country;

            parameter[11] = new SqlParameter("@HomePhone", SqlDbType.VarChar, 50);
            parameter[11].Value = employees.HomePhone;

            parameter[12] = new SqlParameter("@Extension", SqlDbType.VarChar, 50);
            parameter[12].Value = employees.Extension;

            parameter[13] = new SqlParameter("@Notes", SqlDbType.VarChar, 50);
            parameter[13].Value = employees.Notes;

            parameter[14] = new SqlParameter("@ReportsTo", SqlDbType.Int);
            parameter[14].Value = employees.ReportsTo;

            CM.Parameters.AddRange(parameter);
            cn.Open();
            CM.ExecuteNonQuery();
            cn.Close();
            AllData();

        }
        public void UpdateData(int id, Employees employees)
        {
            SqlConnection cn = new SqlConnection("Server = OMER\\SQLEXPRESS;DataBase =Northwind ;integrated security =true ;encrypt=false;");
            SqlCommand CM;//islemler
            SqlDataAdapter DA;//sqlCommand dan geldigi sonuc SqlDataAdapter e depolanacak

            DataTable DT = new DataTable();

            CM = new SqlCommand("Employees_Update", cn);
            CM.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameter = new SqlParameter[16];
            parameter[0] = new SqlParameter("@EmpID", SqlDbType.Int);
            parameter[0].Value = employees.EmployeeID;

            parameter[1] = new SqlParameter("@LastName", SqlDbType.VarChar, 50);
            parameter[1].Value = employees.LastName;

            parameter[2] = new SqlParameter("@FirstName", SqlDbType.VarChar, 50);
            parameter[2].Value = employees.FirstName;

            parameter[3] = new SqlParameter("@Title", SqlDbType.VarChar, 50);
            parameter[3].Value = employees.Title;

            parameter[4] = new SqlParameter("@TitleOfCourtesy", SqlDbType.VarChar, 50);
            parameter[4].Value = employees.TitleOfCourtesy;

            parameter[5] = new SqlParameter("@BirthDate", SqlDbType.VarChar,50);
            parameter[5].Value = employees.BirthDate;

            parameter[6] = new SqlParameter("@HireDate", SqlDbType.VarChar,50);
            parameter[6].Value = employees.HireDate;

            parameter[7] = new SqlParameter("@Address", SqlDbType.VarChar, 50);
            parameter[7].Value = employees.Address;

            parameter[8] = new SqlParameter("@City", SqlDbType.VarChar, 50);
            parameter[8].Value = employees.City;

            parameter[9] = new SqlParameter("@Region", SqlDbType.VarChar, 50);
            parameter[9].Value = employees.Region;

            parameter[10] = new SqlParameter("@PostalCode", SqlDbType.VarChar, 50);
            parameter[10].Value = employees.PostalCode;

            parameter[11] = new SqlParameter("@Country", SqlDbType.VarChar, 50);
            parameter[11].Value = employees.Country;

            parameter[12] = new SqlParameter("@HomePhone", SqlDbType.VarChar, 50);
            parameter[12].Value = employees.HomePhone;

            parameter[13] = new SqlParameter("@Extension", SqlDbType.VarChar, 50);
            parameter[13].Value = employees.Extension;

            parameter[14] = new SqlParameter("@Notes", SqlDbType.VarChar, 50);
            parameter[14].Value = employees.Notes;

            parameter[15] = new SqlParameter("@ReportsTo", SqlDbType.Int);
            parameter[15].Value = employees.ReportsTo;

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

            CM = new SqlCommand("Employees_Delete", cn);
            CM.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter;
            parameter = new SqlParameter("@EmpID", SqlDbType.Int);
            parameter.Value = id;


            CM.Parameters.Add(parameter);
            cn.Open();
            CM.ExecuteNonQuery();
            cn.Close();
            AllData();

        }





        public void Add(Employees table)
        {
            AddData(table);
        }

        public IList<Employees> AllData()
        {
            MyList.Clear();
            ShowAllData();
            return MyList;
        }

        public void Delete(int id)
        {
            DeleteData(id);
        }

        public Employees Find(int id)
        {
            return MyList.Where(x => x.EmployeeID == id).FirstOrDefault();
        }

        public void Update(int id, Employees table)
        {
            UpdateData(id, table);
        }
    }
}
