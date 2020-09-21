using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using totvs_test.Dtos;

namespace totvs_test.Services
{
    class AuctionService : IAuctionService
    {

        private TotvsDbContext _dbContext;

        public AuctionService(TotvsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private AuctionDto FromAuctionEntity(Auction auction)
        {
            return new AuctionDto
            {
                Id = auction.Id,
                Name = auction.Name,
                InitialValue = auction.InitialValue,
                IsUsed = auction.IsUsed,
                ResponsibleId = auction.ResponsibleId,
                OpeningDate = auction.OpeningDate,
                ClosingDate = auction.ClosingDate
            };
        }

        public async Task<AuctionDto> Create(CreateOrUpdateAuctionDto auctionDto)
        {
            var entity = await _dbContext.Auctions.AddAsync(new Auction
            {
                Name = auctionDto.Name,
                InitialValue = auctionDto.InitialValue.GetValueOrDefault(),
                IsUsed = auctionDto.IsUsed.GetValueOrDefault(),
                ResponsibleId = auctionDto.ResponsibleId.GetValueOrDefault(),
                OpeningDate = auctionDto.OpeningDate.GetValueOrDefault(),
                ClosingDate = auctionDto.ClosingDate
            });

            await _dbContext.SaveChangesAsync();

            return FromAuctionEntity(entity.Entity);
        }

        public async Task<AuctionDto> DeleteById(Guid id)
        {
            var auction = await _dbContext.Auctions.FindAsync(id);

            if (auction == null)
            {
                return null;
            }

            _dbContext.Remove(auction);
            await _dbContext.SaveChangesAsync();

            return FromAuctionEntity(auction);
        }

        public async Task<AuctionDto> GetById(Guid id)
        {
            var auction = await _dbContext.Auctions.FindAsync(id);

            if (auction == null)
            {
                return null;
            }

            return FromAuctionEntity(auction);
        }

        public async Task<AuctionDto> Update(Guid id, CreateOrUpdateAuctionDto auctionDto)
        {
            var auction = await _dbContext.Auctions.FindAsync(id);

            if (auction == null)
            {
                return null;
            }

            auction.Name = auctionDto.Name;
            auction.InitialValue = auctionDto.InitialValue.GetValueOrDefault();
            auction.IsUsed = auctionDto.IsUsed.GetValueOrDefault();
            auction.ResponsibleId = auctionDto.ResponsibleId.GetValueOrDefault();
            auction.OpeningDate = auctionDto.OpeningDate.GetValueOrDefault();
            auction.ClosingDate = auctionDto.ClosingDate;

            await _dbContext.SaveChangesAsync();

            return FromAuctionEntity(auction);
        }

        public async Task<IEnumerable<AuctionDto>> GetAll()
        {
            var auctions = await _dbContext.Auctions.ToListAsync();

            return auctions.Select(auction => FromAuctionEntity(auction));
        }
    }
}