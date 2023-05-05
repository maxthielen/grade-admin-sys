namespace grade_admin_sys;

public class Student
{
    private string _firstName;
    private string _lastName;
    private readonly int _studentNumber;
    private readonly DateTime _dateOfBirth;
    private List<Grade> _grades;

    public string FirstName
    {
        get => _firstName;
        set => _firstName = value;
    }
    
    public string LastName
    {
        get => _lastName;
        set => _lastName = value;
    }

    public string FullName
    {
        get => _firstName + " " + _lastName;
    }

    public int StudentNumber
    {
        get => _studentNumber;
    }

    public DateTime DateOfBirth
    {
        get => _dateOfBirth;
    }
    
    public Student(int studentNumber, string firstName, string lastName, DateTime dateOfBirth)
    {
        _grades = new List<Grade>();
        
        _studentNumber = studentNumber;
        _firstName = firstName;
        _lastName = lastName;
        _dateOfBirth = dateOfBirth;
    }
    
    public override string ToString()
    {
        return $"{FullName} {_studentNumber}";
    }

    public void setGrade(int examCode, double value, string note)
    {
        Grade? g = _grades.Find(x => x.ExamCode == examCode);
        if (g == null || g.Frozen)
        {
            _grades.Add(new Grade(examCode, value, note));
        }

        g.Value = value;
    }

    public void PrintGrades()
    {
        _grades.Sort((x,y)=>y.Date.CompareTo(x.Date));
        Console.WriteLine(string.Join('\n',_grades.ToString()));
    }
    
    public void PrintGrades(DateTime start, DateTime end)
    {
        _grades.Sort((x,y)=>y.Date.CompareTo(x.Date));
        for (int i=0; i < _grades.Count; i++)
        {
            if (_grades[i].Date > start && _grades[i].Date < end)
            {
                Console.WriteLine(_grades.ToString());
            }
        }
    }

    public List<Grade> GradesFor(int examCode)
    {
        return _grades.FindAll(x => x.ExamCode == examCode);
    }

    public double GradePointAverage()
    {
        double gp = 0.0;
        List<int> previousCodes = new List<int>();
        _grades.ForEach(x =>
        {
            if (previousCodes.Contains(x.ExamCode))
            {
                int i = previousCodes.LastIndexOf(x.ExamCode);
                if (_grades[i].Value < x.Value)
                {
                    gp -= _grades[i].Value;
                }
                else
                {
                    gp -= x.Value;
                }
            }
            gp += x.Value;
            previousCodes.Add(x.ExamCode);
        });
        return gp / _grades.Count;
    }
}