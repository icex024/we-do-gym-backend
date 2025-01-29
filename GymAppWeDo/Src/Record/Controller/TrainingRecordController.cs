using GymAppWeDo.Helpers;
using GymAppWeDo.Record.Dto;
using GymAppWeDo.Record.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymAppWeDo.Record.Controller;

// [Authorize]
public class TrainingRecordController :BaseApiController
{
    private readonly ITrainingRecordService _trainingRecordService;

    public TrainingRecordController(ITrainingRecordService trainingRecordService)
    {
        _trainingRecordService = trainingRecordService;
    }
    [HttpPost]
    public async Task<IActionResult> CreateNewTrainingRecord
        (CreateTrainingRecordDto dto,
        [FromQuery] string userEmail = "",
        [FromQuery] string? startDate = "",
        [FromQuery] string? endDate = "")
    {
        try
        {
            return Ok(await _trainingRecordService.AddTrainingRecord(dto, userEmail, startDate, endDate));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTrainingRecords
    (
        [FromQuery] string userEmail,
        [FromQuery] string? startDate = "",
        [FromQuery] string? endDate = "")
    {
        try
        {
            return Ok( await _trainingRecordService.GetTrainingRecords(startDate, endDate,userEmail));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}