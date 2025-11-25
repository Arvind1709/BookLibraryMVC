using BookLibraryMVC.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BookLibraryMVC.Services
{
    public class EmployeesServices
    {
        private readonly string _connectionString;

        public EmployeesServices(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public List<Employees> GetEmployees()
        {
            List<Employees> result = new List<Employees>();
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Employees", con);
                da.Fill(dt);
            }

            foreach (DataRow row in dt.Rows)
            {
                result.Add(new Employees
                {
                    EmpID = Convert.ToInt32(row["EmpID"]),
                    EmpName = row["EmpName"].ToString(),
                    Department = row["Department"].ToString(),
                    Salary = Convert.ToDecimal(row["Salary"]),
                    JoiningDate = Convert.ToDateTime(row["JoiningDate"])
                });
            }

            return result;
        }

    }
}
