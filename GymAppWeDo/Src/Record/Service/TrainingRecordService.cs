using GymAppWeDo.Record.Dto;
using GymAppWeDo.Record.Model;
using GymAppWeDo.Record.Repository;

namespace GymAppWeDo.Record.Service;

public class TrainingRecordService : ITrainingRecordService
{
    private readonly ITrainingRecordRepository _trainingRecordRepository;

    public TrainingRecordService(ITrainingRecordRepository trainingRecordRepository)
    {
        _trainingRecordRepository = trainingRecordRepository;
    }
    
    public async Task<List<TrainingRecord>> AddTrainingRecord(CreateTrainingRecordDto dto, string email, string filterDateStartTime, string filterDateEndTime)
    {
        var trainingRecord = new TrainingRecordAdapter().CreateTrainingRecordDtoToTrainingRecord(dto);
        trainingRecord.UserEmail = email;
        await _trainingRecordRepository.AddTrainingRecordAsync(trainingRecord);
        if (filterDateStartTime.Equals("") || filterDateEndTime.Equals(""))
        {
            return await _trainingRecordRepository.GetAllTrainingRecordsForUserAsync(email);
        }
        return await _trainingRecordRepository.GetTrainingRecordsAsync(
            DateTime.Parse(filterDateStartTime),
            DateTime.Parse(filterDateEndTime),
            email);
    }

    public async Task<List<TrainingRecord>> GetTrainingRecords(string filterDateStartTime, string filterDateEndTime,string email)
    {
        if (filterDateStartTime.Equals("") || filterDateEndTime.Equals(""))
        {
                    return await _trainingRecordRepository.GetAllTrainingRecordsForUserAsync(email);
        }
        return await _trainingRecordRepository.GetTrainingRecordsAsync(
                    DateTime.SpecifyKind(DateTime.Parse(filterDateStartTime),DateTimeKind.Utc),
                    DateTime.SpecifyKind(DateTime.Parse(filterDateEndTime), DateTimeKind.Utc),
                    email);
    }
}