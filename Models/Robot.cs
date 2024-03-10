namespace RobotApi.Models;

public class Robot : Entity
{
    public string Name { get; set; }
    public int Level { get; set; } = 0;
}