namespace EmployeePayroll.Api.Controllers
{
    using AutoMapper;
    using EmployeePayroll.Core.DTOs;
    using EmployeePayroll.Core.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            this._employeeService = employeeService;
            this._mapper = mapper;
        }

        [HttpGet(Name = nameof(GetEmployees))]        
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await this._employeeService.GetEmployees();
            var employeesDto = this._mapper.Map<List<EmployeeDto>>(employees);
            return Ok(employeesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployees(int id)
        {
            var employee = await this._employeeService.GetEmployee(id);
            var employeeDto = this._mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }
    }
}
