using BookLibraryMVC.Models;
using BookLibraryMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeesServices _services;

        public EmployeesController(EmployeesServices services)
        {
            _services = services;
        }

        // -----------------------------------------------------------
        // 1. Group By Department → Count Employees
        // -----------------------------------------------------------
        public IActionResult GroupByDepartment()
        {
            var employees = _services.GetEmployees();

            var result = employees
                .GroupBy(e => e.Department)
                .Select(g => new Employees
                {
                    Department = g.Key,
                    TotalEmployees = g.Count()
                }).ToList();

            return View(result);
        }

        // -----------------------------------------------------------
        // 2. Group By Department → Sum Salary, Avg Salary
        // -----------------------------------------------------------
        public IActionResult SalarySummary()
        {
            var employees = _services.GetEmployees();

            var result = employees
                .GroupBy(e => e.Department)
                .Select(g => new Employees
                {
                    Department = g.Key,
                    TotalEmployees = g.Count(),
                    TotalSalary = g.Sum(x => x.Salary),
                    AvgSalary = g.Average(x => x.Salary)
                }).ToList();

            return View(result);
        }

        // -----------------------------------------------------------
        // 3. HAVING Example → Get Departments with more than 2 employees
        // -----------------------------------------------------------
        public IActionResult HavingExample()
        {
            var employees = _services.GetEmployees();

            var result = employees
                .GroupBy(e => e.Department)
                .Where(g => g.Count() > 2)  // HAVING COUNT(*) > 2
                .Select(g => new Employees
                {
                    Department = g.Key,
                    TotalEmployees = g.Count()
                }).ToList();

            return View(result);
        }

        // -----------------------------------------------------------
        // 4. HAVING Salary Example → Avg Salary > 200
        // -----------------------------------------------------------
        public IActionResult HavingAvgSalary()
        {
            var employees = _services.GetEmployees();

            var result = employees
                .GroupBy(e => e.Department)
                .Where(g => g.Average(x => x.Salary) > 200)  // HAVING AVG(Salary) > 200
                .Select(g => new Employees
                {
                    Department = g.Key,
                    AvgSalary = g.Average(x => x.Salary)
                }).ToList();

            return View(result);
        }
    }
}
