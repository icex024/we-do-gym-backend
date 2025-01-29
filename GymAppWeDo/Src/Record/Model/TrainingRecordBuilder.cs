using GymAppWeDo.Record.Enums;

namespace GymAppWeDo.Record.Model;

public class TrainingRecordBuilder : ITrainingRecordBuilder
{
    private TrainingRecord _trainingRecord =  new TrainingRecord();
    
    public TrainingRecordBuilder DurationInMinutes(int durationInMinutes)
    {
        _trainingRecord.DurationInMinutes = durationInMinutes;
        return this;
    }

    public TrainingRecordBuilder TrainingType(TrainingType trainingType)
    {
        _trainingRecord.TrainingType = trainingType;
        return this;
    }

    public TrainingRecordBuilder CaloriesBurned(int caloriesBurned)
    {
        _trainingRecord.CaloriesBurned = caloriesBurned;
        return this;
    }

    public TrainingRecordBuilder Difficulty(int difficulty)
    {
        _trainingRecord.Difficulty = difficulty;
        return this;
    }

    public TrainingRecordBuilder Tiredness(int tiredness)
    {
        _trainingRecord.Tiredness = tiredness;
        return this;
    }

    public TrainingRecordBuilder Note(string note)
    {
        _trainingRecord.Note = note;
        return this;
    }

    public TrainingRecordBuilder DateAndTimeOfTheTraining(DateTime dateTime)
    {
        _trainingRecord.DateAndTimeOfTheTraining = dateTime;
        return this;
    }

    public TrainingRecordBuilder UserEmail(string email)
    {
        _trainingRecord.UserEmail = email;
        return this;
    }

    public TrainingRecord Build()
    {
        TrainingRecord trainingRecord = _trainingRecord; 
        _trainingRecord = new TrainingRecord();
        return trainingRecord;
    }
}