using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Models;
using EmployeeManagement.Web.Services;
using Ergis.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public partial class EditEmployee : ComponentBase
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
        [Parameter]
        public string Id { get; set; }
        private Employee Employee { get; set; } = new Employee();
        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();
        public List<Department> Departments { get; set; } = new List<Department>();
        public ConfirmDialog ConfirmModal { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthStateTask;

            if (!authState.User.Identity.IsAuthenticated)
            {
                string returnUrl = WebUtility.UrlEncode($"/employee/{Id}/edit");
                NavigationManager.NavigateTo($"/identity/account/login?returnUrl={returnUrl}");
            }

            Employee = await EmployeeService.GetByIdAsync(int.Parse(Id));
            Departments = (await DepartmentService.GetAllAsync()).ToList();

            Mapper.Map(Employee, EditEmployeeModel);
        }

        protected async Task OnSubmit()
        {
            Mapper.Map(EditEmployeeModel, Employee);
            var result = await EmployeeService.UpdateAsync(Employee);

            if(result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }

        protected async Task OnDeleteClick()
        {
            ConfirmModal.Show();
        }

        protected async Task OnDeleteConfirm(bool confirm)
        {
            if(confirm)
            {
                await EmployeeService.DeleteAsync(Employee.Id);
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
