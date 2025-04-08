using Ebisx.POS.Api.DTOs.BusinessInfo;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ebisx.POS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BusinessInfoController : ControllerBase
{
    private readonly IBusinessInfoService _businessInfoService;

    public BusinessInfoController(IBusinessInfoService businessInfoService)
    {
        _businessInfoService = businessInfoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BusinessInfoResponseDto>>> GetAllBusinessInfo()
    {
        var businessInfoList = await _businessInfoService.GetAllBusinessInfoAsync();
        return Ok(businessInfoList);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BusinessInfoResponseDto>> GetBusinessInfoById(int id)
    {
        var businessInfo = await _businessInfoService.GetBusinessInfoByIdAsync(id);
        if (businessInfo == null)
        {
            return NotFound();
        }
        return Ok(businessInfo);
    }

    [HttpPost]
    public async Task<ActionResult<BusinessInfoResponseDto>> CreateBusinessInfo(BusinessInfoRequestDto businessInfo)
    {
        var createdBusinessInfo = await _businessInfoService.CreateBusinessInfoAsync(businessInfo);
        return CreatedAtAction(nameof(GetBusinessInfoById), new { id = createdBusinessInfo.Id }, createdBusinessInfo);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateBusinessInfo(int id, BusinessInfoRequestDto businessInfo)
    {
        var updated = await _businessInfoService.UpdateBusinessInfoAsync(id, businessInfo);
        if (!updated)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBusinessInfo(int id)
    {
        var deleted = await _businessInfoService.DeleteBusinessInfoAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
