using Ebisx.POS.Api.DTOs.DiscountType;

namespace Ebisx.POS.Api.DTOs.Discount;

public class DiscountResponseDto
{
    public int Id { get; set; }
    public string Value { get; set; } = string.Empty;
    public bool IsPercentage { get; set; }
    public DiscountTypeResponseDto? DiscountType { get; set; }
}
