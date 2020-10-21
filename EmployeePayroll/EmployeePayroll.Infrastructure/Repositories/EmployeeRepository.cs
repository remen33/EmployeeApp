namespace EmployeePayroll.Infrastructure.Repositories
{
    using EmployeePayroll.Core.CustomEntities;
    using EmployeePayroll.Core.Entities;
    using EmployeePayroll.Core.Interfaces;
    using EmployeePayroll.Infrastructure.Helper;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly UrlServices urlServices;
        public EmployeeRepository(IOptions<UrlServices> option)
        {
            urlServices = option.Value;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            string url = urlServices.EmployeesServices;
            
            using (HttpResponseMessage responseMessage = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var employees = await responseMessage.Content.ReadAsAsync<List<Employee>>();
                    return employees;
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }
    }
}
