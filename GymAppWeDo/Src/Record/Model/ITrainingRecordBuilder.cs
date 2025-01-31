using GymAppWeDo.Record.Enums;

namespace GymAppWeDo.Record.Model;

public interface ITrainingRecordBuilder
{
    TrainingRecordBuilder DurationInMinutes(int durationInMinutes);
    TrainingRecordBuilder TrainingType(TrainingType trainingType);
    TrainingRecordBuilder CaloriesBurned(int caloriesBurned);
    TrainingRecordBuilder Difficulty(int difficulty);
    TrainingRecordBuilder Tiredness(int tiredness);
    TrainingRecordBuilder Note(string note);
    TrainingRecordBuilder DateAndTimeOfTheTraining(DateTime dateTime);
    TrainingRecordBuilder UserEmail(string email);
    TrainingRecord Build();
}