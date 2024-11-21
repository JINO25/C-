using System;
using System.Collections.Generic;

namespace StaffApi.Models;

public partial class Gender
{
    public int GenderId { get; set; }

    public string? GenderDescription { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
