using ShopTARge23.Core.Domain;
using ShopTARge23.Core.Dto;

namespace ShopTARge23.Core.ServiceInterface
{
    public interface IFileServices
    {
        void FilesToApi(KindergartenDto dto, Kindergarten kindergarten);
        void FilesToApi(SpaceshipDto dto, Spaceship domain);
        Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDto[] dtos);
    }
}
