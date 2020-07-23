using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RxProgramming.API
{
    public class EmployeeRepository
    {
        private readonly List<Employee> _employees;

        public EmployeeRepository()
        {
            _employees = new List<Employee>();

            for (int i = 1; i <= 10; i++)
            {
                _employees.Add(new Employee
                {
                    EmployeeId = i,
                    Age = 30 + i,
                    Description = "Description " + i,
                    Name = "Name-" + i,
                    Salary = 850 * i
                }) ;
            }
        }

        public List<Employee> ListEmployees()
        {
            return _employees;
        }

        public Employee GetEmployee(int employeeId)
        {
            return _employees.Where(e=>e.EmployeeId == employeeId).FirstOrDefault();
        }
    }
}
