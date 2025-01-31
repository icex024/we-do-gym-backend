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
    
    public async Task AddTrainingRecord(CreateTrainingRecordDto dto, string email)
    {
        
        var trainingRecord = new TrainingRecordAdapter().CreateTrainingRecordDtoToTrainingRecord(dto);
        trainingRecord.UserEmail = email;
        await _trainingRecordRepository.AddTrainingRecordAsync(trainingRecord);
    }

    public async Task<List<TrainingRecordDto>> GetTrainingRecords(string filterDateStartTime, string filterDateEndTime,string email)
    {
        var records = await GetTrainingRecordsWithParameters(email, filterDateStartTime, filterDateEndTime);
        return ReturnDtos(records);
    }

    private async Task<List<TrainingRecord>> GetTrainingRecordsWithParameters(string email, string filterDateStartTime, string filterDateEndTime)
    {
        if (filterDateStartTime.Equals("") || filterDateEndTime.Equals(""))
        {
            return await _trainingRecordRepository.GetAllTrainingRecordsForUserAsync(email);
        }
        return await _trainingRecordRepository.GetTrainingRecordsAsync(
            DateTime.Parse(filterDateStartTime),
            DateTime.Parse(filterDateEndTime),
            email);
    }

    private List<TrainingRecordDto> ReturnDtos(List<TrainingRecord> records)
    {
        List<TrainingRecordDto> dtos = new List<TrainingRecordDto>();
        foreach (var record in records)
        {
            dtos.Add(new TrainingRecordAdapter().TrainingRecordToTrainingRecordDto(record));
        }

        return dtos;
    }
}