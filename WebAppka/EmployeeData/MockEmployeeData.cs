using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAppka.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
    {
        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id=Guid.NewGuid(),
                Name="jack",
                Surname="johnson"
            },
            new Employee()
            {
                Id=Guid.NewGuid(),
                Name="tom",
                Surname="thomson"
            }
        };


        public Employee AddEmployee(Employee employee)
        {

            employee.Id = Guid.NewGuid();
            employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public Employee EditEmployee(Employee employee)
        {
            var existingEmployee = GetEmployee(employee.Id);
            existingEmployee.Name = employee.Name;
            existingEmployee.Surname = employee.Surname;

            return existingEmployee;
        }

        public Employee GetEmployee(Guid id)
        {
            return employees.SingleOrDefault(x => x.Id == id );

        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
