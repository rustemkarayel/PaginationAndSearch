using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IEmployeeService
    {
        void EmployeeInsert(Employee employee);
        void EmployeeDelete(Employee employee);
        void EmployeeUpdate(Employee employee);
        List<Employee> EmployeeList();
        Employee EmployeeGetById(int id);
        Employee EmployeeGetByName(string name);
    }
}
