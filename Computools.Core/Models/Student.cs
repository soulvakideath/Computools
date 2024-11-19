using System;
using System.Collections.Generic;
using System.Linq;
using Computools.Core.Enums;
using Computools.Core.Models;

public class Student
{
    private readonly List<Subject> _subjects = new();

    public Student(Guid id, string firstName, string secondName, int age, Grant grant)
    {
        Id = id;
        FirstName = firstName;
        SecondName = secondName;
        Age = age;
        Grant = grant;
    }

    public Guid Id { get; }
    public string FirstName { get; } = string.Empty;
    public string SecondName { get; } = string.Empty;
    public int Age { get; }
    public IReadOnlyList<Subject> Subjects => _subjects;
    public Grant Grant { get; }

    public double AverageGrade => _subjects.Count == 0 ? 0 : _subjects.Average(s => s.Grade);

    public static Student Create(Guid id, string firstName, string secondName, int age, Grant grant)
    {
        if (string.IsNullOrEmpty(firstName)) throw new ArgumentException("First Name cannot be null!");
        if (string.IsNullOrEmpty(secondName)) throw new ArgumentException("Second Name cannot be null!");
        if (age < 0) throw new ArgumentException("Age cannot be negative!");

        return new Student(id, firstName, secondName, age, grant);
    }

    public void AddSubject(Subject subject)
    {
        _subjects.Add(subject);
    }
}



