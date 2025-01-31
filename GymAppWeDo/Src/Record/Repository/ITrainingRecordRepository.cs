using GymAppWeDo.Record.Model;

namespace GymAppWeDo.Record.Repository;

public interface ITrainingRecordRepository
{
    Task AddTrainingRecordAsync(TrainingRecord trainingRecord);
    Task<List<TrainingRecord>> GetTrainingRecordsAsync(DateTime startDate, DateTime endDate,string email);
    Task<List<TrainingRecord>> GetAllTrainingRecordsForUserAsync(string email);
}