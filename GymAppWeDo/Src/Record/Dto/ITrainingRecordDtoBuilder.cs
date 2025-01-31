namespace GymAppWeDo.Record.Dto;

public interface ITrainingRecordDtoBuilder
{
    TrainingRecordDtoBuilder Id(int id);
    TrainingRecordDtoBuilder DurationInMinutes(int durationInMinutes);
    TrainingRecordDtoBuilder TrainingType(string trainingType);
    TrainingRecordDtoBuilder CaloriesBurned(int caloriesBurned);
    TrainingRecordDtoBuilder Difficulty(int difficulty);
    TrainingRecordDtoBuilder Tiredness(int tiredness);
    TrainingRecordDtoBuilder Note(string note);
    TrainingRecordDtoBuilder DateAndTimeOfTheTraining(string dateTime);
    TrainingRecordDtoBuilder UserEmail(string email);
    TrainingRecordDto Build();

}