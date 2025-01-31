namespace GymAppWeDo.Record.Dto;

public class TrainingRecordDto
{
    public int Id { get; set; }
    public int DurationInMinutes { get; set; }
    public string TrainingType { get; set; }
    public int CaloriesBurned { get; set; }
    public int Difficulty { get; set; }
    public int Tiredness { get; set; }
    public string Note { get; set; }
    public string DateAndTimeOfTheTraining { get; set; }
    public string UserEmail { get; set; }
}