using EmployeeManagement.Models;
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
    public partial class EmployeeList : ComponentBase
    {
        [CascadingParameter]
        public Task<AuthenticationState> AuthStateTask { get; set; }
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
        public bool DisplayFooter { get; set; } = true;
        public int SelectedEmployeesCount { get; set; } = 0;

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthStateTask;

            if(!authState.User.Identity.IsAuthenticated)
            {
                string returnUrl = WebUtility.UrlEncode("/");
                NavigationManager.NavigateTo($"/identity/account/login?returnUrl={returnUrl}" );
            }

            Employees = await EmployeeService.GetAllAsync();
        }

        protected void EmployeeSelectionChanged(bool isSelected)
        {
            if (isSelected)
                SelectedEmployeesCount++;
            else
                SelectedEmployeesCount--;
        }

        protected async Task DeleteEmployee(int id)
        {
            await EmployeeService.DeleteAsync(id);
            Employees = Employees.Where(e => e.Id != id).ToList();
        }
    }
}
