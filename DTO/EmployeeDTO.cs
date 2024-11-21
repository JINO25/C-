
namespace StaffApi.DTO;
public class EmployeeDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime? date { get; set; }

    public int? DepartmentId { get; set; }

    public int? GenderId { get; set; }
    public string DepartmentName { get; set; }
    public string Gender { get; set; }
}