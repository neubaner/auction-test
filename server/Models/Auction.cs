using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace totvs_test
{
    public class Auction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal InitialValue { get; set; }

        [Required]
        public bool IsUsed { get; set; }

        [Required]
        public Guid ResponsibleId { get; set; }

        [Required]
        public User Responsible { get; set; }

        [Required]
        public DateTime OpeningDate { get; set; }

        public DateTime? ClosingDate { get; set; }

    }
}