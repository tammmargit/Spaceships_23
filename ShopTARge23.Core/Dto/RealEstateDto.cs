﻿using Microsoft.AspNetCore.Http;

namespace ShopTARge23.Core.Dto
{
    public class RealEstateDto
    {
        public Guid? Id { get; set; }
        public double Size { get; set; }
        public string Location { get; set; }
        public int RoomNumber { get; set; }
        public string BuildingType { get; set; }

        public List<IFormFile> Files { get; set; }

        public IEnumerable<FileToDatabaseDto> FileToApiDtos { get; set; }
            = new List<FileToDatabaseDto>();

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
