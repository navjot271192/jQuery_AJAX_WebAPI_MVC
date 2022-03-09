using jQuery_AJAX_WebAPI_MVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace jQuery_AJAX_MVC
{
    public class EmpRepository
    {

        private SqlConnection con;
        private SqlCommand com;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ToString();
            con = new SqlConnection(constr);


        }

        public string AddCarInformation(CarModel Emp)
        {
            try
            {
                //string cs = "data source=.;database=master;integrated security=SSPI";
                //connection();
                using (SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSqlLocaldb;Initial Catalog=EmployeeDB;Integrated Security=SSPI;"))
                {

                    com = new SqlCommand("dbo.InsertData1", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@RegistratonNo", Emp.RegistratonNo);
                    com.Parameters.AddWithValue("@Reg_Date", Emp.Reg_Date);
                    com.Parameters.AddWithValue("@ModelNo", Emp.ModelNo);
                    com.Parameters.AddWithValue("@OwnerName", Emp.OwnerName);
                    con.Open();
                    int i = com.ExecuteNonQuery();
                    con.Close();
                    if (i >= 1)
                    
                    {
                        return "New Employee Added Successfully";

                    }
                    else
                    {
                        return "Employee Not Added";

                    }

                }
            }

            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return "New Employee Added Successfully";
        }

        public DataSet GetAllCarInformation()
        {
            DataSet customers = new DataSet();
            try
            {
                //string cs = "data source=.;database=master;integrated security=SSPI";
                //connection();
                using (SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSqlLocaldb;Initial Catalog=EmployeeDB;Integrated Security=SSPI;"))
                {

                    string queryString = "SELECT * FROM dbo.Customers";
                    SqlDataAdapter adapter = new SqlDataAdapter(queryString, con);

                    adapter.Fill(customers, "Customers");
                }
            }

            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return customers;
        }
    }
}