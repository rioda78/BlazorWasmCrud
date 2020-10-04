using BlazorWasmCrud.Components;
using BlazorWasmCrud.Models;
using BlazorWasmCrud.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasmCrud.Pages
{
    public partial class EmployeePage : ComponentBase
    {
        public IEnumerable<Employee> Employees
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
        public AddEmployeeDialog AddEmployeeDialog
        {
            get;
            set;
        }
        protected async override Task OnInitializedAsync()
        {
            Employees = (await EmployeeDataService.GetAllEmployees()).ToList();
        }
        protected void QuickAddEmployee()
        {
            AddEmployeeDialog.Show();
        }
        public async void AddEmployeeDialog_OnDialogClose()
        {
            Employees = (await EmployeeDataService.GetAllEmployees()).ToList();
            StateHasChanged();
        }
    }
}