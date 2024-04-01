using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RobotApi.Dtos;

public class RobotCreateDto
{
    [JsonPropertyName("name")]
    [MaxLength(10, ErrorMessage = "Max. 10 characters")]
    [MinLength(2, ErrorMessage = "Min. 2 characters")]
    [Required]
    public string Name { get; set; }
}
public class RobotUpdateDto : RobotCreateDto
{
    [JsonPropertyName("version")]
    [Required]
    public Int64 Version { get; set; }
}