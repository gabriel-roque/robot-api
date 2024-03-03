using System.ComponentModel.DataAnnotations.Schema;

namespace RobotApi.Models;

[Table("robots")]
public class Robot
{
    [System.ComponentModel.DataAnnotations.Key]
    [Column("id")]
    public Guid Id { get; set; }
    
    [Column("name")]
    public string Name { get; set; }
}