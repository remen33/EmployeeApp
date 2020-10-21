namespace EmployeePayroll.Core.FactorySalary
{
    using EmployeePayroll.Core.Entities;
    using EmployeePayroll.Core.FactorySalary.Concrete;
    using EmployeePayroll.Core.FactorySalary.Interfaces;
    using EmployeePayroll.Core.Interfaces;

    public class SalaryFactory : ISalaryFactory
    {
        public ISalary GetInstance(Employee employe)
        {
            switch (employe.ContractTypeName)
            {
                case nameof(ContractType.HourlySalaryEmployee):
                    return new SalaryHourly(employe);

                case nameof(ContractType.MonthlySalaryEmployee):
                    return new SalaryMonthly(employe);
                default:
                    return null;
            }
        }
    }
}
