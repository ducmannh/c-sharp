using System;
using System.Collections.Generic;

namespace QLSV_API.Models;

public partial class Student
{
    public int IdStudent { get; set; }

    public string NameStudent { get; set; } = null!;

    public DateTime BirthdayStudent { get; set; }

    public string Gender { get; set; } = null!;

    public int IdFaculty { get; set; }

    public virtual Faculty? IdFacultyNavigation { get; set; } = null!;
}
