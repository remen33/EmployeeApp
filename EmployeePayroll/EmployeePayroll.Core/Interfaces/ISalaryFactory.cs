namespace EmployeePayroll.Core.Interfaces
{
    using EmployeePayroll.Core.Entities;
    using EmployeePayroll.Core.FactorySalary.Interfaces;

    public interface ISalaryFactory
    {
        ISalary GetInstance(Employee employe);
    }
}
