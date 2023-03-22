using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        Manage manageStudent = new Manage();
        while (true)
        {
            Console.WriteLine("Student Management Program");
            Console.WriteLine("-----------------------MENU-----------------------");
            Console.WriteLine("--- 1. Add Student                             ---");
            Console.WriteLine("--- 2. Show the lists of students              ---");
            Console.WriteLine("--- 3. Find student by Name                    ---");
            Console.WriteLine("--- 4. Update student by Id                    ---");
            Console.WriteLine("--- 5. Delete student by Id                    ---");
            Console.WriteLine("--- 6. Sort student by Id                      ---");
            Console.WriteLine("--- 0. Exit                                    ---");
            Console.WriteLine("--------------------------------------------------");
            Console.Write("Choose your option: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("1. Add Student");
                    Console.Write("Enter amount of students: ");
                    int n = Convert.ToInt32(Console.ReadLine());
                    for (int i = 1; i <= n; i++)
                    {
                        Console.WriteLine("\nEnter student {0}: ", i);
                        manageStudent.InputStudent();
                    }
                    Console.WriteLine("Successfully");
                    break;

                case 2:
                    Console.WriteLine("2. Show the lists of students");
                    manageStudent.ShowStudent(manageStudent.getListStudent());
                    break;

                case 3:
                    if (manageStudent.NumberOfStudents() > 0)
                    {
                        Console.WriteLine("3. Find student by Name");
                        Console.Write("Enter Name Student to find: ");
                        String name = Convert.ToString(Console.ReadLine());
                        List<Student> searchResult = manageStudent.FindByName(name);
                        manageStudent.ShowStudent(searchResult);
                    }
                    else
                    {
                        Console.WriteLine("Don't have a Student Name");
                    }
                    break;

                case 4:
                    if (manageStudent.NumberOfStudents() > 0)
                    {
                        Console.WriteLine("4. Update student by Id");
                        Console.Write("Enter a Student ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        manageStudent.UpdateStudent(id);
                    }
                    else
                    {
                        Console.WriteLine("Don't have a Student Id");
                    }
                    break;

                case 5:
                    if (manageStudent.NumberOfStudents() > 0)
                    {
                        Console.WriteLine("5. Delete student by Id");
                        Console.Write("Enter a Student ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        if (manageStudent.DeleteById(id))
                        {
                            Console.WriteLine("Student have id = {0} deleted ", id);
                        }
                        else
                        {
                            Console.WriteLine("Don't have a Student Id");
                        }
                        
                    }
                    break;

                case 6:
                    if(manageStudent.NumberOfStudents() > 0)
                    {
                        Console.WriteLine("6. Sort student by Id");
                        manageStudent.SortById();
                        manageStudent.ShowStudent(manageStudent.getListStudent());
                    }
                    break;

                case 0:
                    return;

                default:
                    Console.WriteLine("There is no this function in the menu");
                    Console.WriteLine("Please choose a function in the menu");
                    break;
            }
        }
    }
}

