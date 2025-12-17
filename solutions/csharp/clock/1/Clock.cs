public class Clock
{
    private int _minutes;

    public Clock(int hours, int minutes)
    {
        _minutes = Normalize(hours * 60 + minutes);
    }

    public Clock Add(int minutes)
    {
        return new Clock(0, _minutes + minutes);
    }

    public Clock Subtract(int minutes)
    {
        return new Clock(0, _minutes - minutes);
    }

    public override string ToString()
    {
        int hours = _minutes / 60;
        int mins = _minutes % 60;
        return $"{hours:D2}:{mins:D2}";
    }

    public override bool Equals(object obj)
    {
        if (obj is Clock other)
        {
            return _minutes == other._minutes;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return _minutes.GetHashCode();
    }

    private int Normalize(int minutes)
    {
        int day = 24 * 60;
        minutes %= day;
        if (minutes < 0)
            minutes += day;
        return minutes;
    }
}
