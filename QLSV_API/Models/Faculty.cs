using System;
using System.Collections.Generic;

namespace QLSV_API.Models;

public partial class Faculty
{
    public int IdFaculty { get; set; }

    public string NameFaculty { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
