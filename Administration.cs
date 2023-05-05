namespace grade_admin_sys;

public class Administration
{
    private List<Student> _students;

    public Administration()
    {
        _students = new List<Student>();

        MainMenu();
    }

    public void MainMenu()
    {
        while (true)
        {
            Console.WriteLine(
                "Welcome!" +
                "\n\t1. Add Student" +
                "\n\t2. Show Student" +
                "\n\t3. Edit Student" +
                "\n\t4. Remove Student" +
                "\n\t5. Show Class" +
                "\n\t6. Exit"
            );
            string? input = Console.ReadLine();
            if (input != null && int.TryParse(input, out int i))
            {
                switch (i)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        ShowStudent();
                        break;
                    case 3:
                        //do
                        break;
                    case 4:
                        //do
                        break;
                    case 5:
                        //do
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid Input. (Please type an integer 1-6)\n");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid Input. (Please type an integer 1-6)\n");
            }
        }
    }

    public void AddStudent()
    {
        string? input = null;

        while (input == null)
        {
            Console.WriteLine("\nFirst Name (e.g. Tom):");
            input = Console.ReadLine();
        }

        string firstName = input;
        input = null;

        while (input == null)
        {
            Console.WriteLine("\nLast Name (e.g. Smith):");
            input = Console.ReadLine();
        }

        string lastName = input;
        input = null;

        DateTime dob = DateTime.Today;
        while (input == null && !DateTime.TryParse(input, out dob))
        {
            Console.WriteLine("\nDate of Birth (e.g. 25/02/2023):");
            input = Console.ReadLine();
        }

        input = null;

        int studentNumber = -1;
        while (input == null && !int.TryParse(input, out studentNumber))
        {
            Student? s = _students.Find(x => x.StudentNumber == studentNumber);
            if (s == null)
            {
                Console.WriteLine("\nStudent Number (e.g. 497441):");
                input = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\nStudent with duplicate student number found! Please use another integer.");
                input = null;
            }
        }

        _students.Add(new Student(studentNumber, firstName, lastName, dob));
        Console.WriteLine($"New student: {_students.Last()}\n");
        MainMenu();
    }

    public void ShowStudent()
    {
        Console.WriteLine("Find student by:\n\t1. Student Number\n\t2. Full Name\n\t3. Back");
        string? input = Console.ReadLine();
        if (input != null && int.TryParse(input, out int i))
        {
            switch (i)
            {
                case 1:
                    FindStudentByNumber();
                    break;
                case 2:
                    FindStudentByName();
                    break;
                case 3:
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid Input. (Please type an integer 1-6)\n");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid Input. (Please type an integer 1-6)\n");
        }
    }

    public void FindStudentByNumber()
    {
        string? input = null;
        int studentNumber = -1;
        while (input == null && !int.TryParse(input, out studentNumber))
        {
            Console.WriteLine("\nStudent Number (e.g. 497441):");
            input = Console.ReadLine();
        }

        Student? s = _students.Find(x => x.StudentNumber == studentNumber);
        if (s == null)
        {
            Console.WriteLine("No student found by that student number.");
        }
        else
        {
            Console.WriteLine(s.ToString());
        }

        MainMenu();
    }

    public void FindStudentByName()
    {
        string? input = null;

        while (input == null && !char.IsUpper(input[0]))
        {
            Console.WriteLine("\nFirst Name (e.g. Tom):");
            input = Console.ReadLine();
        }

        string firstName = input;
        input = null;

        while (input == null && !char.IsUpper(input[0]))
        {
            Console.WriteLine("\nLast Name (e.g. Smith):");
            input = Console.ReadLine();
        }

        string lastName = input;
        input = null;

        Student? s = _students.Find(x => x.FullName == $"{firstName} {lastName}");
        if (s == null)
        {
            Console.WriteLine("No student found by that name.");
        }
        else
        {
            Console.WriteLine(s.ToString());
        }

        MainMenu();
    }
}