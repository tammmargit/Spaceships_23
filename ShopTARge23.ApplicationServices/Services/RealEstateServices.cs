using ShopTARge23.Data;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Core.Domain;
using ShopTARge23.Core.Dto;
using Microsoft.EntityFrameworkCore;

namespace ShopTARge23.ApplicationServices.Services
{
    public class RealEstateServices : IRealEstateServices
    { 
        private readonly ShopTARge23Context _context;

        public RealEstateServices
            (
            ShopTARge23Context context
            )
        {
            _context = context;
        }


        public RealEstateServices
    (
        ShopTARge23Context context,
        IFileServices fileServices
    )
        {
            _context = context;
        }

        public async Task<RealEstate> Create(RealEstateDto dto)
        {
            RealEstate realEstate = new RealEstate();

            realEstate.Id = Guid.NewGuid();
            realEstate.Size = dto.Size;
            realEstate.Location = dto.Location;
            realEstate.RoomNumber = dto.RoomNumber;
            realEstate.BuildingType = dto.BuildingType;
            realEstate.CreatedAt = DateTime.Now;


            await _context.RealEstates.AddAsync(realEstate);
            await _context.SaveChangesAsync();

            return realEstate;
        }


        public async Task<RealEstate> DetailAsync(Guid id)
        {
            var result = await _context.RealEstates
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<RealEstate> Update(RealEstateDto dto)
        {
            RealEstate domain = new();

            domain.Id = dto.Id;
            domain.Size = dto.Size;
            domain.Location = dto.Location;
            domain.RoomNumber = dto.RoomNumber;
            domain.BuildingType = dto.BuildingType;
            domain.CreatedAt = dto.CreatedAt;
            domain.ModifiedAt = DateTime.Now;

            _context.RealEstates.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }

        public async Task<RealEstate> Delete(Guid id)
        {
            var realestate = await _context.RealEstates
                .FirstOrDefaultAsync(x => x.Id == id);

            var images = await _context.FileToApis
                .Where(x => x.RealEstateId == id)
                .Select(y => new FileToApiDto
                {
                    Id = y.Id,
                    RealEstateId = y.RealEstateId,
                    ExistingFilePath = y.ExistingFilePath,
                }).ToArrayAsync();

            _context.RealEstates.Remove(realestate);
            await _context.SaveChangesAsync();

            return realestate;
        }

    }
}