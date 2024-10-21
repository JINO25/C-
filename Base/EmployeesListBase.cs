

using Microsoft.AspNetCore.Components;
using testBlazor.Models;
namespace testBlazor.Base
{

    public class EmployeesListBase : ComponentBase
    {
        [Inject]
        public IRepository repository { get; set; }

        public IEnumerable<Employee> employees { get; set; }


        protected async override Task OnInitializedAsync()
        {
            employees = await repository.GetALlEmployees();
        }


    }
}