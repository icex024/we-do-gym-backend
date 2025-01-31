namespace GymAppWeDo.Record.Dto;

public class CreateTrainingRecordDto
{
    public int DurationInMinutes { get; set; }
    public string TrainingType { get; set; } = string.Empty;
    public int CaloriesBurned { get; set; } = 0;
    public int Difficulty { get; set; } = 0;
    public int Tiredness { get; set; } = 0;
    public string Note { get; set; } = String.Empty;
    public string DateAndTimeOfTheTraining { get; set; } = string.Empty;
}