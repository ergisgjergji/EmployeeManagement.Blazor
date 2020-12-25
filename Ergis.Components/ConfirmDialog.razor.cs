using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ergis.Components
{
    public partial class ConfirmDialog : ComponentBase
    {
        public bool IsVisible { get; set; } = false;

        [Parameter]
        public string Title { get; set; } = "Confirm";
        [Parameter]
        public string Message { get; set; } = "Are you sure you want to continue?";
        [Parameter]
        public string ConfirmBtn { get; set; } = "Yes";
        [Parameter]
        public string CancelBtn { get; set; } = "No";
        [Parameter]
        public EventCallback<bool> ConfirmCallback { get; set; }

        public void Show()
        {
            IsVisible = true;
            StateHasChanged();
        }

        protected async Task OnConfirmationChange(bool confirmed)
        {
            IsVisible = false;
            await ConfirmCallback.InvokeAsync(confirmed);
        }
    }
}
