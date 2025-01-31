using GymAppWeDo.Data;
using GymAppWeDo.Record.Model;
using Microsoft.EntityFrameworkCore;

namespace GymAppWeDo.Record.Repository;

public class TrainingRecordRepository : ITrainingRecordRepository
{
    private readonly MyDbContext _context;

    public TrainingRecordRepository(MyDbContext context)
    {
        _context = context;
    }
    
    public async Task AddTrainingRecordAsync(TrainingRecord trainingRecord)
    {
        _context.TrainingRecords.Add(trainingRecord);
        await _context.SaveChangesAsync();
    }

    public async Task<List<TrainingRecord>> GetTrainingRecordsAsync(DateTime startDate, DateTime endDate, string email)
    {
        return await _context.TrainingRecords
            .Where(item => 
                item.UserEmail == email && 
                (item.DateAndTimeOfTheTraining >= startDate && item.DateAndTimeOfTheTraining <= endDate))
            .ToListAsync();
    }

    public async Task<List<TrainingRecord>> GetAllTrainingRecordsForUserAsync(string email)
    {
        return await _context.TrainingRecords.Where(item => item.UserEmail == email).ToListAsync();
    }
}