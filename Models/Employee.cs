using System;
using System.Collections.Generic;

namespace StaffApi.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public DateTime? DateofBirth { get; set; }

    public int? DepartmentId { get; set; }

    public int? GenderId { get; set; }

    public virtual Department? Department { get; set; }

    public virtual Gender? Gender { get; set; }
}
