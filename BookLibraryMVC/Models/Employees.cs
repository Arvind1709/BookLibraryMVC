namespace BookLibraryMVC.Models
{
    public class Employees
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }
        public DateTime JoiningDate { get; set; }
        // extra fields for grouped results
        public int TotalEmployees { get; set; }
        public decimal TotalSalary { get; set; }
        public decimal AvgSalary { get; set; }
    }
}
