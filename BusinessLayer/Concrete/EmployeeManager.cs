using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal employeeDal;
        public EmployeeManager(IEmployeeDal employeeDal)
        {
            this.employeeDal = employeeDal;
        }

        public void EmployeeDelete(Employee employee)
        {
            employeeDal.delete(employee);
        }

        public Employee EmployeeGetById(int id)
        {
            return employeeDal.get(employee => employee.EmployeeId== id);
        }

        public Employee EmployeeGetByName(string name)
        {
            return employeeDal.get(employee => employee.FirstName== name);
        }

        public void EmployeeInsert(Employee employee)
        {
            employeeDal.insert(employee);
        }

        public List<Employee> EmployeeList()
        {
            return employeeDal.list();
        }

        public void EmployeeUpdate(Employee employee)
        {
            employeeDal.update(employee);
        }
    }
}
