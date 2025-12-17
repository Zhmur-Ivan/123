using System;

public enum Schedule
{
    First,
    Second,
    Third,
    Fourth,
    Last,
    Teenth
}

public class Meetup
{
    private readonly int _month;
    private readonly int _year;

    public Meetup(int month, int year)
    {
        _month = month;
        _year = year;
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        return schedule switch
        {
            Schedule.Teenth => FindTeenth(dayOfWeek),
            Schedule.Last   => FindLast(dayOfWeek),
            Schedule.First  => FindNth(dayOfWeek, 1),
            Schedule.Second => FindNth(dayOfWeek, 2),
            Schedule.Third  => FindNth(dayOfWeek, 3),
            Schedule.Fourth => FindNth(dayOfWeek, 4),
            _ => throw new ArgumentException("Unknown schedule.", nameof(schedule))
        };
    }

    private DateTime FindNth(DayOfWeek wanted, int n)
    {
        // перший день місяця
        DateTime date = new DateTime(_year, _month, 1);

        // зсуваємося до першого потрібного дня тижня
        int offset = ((int)wanted - (int)date.DayOfWeek + 7) % 7;
        date = date.AddDays(offset);

        // n-тий = перший + 7*(n-1)
        date = date.AddDays(7 * (n - 1));

        return date;
    }

    private DateTime FindLast(DayOfWeek wanted)
    {
        int lastDay = DateTime.DaysInMonth(_year, _month);
        DateTime date = new DateTime(_year, _month, lastDay);

        int offsetBack = ((int)date.DayOfWeek - (int)wanted + 7) % 7;
        return date.AddDays(-offsetBack);
    }

    private DateTime FindTeenth(DayOfWeek wanted)
    {
        // teenth = 13..19
        for (int d = 13; d <= 19; d++)
        {
            DateTime date = new DateTime(_year, _month, d);
            if (date.DayOfWeek == wanted)
                return date;
        }

        // теоретично неможливо, але хай буде
        throw new InvalidOperationException("No teenth day found.");
    }
}
