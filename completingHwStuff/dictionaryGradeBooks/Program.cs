class GradeBook
{
    private Dictionary<int, string> students = new Dictionary<int, string>();
    private Dictionary<int, double> grades = new Dictionary<int, double>();

    public void AddStudent()
    {
        Console.Write("Please enter the student ID:");
        string idEntered = Console.ReadLine();
        int id;

        if (!int.TryParse(idEntered, out id))
        {
            Console.WriteLine(@"Please enter a valid student ID.(Numbers Only)");
            return;
        }
        if (students.ContainsKey(id))
        {
            Console.WriteLine("This ID already exists. Please try another one.");
            return;
        }

        Console.Write("Please type in the student's FULL name: ");
        string name = Console.ReadLine();

        Console.Write("Please enter the grade for the student (0.0 - 100.0): ");
        string gradeEntered = Console.ReadLine();
        double grade;

        if (!double.TryParse(gradeEntered, out grade) || grade < 0.0 || grade > 100.0)
        {
            Console.WriteLine("Please enter a valid numeric grade between 0.0 and 100.0.");
            return;
        }

        students.Add(id, name);
        grades.Add(id, grade);

        Console.WriteLine("The student was added successfully.");
    }

    public void UpdateGrade()
    {
        Console.Write("Enter Student ID to update grade: ");
        string idEntered = Console.ReadLine();
        int id;

        if (!int.TryParse(idEntered, out id) || !students.ContainsKey(id))
        {
            Console.WriteLine("Invalid Student ID. Please enter a valid ID that exists.");
            return;
        }

        Console.Write("Enter the updated grade (0.0 - 100.0): ");
        string gradeEntered = Console.ReadLine();
        double newGrade;

        if (!double.TryParse(gradeEntered, out newGrade) || newGrade < 0.0 || newGrade > 100.0)
        {
            Console.WriteLine("Invalid grade entered for Student Grade. Please enter a value between 0.0 and 100.0.");
            return;
        }

        grades[id] = newGrade;
        Console.WriteLine("The grade was updated successfully.");
    }

    public void RemoveStudent()
    {
        Console.Write("Enter Student ID to remove: ");
        string idInput = Console.ReadLine();
        int id;

        if (!int.TryParse(idInput, out id) || !students.ContainsKey(id))
        {
            Console.WriteLine("Invalid Student ID. Please enter a valid ID that exists.");
            return;
        }

        students.Remove(id);
        grades.Remove(id);
        Console.WriteLine("The student was removed successfully.");
    }

    public void DisplayAllStudents()
    {
        Console.WriteLine("Students and their Grades:");
        foreach (var student in students)
        {
            int id = student.Key;
            string name = student.Value;
            double grade = grades[id];
            Console.WriteLine($"ID: {id}\nName: {name}\nGrade: {grade}");
        }
    }

    public void SearchStudentById()
    {
        Console.Write("Enter Student ID to search: ");
        string idInput = Console.ReadLine();
        int id;

        if (!int.TryParse(idInput, out id) || !students.ContainsKey(id))
        {
            Console.WriteLine("Invalid Student ID. Please enter a valid ID that exists.");
            return;
        }

        string name = students[id];
        double grade = grades[id];
        Console.WriteLine($"ID: {id}\nName: {name}\nGrade: {grade}");
    }

    public void CalculateAverageGrade()
    {
        if (grades.Count == 0)
        {
            Console.WriteLine("There are no grades recorded to perform this task.");
            return;
        }

        double total = 0;
        foreach (var grade in grades.Values)
        {
            total += grade;
        }

        double average = total / grades.Count;
        Console.WriteLine($"The average grade is: {average:F2}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        GradeBook gradebook = new GradeBook();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nGradebook Menu:");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Update Student Grade");
            Console.WriteLine("3. Remove Student");
            Console.WriteLine("4. Display All Students");
            Console.WriteLine("5. Search Student by ID");
            Console.WriteLine("6. Calculate Average Grade");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option: ");

            string input = Console.ReadLine();
            int choice;

            if (int.TryParse(input, out choice))
            {
                switch (choice)
                {
                    case 1:
                        gradebook.AddStudent();
                        break;
                    case 2:
                        gradebook.UpdateGrade();
                        break;
                    case 3:
                        gradebook.RemoveStudent();
                        break;
                    case 4:
                        gradebook.DisplayAllStudents();
                        break;
                    case 5:
                        gradebook.SearchStudentById();
                        break;
                    case 6:
                        gradebook.CalculateAverageGrade();
                        break;
                    case 7:
                        running = false;
                        Console.WriteLine("Exiting the program.");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please select a valid menu option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}