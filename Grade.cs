namespace grade_admin_sys;

public class Grade
{
    private double _value;
    private readonly DateTime _date;
    private readonly int _examCode;
    private readonly string _note;
    private bool _frozen;

    public double Value
    {
        get => _value;
        set
        {
            if (value % 0.5 == 0 && !_frozen)
            {
                _value = value;
            }
        }
    }

    public DateTime Date
    {
        get => _date;
    }

    public int ExamCode
    {
        get => _examCode;
    }
    
    public string Note
    {
        get => _note;
    }

    public bool Frozen
    {
        get => _frozen;
        set
        {
            if (value)
            {
                _frozen = value;
            }
        }
    }

    public Grade(int examCode, double value, string note, DateTime date)
    {
        if (value % 0.5 != 0)
        {
            throw new ArgumentException($"{value} is not an increment of 0.5");
        }
        _frozen = false;

        _examCode = examCode;
        _value = value;
        _note = note;
        _date = date;
    }
    
    public Grade(int examCode, double value, string note)
    {
        if (value % 0.5 != 0)
        {
            throw new ArgumentException($"{value} is not an increment of 0.5");
        }
        _frozen = false;
        _date = DateTime.Now;

        _examCode = examCode;
        _value = value;
        _note = note;
    }

    public override string ToString()
    {
        return $"{_examCode} on {_date.ToString("dd-MM-yyyy")}: {_value}";
    }
}