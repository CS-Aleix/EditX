using EditX.Final.Exam.Models;

namespace EditX.Final.Exam.Interfaces;

public class Patient
{
    public DateOnly BirthDate { get; set; }
    public string City { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string SocialSecurityNumber { get; set; }
    public Location Location { get; set; }

    public override string ToString()
    {
        return $"{LastName}";
    }

    public string GetLocation()
    {
        return $"{FirstName} {LastName} is located @{Location.Ward}/{Location.Room}/{Location.Bed}";
    }
}