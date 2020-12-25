using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Ergis.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public partial class EmployeeDetails : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [CascadingParameter]
        public Task<AuthenticationState> AuthStateTask { get; set; }
        [Parameter]
        public string Id { get; set; }
        public Employee Employee { get; set; }
        public string Coordinates { get; set; }
        public bool ShowActions { get; set; } = true;
        public ConfirmDialog ConfirmModal { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthStateTask;

            if (!authState.User.Identity.IsAuthenticated)
            {
                string returnUrl = WebUtility.UrlEncode($"/employee/{Id}");
                NavigationManager.NavigateTo($"/identity/account/login?returnUrl={returnUrl}");
            }

            Employee = await EmployeeService.GetByIdAsync(int.Parse(Id));
        }

        protected void Mouse_Move(MouseEventArgs e)
        {
            Coordinates = "X: " + e.ClientX + " Y: " + e.ClientY;
        }

        protected void ToggleActions_Click()
        {
            ShowActions = !ShowActions;
        }

        protected async Task OnDeleteClick()
        {
            ConfirmModal.Show();
        }

        protected async Task OnDeleteConfirm(bool confirm)
        {
            if (confirm)
            {
                await EmployeeService.DeleteAsync(Employee.Id);
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
