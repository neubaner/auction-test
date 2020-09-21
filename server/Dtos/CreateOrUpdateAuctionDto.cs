using System;
using System.ComponentModel.DataAnnotations;

namespace totvs_test.Dtos
{
    // Varias das propriedades são 
    public class CreateOrUpdateAuctionDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal? InitialValue { get; set; }

        [Required]
        public bool? IsUsed { get; set; }

        [Required]
        public Guid? ResponsibleId { get; set; }

        [Required]
        public DateTime? OpeningDate { get; set; }

        public DateTime? ClosingDate { get; set; }
    }
}