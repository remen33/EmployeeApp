namespace EmployeePayroll.Core.FactorySalary.Concrete
{
    using EmployeePayroll.Core.Entities;
    using EmployeePayroll.Core.FactorySalary.Interfaces;

    public class SalaryHourly : ISalary
    {
        public readonly Employee _employee;

        public SalaryHourly(Employee employee)
        {
            _employee = employee;
        }        

        public void CalculateSalary()
        {
            _employee.AnnualSalary = 120 * _employee.HourlySalary * 12;
        }
    }
}
