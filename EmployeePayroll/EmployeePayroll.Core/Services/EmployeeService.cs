namespace EmployeePayroll.Core.Services
{
    using EmployeePayroll.Core.Entities;
    using EmployeePayroll.Core.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ISalaryFactory _salaryFactory;

        public EmployeeService(IEmployeeRepository employeeRepository, ISalaryFactory salaryFactory)
        {
            this._employeeRepository = employeeRepository;
            this._salaryFactory = salaryFactory;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var employees = await this._employeeRepository.GetEmployees();

            foreach (var item in employees)
            {
                var salary = _salaryFactory.GetInstance(item);
                salary.CalculateSalary();
            }

            return employees;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var employees = await this._employeeRepository.GetEmployees();

            var employeeById = employees.Where(q => q.Id == id).FirstOrDefault();

            if (employeeById == null)
            {
                return employeeById;
            }

            var salary = _salaryFactory.GetInstance(employeeById);
            salary.CalculateSalary();

            return employeeById;
        }
    }
}
