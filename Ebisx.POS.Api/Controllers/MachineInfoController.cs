using Ebisx.POS.Api.DTOs.MachineInfo;
using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ebisx.POS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MachineInfoController : ControllerBase
{
    private readonly IMachineInfoService _machineInfoService;

    public MachineInfoController(IMachineInfoService machineInfoService)
    {
        _machineInfoService = machineInfoService;
    }

    [HttpGet]
    [ProducesResponseType(type: typeof(IEnumerable<MachineInfoResponseDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllMachineInfo()
    {
        var machineInfoList = await _machineInfoService.GetAllMachineInfoAsync();
        return Ok(machineInfoList);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(type: typeof(MachineInfoResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetMachineInfoById(int id)
    {
        var machineInfo = await _machineInfoService.GetMachineInfoByIdAsync(id);
        if (machineInfo == null)
        {
            return NotFound();
        }
        return Ok(machineInfo);
    }

    [HttpPost]
    [ProducesResponseType(type: typeof(MachineInfoResponseDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateMachineInfo(MachineInfoRequestDto machineInfo)
    {
        var createdMachineInfo = await _machineInfoService.CreateMachineInfoAsync(machineInfo);
        return CreatedAtAction(nameof(GetMachineInfoById), new { id = createdMachineInfo.Id }, createdMachineInfo);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateMachineInfo(int id, MachineInfoRequestDto machineInfo)
    {
        var updated = await _machineInfoService.UpdateMachineInfoAsync(id, machineInfo);
        if (!updated)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteMachineInfo(int id)
    {
        var deleted = await _machineInfoService.DeleteMachineInfoAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
