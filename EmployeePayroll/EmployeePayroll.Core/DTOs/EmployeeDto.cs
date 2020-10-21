﻿namespace EmployeePayroll.Core.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ContractTypeName { get; set; }

        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public string RoleDescription { get; set; }

        public double AnnualSalary { get; set; }
    }
}
