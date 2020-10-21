namespace EmployeePayroll.Core.Interfaces
{    
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EmployeePayroll.Core.Entities;

    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployees();
    }
}