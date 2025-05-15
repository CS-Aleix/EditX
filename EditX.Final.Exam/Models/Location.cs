namespace EditX.Final.Exam.Models;

public class Location : BaseObject
{
    public override string ToString()
    {
        return $"{Ward}/{Room}/{Bed}";
    }

    public required string Ward { get; set; }
    public string Room { get; set; }
    public string Bed { get; set; } 
}