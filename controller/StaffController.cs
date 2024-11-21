
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StaffApi.DTO;
using StaffApi.Models;

[Route("api/staff")]
[ApiController]
public class StaffController : ControllerBase
{
    private readonly IStaffRepository staffRepository;
    public StaffController(IStaffRepository staffRepository)
    {
        this.staffRepository = staffRepository;
    }


    [HttpPost]
    public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
    {
        try
        {
            return Ok(await staffRepository.AddEmployee(employee));
        }
        catch (System.Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
        }
    }


    [HttpGet]
    public async Task<ActionResult> GetEmployees()
    {
        try
        {
            return Ok(await staffRepository.GetAllEmployees());
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
        }
    }

    [HttpGet("{id:int}")]

    public async Task<ActionResult<Employee>> GetEmployee(int id)
    {
        Console.WriteLine(id);

        try
        {
            var result = await staffRepository.GetEmployee(id);
            if (result == null) return NotFound();
            return result;
        }

        catch (Exception)
        {
            Console.WriteLine(id);

            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
        }
    }

    [HttpGet("emp-dto/{id2:int}")]

    public async Task<ActionResult<EmployeeDTO>> GetEmployee2(int id2)
    {

        try
        {
            var result = await staffRepository.GetEmployee2(id2);
            if (result == null) return NotFound();
            return result;
        }

        catch (Exception)
        {
            Console.WriteLine(id2);

            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
        }
    }


    [HttpPut()]
    public async Task<ActionResult<Employee>> Update(Employee employee)
    {
        try
        {

            var result = await staffRepository.UpdateEmployee(employee);
            if (result == null) return NotFound();
            return result;
        }

        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
        }

    }


    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Employee>> Delete(int id)
    {
        try
        {

            var result = await staffRepository.DeleteEmployee(id);
            if (result == null) return NotFound();
            return result;
        }

        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
        }
    }
}