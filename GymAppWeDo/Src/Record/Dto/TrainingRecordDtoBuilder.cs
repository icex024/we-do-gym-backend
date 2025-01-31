using GymAppWeDo.Record.Enums;

namespace GymAppWeDo.Record.Dto;

public class TrainingRecordDtoBuilder : ITrainingRecordDtoBuilder
{
    private TrainingRecordDto _trainingRecordDto = new TrainingRecordDto();
    
    public TrainingRecordDtoBuilder Id(int id)
    {
        _trainingRecordDto.Id = id;
        return this;
    }

    public TrainingRecordDtoBuilder DurationInMinutes(int durationInMinutes)
    {
        _trainingRecordDto.DurationInMinutes = durationInMinutes;
        return this;
    }

    public TrainingRecordDtoBuilder TrainingType(string trainingType)
    {
        _trainingRecordDto.TrainingType = trainingType;
        return this;
    }

    public TrainingRecordDtoBuilder CaloriesBurned(int caloriesBurned)
    {
        _trainingRecordDto.CaloriesBurned = caloriesBurned;
        return this;
    }

    public TrainingRecordDtoBuilder Difficulty(int difficulty)
    {
        _trainingRecordDto.Difficulty = difficulty;
        return this;
    }

    public TrainingRecordDtoBuilder Tiredness(int tiredness)
    {
        _trainingRecordDto.Tiredness = tiredness;
        return this;
    }

    public TrainingRecordDtoBuilder Note(string note)
    {
        _trainingRecordDto.Note = note;
        return this;
    }

    public TrainingRecordDtoBuilder DateAndTimeOfTheTraining(string dateTime)
    {
        _trainingRecordDto.DateAndTimeOfTheTraining = dateTime;
return this;
    }

    public TrainingRecordDtoBuilder UserEmail(string email)
    {
        _trainingRecordDto.UserEmail = email;
        return this;
    }
    

    public TrainingRecordDto Build()
    {
        TrainingRecordDto trainingRecordDto = _trainingRecordDto;
        _trainingRecordDto = new TrainingRecordDto();
        return trainingRecordDto; ;
    }
    
    
}