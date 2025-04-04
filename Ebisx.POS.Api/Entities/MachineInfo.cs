    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace Ebisx.POS.Api.Entities;

public class MachineInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string PosSerialNumber { get; set; } = string.Empty;
        [Required]
        public string MinNumber { get; set; } = string.Empty;   
        [Required]
        public string AccreditationNumber { get; set; } = string.Empty;
        [Required]
        public string PtuNumber { get; set; } = string.Empty;
        [Required]
        public DateTime DateIssued { get; set; }
        [Required]
        public DateTime ValidUntil { get; set; }
    }
