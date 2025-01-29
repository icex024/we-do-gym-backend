using GymAppWeDo.Record.Dto;
using GymAppWeDo.Record.Model;

namespace GymAppWeDo.Record.Service;

public interface ITrainingRecordService
{
    Task<List<TrainingRecord>> AddTrainingRecord(CreateTrainingRecordDto dto, string email,
        string filterDateStartTime,string filterDateEndTime);
    Task<List<TrainingRecord>> GetTrainingRecords(string filterDateStartTime,string filterDateEndTime,string email);
}