using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeDbContext Context;

        public DepartmentRepository(EmployeeDbContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            var result = await Context.Departments.ToListAsync();
            return result;
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            var result = await Context.Departments.FindAsync(id);
            return result;
        }
    }
}
