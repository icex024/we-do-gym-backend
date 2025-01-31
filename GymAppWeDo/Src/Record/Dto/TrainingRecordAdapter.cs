using System.Globalization;
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

    private string ReturnCorrectTrainingTypeString(TrainingType trainingType)
    {
        if (Enums.TrainingType.Cardio == trainingType )
        {
            return "CARDIO";
        }
        if (Enums.TrainingType.UpperBody== trainingType)
        {
            return 
                "UPPERBODY";
        }
        if ( Enums.TrainingType.FullBody== trainingType)
        {
            return "FULLBODY";
        }
        if (Enums.TrainingType.LowerBody== trainingType )
        {
            return "LOWERBODY";
        }
        if (Enums.TrainingType.CrossFit== trainingType )
        {
            return "CROSSFIT";
        }
        return "MARTIALARTS";
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
            .DateAndTimeOfTheTraining(DateTime.SpecifyKind(DateTime.Parse(dto.DateAndTimeOfTheTraining,
                null,
                System.Globalization.DateTimeStyles.AdjustToUniversal),DateTimeKind.Utc))
            .Build();
    }

    public TrainingRecordDto TrainingRecordToTrainingRecordDto(TrainingRecord trainingRecord)
    {
        return new TrainingRecordDtoBuilder()
            .Id(trainingRecord.Id)
            .TrainingType(ReturnCorrectTrainingTypeString(trainingRecord.TrainingType))
            .Difficulty(trainingRecord.Difficulty)
            .Tiredness(trainingRecord.Tiredness)
            .Note(trainingRecord.Note)
            .CaloriesBurned(trainingRecord.CaloriesBurned)
            .DateAndTimeOfTheTraining(trainingRecord.DateAndTimeOfTheTraining.ToString(
                "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture))
            .UserEmail(trainingRecord.UserEmail)
            .Build();
    }
}