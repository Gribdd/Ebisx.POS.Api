﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ebisx.POS.Api.Entities;

/// <summary>
/// Represents a type of discount in the POS system.
/// </summary>
[Index(nameof(Name), IsUnique = true)]
public class DiscountType
{
    /// <summary>
    /// Gets or sets the unique identifier for the discount type.
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the discount type.
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;
}
