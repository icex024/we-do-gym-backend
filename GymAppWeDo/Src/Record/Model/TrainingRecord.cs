using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GymAppWeDo.Record.Enums;
using Microsoft.EntityFrameworkCore;

namespace GymAppWeDo.Record.Model;

public class TrainingRecord
{
    [Key]
    public int Id { get; set; }
    
    [Required] public int DurationInMinutes { get; set; } = 0;
    [Required] public TrainingType TrainingType { get; set; } = TrainingType.Cardio;
    [Required] public int CaloriesBurned { get; set; } = 0;
    [Range(1, 10, ErrorMessage = "Please enter valid integer Number")]
    [Required] public int Difficulty { get; set; } = 1;
    [Range(1, 10, ErrorMessage = "Please enter valid integer Number")]
    [Required] 
    public int Tiredness { get; set; } = 1;
    [MaxLength(200)]
    public string Note { get; set; } = "";
    [Required]
    public DateTime DateAndTimeOfTheTraining { get; set; } = DateTime.Now;
    [ForeignKey("User")]
    public string UserEmail { get; set; } = "";
}