using System.ComponentModel.DataAnnotations;
using Ebisx.POS.Api.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ebisx.POS.Api.DTOs;

public class CustomerDto
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string? TinNumber { get; set; }
    public string? IdNumber { get; set; }
}

public class DiscountTypeDto
{
    public string Name { get; set; } = string.Empty;
}

public class CreateDiscountDto
{
    public string Value { get; set; } = string.Empty;
    public bool IsPercentage { get; set; }

    public int DiscountTypeId { get; set; }
}

