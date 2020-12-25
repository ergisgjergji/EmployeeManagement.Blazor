using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public partial class CreateEmployee : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        [Inject]
        public IDepartmentService DepartmentService { get; set; }
        [Inject]
        public IMapper Mapper { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [CascadingParameter]
        public Task<AuthenticationState> AuthStateTask { get; set; }
        public EditEmployeeModel EditEmployeeModel { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthStateTask;

            if (!authState.User.Identity.IsAuthenticated)
            {
                string returnUrl = WebUtility.UrlEncode($"/employee/new");
                NavigationManager.NavigateTo($"/identity/account/login?returnUrl={returnUrl}");
            }

            EditEmployeeModel = new EditEmployeeModel
            {
                DateOfBirth = DateTime.Now,
                DepartmentId = 1,
                Photo = "images/empty.png"
            };
            Departments = (await DepartmentService.GetAllAsync()).ToList();
        }

        protected async Task OnSubmit()
        {
            Employee newEmployee = new Employee();
            Mapper.Map(EditEmployeeModel, newEmployee);
            var result = await EmployeeService.CreateAsync(newEmployee);

            if (result != null)
            {
                NavigationManager.NavigateTo($"/employee/{result.Id}");
            }
        }
    }
}
