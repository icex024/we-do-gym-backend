using GymAppWeDo.Record.Enums;
using GymAppWeDo.Record.Model;

namespace GymAppWeDo.Record.Dto;

public class TrainingRecordAdapter
{
    private TrainingType ReturnCorrectTrainingType(string trainingType)
    {
        if (trainingType.Equals("CARDIO"))
        {
            return TrainingType.Cardio;
        }
        if (trainingType.Equals("UPPERBODY"))
        {
            return TrainingType.UpperBody;
        }
        if (trainingType.Equals("FULLBODY"))
        {
            return TrainingType.FullBody;
        }
        if (trainingType.Equals("LOWERBODY"))
        {
            return TrainingType.LowerBody;
        }
        if (trainingType.Equals("CROSSFIT"))
        {
            return TrainingType.CrossFit;
        }
        return TrainingType.MartialArts;
    }
    
    public TrainingRecord CreateTrainingRecordDtoToTrainingRecord(CreateTrainingRecordDto dto)
    {
        return new TrainingRecordBuilder()
            .DurationInMinutes(dto.DurationInMinutes)
            .TrainingType(ReturnCorrectTrainingType(dto.TrainingType))
            .CaloriesBurned(dto.CaloriesBurned)
            .Difficulty(dto.Difficulty)
            .Tiredness(dto.Tiredness)
            .Note(dto.Note)
            .DateAndTimeOfTheTraining(DateTime.Parse(dto.DateAndtTimeOfTheTraining))
            .Build();
    }
}