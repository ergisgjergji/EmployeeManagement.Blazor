using EmployeeManagement.Models;
using Ergis.Components;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public partial class EmployeeListItem : ComponentBase
    {
        [Parameter]
        public Employee Employee { get; set; }
        [Parameter]
        public bool DisplayFooter { get; set; }
        
        [Parameter]
        public EventCallback<int> OnEmployeeDelete { get; set; }

        public ConfirmDialog ConfirmModal { get; set; }

        protected async Task OnDeleteClick()
        {
            ConfirmModal.Show();
        }

        protected async Task OnDialogConfirm(bool confirm)
        {
            if(confirm)
            {
                await OnEmployeeDelete.InvokeAsync(Employee.Id);
            }
        }
    }
}
