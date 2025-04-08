using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ebisx.POS.Api.Entities;

/// <summary>
/// Represents information about a POS machine.
/// </summary>
public class MachineInfo
{
    /// <summary>
    /// Gets or sets the unique identifier for the machine.
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the serial number of the POS machine.
    /// </summary>
    [Required]
    public string PosSerialNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the MIN (Machine Identifier Number) of the POS machine.
    /// </summary>
    [Required]
    public string MinNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the accreditation number of the machine.
    /// </summary>
    [Required]
    public string AccreditationNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the PTU (Permit to Use) number of the machine.
    /// </summary>
    [Required]
    public string PtuNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the date when the machine was issued.
    /// </summary>
    [Required]
    public DateTime DateIssued { get; set; }

    /// <summary>
    /// Gets or sets the date until the machine is valid.
    /// </summary>
    [Required]
    public DateTime ValidUntil { get; set; }
}
