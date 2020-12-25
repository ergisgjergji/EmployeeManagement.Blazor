using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Employee> CreateAsync(Employee employee)
        {
            return await httpClient.PostJsonAsync<Employee>($"/api/employee", employee);
        }

        public async Task DeleteAsync(int id)
        {
            await httpClient.DeleteAsync($"/api/employee/{id}");
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await httpClient.GetJsonAsync<Employee[]>("api/employee/all");
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await httpClient.GetJsonAsync<Employee>($"/api/employee/{id}");
        }

        public async Task<Employee> UpdateAsync(Employee employee)
        {
            return await httpClient.PutJsonAsync<Employee>($"/api/employee/{employee.Id}", employee);
        }
    }
}
