using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext Context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            Context = context;
        }

        public async Task<Employee> CreateAsync(Employee employee)
        {
            var result = await Context.Employees.AddAsync(employee);
            await Context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var data = await Context.Employees.FirstOrDefaultAsync(e => e.Id == id);

            if(data != null)
            {
                Context.Employees.Remove(data);
                var result = await Context.SaveChangesAsync();
                return result > 0;
            }
            return false;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var result = await Context.Employees.ToListAsync();
            return result;
        }

        public async Task<Employee> GetByEmailAsync(string email)
        {
            var result = await Context.Employees.FirstOrDefaultAsync(e => e.Email == email);
            return result;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            var result = await Context.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.Id == id);
            return result;
        }

        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            IQueryable<Employee> query = Context.Employees;

            if (!string.IsNullOrEmpty(name))
                query = query.Where(e => e.FirstName.Contains(name) || e.LastName.Contains(name));

            if (gender != null)
                query = query.Where(e => e.Gender == gender);

            return await query.ToListAsync();
        }

        public async Task<Employee> UpdateAsync(Employee employee)
        {
            var data = await Context.Employees.FirstOrDefaultAsync(e => e.Id == employee.Id);

            if(data != null)
            {
                data.FirstName = employee.FirstName;
                data.LastName = employee.LastName;
                data.Email = employee.Email;
                data.DateOfBirth = employee.DateOfBirth;
                data.Gender = employee.Gender;
                data.DepartmentId = employee.DepartmentId;
                data.Photo = employee.Photo;

                await Context.SaveChangesAsync();
                return data;
            }
            return null;
        }
    }
}
