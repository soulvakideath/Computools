namespace Computools.Core.Models;

using System;

using System;
using System.Collections.Generic;

public class Subject
{
    public Subject(Guid id, string name, Guid studentId, int grade, DateTime date)
    {
        Id = id;
        Name = name;
        StudentId = studentId;
        Grade = grade;
        Date = date;
    }

    public Guid Id { get; }
    public string Name { get; } = string.Empty;
    public Guid StudentId { get; }
    public int Grade { get; }
    public DateTime Date { get; }

    public static Subject Create(Guid id, string name, Guid studentId, int grade, DateTime date)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentException("Name cannot be null!");
        if (grade < 0 || grade > 100) throw new ArgumentException("Grade must be between 0 and 100!");

        return new Subject(id, name, studentId, grade, date);
    }
}

