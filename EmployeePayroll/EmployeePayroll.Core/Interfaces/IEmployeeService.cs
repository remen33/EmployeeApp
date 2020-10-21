namespace EmployeePayroll.Core.Interfaces
{
    using EmployeePayroll.Core.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployees();

        Task<Employee> GetEmployee(int id);
    }
}