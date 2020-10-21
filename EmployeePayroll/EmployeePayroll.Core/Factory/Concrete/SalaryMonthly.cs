namespace EmployeePayroll.Core.FactorySalary.Concrete
{
    using EmployeePayroll.Core.Entities;
    using EmployeePayroll.Core.FactorySalary.Interfaces;

    public class SalaryMonthly : ISalary
    {
        public readonly Employee _employee;

        public SalaryMonthly(Employee employee)
        {
            _employee = employee;
        }

        public void CalculateSalary()
        {
            _employee.AnnualSalary = _employee.MonthlySalary * 12;
        }
    }
}
