using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using totvs_test.Dtos;

namespace totvs_test.Services
{
    public interface IAuctionService
    {
        public Task<AuctionDto> Create(CreateOrUpdateAuctionDto auctionDto);

        public Task<AuctionDto> GetById(Guid id);

        public Task<IEnumerable<AuctionDto>> GetAll();

        public Task<AuctionDto> Update(Guid id, CreateOrUpdateAuctionDto auctionDto);

        public Task<AuctionDto> DeleteById(Guid id);

    }
}