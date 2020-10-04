using BlazorWasmCrud.Models;
using BlazorWasmCrud.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasmCrud.Pages
{
    public partial class Edit
    {
        [Inject]
        public IEmployeeDataService EmployeeDataService
        {
            get;
            set;
        }
        [Parameter]
        public string EmployeeId
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
        public BlazorWasmCrud.Models.Employee Employee
        {
            get;
            set;
        }
        //used to store state of screen  
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;
        protected override async Task OnInitializedAsync()
        {
            Saved = false;
            int.TryParse(EmployeeId, out
                var employeeId);
            if (employeeId == 0) //new employee is being created  
            {
                Employee = new Employee { };
            }
            else
            {
                Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            }
        }
        protected async Task HandleValidSubmit()
        {
            Saved = false;
            if (Employee.EmployeeId == 0)
            {
                var addedEmployee = await EmployeeDataService.AddEmployee(Employee);
                if (addedEmployee != null)
                {
                    StatusClass = "alert-success";
                    Message = "New employee added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new employee. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await EmployeeDataService.UpdateEmployee(Employee);
                StatusClass = "alert-success";
                Message = "Employee updated successfully.";
                Saved = true;
            }
        }
        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }
        protected async Task DeleteEmployee()
        {
            await EmployeeDataService.DeleteEmployee(Employee.EmployeeId);
            StatusClass = "alert-success";
            Message = "Deleted successfully";
            Saved = true;
        }
        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/");
        }
    }
}