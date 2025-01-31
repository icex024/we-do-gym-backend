using GymAppWeDo.Record.Dto;
using GymAppWeDo.Record.Model;

namespace GymAppWeDo.Record.Service;

public interface ITrainingRecordService
{
    Task AddTrainingRecord(CreateTrainingRecordDto dto, string email);
    Task<List<TrainingRecordDto>> GetTrainingRecords(string filterDateStartTime,string filterDateEndTime,string email);
}