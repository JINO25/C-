using System;
using System.Collections.Generic;

namespace testBlazor.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public DateTime StartingDate { get; set; }

    public int? EduId { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }

    public virtual Education? Edu { get; set; }
}
