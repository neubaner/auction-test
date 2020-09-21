using System;

namespace totvs_test.Dtos
{
    public class AuctionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public decimal InitialValue { get; set; }

        public bool IsUsed { get; set; }

        public Guid ResponsibleId { get; set; }

        public DateTime OpeningDate { get; set; }

        public DateTime? ClosingDate { get; set; }
    }
}