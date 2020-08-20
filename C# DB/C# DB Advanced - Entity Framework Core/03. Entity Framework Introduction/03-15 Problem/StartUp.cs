using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();

            // Problem 03 - Employees Full Information

            var employeesFullInformation = GetEmployeesFullInformation(context);
            Console.WriteLine(employeesFullInformation);

            // Problem 04 - Employees with Salary Over 50 000

            var employeesWithSalaryOver50000 = GetEmployeesWithSalaryOver50000(context);
            Console.WriteLine(employeesWithSalaryOver50000);

            // Problem 05 - Employees from Research and Development

            var employeesFromResearchAndDevelopment = GetEmployeesFromResearchAndDevelopment(context);
            Console.WriteLine(employeesFromResearchAndDevelopment);

            // Problem 06 - Adding a New Address and Updating Employee

            var addingNewAddressToEmployee = AddNewAddressToEmployee(context);
            Console.WriteLine(addingNewAddressToEmployee);

            // Problem 07 - Employees and Projects

            var employeesInPeriod = GetEmployeesInPeriod(context);
            Console.WriteLine(employeesInPeriod);

            // Problem 08 - Addresses by Town

            var addressesByTown = GetAddressesByTown(context);
            Console.WriteLine(addressesByTown);

            // Problem 09 - Employee 147

            var employee147 = GetEmployee147(context);
            Console.WriteLine(employee147);

            // Problem 10 - Departments with More Than 5 Employees

            var departmentsWithMoreThan5Employees = GetDepartmentsWithMoreThan5Employees(context);
            Console.WriteLine(departmentsWithMoreThan5Employees);

            // Problem 11 - Find Latest 10 Projects

            var latestProjects = GetLatestProjects(context);
            Console.WriteLine(latestProjects);

            // Problem 12 - Increase Salaries

            var increasingSalaries = IncreaseSalaries(context);
            Console.WriteLine(increasingSalaries);

            // Problem 13 - Find Employees by First Name Starting with "Sa"

            var employeesByFirstNameStartingWithSa = GetEmployeesByFirstNameStartingWithSa(context);
            Console.WriteLine(employeesByFirstNameStartingWithSa);

            // Problem 14 - Delete Project by Id

            var deletingProjectById = DeleteProjectById(context);
            Console.WriteLine(deletingProjectById);

            // Problem 15 - Remove Town

            var removingTown = RemoveTown(context);
            Console.WriteLine(removingTown);

        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {

            var employeesInfo = context
                .Employees
                .Select(x => new
                {
                    x.EmployeeId,
                    x.FirstName,
                    x.LastName,
                    x.MiddleName,
                    x.JobTitle,
                    x.Salary
                })
                .OrderBy(x => x.EmployeeId)
                .ToList();

            var result = new StringBuilder();

            foreach (var employee in employeesInfo)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return result.ToString().Trim();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employeesInfo = context
                    .Employees
                    .Select(x => new
                    {
                        x.FirstName,
                        x.Salary
                    })
                    .Where(x => x.Salary > 50000)
                    .OrderBy(x => x.FirstName)
                    .ToList();

            var result = new StringBuilder();

            foreach (var employee in employeesInfo)
            {
                result.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return result.ToString().Trim();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employeesInfo = context
                    .Employees
                    .Select(x => new
                    {
                        x.FirstName,
                        x.LastName,
                        x.Department,
                        x.Department.Name,
                        x.Salary
                    })
                    .Where(x => x.Department.Name == "Research and Development")
                    .OrderBy(x => x.Salary)
                    .ThenByDescending(x => x.LastName)
                    .ToList();

            var result = new StringBuilder();

            foreach (var employee in employeesInfo)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Department.Name} - ${employee.Salary:F2}");
            }

            return result.ToString().Trim();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };
            context.Addresses.Add(newAddress);
            context.SaveChanges();

            var findEmployee = context
                .Employees
                .Where(x => x.LastName == "Nakov")
                .FirstOrDefault();
            findEmployee.AddressId = newAddress.AddressId;
            context.SaveChanges();

            var employeesInfo = context
                .Employees
                .Select(x => new
                {
                    x.AddressId,
                    x.Address.AddressText
                })
                .OrderByDescending(x => x.AddressId)
                .Take(10);

            var result = new StringBuilder();

            foreach (var employee in employeesInfo)
            {
                result.AppendLine(employee.AddressText);
            }

            return result.ToString().Trim();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {

            var employeesInfo = context.Employees
                                .Where(x => x.EmployeesProjects
                                  .Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                                .Take(10)
                                .Select(x => new
                                {
                                    x.FirstName,
                                    x.LastName,
                                    ManagerFirstName = x.Manager.FirstName,
                                    ManagerLastName = x.Manager.LastName,
                                    Projects = x.EmployeesProjects
                                      .Select(ep => new
                                      {
                                          ep.Project.Name,
                                          StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                                          EndDate = ep.Project.EndDate.HasValue ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished"
                                      })
                                      .ToList()
                                })
                                .ToList();

            var result = new StringBuilder();

            foreach (var employee in employeesInfo)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var project in employee.Projects)
                {
                    result.AppendLine($"--{project.Name} - {project.StartDate} - {project.EndDate}");
                }
            }

            return result.ToString().Trim();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addressesInfo = context
                    .Addresses
                    .Select(x => new
                    {
                        x.AddressText,
                        x.Town.Name,
                        x.Employees.Count
                    })
                    .OrderByDescending(x => x.Count)
                    .ThenBy(x => x.Name)
                    .ThenBy(x => x.AddressText)
                    .Take(10);

            var result = new StringBuilder();

            foreach (var address in addressesInfo)
            {
                result.AppendLine($"{address.AddressText}, {address.Name} - {address.Count} employees");
            }

            return result.ToString().Trim();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employeeInfo = context
                .Employees
                .Where(x => x.EmployeeId == 147)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    Projects = x.EmployeesProjects
                      .Select(p => new { p.Project.Name })
                      .OrderBy(p => p.Name)
                      .ToList()
                })
                .First();

            var result = new StringBuilder();

            result.AppendLine($"{employeeInfo.FirstName} {employeeInfo.LastName} - {employeeInfo.JobTitle}");

            foreach (var project in employeeInfo.Projects)
            {
                result.AppendLine(project.Name);
            }

            return result.ToString().Trim();

        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var deparmentsInfo = context
              .Departments
              .Where(x => x.Employees.Count() > 5)
              .OrderBy(x => x.Employees.Count())
              .ThenBy(x => x.Name)
              .Select(x => new
              {
                  DepartmentName = x.Name,
                  ManagerFirstName = x.Manager.FirstName,
                  ManagerLastName = x.Manager.LastName,
                  Employees = x
                    .Employees
                    .Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle
                    })
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToList()
              })
              .ToList();

            var result = new StringBuilder();

            foreach (var d in deparmentsInfo)
            {
                result.AppendLine($"{d.DepartmentName} - {d.ManagerFirstName} {d.ManagerLastName}");

                foreach (var e in d.Employees)
                {
                    result.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return result.ToString().Trim();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projectsInfo = context
                .Projects
                .OrderByDescending(u => u.StartDate).Take(10)
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    x.Name,
                    x.Description,
                    x.StartDate
                })
                .ToList();

            var result = new StringBuilder();

            foreach (var project in projectsInfo)
            {
                result.AppendLine(project.Name);
                result.AppendLine(project.Description);
                result.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }

            return result.ToString().Trim();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            decimal raising = 1.12M;

            var employeesInfo = context
                .Employees
                .Where(x => x.Department.Name == "Engineering" ||
                x.Department.Name == "Tool Design" ||
                x.Department.Name == "Marketing" ||
                x.Department.Name == "Information Services").ToList();

            foreach (var employee in employeesInfo)
            {
                employee.Salary *= raising;
            }

            context.SaveChanges();

            var employees = context
                .Employees
                .Where(x => x.Department.Name == "Engineering" ||
                x.Department.Name == "Tool Design" ||
                x.Department.Name == "Marketing" ||
                x.Department.Name == "Information Services")
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.Salary
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            var result = new StringBuilder();

            foreach (var e in employees)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");
            }

            return result.ToString().Trim();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employeesInfo = context
                .Employees
                .Where(x => x.FirstName.StartsWith("Sa"))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            var result = new StringBuilder();

            foreach (var e in employeesInfo)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})");
            }

            return result.ToString().Trim();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var deletingIdFromEmployeeProjects = context
                .EmployeesProjects
                .Where(x => x.ProjectId == 2)
                .ToList();

            context.EmployeesProjects.RemoveRange(deletingIdFromEmployeeProjects);

            var deletingIdFromProjects = context
                .Projects
                .Where(x => x.ProjectId == 2)
                .FirstOrDefault();

            context.Projects.RemoveRange(deletingIdFromProjects);

            var taking10Projects = context
                .Projects
                .Take(10)
                .Select(x => new
                {
                    x.Name
                }).ToList();

            var result = new StringBuilder();

            foreach (var p in taking10Projects)
            {
                result.AppendLine(p.Name);
            }

            return result.ToString().Trim();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var townName = "Seattle";

            var employeeInfo = context
                .Employees
                .Where(x => x.Address.Town.Name == townName)
                .ToList();

            foreach (var e in employeeInfo)
            {
                e.AddressId = null;
            }

            var addressesCount = context
                .Addresses
                .Where(x => x.Town.Name == townName)
                .Count();

            var addressesRemove = context
                .Addresses
                .Where(x => x.Town.Name == townName)
                .ToList();

            context.Addresses.RemoveRange(addressesRemove);

            var townRemove = context
               .Towns
               .Where(x => x.Name == townName)
               .ToList();

            context.Towns.RemoveRange(townRemove);

            context.SaveChanges();

            return $"{addressesCount} addresses in {townName} were deleted";
        }
    }
}
