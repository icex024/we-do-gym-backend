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
    [Authorize]
    public async Task<IActionResult> CreateNewTrainingRecord
        (CreateTrainingRecordDto dto,
        [FromQuery] string? startDate = "",
        [FromQuery] string? endDate = "")
    {
        try
        {
            await _trainingRecordService.AddTrainingRecord(dto, User.Identity.Name);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500);
        }
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllTrainingRecords
    (
        [FromQuery] string? startDate = "",
        [FromQuery] string? endDate = "")
    {
        try
        {
            return Ok( await _trainingRecordService.GetTrainingRecords(startDate, endDate,User.Identity.Name));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}