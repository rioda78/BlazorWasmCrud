using BlazorWasmCrud.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasmCrud.Pages
{
    public partial class Detail
    {
        [Parameter]
        public string EmployeeId
        {
            get;
            set;
        }
        public BlazorWasmCrud.Models.Employee Employee
        {
            get;
            set;
        }
        [Inject]
        public NavigationManager NavigationManager
        {
            get;
            set;
        }
        [Inject]
        public IEmployeeDataService EmployeeDataService
        {
            get;
            set;
        }
        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
        }
        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/");
        }
    }
}