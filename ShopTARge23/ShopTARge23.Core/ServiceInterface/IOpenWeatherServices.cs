using ShopTARge23.Core.Dto.WeatherDtos.OpenWeatherDtos;

namespace ShopTARge23.Core.ServiceInterface
{
    public interface IOpenWeatherServices
    {
        public Task<OpenWeatherResultDto> OpenWeatherResult(OpenWeatherResultDto dto);
    }
}
