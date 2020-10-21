namespace EmployeePayroll.UnitTest
{
    using EmployeePayroll.Core;
    using EmployeePayroll.Core.Entities;
    using EmployeePayroll.Core.FactorySalary;
    using EmployeePayroll.Core.Interfaces;
    using EmployeePayroll.Core.Services;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class EmployeeServiceTest
    {
        private readonly Mock<IEmployeeRepository> _employeeRepository = new Mock<IEmployeeRepository>();

        private readonly EmployeeService _employeeService;

        public EmployeeServiceTest()
        {
            _employeeService = new EmployeeService(_employeeRepository.Object, new SalaryFactory());
        }

        [Fact]
        public async Task GetEmployeeWithSalaryHourly()
        {
            /// Arrange 
            Employee employee = new Employee()
            {
                Id = 1,
                Name = "Juan",
                ContractTypeName = nameof(ContractType.HourlySalaryEmployee),
                RoleId = 1,
                RoleName = "Administrator",                
                HourlySalary = 60000.0,
                MonthlySalary = 80000.0
            };

            employee.AnnualSalary = 120 * employee.HourlySalary * 12;

            List<Employee> listOfEmployees = new List<Employee>();
            listOfEmployees.Add(employee);

            _employeeRepository.Setup(x => x.GetEmployees()).ReturnsAsync(listOfEmployees);

            /// Act
            var employees = await _employeeService.GetEmployees();

            /// Assert
            Assert.Equal(employee.AnnualSalary, employees.FirstOrDefault().AnnualSalary);
        }


        [Fact]
        public async Task GetEmployeeWithSalaryMonthly()
        {
            /// Arrange 
            Employee employee = new Employee()
            {
                Id = 1,
                Name = "Juan",
                ContractTypeName = nameof(ContractType.MonthlySalaryEmployee),
                RoleId = 1,
                RoleName = "Administrator",
                HourlySalary = 60000.0,
                MonthlySalary = 80000.0
            };

            employee.AnnualSalary = employee.HourlySalary * 12;

            List<Employee> listOfEmployees = new List<Employee>();
            listOfEmployees.Add(employee);

            _employeeRepository.Setup(x => x.GetEmployees()).ReturnsAsync(listOfEmployees);

            /// Act
            var employees = await _employeeService.GetEmployees();

            /// Assert
            Assert.Equal(employee.AnnualSalary, employees.FirstOrDefault().AnnualSalary);
        }


        [Fact]
        public async Task GetEmployeeDoesNotExist()
        {
            /// Arrange 
            Employee employee = new Employee()
            {
                Id = 1,
                Name = "Juan",
                ContractTypeName = nameof(ContractType.MonthlySalaryEmployee),
                RoleId = 1,
                RoleName = "Administrator",
                HourlySalary = 60000.0,
                MonthlySalary = 80000.0
            };

            employee.AnnualSalary = employee.HourlySalary * 12;

            List<Employee> listOfEmployees = new List<Employee>();

            _employeeRepository.Setup(x => x.GetEmployees()).ReturnsAsync(listOfEmployees);

            /// Act
            var queryEmployee = await _employeeService.GetEmployee(2);

            /// Assert
            Assert.Null(queryEmployee);
        }

        [Fact]
        public async Task GetEmployeeByIdWithSalaryHourly()
        {
            /// Arrange 
            Employee employee = new Employee()
            {
                Id = 1,
                Name = "Juan",
                ContractTypeName = nameof(ContractType.HourlySalaryEmployee),
                RoleId = 1,
                RoleName = "Administrator",
                HourlySalary = 60000.0,
                MonthlySalary = 80000.0
            };

            employee.AnnualSalary = 120 * employee.HourlySalary * 12;

            List<Employee> listOfEmployees = new List<Employee>();
            listOfEmployees.Add(employee);

            _employeeRepository.Setup(x => x.GetEmployees()).ReturnsAsync(listOfEmployees);

            /// Act
            var queryEmployee = await _employeeService.GetEmployee(1);

            /// Assert
            Assert.Equal(employee.AnnualSalary, queryEmployee.AnnualSalary);
        }


        [Fact]
        public async Task GetEmployeeByIdWithSalaryMonthly()
        {
            /// Arrange 
            Employee employee = new Employee()
            {
                Id = 1,
                Name = "Juan",
                ContractTypeName = nameof(ContractType.MonthlySalaryEmployee),
                RoleId = 1,
                RoleName = "Administrator",
                HourlySalary = 60000.0,
                MonthlySalary = 80000.0
            };

            employee.AnnualSalary = employee.HourlySalary * 12;

            List<Employee> listOfEmployees = new List<Employee>();
            listOfEmployees.Add(employee);

            _employeeRepository.Setup(x => x.GetEmployees()).ReturnsAsync(listOfEmployees);

            /// Act
            var queryEmployee = await _employeeService.GetEmployee(1);

            /// Assert
            Assert.Equal(employee.AnnualSalary, queryEmployee.AnnualSalary);
        }
    }
}
