
using Microsoft.AspNetCore.Components;
using testBlazor.Models;

namespace testBlazor.Base
{
    public class editEmployee : ComponentBase
    {
        public Employee employee { get; set; } = new Employee();

        [Inject]
        public IRepository repository { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }


        [Parameter]
        public string id { get; set; }


        protected async override Task OnInitializedAsync()
        {
            employee = await repository.GetEmployee(int.Parse(id));
        }


        public async Task handleUpdate(Employee employee)
        {
            repository.Update(employee);
            navigationManager.NavigateTo("/");
        }

        public async Task update()
        {
            Console.WriteLine($"{employee.FirstName} and {employee.LastName}");
            await handleUpdate(employee);
        }

    }
}