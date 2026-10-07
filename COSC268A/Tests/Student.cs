using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeTests;

public class Student : IComparable<Student>
{
    private string name;
    private int studentNumber;
    private string email;

    public string Name { get => name; set => name = value; }
    public int StudentNumber { get => studentNumber; }
    public string Email {  get => email; set => email = value; }

    public Student (string name, int studentNumber, string email)
    {
        this.name = name;
        this.studentNumber = studentNumber;
        this.email = email;
    
    }
    //Students are compared based on their student numbers
    //If a student's number is less than another's it belongs before,
    //If two student numbers are equal, we consident Students to be equal

    public int CompareTo(Student other)
    {
        return StudentNumber - other.StudentNumber;
    }
    public override string ToString()
    {
        return Name + " (" + StudentNumber + ")" + Email;
    }
}
