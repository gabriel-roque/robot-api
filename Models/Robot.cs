using System.ComponentModel.DataAnnotations;

namespace RobotApi.Models;

public class Robot : Entity
{
    public string Name { get; set; }
    public int Level { get; set; } = 0;
    
    [ConcurrencyCheck]
    public long Version { get; set; } = 0;
}