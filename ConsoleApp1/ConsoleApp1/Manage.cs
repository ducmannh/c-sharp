using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Manage
{
    private List<Student> ListStudent = null;
    public List<Student> getListStudent()
    {
        return ListStudent;
    }
    public Manage()
    {
        ListStudent = new List<Student>();
    }

    public int NumberOfStudents()
    {
        int countStudent = 0;
        if(ListStudent != null)
        {
            countStudent = ListStudent.Count;
        }
        return countStudent;
    }
    public void InputStudent()
    {
        Student student = new Student();

        Console.Write("Student ID: ");
        student.Id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Student Name: ");
        student.Name = Console.ReadLine();

        Console.Write("Student Date of Birth: ");
        student.Date = Console.ReadLine();

        Console.Write("Gender: ");
        student.Gender = Console.ReadLine();

        Console.Write("Faculty: ");
        student.Faculty = Console.ReadLine();

        ListStudent.Add(student);
    }
    public void ShowStudent(List<Student> listStudent)
    {
        Console.WriteLine("{0,1} {1,4} {2,5} {3,7} {4,9}", "ID", "Name", "Date of Birth", "Gender", "Faculty");
        if (listStudent != null && listStudent.Count > 0)
        {
            foreach (Student student in listStudent)
            {
                Console.WriteLine("{0,1} {1,4} {2,8} {3,10} {4,9}", student.Id, student.Name, student.Date, student.Gender, student.Faculty);
            }
        }
    }
    public Student FindById(int Id)
    {
        Student searchId = null;
        if (ListStudent != null && ListStudent.Count > 0)
        {
            foreach (Student student in ListStudent)
            {
                if (student.Id == Id)
                {
                    searchId = student;
                }
            }
        }
        return searchId;
    }
    public void UpdateStudent(int Id)
    {
        Student student = FindById(Id);
        if (student != null)
        {
            Console.Write("Student Name: ");
            string name = Convert.ToString(Console.ReadLine());
            if (name != null && name.Length > 0)
            {
                student.Name = name;
            }

            Console.Write("Student Date of Birth: ");
            string date = Convert.ToString(Console.ReadLine());
            if (date != null && date.Length > 0)
            {
                student.Date = date;
            }

            Console.Write("Student Gender: ");
            string gender = Convert.ToString(Console.ReadLine());
            if (gender != null && gender.Length > 0)
            {
                student.Gender = gender;
            }

            Console.Write("Student Faculty: ");
            string faculty = Convert.ToString(Console.ReadLine());
            if (faculty != null && faculty.Length > 0)
            {
                student.Faculty = faculty;
            }
        }
    }
    public bool DeleteById(int Id)
    {
        Student student = FindById(Id);
        bool IsDeleted = false;
        if (student != null)
        {
            IsDeleted = ListStudent.Remove(student);
        }
        return IsDeleted;
    }
    public void SortById()
    {
        ListStudent.Sort(delegate (Student student1, Student student2)
        {
            return student1.Id.CompareTo(student2.Id);
        });
    }
    public List<Student> FindByName(String keyword)
    {
        List<Student> searchResult = new List<Student>();
        if(ListStudent != null && ListStudent.Count > 0)
        {
            foreach(Student student in ListStudent)
            {
                if (student.Name.ToLower().Contains(keyword.ToLower()))
                {
                    searchResult.Add(student);
                }
            }
        }
        return searchResult;
    }
}
