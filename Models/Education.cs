using System;
using System.Collections.Generic;

namespace testBlazor.Models;

public partial class Education
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
